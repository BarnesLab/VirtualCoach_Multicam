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

using System.IO;
using System.Diagnostics;
using System.Linq;

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
        private string trialsavingpath = "";
        private string avisavingpath = "";

        static string gazedatasavingpath = "";
        static bool b_recording=false;

        // true means the trial is in use, false means the trial is not in use
        // start recording: b_trial_locked=true, trial index;
        // end trial b_trial_locked=false,
        // start a new trial: b_trial_locked=true
        private bool b_trial_locked = false;

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
        /*
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
        */


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
            //close all files and save if not saved.


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
            FileWriter.Close();
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
            //GenerateRecordingFile();
            
            var eyeTrackers = EyeTrackingOperations_FindAllEyeTrackers.Execute(this);
            while (eyeTrackers.Count < 1)
            {
                System.Threading.Thread.Sleep(2000);
                eyeTrackers = EyeTrackingOperations_FindAllEyeTrackers.Execute(this);
            }
            var eyeTracker = eyeTrackers[0];

            CallEyeTrackerManager.Execute(eyeTracker);
            
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
            
            public static void Execute(IEyeTracker eyeTracker,Form1 formObject)
            {
                if (eyeTracker != null)
                {
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
                if (b_recording)
                {
                    System.IO.File.AppendAllText(gazedatasavingpath, t_str);
                }
                
            }
            // <EndExample>
        }

        private void save_Click(object sender, EventArgs e)
        {         

            //if streaming then stop
            if (save.Text == "Record")
            {
                saveAvi = new SaveFileDialog();
                saveAvi.Filter = "Avi Files (*.avi)|*.avi";
                if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //int h = videoSource.VideoResolution.FrameSize.Height;
                    //int w = videoSource.VideoResolution.FrameSize.Width;
                    h = videoimg.Height;
                    w = videoimg.Width;
                    //h = 240;
                    //w = 320;
                    FileWriter.Open(saveAvi.FileName, w, h, 25, VideoCodec.Default, 5000000);
                    FileWriter.WriteVideoFrame(videoimg);
                    startrecording = true;

                    //AVIwriter.Open(saveAvi.FileName, w, h);
                    label2.Text = "start recording";
                    save.Text = "Stop Recording";
                    //FileWriter.Close();
                    //FinalVideo = captureDevice.VideoDevice;
                    //FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
                    //FinalVideo.Start();
                    Console.WriteLine(saveAvi.FileName);
                    avisavingpath = saveAvi.FileName;
                    GenerateRecordingFile();
                }
                
            }
            else
            {
                if (videoSource.IsRunning)
                {
                    timer1.Enabled = false;
                    CloseVideoSource();
                    label2.Text = "Device stopped.";
                    save.Text = "Record";
                    FileWriter.Close();
                    startrecording = false;
                    
                }
            }
            b_recording = startrecording;
        }

        
        private bool GenerateRecordingFile()
        {
            //for eyegazedata
            var systemTimeStamp = EyeTrackingOperations.GetSystemTimeStamp();
            string t_txtfilename = String.Format("_{0}.txt", systemTimeStamp);

            //var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            //string t_txtfilename= "_" + Timestamp.ToString() + ".txt";
            gazedatasavingpath = avisavingpath.Replace(".", "_") + t_txtfilename;
            
            if (!System.IO.File.Exists(gazedatasavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(gazedatasavingpath));
            }

            System.IO.File.WriteAllText(gazedatasavingpath, "DEVICE,X,Y,Z,TimeStamp\r\n");

            //for trialsaving data
            trialsavingpath = gazedatasavingpath.Replace(".txt", "_trials.txt");
            if (!System.IO.File.Exists(trialsavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(trialsavingpath)) ;
            }
            
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                timer1.Enabled = true;
            }
            else
            {
                label2.Text = "Error: No Device selected.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_trial_Click(object sender, EventArgs e)
        {
            if (!b_recording)
            {
                MessageBox.Show("Start Recording First!");
                return;
            }
            var systemTimeStamp = EyeTrackingOperations.GetSystemTimeStamp();
            string t_str = "";
            if (b_trial_locked)
            {
                //write start time stamp into the file
                t_str = String.Format("Trial{0},START,{1}\r\n",trialIndex.Text,systemTimeStamp);     
                bt_trial.Text = "End of Trial " + trialIndex.Text;                

            }
            else
            {
                //write end timestamp into the file
                t_str = String.Format("Trial{0},START,{1}\r\n", trialIndex.Text, systemTimeStamp);
                bt_trial.Text = "Start A New Trial";
            }
            System.IO.File.AppendAllText(trialsavingpath, t_str);
            b_trial_locked = !b_trial_locked;
        }

        class CallEyeTrackerManager
        {
            internal static void Execute(IEyeTracker eyeTracker)
            {
                if (eyeTracker != null)
                {
                    CallEyeTrackerManagerExample(eyeTracker);
                }
            }
            // <BeginExample>
            private static void CallEyeTrackerManagerExample(IEyeTracker eyeTracker)
            {
                string etmStartupMode = "--version";// "usercalibration";// "displayarea";
                string etmBasePath = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"),
                                                                    "TobiiProEyeTrackerManager"));
                string appFolder = Directory.EnumerateDirectories(etmBasePath, "app*").FirstOrDefault();
                string executablePath = Path.GetFullPath(Path.Combine(etmBasePath,
                                                                        appFolder,
                                                                        "TobiiProEyeTrackerManager.exe"));
                string arguments = "--device-address=" + eyeTracker.Address + " --mode=" + etmStartupMode;
                try
                {
                    Process etmProcess = new Process();
                    // Redirect the output stream of the child process.
                    etmProcess.StartInfo.UseShellExecute = false;
                    etmProcess.StartInfo.RedirectStandardError = true;
                    etmProcess.StartInfo.RedirectStandardOutput = true;
                    etmProcess.StartInfo.FileName = executablePath;
                    etmProcess.StartInfo.Arguments = arguments;
                    etmProcess.Start();
                    string stdOutput = etmProcess.StandardOutput.ReadToEnd();

                    etmProcess.WaitForExit();
                    int exitCode = etmProcess.ExitCode;
                    if (exitCode == 0)
                    {
                        Console.WriteLine("Eye Tracker Manager was called successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Eye Tracker Manager call returned the error code: {0}", exitCode);
                        foreach (string line in stdOutput.Split(Environment.NewLine.ToCharArray()))
                        {
                            if (line.StartsWith("ETM Error:"))
                            {
                                Console.WriteLine(line);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            // <EndExample>
        }

    }
}
