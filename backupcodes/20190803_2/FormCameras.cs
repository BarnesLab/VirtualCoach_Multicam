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

using Flir.Atlas.Image;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;


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
        private bool m_is_thermal=false;//

        //setup thermal camera
        private Camera m_thermalcam;
        private Timer _updateGuiTimer;
        private bool IsSrc1Dirty { get; set; }
        private string m_str;

        private void MainWindow_Src1Changed(object sender, Flir.Atlas.Image.ImageChangedEventArgs e)
        {
            IsSrc1Dirty = true;
        }
        private void _cam1_ConnectionStatusChanged(object sender, Flir.Atlas.Live.ConnectionStatusChangedEventArgs e)
        {
            BeginInvoke((Action)(() => m_str = e.Status.ToString()));
            Console.Write(m_str);
        }
        private void _updateGuiTimer_Tick(object sender, EventArgs e)
        {
            
            if (IsSrc1Dirty && m_thermalcam != null)
            {
                // a refresh is needed of source 1
                try
                {
                    // always lock image data to prevent accessing of the image from other threads.
                    m_thermalcam.GetImage().EnterLock();
                    pictureBox1.Image = m_thermalcam.GetImage().Image;
                }
                catch (Exception)
                {
                    
                }
                finally
                {
                    // We are done with the image data object, release.
                    m_thermalcam.GetImage().ExitLock();
                    IsSrc1Dirty = false;
                }
            }
            
        }

        private Camera CreateCamera(CameraDeviceInfo device)
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

        public void StartRecording(string videofilepath)
        {
            h = videoimg.Height;
            w = videoimg.Width;

            FileWriter.Open(videofilepath, w, h, 25, VideoCodec.Default, 5000000);
            FileWriter.WriteVideoFrame(videoimg);

            m_startrecording = true;
        }

        public void SetThermal(bool is_thermal)
        {
            m_is_thermal = is_thermal;
            if (m_is_thermal)
            {                
                var device = ShowDiscovery();
                if (device == null) return;
                if (m_thermalcam != null)
                {
                    m_thermalcam.GetImage().Changed -= MainWindow_Src1Changed;
                    m_thermalcam.ConnectionStatusChanged -= _cam1_ConnectionStatusChanged;
                    m_thermalcam.Disconnect();
                }
                m_thermalcam = CreateCamera(device);
                // Subscribe to the image changed event. Event driven gui.
                m_thermalcam.GetImage().Changed += MainWindow_Src1Changed;
                m_thermalcam.ConnectionStatusChanged += _cam1_ConnectionStatusChanged;
                m_thermalcam.Connect(device);

            }
        }
        static CameraDeviceInfo ShowDiscovery()
        {
            var dlg = new DiscoveryDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.SelectedCameraDevice;
            }
            return null;
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
        public Image GetPicture()
        { 
            //return videoimg;
            return pictureBox1.Image;
        }
        private void FormCameras_Load(object sender, EventArgs e)
        {
            CloseVideoSource();
            if (m_is_thermal)
            {
                _updateGuiTimer = new Timer { Interval = 40 };
                _updateGuiTimer.Tick += _updateGuiTimer_Tick;
                _updateGuiTimer.Start();
            }
            else
            {
                videoSource = new VideoCaptureDevice(m_deviceMoniker);

                videoSource.VideoResolution = selectResolution(videoSource);//new line

                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

                //videoSource.DesiredFrameSize = new Size(1920, 120);//new Size(160, 120);
                //videoSource.DesiredFrameRate = 10;
                videoSource.Start();
            }
            

            m_startrecording = false;
        }

        private static VideoCapabilities selectResolution(VideoCaptureDevice device)
        {
            if (device.SourceObject is null)
            {
                return device.VideoResolution;
            }
            foreach (var cap in device.VideoCapabilities)
            {
                if (cap.FrameSize.Height == 1080)
                    return cap;
                if (cap.FrameSize.Width == 1920)
                    return cap;
            }
            return device.VideoCapabilities.Last();
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
                if (m_startrecording && FileWriter.IsOpen)
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
            if(m_thermalcam != null)
            {
                m_thermalcam.ConnectionStatusChanged -= _cam1_ConnectionStatusChanged;
                m_thermalcam.Disconnect();
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
