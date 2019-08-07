using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TobiiTesting1
{
    public partial class Form_Empatica : Form
    {
        public bool m_empaticarRecording= false;
        public string m_empaticadevicename = "";

        public Form_Empatica()
        {
            InitializeComponent();
        }


        private void Form_Empatica_Load(object sender, EventArgs e)
        {
            AsynchronousClient.StartClient();
        }

        private void timer_empatica_Tick(object sender, EventArgs e)
        {
            if (m_empaticarRecording)
            {
                AsynchronousClient.SavingEverySecond();
            }
        }

        public void StartRecording(string filepath)
        {
            m_empaticarRecording = true;
            AsynchronousClient.SavingRecord(filepath);
        }

        public void StopRecording()
        {
            m_empaticarRecording = false;
            AsynchronousClient.StopClient();
        }
    }
}
