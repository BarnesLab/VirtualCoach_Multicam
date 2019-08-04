using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Flir.Atlas.Image;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;

namespace TobiiTesting1
{
    public partial class MainWindow : Form
    {
        private Camera _cam1;
        private Timer _updateGuiTimer;
        private bool IsSrc1Dirty { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Text = "Dual Camera Sample, running Atlas version: " + ImageBase.Version;

            // set default directory where to save the snapshots.
            textBoxImageLocation.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            // Create timer to update our UI.
            _updateGuiTimer = new Timer {Interval = 40};
            _updateGuiTimer.Tick += _updateGuiTimer_Tick;
            _updateGuiTimer.Start();
            
        }

        void MainWindow_Src1Changed(object sender, Flir.Atlas.Image.ImageChangedEventArgs e)
        {
            IsSrc1Dirty = true;
        }


        void _updateGuiTimer_Tick(object sender, EventArgs e)
        {
            if (IsSrc1Dirty && _cam1 != null)
            {
                // a refresh is needed of source 1
                try
                {
                    // always lock image data to prevent accessing of the image from other threads.
                    _cam1.GetImage().EnterLock();
                    pictureBoxSource1.Image = _cam1.GetImage().Image;
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
        }
        
        private void buttonDisconnectSrc1_Click(object sender, EventArgs e)
        {
            if (_cam1 != null)
            {
                _cam1.Disconnect();
            }
        }
    }
}
