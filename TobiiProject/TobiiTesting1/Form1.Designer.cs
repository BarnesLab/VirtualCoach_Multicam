namespace TobiiTesting1
{
    partial class Form1
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
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rfsh = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.bt_trial = new System.Windows.Forms.Button();
            this.trialIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_CameraControl = new System.Windows.Forms.ListView();
            this.Record = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Camera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.show = new System.Windows.Forms.Button();
            this.comboBox_showcameras = new System.Windows.Forms.ComboBox();
            this.bt_empatica = new System.Windows.Forms.Button();
            this.timer_empatica = new System.Windows.Forms.Timer(this.components);
            this.textBox_empatica = new System.Windows.Forms.TextBox();
            this.checkBox_face = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(303, 29);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(192, 37);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Hello World!";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(100, 389);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(234, 72);
            this.button2.TabIndex = 4;
            this.button2.Text = "Tobii Eye Tracking Calibration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(100, 135);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(482, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(776, 752);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Camera";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(748, 82);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(714, 653);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // rfsh
            // 
            this.rfsh.Location = new System.Drawing.Point(600, 132);
            this.rfsh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rfsh.Name = "rfsh";
            this.rfsh.Size = new System.Drawing.Size(112, 35);
            this.rfsh.TabIndex = 9;
            this.rfsh.Text = "Refresh";
            this.rfsh.UseVisualStyleBackColor = true;
            this.rfsh.Visible = false;
            this.rfsh.Click += new System.EventHandler(this.rfsh_Click_1);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(100, 594);
            this.save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(230, 77);
            this.save.TabIndex = 10;
            this.save.Text = "Record";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // bt_trial
            // 
            this.bt_trial.Location = new System.Drawing.Point(100, 718);
            this.bt_trial.Name = "bt_trial";
            this.bt_trial.Size = new System.Drawing.Size(230, 69);
            this.bt_trial.TabIndex = 11;
            this.bt_trial.Text = "Start A New Trial";
            this.bt_trial.UseVisualStyleBackColor = true;
            this.bt_trial.Click += new System.EventHandler(this.bt_trial_Click);
            // 
            // trialIndex
            // 
            this.trialIndex.Location = new System.Drawing.Point(459, 738);
            this.trialIndex.Name = "trialIndex";
            this.trialIndex.Size = new System.Drawing.Size(66, 26);
            this.trialIndex.TabIndex = 12;
            this.trialIndex.Text = "1";
            this.trialIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 743);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Trial Index:";
            // 
            // listView_CameraControl
            // 
            this.listView_CameraControl.CheckBoxes = true;
            this.listView_CameraControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Record,
            this.Camera,
            this.Index});
            this.listView_CameraControl.Location = new System.Drawing.Point(104, 209);
            this.listView_CameraControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_CameraControl.Name = "listView_CameraControl";
            this.listView_CameraControl.Size = new System.Drawing.Size(480, 147);
            this.listView_CameraControl.TabIndex = 15;
            this.listView_CameraControl.UseCompatibleStateImageBehavior = false;
            this.listView_CameraControl.View = System.Windows.Forms.View.Details;
            // 
            // Record
            // 
            this.Record.Text = "Record";
            this.Record.Width = 89;
            // 
            // Camera
            // 
            this.Camera.Text = "Camera";
            this.Camera.Width = 165;
            // 
            // Index
            // 
            this.Index.Text = "Index";
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(600, 209);
            this.show.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(112, 149);
            this.show.TabIndex = 16;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // comboBox_showcameras
            // 
            this.comboBox_showcameras.FormattingEnabled = true;
            this.comboBox_showcameras.Location = new System.Drawing.Point(848, 744);
            this.comboBox_showcameras.Name = "comboBox_showcameras";
            this.comboBox_showcameras.Size = new System.Drawing.Size(358, 28);
            this.comboBox_showcameras.TabIndex = 17;
            this.comboBox_showcameras.SelectedIndexChanged += new System.EventHandler(this.comboBox_showcameras_SelectedIndexChanged);
            // 
            // bt_empatica
            // 
            this.bt_empatica.Location = new System.Drawing.Point(100, 491);
            this.bt_empatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_empatica.Name = "bt_empatica";
            this.bt_empatica.Size = new System.Drawing.Size(230, 72);
            this.bt_empatica.TabIndex = 18;
            this.bt_empatica.Text = "Start Empatica";
            this.bt_empatica.UseVisualStyleBackColor = true;
            this.bt_empatica.Click += new System.EventHandler(this.bt_empatica_Click);
            // 
            // timer_empatica
            // 
            this.timer_empatica.Interval = 5000;
            this.timer_empatica.Tick += new System.EventHandler(this.timer_empatica_Tick);
            // 
            // textBox_empatica
            // 
            this.textBox_empatica.Location = new System.Drawing.Point(390, 512);
            this.textBox_empatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_empatica.Name = "textBox_empatica";
            this.textBox_empatica.Size = new System.Drawing.Size(148, 26);
            this.textBox_empatica.TabIndex = 19;
            this.textBox_empatica.Text = "AB2B64";
            this.textBox_empatica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox_face
            // 
            this.checkBox_face.AutoSize = true;
            this.checkBox_face.Location = new System.Drawing.Point(1280, 746);
            this.checkBox_face.Name = "checkBox_face";
            this.checkBox_face.Size = new System.Drawing.Size(160, 24);
            this.checkBox_face.TabIndex = 20;
            this.checkBox_face.Text = "Face Recognition";
            this.checkBox_face.UseVisualStyleBackColor = true;
            this.checkBox_face.CheckedChanged += new System.EventHandler(this.checkBox_face_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 887);
            this.Controls.Add(this.checkBox_face);
            this.Controls.Add(this.textBox_empatica);
            this.Controls.Add(this.bt_empatica);
            this.Controls.Add(this.comboBox_showcameras);
            this.Controls.Add(this.show);
            this.Controls.Add(this.listView_CameraControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trialIndex);
            this.Controls.Add(this.bt_trial);
            this.Controls.Add(this.save);
            this.Controls.Add(this.rfsh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.helloWorldLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button rfsh;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button bt_trial;
        private System.Windows.Forms.TextBox trialIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_CameraControl;
        private System.Windows.Forms.ColumnHeader Record;
        private System.Windows.Forms.ColumnHeader Camera;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.ComboBox comboBox_showcameras;
        private System.Windows.Forms.Button bt_empatica;
        private System.Windows.Forms.Timer timer_empatica;
        private System.Windows.Forms.TextBox textBox_empatica;
        private System.Windows.Forms.CheckBox checkBox_face;
    }
}

