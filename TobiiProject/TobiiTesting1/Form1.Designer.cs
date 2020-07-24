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
            this.btn_calibration = new System.Windows.Forms.Button();
            this.cmb_task = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.btn_startSession = new System.Windows.Forms.Button();
            this.btn_startStopTrial = new System.Windows.Forms.Button();
            this.lbl_session = new System.Windows.Forms.Label();
            this.listView_CameraControl = new System.Windows.Forms.ListView();
            this.Record = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Camera = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_show = new System.Windows.Forms.Button();
            this.cmb_showcameras = new System.Windows.Forms.ComboBox();
            this.btn_empatica = new System.Windows.Forms.Button();
            this.timer_empatica = new System.Windows.Forms.Timer(this.components);
            this.textBox_empatica = new System.Windows.Forms.TextBox();
            this.checkBox_face = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_empatica_record = new System.Windows.Forms.CheckBox();
            this.checkBox_thermalapi = new System.Windows.Forms.CheckBox();
            this.checkBox_empatica_1 = new System.Windows.Forms.CheckBox();
            this.checkBox_empatica_0 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_participant = new System.Windows.Forms.TextBox();
            this.txt_score1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_task = new System.Windows.Forms.Label();
            this.txt_score2 = new System.Windows.Forms.TextBox();
            this.txt_score3 = new System.Windows.Forms.TextBox();
            this.btn_enterScore = new System.Windows.Forms.Button();
            this.txt_score4 = new System.Windows.Forms.TextBox();
            this.label1_score_0 = new System.Windows.Forms.Label();
            this.label1_score_1 = new System.Windows.Forms.Label();
            this.label1_score_2 = new System.Windows.Forms.Label();
            this.label1_score_3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_endSession = new System.Windows.Forms.Button();
            this.txt_tobiiHz = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label_pupil = new System.Windows.Forms.Label();
            this.btn_baseline = new System.Windows.Forms.Button();
            this.num_sessionIndex = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_sessionIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_calibration
            // 
            this.btn_calibration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_calibration.Location = new System.Drawing.Point(16, 255);
            this.btn_calibration.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_calibration.Name = "btn_calibration";
            this.btn_calibration.Size = new System.Drawing.Size(256, 72);
            this.btn_calibration.TabIndex = 4;
            this.btn_calibration.Text = "Eye Tracking Calibration";
            this.btn_calibration.UseVisualStyleBackColor = true;
            this.btn_calibration.Click += new System.EventHandler(this.calibration_Click);
            // 
            // cmb_task
            // 
            this.cmb_task.Enabled = false;
            this.cmb_task.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmb_task.FormattingEnabled = true;
            this.cmb_task.Location = new System.Drawing.Point(150, 617);
            this.cmb_task.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_task.Name = "cmb_task";
            this.cmb_task.Size = new System.Drawing.Size(392, 33);
            this.cmb_task.TabIndex = 5;
            this.cmb_task.SelectedIndexChanged += new System.EventHandler(this.task_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(762, 802);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 7;
            // 
            // timer_main
            // 
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(740, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1018, 589);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(567, 205);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(112, 40);
            this.btn_refresh.TabIndex = 9;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // btn_startSession
            // 
            this.btn_startSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_startSession.Location = new System.Drawing.Point(32, 475);
            this.btn_startSession.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_startSession.Name = "btn_startSession";
            this.btn_startSession.Size = new System.Drawing.Size(438, 83);
            this.btn_startSession.TabIndex = 10;
            this.btn_startSession.Text = "Start Session";
            this.btn_startSession.UseVisualStyleBackColor = true;
            this.btn_startSession.Click += new System.EventHandler(this.startSession_Click);
            // 
            // btn_startStopTrial
            // 
            this.btn_startStopTrial.Enabled = false;
            this.btn_startStopTrial.Location = new System.Drawing.Point(567, 608);
            this.btn_startStopTrial.Name = "btn_startStopTrial";
            this.btn_startStopTrial.Size = new System.Drawing.Size(147, 52);
            this.btn_startStopTrial.TabIndex = 11;
            this.btn_startStopTrial.Text = "Start A New Trial";
            this.btn_startStopTrial.UseVisualStyleBackColor = true;
            this.btn_startStopTrial.Click += new System.EventHandler(this.startStopTrial_Click);
            // 
            // lbl_session
            // 
            this.lbl_session.AutoSize = true;
            this.lbl_session.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_session.Location = new System.Drawing.Point(500, 432);
            this.lbl_session.Name = "lbl_session";
            this.lbl_session.Size = new System.Drawing.Size(89, 25);
            this.lbl_session.TabIndex = 13;
            this.lbl_session.Text = "Session:";
            // 
            // listView_CameraControl
            // 
            this.listView_CameraControl.CheckBoxes = true;
            this.listView_CameraControl.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Record,
            this.Camera,
            this.Index});
            this.listView_CameraControl.HideSelection = false;
            this.listView_CameraControl.Location = new System.Drawing.Point(46, 68);
            this.listView_CameraControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_CameraControl.Name = "listView_CameraControl";
            this.listView_CameraControl.Size = new System.Drawing.Size(512, 199);
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
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(567, 97);
            this.btn_show.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(112, 98);
            this.btn_show.TabIndex = 0;
            this.btn_show.Text = "Apply";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.show_Click);
            // 
            // cmb_showcameras
            // 
            this.cmb_showcameras.FormattingEnabled = true;
            this.cmb_showcameras.Location = new System.Drawing.Point(843, 720);
            this.cmb_showcameras.Name = "cmb_showcameras";
            this.cmb_showcameras.Size = new System.Drawing.Size(910, 28);
            this.cmb_showcameras.TabIndex = 17;
            this.cmb_showcameras.SelectedIndexChanged += new System.EventHandler(this.comboBox_showcameras_SelectedIndexChanged);
            // 
            // btn_empatica
            // 
            this.btn_empatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btn_empatica.Location = new System.Drawing.Point(304, 255);
            this.btn_empatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_empatica.Name = "btn_empatica";
            this.btn_empatica.Size = new System.Drawing.Size(225, 72);
            this.btn_empatica.TabIndex = 18;
            this.btn_empatica.Text = "Start Empatica";
            this.btn_empatica.UseVisualStyleBackColor = true;
            this.btn_empatica.Click += new System.EventHandler(this.empatica_Click);
            // 
            // timer_empatica
            // 
            this.timer_empatica.Interval = 5000;
            this.timer_empatica.Tick += new System.EventHandler(this.timer_empatica_Tick);
            // 
            // textBox_empatica
            // 
            this.textBox_empatica.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.textBox_empatica.Location = new System.Drawing.Point(1520, 757);
            this.textBox_empatica.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_empatica.Name = "textBox_empatica";
            this.textBox_empatica.Size = new System.Drawing.Size(56, 21);
            this.textBox_empatica.TabIndex = 19;
            this.textBox_empatica.Text = "AB2B64";
            this.textBox_empatica.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_empatica.Visible = false;
            // 
            // checkBox_face
            // 
            this.checkBox_face.AutoSize = true;
            this.checkBox_face.Location = new System.Drawing.Point(1593, 754);
            this.checkBox_face.Name = "checkBox_face";
            this.checkBox_face.Size = new System.Drawing.Size(160, 24);
            this.checkBox_face.TabIndex = 20;
            this.checkBox_face.Text = "Face Recognition";
            this.checkBox_face.UseVisualStyleBackColor = true;
            this.checkBox_face.Visible = false;
            this.checkBox_face.CheckedChanged += new System.EventHandler(this.checkBox_face_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(758, 725);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Camera";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_empatica_record);
            this.groupBox1.Controls.Add(this.checkBox_thermalapi);
            this.groupBox1.Controls.Add(this.checkBox_empatica_1);
            this.groupBox1.Controls.Add(this.checkBox_empatica_0);
            this.groupBox1.Controls.Add(this.btn_empatica);
            this.groupBox1.Controls.Add(this.btn_calibration);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(32, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 362);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Device";
            // 
            // checkBox_empatica_record
            // 
            this.checkBox_empatica_record.AutoSize = true;
            this.checkBox_empatica_record.Checked = true;
            this.checkBox_empatica_record.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_empatica_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.checkBox_empatica_record.Location = new System.Drawing.Point(536, 255);
            this.checkBox_empatica_record.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox_empatica_record.Name = "checkBox_empatica_record";
            this.checkBox_empatica_record.Size = new System.Drawing.Size(104, 24);
            this.checkBox_empatica_record.TabIndex = 24;
            this.checkBox_empatica_record.Text = "RecordAll";
            this.checkBox_empatica_record.UseVisualStyleBackColor = true;
            // 
            // checkBox_thermalapi
            // 
            this.checkBox_thermalapi.AutoSize = true;
            this.checkBox_thermalapi.Checked = true;
            this.checkBox_thermalapi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_thermalapi.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.checkBox_thermalapi.Location = new System.Drawing.Point(536, 46);
            this.checkBox_thermalapi.Name = "checkBox_thermalapi";
            this.checkBox_thermalapi.Size = new System.Drawing.Size(125, 21);
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
            this.checkBox_empatica_1.Location = new System.Drawing.Point(536, 318);
            this.checkBox_empatica_1.Name = "checkBox_empatica_1";
            this.checkBox_empatica_1.Size = new System.Drawing.Size(97, 24);
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
            this.checkBox_empatica_0.Location = new System.Drawing.Point(536, 289);
            this.checkBox_empatica_0.Name = "checkBox_empatica_0";
            this.checkBox_empatica_0.Size = new System.Drawing.Size(95, 24);
            this.checkBox_empatica_0.TabIndex = 21;
            this.checkBox_empatica_0.Text = "AB2B64";
            this.checkBox_empatica_0.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label9.Location = new System.Drawing.Point(838, 808);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(139, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "acc,bvp,ibi,tmp,gsr";
            this.label9.Visible = false;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(145, 862);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(62, 25);
            this.lbl_time.TabIndex = 23;
            this.lbl_time.Text = "00:00";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(36, 429);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(109, 25);
            this.lbl_name.TabIndex = 24;
            this.lbl_name.Text = "Participant:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 675);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 25);
            this.label5.TabIndex = 25;
            this.label5.Text = "Score:";
            // 
            // txt_participant
            // 
            this.txt_participant.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_participant.Location = new System.Drawing.Point(150, 429);
            this.txt_participant.Name = "txt_participant";
            this.txt_participant.Size = new System.Drawing.Size(331, 30);
            this.txt_participant.TabIndex = 26;
            this.txt_participant.Text = "Name";
            this.txt_participant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_score1
            // 
            this.txt_score1.Enabled = false;
            this.txt_score1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_score1.Location = new System.Drawing.Point(150, 675);
            this.txt_score1.Name = "txt_score1";
            this.txt_score1.Size = new System.Drawing.Size(82, 30);
            this.txt_score1.TabIndex = 27;
            this.txt_score1.Text = "0";
            this.txt_score1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(36, 862);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 25);
            this.label7.TabIndex = 29;
            this.label7.Text = "Timer:";
            // 
            // txt_comment
            // 
            this.txt_comment.Enabled = false;
            this.txt_comment.Location = new System.Drawing.Point(150, 902);
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_comment.Size = new System.Drawing.Size(392, 93);
            this.txt_comment.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(36, 902);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 25);
            this.label6.TabIndex = 31;
            this.label6.Text = "Comment:";
            // 
            // lbl_task
            // 
            this.lbl_task.AutoSize = true;
            this.lbl_task.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_task.Location = new System.Drawing.Point(44, 620);
            this.lbl_task.Name = "lbl_task";
            this.lbl_task.Size = new System.Drawing.Size(62, 25);
            this.lbl_task.TabIndex = 32;
            this.lbl_task.Text = "Task:";
            // 
            // txt_score2
            // 
            this.txt_score2.Enabled = false;
            this.txt_score2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_score2.Location = new System.Drawing.Point(150, 718);
            this.txt_score2.Name = "txt_score2";
            this.txt_score2.Size = new System.Drawing.Size(82, 30);
            this.txt_score2.TabIndex = 33;
            this.txt_score2.Text = "0";
            this.txt_score2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_score3
            // 
            this.txt_score3.Enabled = false;
            this.txt_score3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_score3.Location = new System.Drawing.Point(150, 763);
            this.txt_score3.Name = "txt_score3";
            this.txt_score3.Size = new System.Drawing.Size(82, 30);
            this.txt_score3.TabIndex = 34;
            this.txt_score3.Text = "0";
            this.txt_score3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_enterScore
            // 
            this.btn_enterScore.Enabled = false;
            this.btn_enterScore.Location = new System.Drawing.Point(568, 902);
            this.btn_enterScore.Name = "btn_enterScore";
            this.btn_enterScore.Size = new System.Drawing.Size(146, 94);
            this.btn_enterScore.TabIndex = 35;
            this.btn_enterScore.Text = "Enter Score";
            this.btn_enterScore.UseVisualStyleBackColor = true;
            this.btn_enterScore.Click += new System.EventHandler(this.enterScore_Click);
            // 
            // txt_score4
            // 
            this.txt_score4.Enabled = false;
            this.txt_score4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txt_score4.Location = new System.Drawing.Point(150, 806);
            this.txt_score4.Name = "txt_score4";
            this.txt_score4.Size = new System.Drawing.Size(82, 30);
            this.txt_score4.TabIndex = 30;
            this.txt_score4.Text = "0";
            this.txt_score4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1_score_0
            // 
            this.label1_score_0.AutoSize = true;
            this.label1_score_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_0.Location = new System.Drawing.Point(260, 675);
            this.label1_score_0.Name = "label1_score_0";
            this.label1_score_0.Size = new System.Drawing.Size(139, 25);
            this.label1_score_0.TabIndex = 37;
            this.label1_score_0.Text = "Performance 1";
            // 
            // label1_score_1
            // 
            this.label1_score_1.AutoSize = true;
            this.label1_score_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_1.Location = new System.Drawing.Point(260, 718);
            this.label1_score_1.Name = "label1_score_1";
            this.label1_score_1.Size = new System.Drawing.Size(139, 25);
            this.label1_score_1.TabIndex = 38;
            this.label1_score_1.Text = "Performance 2";
            // 
            // label1_score_2
            // 
            this.label1_score_2.AutoSize = true;
            this.label1_score_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_2.Location = new System.Drawing.Point(260, 763);
            this.label1_score_2.Name = "label1_score_2";
            this.label1_score_2.Size = new System.Drawing.Size(139, 25);
            this.label1_score_2.TabIndex = 39;
            this.label1_score_2.Text = "Performance 3";
            // 
            // label1_score_3
            // 
            this.label1_score_3.AutoSize = true;
            this.label1_score_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1_score_3.Location = new System.Drawing.Point(260, 806);
            this.label1_score_3.Name = "label1_score_3";
            this.label1_score_3.Size = new System.Drawing.Size(139, 25);
            this.label1_score_3.TabIndex = 40;
            this.label1_score_3.Text = "Performance 4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1400, 749);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 41;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_endSession
            // 
            this.btn_endSession.Enabled = false;
            this.btn_endSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_endSession.Location = new System.Drawing.Point(1416, 849);
            this.btn_endSession.Name = "btn_endSession";
            this.btn_endSession.Size = new System.Drawing.Size(342, 148);
            this.btn_endSession.TabIndex = 42;
            this.btn_endSession.Text = "End Session";
            this.btn_endSession.UseVisualStyleBackColor = true;
            this.btn_endSession.Click += new System.EventHandler(this.endSession_Click);
            // 
            // txt_tobiiHz
            // 
            this.txt_tobiiHz.Location = new System.Drawing.Point(1119, 765);
            this.txt_tobiiHz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_tobiiHz.Name = "txt_tobiiHz";
            this.txt_tobiiHz.Size = new System.Drawing.Size(148, 26);
            this.txt_tobiiHz.TabIndex = 43;
            this.txt_tobiiHz.Text = "60";
            this.txt_tobiiHz.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(834, 769);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(273, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Set Eyetracker Frequency (1~120 hz)";
            this.label10.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1278, 760);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 35);
            this.button3.TabIndex = 45;
            this.button3.Text = "Change";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_pupil
            // 
            this.label_pupil.AutoSize = true;
            this.label_pupil.Location = new System.Drawing.Point(838, 849);
            this.label_pupil.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_pupil.Name = "label_pupil";
            this.label_pupil.Size = new System.Drawing.Size(0, 20);
            this.label_pupil.TabIndex = 46;
            // 
            // btn_baseline
            // 
            this.btn_baseline.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btn_baseline.Location = new System.Drawing.Point(478, 475);
            this.btn_baseline.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_baseline.Name = "btn_baseline";
            this.btn_baseline.Size = new System.Drawing.Size(238, 83);
            this.btn_baseline.TabIndex = 47;
            this.btn_baseline.Text = "Baseline: 3 min";
            this.btn_baseline.UseVisualStyleBackColor = true;
            this.btn_baseline.UseWaitCursor = true;
            this.btn_baseline.Click += new System.EventHandler(this.baseline_Click);
            // 
            // num_sessionIndex
            // 
            this.num_sessionIndex.Location = new System.Drawing.Point(594, 431);
            this.num_sessionIndex.Name = "num_sessionIndex";
            this.num_sessionIndex.Size = new System.Drawing.Size(120, 26);
            this.num_sessionIndex.TabIndex = 49;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1790, 1012);
            this.Controls.Add(this.num_sessionIndex);
            this.Controls.Add(this.txt_participant);
            this.Controls.Add(this.btn_baseline);
            this.Controls.Add(this.label_pupil);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_session);
            this.Controls.Add(this.txt_tobiiHz);
            this.Controls.Add(this.btn_endSession);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_empatica);
            this.Controls.Add(this.label1_score_3);
            this.Controls.Add(this.label1_score_2);
            this.Controls.Add(this.label1_score_1);
            this.Controls.Add(this.label1_score_0);
            this.Controls.Add(this.txt_score4);
            this.Controls.Add(this.btn_enterScore);
            this.Controls.Add(this.txt_score3);
            this.Controls.Add(this.txt_score2);
            this.Controls.Add(this.lbl_task);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_comment);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_score1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_face);
            this.Controls.Add(this.cmb_showcameras);
            this.Controls.Add(this.btn_show);
            this.Controls.Add(this.listView_CameraControl);
            this.Controls.Add(this.btn_startStopTrial);
            this.Controls.Add(this.btn_startSession);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_task);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Virtual Coach";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_sessionIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_calibration;
        private System.Windows.Forms.ComboBox cmb_task;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_main;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.Button btn_startSession;
        private System.Windows.Forms.Button btn_startStopTrial;
        private System.Windows.Forms.Label lbl_session;
        private System.Windows.Forms.ListView listView_CameraControl;
        private System.Windows.Forms.ColumnHeader Record;
        private System.Windows.Forms.ColumnHeader Camera;
        private System.Windows.Forms.ColumnHeader Index;
        private System.Windows.Forms.Button btn_show;
        private System.Windows.Forms.ComboBox cmb_showcameras;
        private System.Windows.Forms.Button btn_empatica;
        private System.Windows.Forms.Timer timer_empatica;
        private System.Windows.Forms.TextBox textBox_empatica;
        private System.Windows.Forms.CheckBox checkBox_face;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_participant;
        private System.Windows.Forms.TextBox txt_score1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_task;
        private System.Windows.Forms.TextBox txt_score2;
        private System.Windows.Forms.TextBox txt_score3;
        private System.Windows.Forms.Button btn_enterScore;
        private System.Windows.Forms.TextBox txt_score4;
        private System.Windows.Forms.Label label1_score_0;
        private System.Windows.Forms.Label label1_score_1;
        private System.Windows.Forms.Label label1_score_2;
        private System.Windows.Forms.Label label1_score_3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_empatica_1;
        private System.Windows.Forms.CheckBox checkBox_empatica_0;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_thermalapi;
        private System.Windows.Forms.Button btn_endSession;
        private System.Windows.Forms.TextBox txt_tobiiHz;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label_pupil;
        private System.Windows.Forms.CheckBox checkBox_empatica_record;
        private System.Windows.Forms.Button btn_baseline;
        private System.Windows.Forms.NumericUpDown num_sessionIndex;
    }
}

