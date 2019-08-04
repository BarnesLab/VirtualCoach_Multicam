using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using Accord.Video.VFW;


// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace TobiiTesting1
{
    public partial class Form1 : Form
    {
        private bool DeviceExist = false;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;


        //private FilterInfoCollection VideoCaptureDevices;
        //private VideoCaptureDevice FinalVideo = null;
        //private VideoCaptureDeviceForm captureDevice;
        private Bitmap videoimg;
        //private AVIWriter AVIwriter = new AVIWriter();
        private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;


        public Form1()
        {
            InitializeComponent();
        }

        // get the devices name
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                DeviceExist = true;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
                comboBox1.SelectedIndex = 0; //make dafault to first cam
            }
            catch (ApplicationException)
            {
                DeviceExist = false;
                comboBox1.Items.Add("No capture device on your system");
            }
        }


       

        //toggle start and stop button
        private void start_Click(object sender, EventArgs e)
        {
            if (start.Text == "Start")
            {
                if (DeviceExist)
                {
                    videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                    CloseVideoSource();
                    videoSource.DesiredFrameSize = new Size(160, 120);
                    //videoSource.DesiredFrameRate = 10;
                    videoSource.Start();
                    label2.Text = "Device running...";
                    start.Text = "&Stop";
                    timer1.Enabled = true;
                }
                else
                {
                    label2.Text = "Error: No Device selected.";
                }
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    label2.Text = "Device stopped.";
                    start.Text = "Start";
                }
            }
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            pictureBox1.Image = videoimg;

            // save image to file
            FileWriter.WriteVideoFrame(videoimg);
        }

        //close the device safely
        private void CloseVideoSource()
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }

        //get total received frame at 1 second tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Device running... " + videoSource.FramesReceived.ToString() + " FPS";
        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
        }

        private void rfsh_Click_1(object sender, EventArgs e)
        {
            getCamList();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            Browsing for eye trackers or selecting an eye tracker with known address.
            Establishing a connection with the eye tracker.
            Running a calibration procedure in which the eye tracker is calibrated to the user.
            Setting up a subscription to gaze data, and collecting and saving the data on the computer running the application.In some cases, the data is also shown live by the application.
            */



        }

        private void save_Click(object sender, EventArgs e)
        {
            saveAvi = new SaveFileDialog();
            saveAvi.Filter = "Avi Files (*.avi)|*.avi";
            if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int h = videoSource.VideoResolution.FrameSize.Height;
                int w = videoSource.VideoResolution.FrameSize.Width;
                FileWriter.Open(saveAvi.FileName, w, h, 25, VideoCodec.Default, 5000000);
                FileWriter.WriteVideoFrame(videoimg);

                //AVIwriter.Open(saveAvi.FileName, w, h);
                label2.Text = "video saved";
                FileWriter.Close();
                //FinalVideo = captureDevice.VideoDevice;
                //FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                //FinalVideo.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource == null)
            { return; }
            if (videoSource.IsRunning)
            {
                this.videoSource.Stop();
                FileWriter.Close();
                //this.AVIwriter.Close();
            }
        }
    }
}
