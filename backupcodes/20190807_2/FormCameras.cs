﻿using System;
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
        public Bitmap videoimg;

        private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;
        public bool m_startrecording;
        public int m_index;//index in the listview
        private int w= 1920, h= 1080;
        private static bool m_changed = true;

        public bool m_duplicate=false;// duplicate display on the main window

        public List<Bitmap> m_framelist = new List<Bitmap>(50);

        public void StartRecording(string videofilepath)
        {
            if (!m_changed)
            {
                h = videoimg.Height;//videoSource.VideoResolution.FrameSize.Height;// 
                w = videoimg.Width; //videoSource.VideoResolution.FrameSize.Width;// 
            }
            FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Default, 5000000);
            //FileWriter.WriteVideoFrame(videoimg);

            m_startrecording = true;
        }

        public void StopRecording()
        {
            m_startrecording = false;
            //wait 0.1 s
            FileWriter.Close();
        }
        public FormCameras()
        {
            InitializeComponent();
        }
        /*
        public Image GetPicture
        {
            get { return pictureBox1.Image; }
            //return videoimg;
            //return pictureBox1.Image;
        }
        */

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
                if (cap.FrameSize.Height == 1080)
                    return cap;
                if (cap.FrameSize.Width == 1920)
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

        private void video_NewFrame_2nd(object sender, NewFrameEventArgs eventArgs)
        {
            if (m_duplicate)
            {
                videoimg = (Bitmap)eventArgs.Frame.Clone();

                m_framelist.Add(videoimg);
                if (m_framelist.Count > 100)
                {
                    m_framelist[0].Dispose();
                    m_framelist.RemoveAt(0);
                }
                
            }
            else
            {
                Bitmap t_frame = videoimg;

                videoimg = (Bitmap)eventArgs.Frame.Clone();

                if (t_frame != null)
                {
                    t_frame.Dispose();
                }
            }
            
            
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

            try
            {
                //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();                    
                // save image to file
                if (m_startrecording && FileWriter.IsOpen && videoimg != null)
                {
                    FileWriter.WriteVideoFrame(videoimg);
                    FileWriter.Flush();
                }
                pictureBox1.Image = videoimg;
            }
            catch
            {
                Console.WriteLine("object is used somewhere else");
            }
            

        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            m_framelist.Add(videoimg);

            try
            {
                if (m_startrecording && FileWriter.IsOpen && videoimg != null)
                {
                    FileWriter.WriteVideoFrame(videoimg);
                    FileWriter.Flush();
                }
                pictureBox1.Image = videoimg;
                                
            }
            catch
            {
                Console.WriteLine("object is used somewhere else");
            }

            
            if (m_framelist.Count > 50)//100
            {
                m_framelist[0].Dispose();
                m_framelist.RemoveAt(0);
            }
        }


        private void video_NewFrame_fun(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();

            //do processing here
            try
            {
                //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
                // save image to file
                if (m_startrecording && FileWriter.IsOpen && videoimg != null)
                {
                    FileWriter.WriteVideoFrame(videoimg);
                    FileWriter.Flush();
                }
                pictureBox1.Image = videoimg;// (Bitmap)eventArgs.Frame.Clone();
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
