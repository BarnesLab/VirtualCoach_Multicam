using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Accord.Video;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;

using System.Threading;

using Flir.Atlas.Image;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;

namespace TobiiTesting1
{
    public partial class MainWindow : Form
    {
        private Camera _cam1;
        //private Timer _updateGuiTimer;
        public int m_index;//index in the listview

        private int w = 80;
        private int h = 60;

        public bool m_startrecording;
        private bool IsSrc1Dirty { get; set; }
        private VideoFileWriter FileWriter = new VideoFileWriter();

        private Bitmap videoimg;

        long StartTick = DateTime.Now.Ticks;

        public static string m_csvfilename;
        public static ThermalImageFile th = new ThermalImageFile("thermal.jpg");
        public static FileStream m_fs;

        Point[] m_points=new Point[60*80];// w=80,h=60

        public static string m_allcvs;
        private int ncount = 0;
        //private string m_imagefolder;
        public MainWindow()
        {
            InitializeComponent();

            Text = "Dual Camera Sample, running Atlas version: " + ImageBase.Version;

            // set default directory where to save the snapshots.
            textBoxImageLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            timer1.Enabled = true;
            //m_timerinterval = timer1.Interval;
            // Create timer to update our UI.
            //_updateGuiTimer = new Timer {Interval = m_timerinterval };
            //_updateGuiTimer.Tick += _updateGuiTimer_Tick;
            //_updateGuiTimer.Start();

        }

        void MainWindow_Src1Changed(object sender, Flir.Atlas.Image.ImageChangedEventArgs e)
        {
            IsSrc1Dirty = true;
        }
        /*
        void _updateGuiTimer_Tick(object sender, EventArgs e)
        {
            m_second += timer1.Interval;
            if (IsSrc1Dirty && _cam1 != null)
            {
                // a refresh is needed of source 1
                try
                {
                    // always lock image data to prevent accessing of the image from other threads.
                    _cam1.GetImage().EnterLock();
                    pictureBoxSource1.Image = _cam1.GetImage().Image;                                      

                    // save image to file
                    if (m_startrecording && FileWriter.IsOpen)
                    {
                        videoimg = (Bitmap)_cam1.GetImage().Image;
                        FileWriter.WriteVideoFrame(videoimg, TimeSpan.FromMilliseconds(m_second));
                        FileWriter.Flush();

                        
                        //ThermalImage th = new ThermalImage();
                        //byte[] arr = _cam1.GetImage().GetData();
                        //th.Load(arr);
                        

                        double pixel_temp = 0;
                        var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();
                        string line = UnixTimestamp + ",";

                        double[,] pixel_array = _cam1.GetImage().ImageProcessing.GetPixelsArray(); //array containing the raw signal data
                        for (int y = 0; y < th.Height; y++)
                        {
                            for (int x = 0; x < th.Width; x++)
                            {
                                int pixel_int = (int)pixel_array[y, x]; //casting the signal value to int
                                pixel_temp = th.GetValueFromSignal(pixel_int); //converting signal to temperature
                                line += pixel_temp.ToString("0.00") + ","; //"building" each line
                            }                            
                        }
                        line += "\r\n";
                        System.IO.File.AppendAllText(m_csvfilename, line);
                        

                    }


                }
                catch (Exception)
                {


                }
                finally
                {
                    // We are done with the image data object, release.
                    _cam1.GetImage().ExitLock();
                    IsSrc1Dirty = false;
                }
            }
            
        }
        */
        public void CloseVideoSource()
        {
            if (_cam1 != null)
            {
                _cam1.ConnectionStatusChanged -= _cam1_ConnectionStatusChanged;
                _cam1.Disconnect();
            }
            //close all files and save if not saved.
            FileWriter.Close();
        }

        Camera CreateCamera(CameraDeviceInfo device)
        {
            try
            {
                if (device.SelectedStreamingFormat == ImageFormat.Argb)
                {
                    return new VideoOverlayCamera(true);
                }
                if (device.SelectedStreamingFormat == ImageFormat.FlirFileFormat)
                {
                    return new ThermalCamera(true);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Missing Atlas dependencies:" + e.Message);
                Close(); 
            }
            
            throw new ArgumentOutOfRangeException("Unsupported streaming format");
        }

        private void buttonSource1_Click(object sender, EventArgs e)
        {
            // Connect to a camera
            var device = ShowDiscovery();
            if (device == null) return;
            if (_cam1 != null)
            {
                _cam1.GetImage().Changed -= MainWindow_Src1Changed;
                _cam1.ConnectionStatusChanged -= _cam1_ConnectionStatusChanged;
                _cam1.Disconnect();
            }
            _cam1 = CreateCamera(device);
            // Subscribe to the image changed event. Event driven gui.
            _cam1.GetImage().Changed += MainWindow_Src1Changed;
            _cam1.ConnectionStatusChanged += _cam1_ConnectionStatusChanged;
            _cam1.Connect(device);
        }

        void _cam1_ConnectionStatusChanged(object sender, Flir.Atlas.Live.ConnectionStatusChangedEventArgs e)
        {
            BeginInvoke((Action) (() => labelStatusSrc1.Text = e.Status.ToString()));
        }

        
        static CameraDeviceInfo ShowDiscovery()
        {
            var dlg= new DiscoveryDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.SelectedCameraDevice;
            }
            return null;
        }

