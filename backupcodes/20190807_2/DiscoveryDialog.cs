using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;

namespace TobiiTesting1
{
    public partial class DiscoveryDialog : Form
    {
        private readonly Discovery _discovery;

        public DiscoveryDialog()
        {
            InitializeComponent();

            _discovery = new Discovery();
            _discovery.DeviceFound += _discovery_DeviceFound;
            _discovery.DeviceLost += _discovery_DeviceLost;
            _discovery.DeviceError += _discovery_DeviceError;
            _discovery.Start();
        }
        void _discovery_DeviceError(object sender, DeviceErrorEventArgs e)
        {
            BeginInvoke((Action)(() => ShowError(e.ErrorMessage)));
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message);
        }

        void _discovery_DeviceLost(object sender, CameraDeviceInfoEventArgs e)
        {
            BeginInvoke((Action)(() => RemoveDevice(e.CameraDevice)));
        }

        void _discovery_DeviceFound(object sender, CameraDeviceInfoEventArgs e)
        {
            BeginInvoke((Action)(() => AddDevice(e.CameraDevice)));
        }

        private void RemoveDevice(CameraDeviceInfo cameraDeviceInfo)
        {
            foreach (ListViewItem item in listViewDevices.Items)
            {
                var device = item.Tag as CameraDeviceInfo;
                if (device != null && device.DeviceIdentifier == cameraDeviceInfo.DeviceIdentifier)
                {
                    listViewDevices.Items.Remove(item);
                }
            }
        }

        private void AddDevice(CameraDeviceInfo cameraDeviceInfo)
        {
            foreach (var streamingFormat in cameraDeviceInfo.StreamingFormats)
            {
                var info = new CameraDeviceInfo(cameraDeviceInfo);
                var item = new ListViewItem(string.Format("{0}", cameraDeviceInfo.Name));
                if (cameraDeviceInfo.IpSettings != null)
                {
                    item.SubItems.Add(cameraDeviceInfo.IpSettings.IpAddress);
                    item.SubItems.Add(cameraDeviceInfo.IpSettings.IsWireless ? "Yes" : "No");
                }
                else
                {
                    item.SubItems.Add("N/A"); // IP
                    item.SubItems.Add("N/A"); // WiFi
                }
                info.SelectedStreamingFormat = streamingFormat;
                item.SubItems.Add(streamingFormat.ToString());
                item.Tag = info;
                listViewDevices.Items.Add(item);
            }
        }

        private void listViewDevices_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _discovery.Stop();

            ListView.SelectedListViewItemCollection items = listViewDevices.SelectedItems;
            if (items.Count > 0)
            {
                ListViewItem lv = items[0];
                var device = lv.Tag as CameraDeviceInfo;
                SelectedCameraDevice = device;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        public CameraDeviceInfo SelectedCameraDevice { get; set; }

        private void DiscoveryDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _discovery.DeviceFound -= _discovery_DeviceFound;
            _discovery.DeviceLost -= _discovery_DeviceLost;
            _discovery.DeviceError -= _discovery_DeviceError;
            ThreadPool.QueueUserWorkItem(DisposeDiscovery, _discovery);
        }

        static void DisposeDiscovery(Object context)
        {
            var discovery = (Discovery)context;
            discovery.Dispose();
        }

        private void listViewDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
