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
using System.Linq;


using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

namespace TobiiTesting1
{
    public partial class FormCameras : Form
    {
        private string m_deviceMoniker;
        private VideoCaptureDevice videoSource = null;
        private Bitmap videoimg;

        private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;
        public bool m_startrecording;
        public int m_index;//index in the listview
        private int w, h;

        public void StartRecording(string videofilepath)
        {
            h = videoimg.Height;
            w = videoimg.Width;

            FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Default, 5000000);
            FileWriter.WriteVideoFrame(videoimg);

            m_startrecording = true;
        }

        public void StopRecording()
        {
            m_startrecording = false;
            FileWriter.Close();
        }
        public FormCameras()
        {
            InitializeComponent();
        }
        public Image GetPicture()
        { 
            //return videoimg;
            return pictureBox1.Image;
        }
        private void FormCameras_Load(object sender, EventArgs e)
        {
            CloseVideoSource();

            videoSource = new VideoCaptureDevice(m_deviceMoniker);
            
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);


            //videoSource.DesiredFrameSize = new Size(160, 120);//new Size(160, 120);
            //videoSource.DesiredFrameRate = 10;
            videoSource.Start();

            m_startrecording = false;
        }

        public void SetDeviceMonikerString(string deviceMoniker)
        {
            m_deviceMoniker = deviceMoniker;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            try
            {
                pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                // save image to file
                if (m_startrecording)
                {
                    FileWriter.WriteVideoFrame(videoimg);
                    FileWriter.Flush();
                }
            }
            catch
            {
                Console.WriteLine("object is used somewhere else");
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

        private void FormCameras_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource(); 
        }
    }
}
