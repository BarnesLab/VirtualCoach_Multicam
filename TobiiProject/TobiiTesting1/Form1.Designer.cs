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
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
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
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_thermalapi = new System.Windows.Forms.CheckBox();
            this.checkBox_empatica_1 = new System.Windows.Forms.CheckBox();
            this.checkBox_empatica_0 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_participant = new System.Windows.Forms.TextBox();
            this.textBox_score_0 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_score_1 = new System.Windows.Forms.TextBox();
            this.textBox_score_2 = new System.Windows.Forms.TextBox();
            this.bt_enter = new System.Windows.Forms.Button();
            this.textBox_score_3 = new System.Windows.Forms.TextBox();
            this.label1_score_0 = new System.Windows.Forms.Label();
            this.label1_score_1 = new System.Windows.Forms.Label();
            this.label1_score_2 = new System.Windows.Forms.Label();
            this.label1_score_3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_endtask = new System.Windows.Forms.Button();
            this.textBox_pupil = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label_pupil = new System.Windows.Forms.Label();
            this.checkBox_empatica_record = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button2.Location = new System.Drawing.Point(11, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 47);
            this.button2.TabIndex = 4;
            this.button2.Text = "Eye Tracking Calibration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 365);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(252, 24);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 521);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // timer_main
            // 
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(493, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(679, 383);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // rfsh
            // 
            this.rfsh.Location = new System.Drawing.Point(378, 133);
            this.rfsh.Name = "rfsh";
            this.rfsh.Size = new System.Drawing.Size(75, 26);
            this.rfsh.TabIndex = 9;
            this.rfsh.Text = "Refresh";
            this.rfsh.UseVisualStyleBackColor = true;
            this.rfsh.Click += new System.EventHandler(this.rfsh_Click_1);
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.save.Location = new System.Drawing.Point(21, 263);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(455, 54);
            this.save.TabIndex = 10;
            this.save.Text = "Start Session";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // bt_trial
            // 
            this.bt_trial.Enabled = false;
            this.bt_trial.Location = new System.Drawing.Point(378, 361);
            this.bt_trial.Margin = new System.Windows.Forms.Padding(2);
            this.bt_trial.Name = "bt_trial";
            this.bt_trial.Size = new System.Drawing.Size(98, 53);
            this.bt_trial.TabIndex = 11;
            this.bt_trial.Text = "Start A New Trial";
            this.bt_trial.UseVisualStyleBackColor = true;
            this.bt_trial.Click += new System.EventHandler(this.bt_trial_Click);
            // 
            // trialIndex
            // 
            this.trialIndex.Enabled = false;
            this.trialIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialIndex.Location = new System.Drawing.Point(111, 395);
            this.trialIndex.Margin = new System.Windows.Forms.Padding(2);
            this.trialIndex.Name = "trialIndex";
            this.trialIndex.Size = new System.Drawing.Size(252, 23);
            this.trialIndex.TabIndex = 12;
            this.trialIndex.Text = "1";
            this.trialIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 395);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Trial number:";
            // 
            // listView_CameraControl
            // 
            this.listView_CameraControl.CheckBoxes = true;
            this.listView_CameraControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Record,
            this.Camera,
            this.Index});
            this.listView_CameraControl.HideSelection = false;
            this.listView_CameraControl.Location = new System.Drawing.Point(31, 44);
            this.listView_CameraControl.Name = "listView_CameraControl";
            this.listView_CameraControl.Size = new System.Drawing.Size(343, 131);
            this.listView_CameraControl.TabIndex = 15;
            this.listView_CameraControl.UseCompatibleStateImageBehavior = false;
            this.listView_CameraControl.View = System.Windows.Forms.View.Details;
            this.listView_CameraControl.SelectedIndexChanged += new System.EventHandler(this.listView_CameraControl_SelectedIndexChanged);
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
            this.show.Location = new System.Drawing.Point(378, 63);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 64);
            this.show.TabIndex = 0;
            this.show.Text = "Apply";
            this.show.UseVisualStyleBackColor = true;
            this.show.Click += new System.EventHandler(this.show_Click);
            // 
            // comboBox_showcameras
            // 
            this.comboBox_showcameras.FormattingEnabled = true;
            this.comboBox_showcameras.Location = new System.Drawing.Point(562, 468);
            this.comboBox_showcameras.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_showcameras.Name = "comboBox_showcameras";
            this.comboBox_showcameras.Size = new System.Drawing.Size(608, 21);
            this.comboBox_showcameras.TabIndex = 17;
            this.comboBox_showcameras.SelectedIndexChanged += new System.EventHandler(this.comboBox_showcameras_SelectedIndexChanged);
            // 
            // bt_empatica
            // 
            this.bt_empatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.bt_empatica.Location = new System.Drawing.Point(203, 166);
            this.bt_empatica.Name = "bt_empatica";
            this.bt_empatica.Size = new System.Drawing.Size(150, 47);
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
            this.textBox_empatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.textBox_empatica.Location = new System.Drawing.Point(1013, 492);
            this.textBox_empatica.Name = "textBox_empatica";
            this.textBox_empatica.Size = new System.Drawing.Size(39, 17);
            this.textBox_empatica.TabIndex = 19;
            this.textBox_empatica.Text = "AB2B64";
            this.textBox_empatica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_empatica.Visible = false;
            // 
            // checkBox_face
            // 
            this.checkBox_face.AutoSize = true;
            this.checkBox_face.Location = new System.Drawing.Point(1062, 490);
            this.checkBox_face.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_face.Name = "checkBox_face";
            this.checkBox_face.Size = new System.Drawing.Size(110, 17);
            this.checkBox_face.TabIndex = 20;
            this.checkBox_face.Text = "Face Recognition";
            this.checkBox_face.UseVisualStyleBackColor = true;
            this.checkBox_face.Visible = false;
            this.checkBox_face.CheckedChanged += new System.EventHandler(this.checkBox_face_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 471);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Camera";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_empatica_record);
            this.groupBox1.Controls.Add(this.checkBox_thermalapi);
            this.groupBox1.Controls.Add(this.checkBox_empatica_1);
            this.groupBox1.Controls.Add(this.checkBox_empatica_0);
            this.groupBox1.Controls.Add(this.bt_empatica);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(457, 235);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // checkBox_thermalapi
            // 
            this.checkBox_thermalapi.AutoSize = true;
            this.checkBox_thermalapi.Checked = true;
            this.checkBox_thermalapi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_thermalapi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.checkBox_thermalapi.Location = new System.Drawing.Point(357, 30);
            this.checkBox_thermalapi.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_thermalapi.Name = "checkBox_thermalapi";
            this.checkBox_thermalapi.Size = new System.Drawing.Size(83, 14);
            this.checkBox_thermalapi.TabIndex = 23;
            this.checkBox_thermalapi.Text = "Use Thermal API";
            this.checkBox_thermalapi.UseVisualStyleBackColor = true;
            // 
            // checkBox_empatica_1
            // 
            this.checkBox_empatica_1.AutoSize = true;
            this.checkBox_empatica_1.Checked = true;
            this.checkBox_empatica_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_empatica_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkBox_empatica_1.Location = new System.Drawing.Point(357, 207);
            this.checkBox_empatica_1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_empatica_1.Name = "checkBox_empatica_1";
            this.checkBox_empatica_1.Size = new System.Drawing.Size(66, 17);
            this.checkBox_empatica_1.TabIndex = 22;
            this.checkBox_empatica_1.Text = "3A4FCD";
            this.checkBox_empatica_1.UseVisualStyleBackColor = true;
            // 
            // checkBox_empatica_0
            // 
            this.checkBox_empatica_0.AutoSize = true;
            this.checkBox_empatica_0.Checked = true;
            this.checkBox_empatica_0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_empatica_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkBox_empatica_0.Location = new System.Drawing.Point(357, 188);
            this.checkBox_empatica_0.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_empatica_0.Name = "checkBox_empatica_0";
            this.checkBox_empatica_0.Size = new System.Drawing.Size(65, 17);
            this.checkBox_empatica_0.TabIndex = 21;
            this.checkBox_empatica_0.Text = "AB2B64";
            this.checkBox_empatica_0.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label9.Location = new System.Drawing.Point(559, 525);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "acc,bvp,ibi,tmp,gsr";
            this.label9.Visible = false;
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_time.Location = new System.Drawing.Point(107, 560);
            this.label_time.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(44, 17);
            this.label_time.TabIndex = 23;
            this.label_time.Text = "00:00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 339);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Participant:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 435);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Score:";
            // 
            // textBox_participant
            // 
            this.textBox_participant.Enabled = false;
            this.textBox_participant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_participant.Location = new System.Drawing.Point(111, 339);
            this.textBox_participant.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_participant.Name = "textBox_participant";
            this.textBox_participant.Size = new System.Drawing.Size(252, 23);
            this.textBox_participant.TabIndex = 26;
            this.textBox_participant.Text = "Name";
            this.textBox_participant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_score_0
            // 
            this.textBox_score_0.Enabled = false;
            this.textBox_score_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_score_0.Location = new System.Drawing.Point(111, 435);
            this.textBox_score_0.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_score_0.Name = "textBox_score_0";
            this.textBox_score_0.Size = new System.Drawing.Size(56, 23);
            this.textBox_score_0.TabIndex = 27;
            this.textBox_score_0.Text = "0";
            this.textBox_score_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(24, 560);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "Timer:";
            // 
            // textBox_comment
            // 
            this.textBox_comment.Enabled = false;
            this.textBox_comment.Location = new System.Drawing.Point(101, 586);
            this.textBox_comment.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_comment.Size = new System.Drawing.Size(272, 62);
            this.textBox_comment.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(24, 586);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 31;
            this.label6.Text = "Comment:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 367);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Task:";
            // 
            // textBox_score_1
            // 
            this.textBox_score_1.Enabled = false;
            this.textBox_score_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_score_1.Location = new System.Drawing.Point(111, 463);
            this.textBox_score_1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_score_1.Name = "textBox_score_1";
            this.textBox_score_1.Size = new System.Drawing.Size(56, 23);
            this.textBox_score_1.TabIndex = 33;
            this.textBox_score_1.Text = "0";
            this.textBox_score_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_score_2
            // 
            this.textBox_score_2.Enabled = false;
            this.textBox_score_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_score_2.Location = new System.Drawing.Point(111, 492);
            this.textBox_score_2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_score_2.Name = "textBox_score_2";
            this.textBox_score_2.Size = new System.Drawing.Size(56, 23);
            this.textBox_score_2.TabIndex = 34;
            this.textBox_score_2.Text = "0";
            this.textBox_score_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_enter
            // 
            this.bt_enter.Enabled = false;
            this.bt_enter.Location = new System.Drawing.Point(378, 586);
            this.bt_enter.Margin = new System.Windows.Forms.Padding(2);
            this.bt_enter.Name = "bt_enter";
            this.bt_enter.Size = new System.Drawing.Size(109, 61);
            this.bt_enter.TabIndex = 35;
            this.bt_enter.Text = "Enter Score";
            this.bt_enter.UseVisualStyleBackColor = true;
            this.bt_enter.Click += new System.EventHandler(this.bt_enter_Click);
            // 
            // textBox_score_3
            // 
            this.textBox_score_3.Enabled = false;
            this.textBox_score_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox_score_3.Location = new System.Drawing.Point(111, 520);
            this.textBox_score_3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_score_3.Name = "textBox_score_3";
            this.textBox_score_3.Size = new System.Drawing.Size(56, 23);
            this.textBox_score_3.TabIndex = 30;
            this.textBox_score_3.Text = "0";
            this.textBox_score_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1_score_0
            // 
            this.label1_score_0.AutoSize = true;
            this.label1_score_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_0.Location = new System.Drawing.Point(184, 435);
            this.label1_score_0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_score_0.Name = "label1_score_0";
            this.label1_score_0.Size = new System.Drawing.Size(101, 17);
            this.label1_score_0.TabIndex = 37;
            this.label1_score_0.Text = "Performance 1";
            // 
            // label1_score_1
            // 
            this.label1_score_1.AutoSize = true;
            this.label1_score_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_1.Location = new System.Drawing.Point(184, 463);
            this.label1_score_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_score_1.Name = "label1_score_1";
            this.label1_score_1.Size = new System.Drawing.Size(101, 17);
            this.label1_score_1.TabIndex = 38;
            this.label1_score_1.Text = "Performance 2";
            // 
            // label1_score_2
            // 
            this.label1_score_2.AutoSize = true;
            this.label1_score_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_2.Location = new System.Drawing.Point(184, 492);
            this.label1_score_2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_score_2.Name = "label1_score_2";
            this.label1_score_2.Size = new System.Drawing.Size(101, 17);
            this.label1_score_2.TabIndex = 39;
            this.label1_score_2.Text = "Performance 3";
            // 
            // label1_score_3
            // 
            this.label1_score_3.AutoSize = true;
            this.label1_score_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_3.Location = new System.Drawing.Point(184, 520);
            this.label1_score_3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_score_3.Name = "label1_score_3";
            this.label1_score_3.Size = new System.Drawing.Size(101, 17);
            this.label1_score_3.TabIndex = 40;
            this.label1_score_3.Text = "Performance 4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(933, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_endtask
            // 
            this.button_endtask.Enabled = false;
            this.button_endtask.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.button_endtask.Location = new System.Drawing.Point(944, 552);
            this.button_endtask.Margin = new System.Windows.Forms.Padding(2);
            this.button_endtask.Name = "button_endtask";
            this.button_endtask.Size = new System.Drawing.Size(228, 96);
            this.button_endtask.TabIndex = 42;
            this.button_endtask.Text = "End Session";
            this.button_endtask.UseVisualStyleBackColor = true;
            this.button_endtask.Click += new System.EventHandler(this.button_endtask_Click);
            // 
            // textBox_pupil
            // 
            this.textBox_pupil.Location = new System.Drawing.Point(746, 497);
            this.textBox_pupil.Name = "textBox_pupil";
            this.textBox_pupil.Size = new System.Drawing.Size(100, 20);
            this.textBox_pupil.TabIndex = 43;
            this.textBox_pupil.Text = "60";
            this.textBox_pupil.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(556, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(184, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "Set Eyetracker Frequency (1~120 hz)";
            this.label10.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(852, 494);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 45;
            this.button3.Text = "Change";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_pupil
            // 
            this.label_pupil.AutoSize = true;
            this.label_pupil.Location = new System.Drawing.Point(559, 552);
            this.label_pupil.Name = "label_pupil";
            this.label_pupil.Size = new System.Drawing.Size(0, 13);
            this.label_pupil.TabIndex = 46;
            // 
            // checkBox_empatica_record
            // 
            this.checkBox_empatica_record.AutoSize = true;
            this.checkBox_empatica_record.Checked = true;
            this.checkBox_empatica_record.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_empatica_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkBox_empatica_record.Location = new System.Drawing.Point(357, 166);
            this.checkBox_empatica_record.Name = "checkBox_empatica_record";
            this.checkBox_empatica_record.Size = new System.Drawing.Size(72, 17);
            this.checkBox_empatica_record.TabIndex = 24;
            this.checkBox_empatica_record.Text = "RecordAll";
            this.checkBox_empatica_record.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 658);
            this.Controls.Add(this.label_pupil);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_pupil);
            this.Controls.Add(this.button_endtask);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_empatica);
            this.Controls.Add(this.label1_score_3);
            this.Controls.Add(this.label1_score_2);
            this.Controls.Add(this.label1_score_1);
            this.Controls.Add(this.label1_score_0);
            this.Controls.Add(this.textBox_score_3);
            this.Controls.Add(this.bt_enter);
            this.Controls.Add(this.textBox_score_2);
            this.Controls.Add(this.textBox_score_1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_comment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_score_0);
            this.Controls.Add(this.textBox_participant);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_face);
            this.Controls.Add(this.comboBox_showcameras);
            this.Controls.Add(this.show);
            this.Controls.Add(this.listView_CameraControl);
            this.Controls.Add(this.trialIndex);
            this.Controls.Add(this.bt_trial);
            this.Controls.Add(this.save);
            this.Controls.Add(this.rfsh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Virtual Coach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_main;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_participant;
        private System.Windows.Forms.TextBox textBox_score_0;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_comment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_score_1;
        private System.Windows.Forms.TextBox textBox_score_2;
        private System.Windows.Forms.Button bt_enter;
        private System.Windows.Forms.TextBox textBox_score_3;
        private System.Windows.Forms.Label label1_score_0;
        private System.Windows.Forms.Label label1_score_1;
        private System.Windows.Forms.Label label1_score_2;
        private System.Windows.Forms.Label label1_score_3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_empatica_1;
        private System.Windows.Forms.CheckBox checkBox_empatica_0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_thermalapi;
        private System.Windows.Forms.Button button_endtask;
        private System.Windows.Forms.TextBox textBox_pupil;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_pupil;
        private System.Windows.Forms.CheckBox checkBox_empatica_record;
    }
}

