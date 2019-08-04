using System;
using System.Drawing;
using System.Windows.Forms;
using Flir.Atlas.Image;


namespace Save2CSV
{
    public partial class Form1 : Form
    {
        string filename = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Image files (*.jpg)|*.jpg";
            fd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            fd.RestoreDirectory = true;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filename = fd.FileName;
                ThermalImageFile th = new ThermalImageFile(filename);
                var img = th.Image;
                pictureBox1.Image = (Image)img.Clone();
                th.Dispose();
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            SaveFileDialog fde = new SaveFileDialog();
            fde.Filter = "CSV file(*.csv)|*.csv";
            fde.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            fde.RestoreDirectory = true;
            if (fde.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(fde.FileName);
                ThermalImageFile th = new ThermalImageFile(filename);
                double[,] pixel_array = th.ImageProcessing.GetPixelsArray(); //array containing the raw signal data
                for (int y = 0; y < th.Height;y++)
                {
                    string line = string.Empty;
                    for (int x = 0; x < th.Width;x++)
                    {
                        int pixel_int = (int)pixel_array[y, x]; //casting the signal value to int
                        double pixel_temp = th.GetValueFromSignal(pixel_int); //converting signal to temperature
                        line += pixel_temp.ToString("0.00") + ";"; //"building" each line
                    }
                    file.WriteLine(line); //writing a line to the excel sheet
                }
                file.Flush();
                file.Close();
                th.Dispose();
            }
        }
    }
}
