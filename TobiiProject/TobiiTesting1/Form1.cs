using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Accord.Video.DirectShow;
using Tobii.Research;

using System.IO;
using System.Diagnostics;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

using System.Timers;
using VirtualCoach;
using Accord;
// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace TobiiTesting1
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource = null;        

        //private FilterInfoCollection VideoCaptureDevices;
        //private VideoCaptureDevice FinalVideo = null;
        //private VideoCaptureDeviceForm captureDevice;
        //private Bitmap videoimg;
        //private AVIWriter AVIwriter = new AVIWriter();
        //private VideoFileWriter FileWriter = new VideoFileWriter();
        private SaveFileDialog saveAvi;
        public static bool startsession;
        public static bool eyetrackingrecordenabled = false;

        private string trialsavingpath = "";

        static string gazedatasavingpath = "";

        private string m_savingfolder = "";
        //static bool b_recording = false;

        static float m_eyegazex, m_eyegazey;
        static string m_eyegazestr = "No Eye Tracker";

        // true means the trial is in use, false means the trial is not in use
        // start recording: b_trial_locked=true, trial index;
        // end trial b_trial_locked=false,
        // start a new trial: b_trial_locked=true
        private bool b_trial_locked = true;
        //FormCamera cameraForm = new FormCamera();
        List<FormCameras> m_cameras = new List<FormCameras>();
        List<MainWindow> m_thermalcams = new List<MainWindow>();

        private int _trialIndex = 0;
        private AccObserver _trialEmpaticaObserver;
        private IDisposable _trialEmpaticaUnsubscriber_0;
        private IDisposable _trialEmpaticaUnsubscriber_1;

        //Form_Empatica empaticaForm;

        public bool m_empaticarunning;
        //private CascadeClassifier _cascadeClassifier;

        private DateTime m_trialstart = DateTime.Now;

        private string str_trial = "";

        private string[,] task_performance = new string[5, 4] {
                {"#of object dropped outside field of view","N/A","N/A","N/A"},
                {"All cuts within the lines? YES: 0, NO: 1","N/A","N/A","N/A"},
                {"Loop is secure? YES: 0, NO: 1","Loop is ___mm away from mark on appendage","N/A","N/A"},
                {"Knot is secure? YES: 0, NO: 1","Slit in drain is closed? YES: 0, NO: 1","Suture is ___mm away from dots","Drain was avulsed from foam block? YES: 0, NO: 1"},
                {"Knot is secure? YES: 0, NO: 1","Slit in drain is closed? YES: 0, NO: 1","Suture is ___mm away from dots","Drain was avulsed from foam block? YES: 0, NO: 1"}
            };

        private static AsynchronousClientD m_empatica_0 = new AsynchronousClientD();
        private static AsynchronousClientD m_empatica_1 = new AsynchronousClientD();

        private static System.Timers.Timer aTimer;
        private static bool m_starttimer;

        private static float m_eyetrackerfrequency = 120;

        private static bool m_baselinestarted = false;
        
        public Form1()
        {
            InitializeComponent();
            startsession = false;
            m_empaticarunning = false;
        }

        // get the devices name
        private void getCamList()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                //comboBox1.Items.Clear();
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                listView_CameraControl.Items.Clear();
                int t_index = 0;
                foreach (FilterInfo device in videoDevices)
                {
                    //comboBox1.Items.Add(device.Name);

                    ListViewItem item1 = new ListViewItem("", 0);
                    if (device.Name.Contains("eBUS"))
                    {
                        item1.Checked = false;
                    }
                    else
                    {
                        item1.Checked = false;
                    }
                                       
                    item1.SubItems.Add(device.Name);
                    item1.SubItems.Add(t_index.ToString());
                    listView_CameraControl.Items.Add(item1);
                    t_index++;
                }
            }
            catch (ApplicationException)
            {
                //comboBox1.Items.Add("No capture device on your system");
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
        

        //get total received frame at 1 second tick
        private void timer_main_Tick(object sender, EventArgs e)
        {
            //update timer
            TimeSpan t_min = DateTime.Now.Subtract(m_trialstart);
            lbl_time.Text = String.Format("{0:D2}:{1:D2}", t_min.Minutes, t_min.Seconds);
        }

        //prevent sudden close while device is running
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            aTimer.Enabled = false;
            
            foreach (FormCameras item in m_cameras)
            {
                item.CloseVideoSource();
            }
            foreach (MainWindow item in m_thermalcams)
            {
                item.CloseVideoSource();
            }

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            getCamList();
            //comboBox1.SelectedIndex = 0; //make dafault to first cam
        }

        private void calibration_Click(object sender, EventArgs e)
        {
            /*
            Browsing for eye trackers or selecting an eye tracker with known address.
            Establishing a connection with the eye tracker.
            Running a calibration procedure in which the eye tracker is calibrated to the user.
            Setting up a subscription to gaze data, and collecting and saving the data on the computer running the application.In some cases, the data is also shown live by the application.
            */
            
            var eyeTrackers = EyeTrackingOperations_FindAllEyeTrackers.Execute(this);
            while (eyeTrackers.Count < 1)
            {
                System.Threading.Thread.Sleep(2000);
                eyeTrackers = EyeTrackingOperations_FindAllEyeTrackers.Execute(this);
            }
            var eyeTracker = eyeTrackers[0];


            IEyeTracker_GazeOutputFrequencies.Execute(eyeTracker);
            label_pupil.Text = "eyetracker frequency: "+m_eyetrackerfrequency.ToString()+" Hz";

            CallEyeTrackerManager.Execute(eyeTracker);

            IEyeTracker_GazeDataReceived.Execute(eyeTracker,this);

        }

        internal static class IEyeTracker_GazeOutputFrequencies
        {
            internal static void Execute(IEyeTracker eyeTracker)
            {
                GazeOutputFrequencies(eyeTracker);
            }
            // <BeginExample>
            internal static void GazeOutputFrequencies(IEyeTracker eyeTracker)
            {
                Console.WriteLine("\nGaze output frequencies.");
                // Get and store current frequency so it can be restored.
                var initialGazeOutputFrequency = eyeTracker.GetGazeOutputFrequency();
                Console.WriteLine("Gaze output frequency is: {0} hertz.", initialGazeOutputFrequency);
                try
                {
                    // Get all gaze output frequencies.
                    var allGazeOutputFrequencies = eyeTracker.GetAllGazeOutputFrequencies();
                    foreach (var gazeOutputFrequency in allGazeOutputFrequencies)
                    {
                        if (gazeOutputFrequency < 110.0f)
                        {
                            initialGazeOutputFrequency = gazeOutputFrequency;
                            eyeTracker.SetGazeOutputFrequency(gazeOutputFrequency);
                            m_eyetrackerfrequency = gazeOutputFrequency;
                        }
                        //eyeTracker.SetGazeOutputFrequency(gazeOutputFrequency);
                        //Console.WriteLine("New gaze output frequency is: {0} hertz.", gazeOutputFrequency.ToString());
                    }
                }
                finally
                {
                    eyeTracker.SetGazeOutputFrequency(initialGazeOutputFrequency);
                    Console.WriteLine("Gaze output frequency reset to: {0} hertz.", eyeTracker.GetGazeOutputFrequency());
                }
            }
            // <EndExample>
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

                var t_str = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}\r\n",
                    e.LeftEye.GazeOrigin.Validity,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.X,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Y,
                    e.LeftEye.GazeOrigin.PositionInUserCoordinates.Z,
                    e.LeftEye.GazePoint.PositionOnDisplayArea.X,
                    e.LeftEye.GazePoint.PositionOnDisplayArea.Y,
                    e.RightEye.GazePoint.PositionOnDisplayArea.X,
                    e.RightEye.GazePoint.PositionOnDisplayArea.Y,
                    e.LeftEye.Pupil.Validity,
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
                if (eyetrackingrecordenabled)
                {
                    System.IO.File.AppendAllText(gazedatasavingpath, t_str);
                }
                
            }
            // <EndExample>
        }
        private void startSession_Click(object sender, EventArgs e)
        {
            btn_baseline.Enabled = true;
            m_baselinestarted = false;

            saveAvi = new SaveFileDialog();
            //saveAvi.Filter = "Txt Files (*.txt)|*.txt";
            saveAvi.FileName = DateTimeOffset.Now.ToString("MM_dd_yy_hh_mm_ss");//saveAvi.FileName= DateTimeOffset.Now.ToString("MM_dd_yyyy hh_mm_ss");
            if (saveAvi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //create a new folder
                try
                {
                    m_savingfolder = saveAvi.FileName;

                    // Determine whether the directory exists.
                    if (Directory.Exists(m_savingfolder))
                    {
                        Console.WriteLine("That path exists already.");
                    }
                    else
                    {
                        DirectoryInfo di = Directory.CreateDirectory(m_savingfolder);
                        Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(m_savingfolder));
                    }
                    
                    GenerateRecordingFile();
                    
                    startsession = true;

                    txt_participant.Enabled = false;
                    num_sessionIndex.Enabled = false;
                    btn_endSession.Enabled = true;
                    cmb_task.Enabled = true;                    
                    btn_startStopTrial.Enabled = true;

                    txt_score1.Enabled = true;
                    txt_score2.Enabled = true;
                    txt_score3.Enabled = true;
                    txt_score4.Enabled = true;
                    txt_comment.Enabled = true;
                }
                catch 
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
                finally
                {
                    btn_startSession.Enabled = false;
                    System.Threading.Thread.Sleep(500);
                }

                //avisavingpath = saveAvi.FileName;
            }

        }
        

        
        private bool GenerateRecordingFile()
        {
            //for eyegazedata
            var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
            //string t_txtfilename = String.Format("_Tobii_{0}.txt", local_timestamp);

            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            
            //for trialsaving data
            trialsavingpath = m_savingfolder+ "\\Trials_" + UnixTimestamp.ToString()+".txt";

            if (!File.Exists(trialsavingpath))
            {
                //trial format: participant,recordtype,index,status,score,unixtimestamp,localtimestamp,comment
                //participant,unixtimestamp,localtimestamp,recordtype,status,taskindex,trialindex,score,comment

                //string t_str = "participant,unixtimestamp,localtimestamp,recordtype,status,taskindex,trialindex,duration,score,comment\r\n";
                //\"participant\":,\"unixtimestamp\":,\"localtimestamp\":,\"recordtype\":,\"status\":,\"taskindex\":,\"trialindex\":,\"duration\":,\"score\":,\"comment\":
                //start session
                File.WriteAllText(trialsavingpath, "{\r\n");

                //t_str = String.Format("{0},{1},{2},SESSION,START,NA,NA,NA,NA,NA\r\n", textBox_participant.Text, UnixTimestamp, local_timestamp);

                var t_str = String.Format("{{\"participant\":\"{0}\"," +
                    "\"unixtimestamp\":\"{1}\"," +
                    "\"localtimestamp\":\"{2}\"," +
                    "\"recordtype\":\"SESSION\"," +
                    "\"status\":\"START\"," +
                    "\"taskindex\":\"NA\"," +
                    "\"trialindex\":\"NA\"," +
                    "\"duration\":\"NA\"," +
                    "\"score\":\"NA\"," +
                    "\"comment\":\"NA\"}},\r\n", 
                    txt_participant.Text, UnixTimestamp, local_timestamp);

                System.IO.File.AppendAllText(trialsavingpath, t_str);

            }
            
            return true;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_enterScore.Enabled)
            {
                var str_score = String.Format("\"{{1:{0},2:{1},3:{2},4:{3}}}\"", txt_score1.Text, txt_score2.Text, txt_score3.Text, txt_score4.Text);

                //t_str = String.Format("{0},Trial,{1},END,{2},{3},{4},\"{5}\"\r\n", textBox_participant.Text, trialIndex.Text, textBox_score_0.Text, UnixTimestamp, local_timestamp, textBox_comment.Text.Replace("\r\n"," "));
                //string t_str = String.Format("{0},{1},{2},\"{3}\"\r\n", str_trial, label_time.Text, str_score, textBox_comment.Text.Replace("\r\n", " "));

                string t_str = String.Format("{{{0}" +
                        "\"duration\":\"{1}\"," +
                        "\"score\":\"{2}\"," +
                        "\"comment\":\"{3}\"}},\r\n",
                        str_trial, lbl_time.Text, str_score, txt_comment.Text.Replace("\r\n", " "));

                System.IO.File.AppendAllText(trialsavingpath, t_str);

            }
            if (btn_endSession.Enabled)
            {
                var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
                var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

                if (System.IO.File.Exists(trialsavingpath))
                {
                    string t_str = String.Format("{{\"participant\":\"{0}\"," +
                        "\"unixtimestamp\":\"{1}\"," +
                        "\"localtimestamp\":\"{2}\"," +
                        "\"recordtype\":\"SESSION\"," +
                        "\"status\":\"STOP\"," +
                        "\"taskindex\":\"NA\"," +
                        "\"trialindex\":\"NA\"," +
                        "\"duration\":\"NA\"," +
                        "\"score\":\"NA\"," +
                        "\"comment\":\"NA\"}}\r\n",
                        txt_participant.Text, UnixTimestamp, local_timestamp);

                    //participant,unixtimestamp,localtimestamp,recordtype,status,taskindex,trialindex,duration,score,comment
                    // t_str = String.Format("{0},{1},{2},SESSION,STOP,NA,NA,NA,NA,NA\r\n", textBox_participant.Text, UnixTimestamp, local_timestamp);
                    System.IO.File.AppendAllText(trialsavingpath, t_str);

                    t_str = "}\r\n";
                    System.IO.File.AppendAllText(trialsavingpath, t_str);

                }
            }
            aTimer.Stop();
            aTimer.Dispose();
            if (videoSource == null)
            { return; }
            if (videoSource.IsRunning)
            {
                this.videoSource.Stop();

            }            
            
        }

        private void task_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1_score_0.Text = task_performance[cmb_task.SelectedIndex, 0];
            label1_score_1.Text = task_performance[cmb_task.SelectedIndex, 1];
            label1_score_2.Text = task_performance[cmb_task.SelectedIndex, 2];
            label1_score_3.Text = task_performance[cmb_task.SelectedIndex, 3];
            //open the FormCamera, display the realtime image on the picturebox

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getCamList();
            addTaskList();
            SetTimer();
            //setup empatica device name
            ReadInitiatefile("virtualcoach.ini");
        }

        private void ReadInitiatefile(string filename)
        {
            //E4Wristband:AB2B64
            //E4Wristband: 3A4FCD
            if (System.IO.File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    List<string> lines = new List<string>();
                    List<string> t_subscribe = new List<string>();
                    int t_sleep = 1000;
                    while (!reader.EndOfStream)
                    {
                        string t_str=reader.ReadLine();
                        if (t_str.Contains("E4Wristband:"))
                        {
                            lines.Add(t_str.Replace("E4Wristband:", ""));
                        }
                        else if (t_str.Contains("E4Sleeptime:"))
                        {
                            t_sleep = Convert.ToInt32(t_str.Replace("E4Sleeptime:", ""));
                        }
                        else if (t_str.Contains("E4Subscribe:"))
                        {
                            t_subscribe.Add(t_str.Replace("E4Subscribe:", "device_subscribe ") +" ON");
                        }
                    }
                    if (lines.Count == 1)
                    {
                        checkBox_empatica_0.Text = lines[0];
                    }
                    else if (lines.Count > 1)
                    {
                        checkBox_empatica_0.Text = lines[0];
                        checkBox_empatica_1.Text = lines[1];
                    }
                    m_empatica_0.SetupEmpaticaDevice(t_subscribe.ToArray(), t_sleep);
                    m_empatica_1.SetupEmpaticaDevice(t_subscribe.ToArray(), t_sleep);
                }
            }

        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(100);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}",e.SignalTime);
            if (m_starttimer && aTimer.Enabled)
            {
                this.Invoke((MethodInvoker)delegate () { pictureBox1.Image = m_cameras[cmb_showcameras.SelectedIndex].GetPicture(); });

                //pictureBox1.Image = m_cameras[comboBox_showcameras.SelectedIndex].GetPicture();
            }            

        }

        private void addTaskList()
        {
            foreach (var task in Enum.GetValues(typeof(iThrivTask)).Cast<iThrivTask>())
            {
                cmb_task.Items.Add(task.GetDescription());
            }

            cmb_task.SelectedIndex = 0;
        }

        private void show_Click(object sender, EventArgs e)
        {
            //create forms and show
            cmb_showcameras.Items.Clear();
            int t_count = 0;
            foreach (ListViewItem item in listView_CameraControl.Items)
            {
                if (item.Checked)
                {
                    //if normal then show normal,
                    //else show FlirFileFormat
                    if (item.SubItems[1].Text.Contains("FLIR") && checkBox_thermalapi.Checked)//&& checkBox_thermalapi.Checked
                    {
                        MainWindow t_cameraForm = new MainWindow();
                        t_cameraForm.m_index = item.Index;

                        t_cameraForm.Show();
                        m_thermalcams.Add(t_cameraForm);
                    }
                    else
                    {
                        FormCameras t_cameraForm = new FormCameras();
                        t_cameraForm.SetDeviceMonikerString(videoDevices[item.Index].MonikerString);
                        t_cameraForm.m_index = item.Index;

                        t_cameraForm.Show();
                        m_cameras.Add(t_cameraForm);
                        cmb_showcameras.Items.Add(item.SubItems[1].Text + "_" + item.Index);
                        //comboBox_showcameras.SelectedIndex = 0;
                    }                    

                    //add cameras into the comboBox_showcameras
                    t_count++;
                }
                
            }
            

            if (t_count>0)
            {
                //_cascadeClassifier = new CascadeClassifier(@"..\data\haarcascades\haarcascade_frontalface_alt2.xml");
            }


        }

        private void empatica_Click(object sender, EventArgs e)
        {
            //empaticaForm = new Form_Empatica();
            //empaticaForm.m_empaticadevicename = textBox_empatica.Text;
            //empaticaForm.Show();
            
            
            if (!m_empaticarunning)
            {
                try
                {
                    if (checkBox_empatica_0.Checked)
                    {
                        if (m_empatica_0.StartClient(checkBox_empatica_0.Text))
                        {
                            checkBox_empatica_0.Enabled = false;
                        }
                        else
                        {
                            checkBox_empatica_0.Checked = false;
                        }
                    }
                    if (checkBox_empatica_1.Checked)
                    {
                        if (m_empatica_1.StartClient(checkBox_empatica_1.Text))
                        {
                            checkBox_empatica_1.Enabled = false;
                        }
                        else
                        {
                            checkBox_empatica_1.Checked = false;
                        }
                    }
                    
                    btn_empatica.Text = "Stop Empatica";
                }
                catch
                {
                    Console.WriteLine("Empatica is not running correctly");
                    return;
                }
                
            }
            else
            {
                if (checkBox_empatica_0.Checked)
                {
                    m_empatica_0.StopClient();
                    checkBox_empatica_0.Enabled = true;
                }
                if (checkBox_empatica_1.Checked)
                {
                    m_empatica_1.StopClient();
                    checkBox_empatica_1.Enabled = true;
                }
                
                btn_empatica.Text = "Start Empatica";
            }
            m_empaticarunning = !m_empaticarunning;
            
            
        }

        private void comboBox_showcameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pictureBox1.Image = m_cameras[comboBox_showcameras.SelectedIndex].GetPicture();
            m_starttimer = true;
            //pictureBox1.Image = m_cameras[comboBox_showcameras.SelectedIndex].videoimg;
        }

        private void timer_empatica_Tick(object sender, EventArgs e)
        {
            if (startsession)
            {
                if (checkBox_empatica_0.Checked)
                {
                    m_empatica_0.SavingEverySecond();
                }
                if (checkBox_empatica_1.Checked)
                {
                    m_empatica_1.SavingEverySecond();
                }
                
            }
        }

        private void checkBox_face_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void enterScore_Click(object sender, EventArgs e)
        {
            //task_list[comboBox1.SelectedIndex], trialIndex.Text, textBox_score_0.Text,
            //trial format: participant,unixtimestamp,localtimestamp,recordtype,status,
            //taskindex,trialindex,score,comment

            var str_score = String.Format("\"{{1:{0},2:{1},3:{2},4:{3}}}\"", txt_score1.Text, txt_score2.Text, txt_score3.Text, txt_score4.Text);

            //t_str = String.Format("{0},Trial,{1},END,{2},{3},{4},\"{5}\"\r\n", textBox_participant.Text, trialIndex.Text, textBox_score_0.Text, UnixTimestamp, local_timestamp, textBox_comment.Text.Replace("\r\n"," "));
            //string t_str = String.Format("{0},{1},{2},\"{3}\"\r\n", str_trial, label_time.Text, str_score, textBox_comment.Text.Replace("\r\n", " "));

            string t_str = String.Format("{{{0}"+
                    "\"duration\":\"{1}\"," +
                    "\"score\":\"{2}\"," +
                    "\"comment\":\"{3}\"}},\r\n",
                    str_trial, lbl_time.Text, str_score, txt_comment.Text.Replace("\r\n", " "));


            System.IO.File.AppendAllText(trialsavingpath, t_str);

            txt_comment.Text = "";
            btn_enterScore.Enabled = false;


            txt_score1.Text = "0";
            txt_score2.Text = "0";
            txt_score3.Text = "0";
            txt_score4.Text = "0";

            lbl_time.Text = "00:00";
            m_trialstart = DateTime.Now;//trialperiod = 0;
            cmb_task.Enabled = true;
            btn_startStopTrial.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainWindow t_cameraForm = new MainWindow();
            t_cameraForm.Show();
        }

        private void endSession_Click(object sender, EventArgs e)
        {
            
            if (!b_trial_locked)
            {
                MessageBox.Show("Finish the running trial!");
                return;
            }
            if (btn_enterScore.Enabled)
            {
                MessageBox.Show("Enter the previous score!");
                return;
            }

            m_starttimer = false;
            startsession = false;

            //loggging
            var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            if (System.IO.File.Exists(trialsavingpath))
            {
                string t_str = String.Format("{{\"participant\":\"{0}\"," +
                    "\"unixtimestamp\":\"{1}\"," +
                    "\"localtimestamp\":\"{2}\"," +
                    "\"recordtype\":\"SESSION\"," +
                    "\"status\":\"STOP\"," +
                    "\"taskindex\":\"NA\"," +
                    "\"trialindex\":\"NA\"," +
                    "\"duration\":\"NA\"," +
                    "\"score\":\"NA\"," +
                    "\"comment\":\"NA\"}}\r\n",
                    txt_participant.Text, UnixTimestamp, local_timestamp);

                //participant,unixtimestamp,localtimestamp,recordtype,status,taskindex,trialindex,duration,score,comment
                // t_str = String.Format("{0},{1},{2},SESSION,STOP,NA,NA,NA,NA,NA\r\n", textBox_participant.Text, UnixTimestamp, local_timestamp);
                System.IO.File.AppendAllText(trialsavingpath, t_str);

                t_str = "}\r\n";
                System.IO.File.AppendAllText(trialsavingpath, t_str);

            }            

            btn_endSession.Enabled = false;

            num_sessionIndex.Enabled = false;
            btn_startStopTrial.Enabled = false;
            txt_score1.Enabled = false;
            txt_score2.Enabled = false;
            txt_score3.Enabled = false;
            txt_score4.Enabled = false;
            txt_comment.Enabled = false;
            btn_enterScore.Enabled = false;
            btn_startSession.Enabled = true;
        }

        private void listView_CameraControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startStopTrial_Click(object sender, EventArgs e)
        {
            if (!startsession)
            {
                MessageBox.Show("Start session first!");
                return;
            }

            if (btn_enterScore.Enabled)
            {
                MessageBox.Show("Enter the previous score!");
                return;
            }

            var local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

            if (b_trial_locked)
            {
                _trialIndex++;

                string trialinfo= String.Format("task{0}_trial{1}_{2}", Enum.GetName(typeof(iThrivTask), cmb_task.SelectedIndex), _trialIndex, UnixTimestamp);
                foreach (FormCameras item in m_cameras)
                {
                    string filepath = String.Format("{0}\\Camera{1}_{2}.avi", m_savingfolder, item.m_index, trialinfo);
                    item.StartRecording(filepath);                           
                }
                foreach (MainWindow item in m_thermalcams)
                {
                    string filepath = String.Format("{0}\\Thermal{1}_{2}.avi", m_savingfolder, item.m_index, trialinfo);
                    item.StartRecording(filepath);                    
                }

                
                //wait until all opened
                /*
                int t_count = m_thermalcams.Count + m_cameras.Count;
                while (t_count==0)
                {
                    foreach (FormCameras item in m_cameras)
                    {
                        while (item.CheckFileWriterOpen())
                        {
                            t_count--;
                            System.Threading.Thread.Sleep(500);
                        }

                    }
                    foreach (MainWindow item in m_thermalcams)
                    {
                        while (item.CheckFileWriterOpen())
                        {
                            t_count--;
                            System.Threading.Thread.Sleep(500);
                        }
                    }
                    
                }
                */

                //testing
                //m_empaticarunning = true;
                if (m_empaticarunning)
                {
                    //revised on 11/25/2019
                    //if checked record all empatica data into one file
                    if (checkBox_empatica_record.Checked)
                    {
                        string t_empatica_taskinfo = String.Format("task{0}_wholetrial", Enum.GetName(typeof(iThrivTask), cmb_task.SelectedIndex));
                        if (checkBox_empatica_0.Checked)
                        {
                            m_empatica_0.SavingRecord(m_savingfolder, t_empatica_taskinfo);
                        }
                        if (checkBox_empatica_1.Checked)
                        {
                            m_empatica_1.SavingRecord(m_savingfolder, t_empatica_taskinfo);
                        }
                    }
                    else
                    {
                        if (checkBox_empatica_0.Checked)
                        {
                            m_empatica_0.SavingRecord(m_savingfolder, trialinfo);
                        }
                        if (checkBox_empatica_1.Checked)
                        {
                            m_empatica_1.SavingRecord(m_savingfolder, trialinfo);
                        }
                                                
                    }
                    timer_empatica.Enabled = true;
                }
                //m_empaticarunning = false;

                gazedatasavingpath = String.Format("{0}\\Tobii_{1}.txt", m_savingfolder,  trialinfo); //m_savingfolder + "_Tobii.txt";


                local_timestamp = DateTimeOffset.Now.ToString("MM/dd/yyyy hh:mm:ss.fff").ToString();
                UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

                File.WriteAllText(gazedatasavingpath, "DEVICE,X,Y,Z,LPDA_X,LPDA_Y,RPDA_X,RPDA_Y,Pupil_VA,Pupil_left,Pupil_right,UnixTS,TimeStamp\r\n");

                eyetrackingrecordenabled = true;
                string t_str = String.Format("{{\"participant\":\"{0}\"," +
                    "\"unixtimestamp\":\"{1}\"," +
                    "\"localtimestamp\":\"{2}\"," +
                    "\"recordtype\":\"TRIAL\"," +
                    "\"status\":\"START\"," +
                    "\"taskindex\":\"{3}\"," +
                    "\"trialindex\":\"{4}\"," +
                    "\"duration\":\"NA\"," +
                    "\"score\":\"NA\"," +
                    "\"comment\":\"NA\"}},\r\n",
                    txt_participant.Text, UnixTimestamp, local_timestamp, Enum.GetName(typeof(iThrivTask), cmb_task.SelectedIndex), _trialIndex);
                                
                btn_startStopTrial.Text = "End Trial";
                btn_enterScore.Enabled = false;
                cmb_task.Enabled = false;

                File.AppendAllText(trialsavingpath, t_str);

                System.Threading.Thread.Sleep(500);

                _trialEmpaticaUnsubscriber_0?.Dispose();
                _trialEmpaticaUnsubscriber_1?.Dispose();

                _trialEmpaticaObserver = new AccObserver();

                _trialEmpaticaUnsubscriber_0 = m_empatica_0.Subscribe(_trialEmpaticaObserver);
                _trialEmpaticaUnsubscriber_1 = m_empatica_1.Subscribe(_trialEmpaticaObserver);

                m_trialstart = DateTime.Now;
                timer_main.Enabled = true;
            }
            else
            {
                foreach (FormCameras item in m_cameras)
                {
                    item.StopRecording();
                }
                foreach (MainWindow item in m_thermalcams)
                {
                    item.StopRecording();
                }
                // revised on 11/25/2019
                // if checked, all empatica will be stored in a whole file 
                if (checkBox_empatica_record.Checked)
                {
                    //pass
                }
                else
                {
                    timer_empatica.Enabled = false;
                }
                
                eyetrackingrecordenabled = false;
                //write end timestamp into the file
                //str_trial = String.Format("{0},{1},{2},Trial,END,{3},{4}", textBox_participant.Text, UnixTimestamp, local_timestamp, task_list_log[comboBox1.SelectedIndex], trialIndex.Text);

                str_trial = String.Format("\"participant\":\"{0}\"," +
                    "\"unixtimestamp\":\"{1}\"," +
                    "\"localtimestamp\":\"{2}\"," +
                    "\"recordtype\":\"TRIAL\"," +
                    "\"status\":\"END\"," +
                    "\"taskindex\":\"{3}\"," +
                    "\"trialindex\":\"{4}\","
                    , txt_participant.Text, UnixTimestamp, local_timestamp, Enum.GetName(typeof(iThrivTask), cmb_task.SelectedIndex), _trialIndex);

                btn_startStopTrial.Text = "Start A New Trial";
                
                timer_main.Enabled = false;

                btn_enterScore.Enabled = true;
                btn_startStopTrial.Enabled = false;

                new ResultDialog
                (
                    (iThrivTask)cmb_task.SelectedIndex,
                    (int)num_sessionIndex.Value,
                    _trialIndex,
                    DateTime.Now - m_trialstart,
                    _trialEmpaticaObserver.Magnitudes.ToArray()
                ).ShowDialog(this);
            }
            //save video
            //iterate the listcameras

            b_trial_locked = !b_trial_locked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_eyetrackerfrequency = float.Parse(txt_tobiiHz.Text);
        }

        private void baseline_Click(object sender, EventArgs e)
        {
            if (!m_baselinestarted)
            {
                startStopTrial_Click(sender, e);
                m_baselinestarted = !m_baselinestarted;
            }
            else if (m_baselinestarted)
            {
                startStopTrial_Click(sender, e);
                enterScore_Click(sender, e);
                btn_baseline.Enabled = false;
            }
                        
        }

        private void trialIndex_TextChanged(object sender, EventArgs e)
        {

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
                /*
                 * Remarks
                    System environment variables define the behavior of the global operating system environment. Local environment variables define the behavior of the environment of the current user session.

                    The following is a selection of valid environment variables:

                    ALLUSERSPROFILE=C:\ProgramData
                    APPDATA=C:\Users\user\AppData\Roaming
                    HOMEPATH=\Users\user
                    LOCALAPPDATA=C:\Users\user\AppData\Local
                    PROGRAMDATA=C:\ProgramData
                    PUBLIC=C:\Users\Public
                    TEMP=C:\Users\user\AppData\Local\Temp
                    TMP=C:\Users\user\AppData\Local\Temp
                    USERPROFILE=C:\Users\user
                */
                string etmStartupMode = "usercalibration";// "usercalibration";// "displayarea";//"--version"//"displayarea"
                string executablePath="";

                string etmBasePath = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"),"TobiiProEyeTrackerManager"));
                if (Directory.Exists(etmBasePath))
                {
                    string appFolder = Directory.EnumerateDirectories(etmBasePath, "app*").FirstOrDefault();
                    executablePath = Path.GetFullPath(Path.Combine(etmBasePath,
                                                                       appFolder,
                                                                       "TobiiProEyeTrackerManager.exe"));
                }
                else
                {
                    etmBasePath = Path.GetFullPath(Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), "programs/TobiiProEyeTrackerManager"));
                    executablePath = Path.GetFullPath(Path.Combine(etmBasePath, "TobiiProEyeTrackerManager.exe"));
                }
                
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