        static void SaveSnapshot(Camera camera, string path)
        {
            try
            {
                camera.GetImage().EnterLock();
                if (camera.ConnectionStatus == ConnectionStatus.Connected)
                {
                    camera.GetImage().SaveSnapshot(path);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Failed to save snapshot: " + exception.Message);
            }
            finally
            {
                camera.GetImage().ExitLock();
            }
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            // save snapshot from both sources in selected location.
            // create auto filename based on current date and time.
            DateTime now = DateTime.Now;
            string filenameSrc1 = textBoxImageLocation.Text + "\\" + now.ToString("yyyy-MM-ddTHHmmssfff") + "_src1";
            string filenameSrc2 = textBoxImageLocation.Text + "\\" + now.ToString("yyyy-MM-ddTHHmmssfff") + "_src2";
            if (_cam1 != null)
            {
                SaveSnapshot(_cam1, filenameSrc1);

            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cam1 != null)
            {
                _cam1.ConnectionStatusChanged -= _cam1_ConnectionStatusChanged;
                _cam1.Disconnect();
            }
            th.Dispose();
        }
        
        private void buttonDisconnectSrc1_Click(object sender, EventArgs e)
        {
            if (_cam1 != null)
            {
                _cam1.Disconnect();
            }
        }
        public void StopRecording()
        {
            m_startrecording = false;
            //wait 0.1 s
            FileWriter.Close();
            StartTick = DateTime.Now.Ticks;

            timer2.Enabled = false;

            System.IO.File.AppendAllText(m_csvfilename, m_allcvs);
            m_allcvs = "";
            
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            m_startrecording = false;
        }

        public Image GetPicture()
        {
            //return videoimg;
            return pictureBoxSource1.Image;
        }

        public void StartRecording(string videofilepath)
        {
            h = 60;
            w = 80;

            m_allcvs = "";
            FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Default, 1000000);
            //FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Raw);
            //FileWriter.Open(videofilepath, w, h);

            m_startrecording = true;
            StartTick = DateTime.Now.Ticks;

            m_csvfilename = videofilepath.Replace(".avi", ".csv");

            //m_imagefolder = videofilepath.Replace(".avi", "_img");
            //System.IO.Directory.CreateDirectory(m_imagefolder);
            if (checkBox_csv.Checked)
            {
                if (!System.IO.File.Exists(m_csvfilename))
                {
                    //create file
                    using (var t_file = System.IO.File.Create(m_csvfilename)) ;
                }
                //m_fs= new FileStream(m_csvfilename, FileMode.Open, FileAccess.Write,FileShare.ReadWrite);
            }
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (IsSrc1Dirty && _cam1 != null)
            {
                //Console.Write("count" + ncount++);
                // a refresh is needed of source 1
                try
                {
                    // always lock image data to prevent accessing of the image from other threads.
                    _cam1.GetImage().EnterLock();
                    pictureBoxSource1.Image = _cam1.GetImage().Image;

                    // save image to file
                    if (m_startrecording && FileWriter.IsOpen)
                    {
                        //StartTick;

                        long currentTick = DateTime.Now.Ticks;
                        var frameOffset = new TimeSpan(currentTick - StartTick);

                        //videoimg = (Bitmap)_cam1.GetImage().Image;
                        videoimg = (Bitmap)pictureBoxSource1.Image.Clone();
                        FileWriter.WriteVideoFrame(videoimg, frameOffset);
                        //Console.Write("timespan"+m_second);
                        //FileWriter.WriteVideoFrame(videoimg);
                        FileWriter.Flush();

                        if (checkBox_csv.Checked)
                        {
                            
                            double[,] pixel_array = _cam1.GetImage().ImageProcessing.GetPixelsArray(); //array containing the raw signal data
                            Thread t_thread = new Thread(()=>SaveToCsv(pixel_array));
                            t_thread.Start();
                        }
                        
                    }
                }
                catch (Exception)
                {


                }
                finally
                {
                    // We are done with the image data object, release.
                    _cam1.GetImage().ExitLock();
                    //IsSrc1Dirty = false;
                }
            }
        }

        public async void SaveToCsv(double[,] pixel_array)
        {
            var UnixTimestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds().ToString();

            //_cam1.GetImage().SaveSnapshot(m_imagefolder+"\\"+ UnixTimestamp);
            //ThermalImage th = new ThermalImage();
            //byte[] arr = _cam1.GetImage().GetData();
            //th.Load(arr);


            double pixel_temp = 0;
            string line = UnixTimestamp + ",";

            //double[,] pixel_array = _cam1.GetImage().ImageProcessing.GetPixelsArray(); //array containing the raw signal data
            for (int y = 0; y < th.Height; y++)
            {
                for (int x = 0; x < th.Width; x++)
                {
                    int pixel_int = (int)pixel_array[y, x]; //casting the signal value to int
                    pixel_temp = th.GetValueFromSignal(pixel_int); //converting signal to temperature
                    line += pixel_temp.ToString("0.00") + ","; //"building" each line
                }
            }
            line += "\r\n";
            m_allcvs += line;
            //System.IO.File.AppendAllText(m_csvfilename, line);
            /*
            byte[] encodedText = Encoding.Unicode.GetBytes(line);

            using (FileStream sourceStream = new FileStream(m_csvfilename,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync: true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
            */
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string t_str = m_allcvs;
            m_allcvs = "";
            System.IO.File.AppendAllText(m_csvfilename, t_str);
        }
    }
}
