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

using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;
using Accord.Video.VFW;
using Tobii.Research;

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
        private bool startrecording;

        private int w, h;
        private string m_folder;
        private string filename="";

        public Form1()
        {
            InitializeComponent();
            startrecording = false;

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

        private void UpdateLabel2Text(String t_info)
        {
            label2.Text = t_info;
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
                    FileWriter.Close();
                    startrecording = false;
                }
            }
        }

        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone(); ;

            // save image to file
            if (startrecording)
            {
                FileWriter.WriteVideoFrame(videoimg);
            }
            
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
            GenerateRecordingFile();
            var eyeTrackers = EyeTrackingOperations_FindAllEyeTrackers.Execute(this);
            var eyeTracker = eyeTrackers[0];
            IEyeTracker_GazeDataReceived.Execute(eyeTracker,this);

        }
        internal static class EyeTrackingOperations_FindAllEyeTrackers
        {
            internal static EyeTrackerCollection Execute(Form1 formObject)
            {
                // <BeginExample>
                //Console.WriteLine("\nSearching for all eye trackers");
                EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();
                foreach (IEyeTracker eyeTracker in eyeTrackers)
                {
                    //Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", eyeTracker.Address, eyeTracker.DeviceName, eyeTracker.Model, eyeTracker.SerialNumber, eyeTracker.FirmwareVersion, eyeTracker.RuntimeVersion);
                    var t_str = String.Format("{0}, {1}, {2}, {3}, {4}, {5}", eyeTracker.Address, eyeTracker.DeviceName, eyeTracker.Model, eyeTracker.SerialNumber, eyeTracker.FirmwareVersion, eyeTracker.RuntimeVersion);
                    formObject.UpdateLabel2Text(t_str);
                }
                // <EndExample>
                return eyeTrackers;
            }
        }
        class IEyeTracker_GazeDataReceived
        {
            private static string filename;
            public static void Execute(IEyeTracker eyeTracker,Form1 formObject)
            {
                if (eyeTracker != null)
                {
                    filename = formObject.filename;
                    GazeData(eyeTracker);
                }
            }
            // <BeginExample>
            private static void GazeData(IEyeTracker eyeTracker)
            {
                // Start listening to gaze data.

                eyeTracker.GazeDataReceived += EyeTracker_GazeDataReceived;
                // Wait for some data to be received.
                System.Threading.Thread.Sleep(2000);//2000
                // Stop listening to gaze data.
                //eyeTracker.GazeDataReceived -= EyeTracker_GazeDataReceived;
            }
            private static void EyeTracker_GazeDataReceived(object sender, GazeDataEventArgs e)
            {
                var systemTimeStamp = EyeTrackingOperations.GetSystemTimeStamp();
                var t_str = String.Format("{0},{1},{2},{3},{4}\r\n",
                    e.LeftEye.GazeOrigin.Validity,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.X,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Z,
                    systemTimeStamp);
                /* 
                 (
                 "Gaze data with {0} left eye origin at point ({1}, {2}, {3}) in the user coordinate system. TimeStamp: {4}",
                 e.LeftEye.GazeOrigin.Validity,
                 e.LeftEye.GazeOrigin.PositionInUserCoordinates.X,
                 e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y,
                 e.LeftEye.GazeOrigin.PositionInUserCoordinates.Z,
                 systemTimeStamp);
                 */

                //System.IO.File.WriteAllText(filename, t_str);
                System.IO.File.AppendAllText(filename, t_str);
            }
            // <EndExample>
        }

        private void save_Click(object sender, EventArgs e)
        {
            saveAvi = new SaveFileDialog();
            saveAvi.Filter = "Avi Files (*.avi)|*.avi";
            if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //int h = videoSource.VideoResolution.FrameSize.Height;
                //int w = videoSource.VideoResolution.FrameSize.Width;
                h = 240;
                w = 320;
                FileWriter.Open(saveAvi.FileName, w, h, 25, VideoCodec.Default, 5000000);
                FileWriter.WriteVideoFrame(videoimg);
                startrecording = true;

                //AVIwriter.Open(saveAvi.FileName, w, h);
                label2.Text = "start recording";
                save.Text = "recording";
                //FileWriter.Close();
                //FinalVideo = captureDevice.VideoDevice;
                //FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                //FinalVideo.Start();
            }
        }

        private void start_recording_Click(object sender, EventArgs e)
        {
            //Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(DateTime.Now)).TotalSeconds;
            GenerateRecordingFile();
        }
        private bool GenerateRecordingFile()
        {
            var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            this.filename = Timestamp.ToString() + ".txt";

            if (!System.IO.File.Exists(this.filename))
            {
                //create file
                using (var t_file = System.IO.File.Create(this.filename)) ;
            }

            System.IO.File.WriteAllText(this.filename, "DEVICE,X,Y,Z,TimeStamp\r\n");
            return true;
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
