namespace TobiiTesting1
{
    partial class MainWindow
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
            this.buttonSource1 = new System.Windows.Forms.Button();
            this.pictureBoxSource1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxImageLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveImage = new System.Windows.Forms.Button();
            this.buttonDisconnectSrc1 = new System.Windows.Forms.Button();
            this.labelStatusSrc1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_csv = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSource1
            // 
            this.buttonSource1.Location = new System.Drawing.Point(12, 36);
            this.buttonSource1.Name = "buttonSource1";
            this.buttonSource1.Size = new System.Drawing.Size(75, 23);
            this.buttonSource1.TabIndex = 0;
            this.buttonSource1.Text = "Source...";
            this.buttonSource1.UseVisualStyleBackColor = true;
            this.buttonSource1.Click += new System.EventHandler(this.buttonSource1_Click);
            // 
            // pictureBoxSource1
            // 
            this.pictureBoxSource1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSource1.Location = new System.Drawing.Point(12, 65);
            this.pictureBoxSource1.Name = "pictureBoxSource1";
            this.pictureBoxSource1.Size = new System.Drawing.Size(404, 314);
            this.pictureBoxSource1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSource1.TabIndex = 1;
            this.pictureBoxSource1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxImageLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBoxImageLocation
            // 
            this.textBoxImageLocation.Location = new System.Drawing.Point(105, 17);
            this.textBoxImageLocation.Name = "textBoxImageLocation";
            this.textBoxImageLocation.Size = new System.Drawing.Size(298, 20);
            this.textBoxImageLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image location:";
            // 
            // buttonSaveImage
            // 
            this.buttonSaveImage.Location = new System.Drawing.Point(341, 36);
            this.buttonSaveImage.Name = "buttonSaveImage";
            this.buttonSaveImage.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveImage.TabIndex = 3;
            this.buttonSaveImage.Text = "Save";
            this.buttonSaveImage.UseVisualStyleBackColor = true;
            this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
            // 
            // buttonDisconnectSrc1
            // 
            this.buttonDisconnectSrc1.Location = new System.Drawing.Point(341, 385);
            this.buttonDisconnectSrc1.Name = "buttonDisconnectSrc1";
            this.buttonDisconnectSrc1.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnectSrc1.TabIndex = 4;
            this.buttonDisconnectSrc1.Text = "Disconnect";
            this.buttonDisconnectSrc1.UseVisualStyleBackColor = true;
            this.buttonDisconnectSrc1.Click += new System.EventHandler(this.buttonDisconnectSrc1_Click);
            // 
            // labelStatusSrc1
            // 
            this.labelStatusSrc1.AutoSize = true;
            this.labelStatusSrc1.Location = new System.Drawing.Point(12, 385);
            this.labelStatusSrc1.Name = "labelStatusSrc1";
            this.labelStatusSrc1.Size = new System.Drawing.Size(73, 13);
            this.labelStatusSrc1.TabIndex = 5;
            this.labelStatusSrc1.Text = "Disconnected";
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox_csv
            // 
            this.checkBox_csv.AutoSize = true;
            this.checkBox_csv.Checked = true;
            this.checkBox_csv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_csv.Location = new System.Drawing.Point(178, 36);
            this.checkBox_csv.Name = "checkBox_csv";
            this.checkBox_csv.Size = new System.Drawing.Size(85, 17);
            this.checkBox_csv.TabIndex = 6;
            this.checkBox_csv.Text = "SaveToCSV";
            this.checkBox_csv.UseVisualStyleBackColor = true;
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 490);
            this.Controls.Add(this.checkBox_csv);
            this.Controls.Add(this.labelStatusSrc1);
            this.Controls.Add(this.buttonDisconnectSrc1);
            this.Controls.Add(this.buttonSaveImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBoxSource1);
            this.Controls.Add(this.buttonSource1);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSource1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSource1;
        private System.Windows.Forms.PictureBox pictureBoxSource1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxImageLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Button buttonDisconnectSrc1;
        private System.Windows.Forms.Label labelStatusSrc1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox_csv;
        private System.Windows.Forms.Timer timer2;
    }
}

