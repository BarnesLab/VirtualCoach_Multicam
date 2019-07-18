namespace TobiiTesting1
{
    partial class Form_Empatica
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_Log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_device = new System.Windows.Forms.TextBox();
            this.timer_empatica = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // textBox_Log
            // 
            this.textBox_Log.Location = new System.Drawing.Point(22, 50);
            this.textBox_Log.Multiline = true;
            this.textBox_Log.Name = "textBox_Log";
            this.textBox_Log.Size = new System.Drawing.Size(578, 562);
            this.textBox_Log.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empatica";
            // 
            // textBox_device
            // 
            this.textBox_device.Location = new System.Drawing.Point(90, 16);
            this.textBox_device.Name = "textBox_device";
            this.textBox_device.ReadOnly = true;
            this.textBox_device.Size = new System.Drawing.Size(121, 20);
            this.textBox_device.TabIndex = 2;
            this.textBox_device.Text = "AB2B64";
            this.textBox_device.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer_empatica
            // 
            this.timer_empatica.Interval = 10000;
            this.timer_empatica.Tick += new System.EventHandler(this.timer_empatica_Tick);
            // 
            // Form_Empatica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 642);
            this.Controls.Add(this.textBox_device);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Log);
            this.Name = "Form_Empatica";
            this.Text = "Form_Empatica";
            this.Load += new System.EventHandler(this.Form_Empatica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_device;
        private System.Windows.Forms.Timer timer_empatica;
    }
}