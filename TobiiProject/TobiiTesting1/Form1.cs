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


using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Drawing;

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
        //private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;
        public static bool startrecording;

        private int w, h;
        private string m_folder;
        private string trialsavingpath = "";
        private string avisavingpath = "";

        static string gazedatasavingpath = "";
        //static bool b_recording = false;

        static float m_eyegazex, m_eyegazey;
        static string m_eyegazestr = "No Eye Tracker";

        // true means the trial is in use, false means the trial is not in use
        // start recording: b_trial_locked=true, trial index;
        // end trial b_trial_locked=false,
        // start a new trial: b_trial_locked=true
        private bool b_trial_locked = true;
        FormCamera cameraForm = new FormCamera();
        List<FormCameras> m_cameras = new List<FormCameras>();
        //Form_Empatica empaticaForm;

        public bool m_empaticarunning;
        private CascadeClassifier _cascadeClassifier;
        

        public Form1()
        {
            InitializeComponent();
            startrecording = false;
            m_empaticarunning = false;
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
                listView_CameraControl.Items.Clear();
                int t_index = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);

                    ListViewItem item1 = new ListViewItem("", 0);
                    item1.Checked = true;                    
                    item1.SubItems.Add(device.Name);
                    item1.SubItems.Add(t_index.ToString());
                    listView_CameraControl.Items.Add(item1);
                    t_index++;
                }
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
       
        private Mat DrawInfoToImage(Mat img,string t_str="test")
        {
            CvInvoke.PutText(
               img,
               m_eyegazestr,
               new System.Drawing.Point(10, 80),
               FontFace.HersheyComplex,
               0.5,
               new Bgr(0, 255, 0).MCvScalar);
            return img;
        }
        //eventhandler if new frame is ready
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            videoimg = (Bitmap)eventArgs.Frame.Clone();
            //do processing here
            //pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

            Image<Bgr, Byte> imageCV = new Image<Bgr, byte>(videoimg); //Image Class from Emgu.CV
            //Mat mat = imageCV.Mat;

            //update the eyegaze data

            Rectangle eyegaze = new System.Drawing.Rectangle((int)m_eyegazex, (int)m_eyegazey, 20,20);//x,y,w,h
            imageCV.Draw(eyegaze, new Bgr(0, 255, 0));
            //cameraForm.pictureBox1.Image = imageCV.Bitmap;

            //darw text to image
            
            Mat mat = DrawInfoToImage(imageCV.Mat,m_eyegazestr);
            //cameraForm.pictureBox1.Image = mat.Bitmap;
            pictureBox1.Image = mat.Bitmap;
            //cameraForm.pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            // save image to file
            if (startrecording)
            {
                //FileWriter.WriteVideoFrame(videoimg);
                //FileWriter.Flush();
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

            Image t_image = m_cameras[comboBox_showcameras.SelectedIndex].GetPicture();
            if (t_image != null)
            {
                //Bitmap t_img = (Bitmap)m_cameras[comboBox_showcameras.SelectedIndex].GetPicture().Clone();
                Bitmap t_img = (Bitmap)t_image.Clone();

                
                Image<Bgr, Byte> imageCV = new Image<Bgr, byte>(t_img);

                if (imageCV != null)
                {
                    if (checkBox_face.Checked)
                    {
                        var grayframe = imageCV.Convert<Gray, byte>();
                        var faces = _cascadeClassifier.DetectMultiScale(grayframe, 1.1, 10, Size.Empty); //the actual face detection happens here


                        foreach (var face in faces)
                        {
                            imageCV.Draw(face, new Bgr(Color.BurlyWood), 3); //the detected face(s) is highlighted here using a box that is drawn around it/them

                        }
                    }                                   


                    Rectangle eyegaze = new System.Drawing.Rectangle((int)(m_eyegazex * t_img.Width), (int)(m_eyegazey * t_img.Height), 20, 20);//x,y,w,h
                    imageCV.Draw(eyegaze, new Bgr(0, 255, 0));

                    //darw text to image

                    Mat mat = DrawInfoToImage(imageCV.Mat, m_eyegazestr);
                    //cameraForm.pictureBox1.Image = mat.Bitmap;
                    pictureBox1.Image = mat.Bitmap;
                }

                //update the eyegaze data
                //m_eyegazex = 0.5f;
                //m_eyegazey = 0.3f;
                
            }
            

        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseVideoSource();
            //FileWriter.Close();
            foreach (FormCameras item in m_cameras)
            {
                item.CloseVideoSource();
            }
        }

        private void rfsh_Click_1(object sender, EventArgs e)
        {
            getCamList();
            comboBox1.SelectedIndex = 0; //make dafault to first cam
        }

        /*
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Click on the link below to continue learning how to build a desktop app using WinForms!
            System.Diagnostics.Process.Start("http://aka.ms/dotnet-get-started-desktop");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks!");
        }
        */
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
                var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
                var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();

                var t_str = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}\r\n",
                    e.LeftEye.GazeOrigin.Validity,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.X,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Z,
                    e.LeftEye.GazePoint.PositionOnDisplayArea.X,
                    e.LeftEye.GazePoint.PositionOnDisplayArea.Y,
                    e.LeftEye.Pupil.PupilDiameter,
                    e.RightEye.Pupil.PupilDiameter,
                    UnixTimestamp,
                local_timestamp);

                

               
                //project eye tracking data to form image
                // eye tracking data: screen center point (0,0)
                m_eyegazex = e.LeftEye.GazePoint.PositionOnDisplayArea.X;
                m_eyegazey = e.LeftEye.GazePoint.PositionOnDisplayArea.Y;

                m_eyegazestr = String.Format("{0},{1},{2}",
                   m_eyegazex,
                   m_eyegazey,
                   UnixTimestamp);


                //m_eyegazey = e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y;
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
                if (startrecording)
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
                    //iterate the listcameras
                    foreach(FormCameras item in m_cameras)
                    {
                        item.StartRecording(saveAvi.FileName.Replace(".", "_"+item.m_index+ "."));                        
                    }
                    //empaticaForm.StartRecording(saveAvi.FileName);


                    //h = videoimg.Height;
                    //w = videoimg.Width;

                    //FileWriter.Open(saveAvi.FileName, w, h, 25, VideoCodec.Default, 5000000);
                    //FileWriter.WriteVideoFrame(videoimg);
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
                    if (m_empaticarunning)
                    {
                        AsynchronousClient.SavingRecord(saveAvi.FileName);
                        timer_empatica.Enabled = true;
                    }
                    
                }
                
            }
            else
            {

                if (true)
                {
                    foreach (FormCameras item in m_cameras)
                    {
                        item.StopRecording();
                    }

                    timer1.Enabled = false;
                    //CloseVideoSource();
                    label2.Text = "Device stopped.";
                    save.Text = "Record";
                    //FileWriter.Close();
                    startrecording = false;
                    timer_empatica.Enabled = false;
                }
            }
            //b_recording = startrecording;
        }

        
        private bool GenerateRecordingFile()
        {
            //for eyegazedata
            var local_timestamp = DateTimeOffset.Now.ToString("MM_dd_yyyy hh_mm_ss");
            string t_txtfilename = String.Format("_Tobii_{0}.txt", local_timestamp);

            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();
            //string t_txtfilename= "_" + Timestamp.ToString() + ".txt";
            gazedatasavingpath = avisavingpath.Replace(".", "_") + t_txtfilename;
            
            if (!System.IO.File.Exists(gazedatasavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(gazedatasavingpath));
            }

            System.IO.File.WriteAllText(gazedatasavingpath, "DEVICE,X,Y,Z,PDA_X,PDA_Y,Pupil_left,Pupil_right,UnixTS,TimeStamp\r\n");

            //for trialsaving data
            trialsavingpath = gazedatasavingpath.Replace(".txt", "_trials.txt");
            if (!System.IO.File.Exists(trialsavingpath))
            {
                //create file
                using (var t_file = System.IO.File.Create(trialsavingpath));

                string t_str = String.Format("VIDEORECORDING_START,{0},{1}\r\n", UnixTimestamp, local_timestamp);                
                System.IO.File.AppendAllText(trialsavingpath, t_str);

                t_str = String.Format("Trial{0},START,{1},{2}\r\n", trialIndex.Text, UnixTimestamp, local_timestamp);
                System.IO.File.AppendAllText(trialsavingpath, t_str);
                bt_trial.Text = "End the Trial " + trialIndex.Text;

                b_trial_locked = !b_trial_locked;
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
                //FileWriter.Close();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //open the FormCamera, display the realtime image on the picturebox
            

            if (DeviceExist)
            {
                CloseVideoSource();
                //cameraForm.Show();

                videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

                
                //videoSource.DesiredFrameSize = new Size(160, 120);//new Size(160, 120);
                //videoSource.DesiredFrameRate = 10;
                videoSource.Start();

                label2.Text = "Device running...";
                //timer1.Enabled = true;
            }
            else
            {
                label2.Text = "Error: No Device selected.";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getCamList();
            timer1.Enabled = false;
        }

        private void show_Click(object sender, EventArgs e)
        {
            //create forms and show
            comboBox_showcameras.Items.Clear();
            int t_count = 0;
            foreach (ListViewItem item in listView_CameraControl.Items)
            {
                if (item.Checked)
                {
                    FormCameras t_cameraForm = new FormCameras();
                    t_cameraForm.SetDeviceMonikerString(videoDevices[item.Index].MonikerString);
                    t_cameraForm.m_index = item.Index;

                    t_cameraForm.Show();
                    m_cameras.Add(t_cameraForm);

                    //add cameras into the comboBox_showcameras
                    
                    comboBox_showcameras.Items.Add(item.SubItems[1].Text+"_"+item.Index);
                    comboBox_showcameras.SelectedIndex = 0;
                    t_count++;
                }
            }
            if (t_count>0)
            {
                timer1.Enabled = true;
                //_cascadeClassifier = new CascadeClassifier(@".\\haarcascades\\" + "haarcascade_frontalface_alt2.xml");
                _cascadeClassifier = new CascadeClassifier(@"..\data\haarcascades\haarcascade_frontalface_alt2.xml");
            }


        }

        private void bt_empatica_Click(object sender, EventArgs e)
        {
            //empaticaForm = new Form_Empatica();
            //empaticaForm.m_empaticadevicename = textBox_empatica.Text;
            //empaticaForm.Show();
            
            
            if (!m_empaticarunning)
            {
                try
                {
                    AsynchronousClient.StartClient(textBox_empatica.Text);
                    bt_empatica.Text = "Stop Empatica";
                }
                catch
                {
                    Console.WriteLine("Empatica is not running correctly");
                    return;
                }
                
            }
            else
            {
                AsynchronousClient.StopClient();
                bt_empatica.Text = "Start Empatica";
            }
            m_empaticarunning = !m_empaticarunning;
            
            
        }

        private void comboBox_showcameras_SelectedIndexChanged(object sender, EventArgs e)
        {

            pictureBox1.Image = m_cameras[comboBox_showcameras.SelectedIndex].GetPicture();
            //get position data
            //show on the image

        }

        private void timer_empatica_Tick(object sender, EventArgs e)
        {
            if (startrecording)
            {
                AsynchronousClient.SavingEverySecond();
            }
        }

        private void checkBox_face_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bt_trial_Click(object sender, EventArgs e)
        {
            if (!startrecording)
            {
                MessageBox.Show("Start Recording First!");
                return;
            }
            var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            string t_str = "";
            if (b_trial_locked)
            {
                //write start time stamp into the file
                t_str = String.Format("Trial{0},START,{1},{2}\r\n",trialIndex.Text, UnixTimestamp, local_timestamp);     
                bt_trial.Text = "End the Trial " + trialIndex.Text;
                
            }
            else
            {
                //write end timestamp into the file
                t_str = String.Format("Trial{0},END,{1},{2}\r\n", trialIndex.Text, UnixTimestamp, local_timestamp);
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
                string etmStartupMode = "usercalibration";// "usercalibration";// "displayarea";//"--version"
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
