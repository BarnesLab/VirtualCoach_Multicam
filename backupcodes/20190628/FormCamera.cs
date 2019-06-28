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
    public partial class FormCamera : Form
    {
        public FormCamera()
        {
            InitializeComponent();
        }
        
        private void resizePicture()
        {
            this.pictureBox1.Width = this.Width;
            this.pictureBox1.Height = this.Height;
        }

        private void FormCamera_Load(object sender, EventArgs e)
        {
        }

        private void FormCamera_Resize(object sender, EventArgs e)
        {
            resizePicture();
        }

        
    }
}
