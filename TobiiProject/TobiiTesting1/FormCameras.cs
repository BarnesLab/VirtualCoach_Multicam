using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;
using Accord.Video.VFW;
using Tobii.Research;

using System.IO;
using System.Diagnostics;


using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using System.Threading;

namespace TobiiTesting1
{
    public partial class FormCameras : Form
    {
        //lock thread
        private static ReaderWriterLockSlim _readWriteLock = new ReaderWriterLockSlim();

        private string m_deviceMoniker;
        private VideoCaptureDevice videoSource = null;
        public Bitmap videoimg;

        private VideoFileWriter FileWriter = new VideoFileWriter();
        public bool m_startrecording;
        public int m_index;//index in the listview
        private int w= 1280, h= 720;
        private static bool m_changed = true;

        public bool m_duplicate=false;// duplicate display on the main window

        public List<Bitmap> m_framelist = new List<Bitmap>(50);
        public long StartTick = DateTime.Now.Ticks;
        //public bool m_stopwriting = true;
        long previous = DateTime.Now.Ticks;


        public bool CheckFileWriterOpen()
        {

            return FileWriter.IsOpen;
        }
        public void StartRecording(string videofilepath)
        {
            if (!m_changed)
            {
                h = videoimg.Height;//videoSource.VideoResolution.FrameSize.Height;// 
                w = videoimg.Width; //videoSource.VideoResolution.FrameSize.Width;// 
            }
            if (FileWriter.IsOpen)
            {
                FileWriter.Close();
            }

            _readWriteLock.EnterWriteLock();
            try
            {
                FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Default, 1000000);//5000000
                //FileWriter.WriteVideoFrame(videoimg);
                m_startrecording = true;
            }
            catch
            {

            }
            _readWriteLock.ExitWriteLock();


            StartTick = DateTime.Now.Ticks;
            timer_saveframe.Enabled = true;
        }

        public void StopRecording()
        {
           
            //_readWriteLock.EnterWriteLock();
            try
            {
                timer_saveframe.Enabled = false;
                FileWriter.Close();
                m_startrecording = false;
                Console.WriteLine("stop recording");
            }
            finally
            {
                //_readWriteLock.ExitWriteLock();
            }

        }
        public void StopRecording_ori()
        {
            m_startrecording = false;

        }
        public FormCameras()
        {
            InitializeComponent();
        }

        public Image GetPicture()
        {
            return pictureBox1.Image;
        }


        private void FormCameras_Load(object sender, EventArgs e)
        {
            CloseVideoSource();

            videoSource = new VideoCaptureDevice(m_deviceMoniker);
            VideoCapabilities t_c = selectResolution(videoSource);//new line
            if (m_changed)
            {
                videoSource.VideoResolution = t_c;
                h = videoSource.VideoResolution.FrameSize.Height;
                w = videoSource.VideoResolution.FrameSize.Width;
            }
            
            //videoSource.VideoResolution = selectResolution(videoSource);//new line

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

            //videoSource.DesiredFrameSize = new Size(1920, 1080);
            //videoSource.DesiredFrameSize = new Size(1920, 120);//new Size(160, 120);
            //videoSource.DesiredFrameRate = 10;
            videoSource.Start();

            m_startrecording = false;
        }

        private static VideoCapabilities selectResolution(VideoCaptureDevice device)
        {
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 720 && cap.FrameSize.Width == 1280)
                    return cap;
                if (cap.FrameSize.Height == 1080 && cap.FrameSize.Width == 1960)
                    return cap;
            }
            m_changed = false;
            return device.VideoCapabilities.Last();
            //return device.VideoCapabilities.Last();
        }

        public void SetDeviceMonikerString(string deviceMoniker)
        {
            m_deviceMoniker = deviceMoniker;
        }

        public void DuplicateDisplay(bool t_status = true)
        {
            m_duplicate = t_status;
        }
        
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            
            //_readWriteLock.EnterWriteLock();
            try
            {
                
                pictureBox1.Image = videoimg;
                                
            }
            catch
            {
                Console.WriteLine("object is used somewhere else 2");
            }
            finally
            {
                //_readWriteLock.ExitWriteLock();
            }
            m_framelist.Add(videoimg);


            if (m_framelist.Count > 50)//100
            {
                m_framelist[0].Dispose();
                m_framelist.RemoveAt(0);
            }
            
        }
        private void video_NewFrame_ori(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();

            //_readWriteLock.EnterWriteLock();
            try
            {
                if (m_startrecording && FileWriter.IsOpen && videoimg != null)
                {
                    //FileWriter.WriteVideoFrame(videoimg);
                    FileWriter.WriteVideoFrame(videoimg);

                    FileWriter.Flush();
                }
                pictureBox1.Image = videoimg;

            }
            catch
            {
                Console.WriteLine("object is used somewhere else 2");
            }
            finally
            {
                //_readWriteLock.ExitWriteLock();
            }
            m_framelist.Add(videoimg);


            if (m_framelist.Count > 50)//100
            {
                m_framelist[0].Dispose();
                m_framelist.RemoveAt(0);
            }

            if (!m_startrecording && FileWriter.IsOpen)
            {

                //FileWriter.Close();

                //_readWriteLock.EnterWriteLock();
                try
                {
                    FileWriter.Close();
                    Console.WriteLine("stop recording");
                }
                finally
                {
                    //_readWriteLock.ExitWriteLock();
                }
            }
        }

        //close the device safely
        public void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            //close all files and save if not saved.
            FileWriter.Close();
        }

        private void FormCameras_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseVideoSource();
        }

        private void timer_saveframe_Tick(object sender, EventArgs e)
        {
           
            try
            {
                if (DateTime.Now.Ticks - previous < 300000)
                {
                    System.Threading.Thread.Sleep(10);
                }

                TimeSpan frameOffset = new TimeSpan(DateTime.Now.Ticks - StartTick);

                Bitmap videoimg2 = (Bitmap)pictureBox1.Image.Clone();
                FileWriter.WriteVideoFrame(videoimg2, frameOffset);
                FileWriter.Flush();
                videoimg2.Dispose();
                previous = DateTime.Now.Ticks;
            }
            catch
            {
                Console.WriteLine(DateTime.Now.Ticks - previous);
            }
            
            
        }

        private void FormCameras_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource(); 
        }
    }
}
