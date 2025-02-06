namespace MotorControl_WinForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Axis3_ServoOFF = new System.Windows.Forms.Button();
            this.btn_Axis2_ServoOFF = new System.Windows.Forms.Button();
            this.btn_Axis1_ServoOFF = new System.Windows.Forms.Button();
            this.btn_Axis3_ServoON = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Axis2_ServoON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Axis1_ServoON = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Position_Z = new System.Windows.Forms.TextBox();
            this.tb_Position_Y = new System.Windows.Forms.TextBox();
            this.tb_Position_X = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btn_Jog_Z_Minus = new System.Windows.Forms.Button();
            this.btn_Jog_Z_Plus = new System.Windows.Forms.Button();
            this.btn_Jog_X_Minus = new System.Windows.Forms.Button();
            this.btn_Jog_Y_Minus = new System.Windows.Forms.Button();
            this.btn_Jog_X_Plus = new System.Windows.Forms.Button();
            this.btn_Jog_Y_Plus = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_PositionMove = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_PositionMove_Z = new System.Windows.Forms.TextBox();
            this.tb_PositionMove_Y = new System.Windows.Forms.TextBox();
            this.tb_PositionMove_X = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_Tcd_Now = new System.Windows.Forms.TextBox();
            this.tb_Tca_Now = new System.Windows.Forms.TextBox();
            this.tb_Speed_Now = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btn_SpeedSetUp = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tb_Tcd_Target = new System.Windows.Forms.TextBox();
            this.tb_Tca_Target = new System.Windows.Forms.TextBox();
            this.tb_Speed_Target = new System.Windows.Forms.TextBox();
            this.btn_EmergencyStop = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_DistanceSet_0001 = new System.Windows.Forms.Button();
            this.btn_DistanceSet_01 = new System.Windows.Forms.Button();
            this.btn_DistanceSet_1 = new System.Windows.Forms.Button();
            this.btn_DistanceSet_001 = new System.Windows.Forms.Button();
            this.btn_DistanceSet_10 = new System.Windows.Forms.Button();
            this.tb_Distance = new System.Windows.Forms.TextBox();
            this.tb_CustomMove = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn_Custom_Z_Minus = new System.Windows.Forms.Button();
            this.btn_Custom_Z_Plus = new System.Windows.Forms.Button();
            this.btn_Custom_X_Minus = new System.Windows.Forms.Button();
            this.btn_Custom_Y_Minus = new System.Windows.Forms.Button();
            this.btn_Custom_X_Plus = new System.Windows.Forms.Button();
            this.btn_Custom_Y_Plus = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Sequence1 = new System.Windows.Forms.Button();
            this.btn_Sequence2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_PositionSave = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btn_PathSetting = new System.Windows.Forms.Button();
            this.tb_Offset = new System.Windows.Forms.TextBox();
            this.tb_EmptyCount = new System.Windows.Forms.TextBox();
            this.tb_SizeOfArr = new System.Windows.Forms.TextBox();
            this.tb_ExposureTime = new System.Windows.Forms.TextBox();
            this.btn_Constants_Change = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.tb_ROUND_HIGH = new System.Windows.Forms.TextBox();
            this.tb_ROUND_LOW = new System.Windows.Forms.TextBox();
            this.tb_AREA_HIGH = new System.Windows.Forms.TextBox();
            this.tb_AREA_LOW = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.btn_Expanded = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_Fullscreen = new System.Windows.Forms.Button();
            this.tb_Expanded = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.panel_SaveXYZ = new System.Windows.Forms.Panel();
            this.tb_SaveName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Location = new System.Drawing.Point(14, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "연결";
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.Location = new System.Drawing.Point(6, 87);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(126, 61);
            this.btn_Disconnect.TabIndex = 2;
            this.btn_Disconnect.Text = "연결 해제";
            this.btn_Disconnect.UseVisualStyleBackColor = true;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(6, 20);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(126, 56);
            this.btn_Connect.TabIndex = 2;
            this.btn_Connect.Text = "연결";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Axis3_ServoOFF);
            this.groupBox2.Controls.Add(this.btn_Axis2_ServoOFF);
            this.groupBox2.Controls.Add(this.btn_Axis1_ServoOFF);
            this.groupBox2.Controls.Add(this.btn_Axis3_ServoON);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btn_Axis2_ServoON);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btn_Axis1_ServoON);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(14, 484);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 141);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "연결 상태";
            // 
            // btn_Axis3_ServoOFF
            // 
            this.btn_Axis3_ServoOFF.Location = new System.Drawing.Point(187, 77);
            this.btn_Axis3_ServoOFF.Name = "btn_Axis3_ServoOFF";
            this.btn_Axis3_ServoOFF.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis3_ServoOFF.TabIndex = 1;
            this.btn_Axis3_ServoOFF.Tag = "3,1";
            this.btn_Axis3_ServoOFF.Text = "OFF";
            this.btn_Axis3_ServoOFF.UseVisualStyleBackColor = true;
            this.btn_Axis3_ServoOFF.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // btn_Axis2_ServoOFF
            // 
            this.btn_Axis2_ServoOFF.Location = new System.Drawing.Point(95, 77);
            this.btn_Axis2_ServoOFF.Name = "btn_Axis2_ServoOFF";
            this.btn_Axis2_ServoOFF.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis2_ServoOFF.TabIndex = 1;
            this.btn_Axis2_ServoOFF.Tag = "2,1";
            this.btn_Axis2_ServoOFF.Text = "OFF";
            this.btn_Axis2_ServoOFF.UseVisualStyleBackColor = true;
            this.btn_Axis2_ServoOFF.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // btn_Axis1_ServoOFF
            // 
            this.btn_Axis1_ServoOFF.Location = new System.Drawing.Point(3, 77);
            this.btn_Axis1_ServoOFF.Name = "btn_Axis1_ServoOFF";
            this.btn_Axis1_ServoOFF.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis1_ServoOFF.TabIndex = 1;
            this.btn_Axis1_ServoOFF.Tag = "1,1";
            this.btn_Axis1_ServoOFF.Text = "OFF";
            this.btn_Axis1_ServoOFF.UseVisualStyleBackColor = true;
            this.btn_Axis1_ServoOFF.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // btn_Axis3_ServoON
            // 
            this.btn_Axis3_ServoON.Location = new System.Drawing.Point(187, 34);
            this.btn_Axis3_ServoON.Name = "btn_Axis3_ServoON";
            this.btn_Axis3_ServoON.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis3_ServoON.TabIndex = 1;
            this.btn_Axis3_ServoON.Tag = "3,0";
            this.btn_Axis3_ServoON.Text = "ON";
            this.btn_Axis3_ServoON.UseVisualStyleBackColor = true;
            this.btn_Axis3_ServoON.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Axis3";
            // 
            // btn_Axis2_ServoON
            // 
            this.btn_Axis2_ServoON.Location = new System.Drawing.Point(95, 34);
            this.btn_Axis2_ServoON.Name = "btn_Axis2_ServoON";
            this.btn_Axis2_ServoON.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis2_ServoON.TabIndex = 1;
            this.btn_Axis2_ServoON.Tag = "2,0";
            this.btn_Axis2_ServoON.Text = "ON";
            this.btn_Axis2_ServoON.UseVisualStyleBackColor = true;
            this.btn_Axis2_ServoON.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Axis2";
            // 
            // btn_Axis1_ServoON
            // 
            this.btn_Axis1_ServoON.Location = new System.Drawing.Point(3, 34);
            this.btn_Axis1_ServoON.Name = "btn_Axis1_ServoON";
            this.btn_Axis1_ServoON.Size = new System.Drawing.Size(86, 36);
            this.btn_Axis1_ServoON.TabIndex = 1;
            this.btn_Axis1_ServoON.Tag = "1,0";
            this.btn_Axis1_ServoON.Text = "ON";
            this.btn_Axis1_ServoON.UseVisualStyleBackColor = true;
            this.btn_Axis1_ServoON.Click += new System.EventHandler(this.Servo_ON_OFF);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Axis1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tb_Position_Z);
            this.groupBox3.Controls.Add(this.tb_Position_Y);
            this.groupBox3.Controls.Add(this.tb_Position_X);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(268, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "현재 위치";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(178, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "X";
            // 
            // tb_Position_Z
            // 
            this.tb_Position_Z.Location = new System.Drawing.Point(197, 33);
            this.tb_Position_Z.Name = "tb_Position_Z";
            this.tb_Position_Z.ReadOnly = true;
            this.tb_Position_Z.Size = new System.Drawing.Size(60, 21);
            this.tb_Position_Z.TabIndex = 0;
            // 
            // tb_Position_Y
            // 
            this.tb_Position_Y.Location = new System.Drawing.Point(112, 33);
            this.tb_Position_Y.Name = "tb_Position_Y";
            this.tb_Position_Y.ReadOnly = true;
            this.tb_Position_Y.Size = new System.Drawing.Size(60, 21);
            this.tb_Position_Y.TabIndex = 0;
            // 
            // tb_Position_X
            // 
            this.tb_Position_X.Location = new System.Drawing.Point(28, 33);
            this.tb_Position_X.Name = "tb_Position_X";
            this.tb_Position_X.ReadOnly = true;
            this.tb_Position_X.Size = new System.Drawing.Size(60, 21);
            this.tb_Position_X.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.btn_Jog_Z_Minus);
            this.groupBox4.Controls.Add(this.btn_Jog_Z_Plus);
            this.groupBox4.Controls.Add(this.btn_Jog_X_Minus);
            this.groupBox4.Controls.Add(this.btn_Jog_Y_Minus);
            this.groupBox4.Controls.Add(this.btn_Jog_X_Plus);
            this.groupBox4.Controls.Add(this.btn_Jog_Y_Plus);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Location = new System.Drawing.Point(6, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(268, 211);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "조그 이동";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(41, 110);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 12);
            this.label24.TabIndex = 3;
            this.label24.Text = "X";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(124, 110);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(13, 12);
            this.label23.TabIndex = 2;
            this.label23.Text = "Y";
            // 
            // btn_Jog_Z_Minus
            // 
            this.btn_Jog_Z_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_Z_Minus.Location = new System.Drawing.Point(185, 150);
            this.btn_Jog_Z_Minus.Name = "btn_Jog_Z_Minus";
            this.btn_Jog_Z_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_Z_Minus.TabIndex = 1;
            this.btn_Jog_Z_Minus.Tag = "3,1";
            this.btn_Jog_Z_Minus.Text = "-";
            this.btn_Jog_Z_Minus.UseVisualStyleBackColor = true;
            this.btn_Jog_Z_Minus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_Z_Minus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // btn_Jog_Z_Plus
            // 
            this.btn_Jog_Z_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_Z_Plus.Location = new System.Drawing.Point(185, 31);
            this.btn_Jog_Z_Plus.Name = "btn_Jog_Z_Plus";
            this.btn_Jog_Z_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_Z_Plus.TabIndex = 1;
            this.btn_Jog_Z_Plus.Tag = "3,0";
            this.btn_Jog_Z_Plus.Text = "+";
            this.btn_Jog_Z_Plus.UseVisualStyleBackColor = true;
            this.btn_Jog_Z_Plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_Z_Plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // btn_Jog_X_Minus
            // 
            this.btn_Jog_X_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_X_Minus.Location = new System.Drawing.Point(17, 150);
            this.btn_Jog_X_Minus.Name = "btn_Jog_X_Minus";
            this.btn_Jog_X_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_X_Minus.TabIndex = 1;
            this.btn_Jog_X_Minus.Tag = "1,1";
            this.btn_Jog_X_Minus.Text = "-";
            this.btn_Jog_X_Minus.UseVisualStyleBackColor = true;
            this.btn_Jog_X_Minus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_X_Minus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // btn_Jog_Y_Minus
            // 
            this.btn_Jog_Y_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_Y_Minus.Location = new System.Drawing.Point(100, 150);
            this.btn_Jog_Y_Minus.Name = "btn_Jog_Y_Minus";
            this.btn_Jog_Y_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_Y_Minus.TabIndex = 1;
            this.btn_Jog_Y_Minus.Tag = "2,1";
            this.btn_Jog_Y_Minus.Text = "-";
            this.btn_Jog_Y_Minus.UseVisualStyleBackColor = true;
            this.btn_Jog_Y_Minus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_Y_Minus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // btn_Jog_X_Plus
            // 
            this.btn_Jog_X_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_X_Plus.Location = new System.Drawing.Point(17, 31);
            this.btn_Jog_X_Plus.Name = "btn_Jog_X_Plus";
            this.btn_Jog_X_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_X_Plus.TabIndex = 1;
            this.btn_Jog_X_Plus.Tag = "1,0";
            this.btn_Jog_X_Plus.Text = "+";
            this.btn_Jog_X_Plus.UseVisualStyleBackColor = true;
            this.btn_Jog_X_Plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_X_Plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // btn_Jog_Y_Plus
            // 
            this.btn_Jog_Y_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Jog_Y_Plus.Location = new System.Drawing.Point(100, 31);
            this.btn_Jog_Y_Plus.Name = "btn_Jog_Y_Plus";
            this.btn_Jog_Y_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Jog_Y_Plus.TabIndex = 1;
            this.btn_Jog_Y_Plus.Tag = "2,0";
            this.btn_Jog_Y_Plus.Text = "+";
            this.btn_Jog_Y_Plus.UseVisualStyleBackColor = true;
            this.btn_Jog_Y_Plus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseDown);
            this.btn_Jog_Y_Plus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.JogButton_MouseUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(210, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "Z";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_PositionMove);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.tb_PositionMove_Z);
            this.groupBox7.Controls.Add(this.tb_PositionMove_Y);
            this.groupBox7.Controls.Add(this.tb_PositionMove_X);
            this.groupBox7.Location = new System.Drawing.Point(6, 597);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(354, 130);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "위치 이동";
            // 
            // btn_PositionMove
            // 
            this.btn_PositionMove.Location = new System.Drawing.Point(138, 77);
            this.btn_PositionMove.Name = "btn_PositionMove";
            this.btn_PositionMove.Size = new System.Drawing.Size(85, 30);
            this.btn_PositionMove.TabIndex = 2;
            this.btn_PositionMove.Text = "이동";
            this.btn_PositionMove.UseVisualStyleBackColor = true;
            this.btn_PositionMove.Click += new System.EventHandler(this.btn_PositionMove_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(241, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 12);
            this.label17.TabIndex = 1;
            this.label17.Text = "Z";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(127, 34);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 12);
            this.label18.TabIndex = 1;
            this.label18.Text = "Y";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 12);
            this.label19.TabIndex = 1;
            this.label19.Text = "X";
            // 
            // tb_PositionMove_Z
            // 
            this.tb_PositionMove_Z.Location = new System.Drawing.Point(261, 30);
            this.tb_PositionMove_Z.Name = "tb_PositionMove_Z";
            this.tb_PositionMove_Z.Size = new System.Drawing.Size(76, 21);
            this.tb_PositionMove_Z.TabIndex = 0;
            // 
            // tb_PositionMove_Y
            // 
            this.tb_PositionMove_Y.Location = new System.Drawing.Point(147, 30);
            this.tb_PositionMove_Y.Name = "tb_PositionMove_Y";
            this.tb_PositionMove_Y.Size = new System.Drawing.Size(76, 21);
            this.tb_PositionMove_Y.TabIndex = 0;
            // 
            // tb_PositionMove_X
            // 
            this.tb_PositionMove_X.Location = new System.Drawing.Point(34, 30);
            this.tb_PositionMove_X.Name = "tb_PositionMove_X";
            this.tb_PositionMove_X.Size = new System.Drawing.Size(76, 21);
            this.tb_PositionMove_X.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label16);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.tb_Tcd_Now);
            this.groupBox8.Controls.Add(this.tb_Tca_Now);
            this.groupBox8.Controls.Add(this.tb_Speed_Now);
            this.groupBox8.Location = new System.Drawing.Point(292, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(147, 153);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "현재 속도";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 4;
            this.label16.Text = "감속도";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "가속도";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "속도";
            // 
            // tb_Tcd_Now
            // 
            this.tb_Tcd_Now.Location = new System.Drawing.Point(61, 117);
            this.tb_Tcd_Now.Name = "tb_Tcd_Now";
            this.tb_Tcd_Now.ReadOnly = true;
            this.tb_Tcd_Now.Size = new System.Drawing.Size(76, 21);
            this.tb_Tcd_Now.TabIndex = 3;
            // 
            // tb_Tca_Now
            // 
            this.tb_Tca_Now.Location = new System.Drawing.Point(61, 77);
            this.tb_Tca_Now.Name = "tb_Tca_Now";
            this.tb_Tca_Now.ReadOnly = true;
            this.tb_Tca_Now.Size = new System.Drawing.Size(76, 21);
            this.tb_Tca_Now.TabIndex = 3;
            // 
            // tb_Speed_Now
            // 
            this.tb_Speed_Now.Location = new System.Drawing.Point(61, 39);
            this.tb_Speed_Now.Name = "tb_Speed_Now";
            this.tb_Speed_Now.ReadOnly = true;
            this.tb_Speed_Now.Size = new System.Drawing.Size(76, 21);
            this.tb_Speed_Now.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btn_SpeedSetUp);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.label21);
            this.groupBox9.Controls.Add(this.label22);
            this.groupBox9.Controls.Add(this.tb_Tcd_Target);
            this.groupBox9.Controls.Add(this.tb_Tca_Target);
            this.groupBox9.Controls.Add(this.tb_Speed_Target);
            this.groupBox9.Location = new System.Drawing.Point(292, 162);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(147, 178);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "속도 설정";
            // 
            // btn_SpeedSetUp
            // 
            this.btn_SpeedSetUp.Location = new System.Drawing.Point(32, 149);
            this.btn_SpeedSetUp.Name = "btn_SpeedSetUp";
            this.btn_SpeedSetUp.Size = new System.Drawing.Size(75, 23);
            this.btn_SpeedSetUp.TabIndex = 5;
            this.btn_SpeedSetUp.Text = "설정";
            this.btn_SpeedSetUp.UseVisualStyleBackColor = true;
            this.btn_SpeedSetUp.Click += new System.EventHandler(this.btn_SpeedSetUp_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 12);
            this.label20.TabIndex = 4;
            this.label20.Text = "감속도";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 4;
            this.label21.Text = "가속도";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 42);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 4;
            this.label22.Text = "속도";
            // 
            // tb_Tcd_Target
            // 
            this.tb_Tcd_Target.Location = new System.Drawing.Point(61, 117);
            this.tb_Tcd_Target.Name = "tb_Tcd_Target";
            this.tb_Tcd_Target.Size = new System.Drawing.Size(76, 21);
            this.tb_Tcd_Target.TabIndex = 3;
            // 
            // tb_Tca_Target
            // 
            this.tb_Tca_Target.Location = new System.Drawing.Point(61, 77);
            this.tb_Tca_Target.Name = "tb_Tca_Target";
            this.tb_Tca_Target.Size = new System.Drawing.Size(76, 21);
            this.tb_Tca_Target.TabIndex = 3;
            // 
            // tb_Speed_Target
            // 
            this.tb_Speed_Target.Location = new System.Drawing.Point(61, 39);
            this.tb_Speed_Target.Name = "tb_Speed_Target";
            this.tb_Speed_Target.Size = new System.Drawing.Size(76, 21);
            this.tb_Speed_Target.TabIndex = 3;
            // 
            // btn_EmergencyStop
            // 
            this.btn_EmergencyStop.BackColor = System.Drawing.Color.Red;
            this.btn_EmergencyStop.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_EmergencyStop.Location = new System.Drawing.Point(906, 782);
            this.btn_EmergencyStop.Name = "btn_EmergencyStop";
            this.btn_EmergencyStop.Size = new System.Drawing.Size(146, 110);
            this.btn_EmergencyStop.TabIndex = 8;
            this.btn_EmergencyStop.Text = "긴급 정지";
            this.btn_EmergencyStop.UseVisualStyleBackColor = false;
            this.btn_EmergencyStop.Click += new System.EventHandler(this.btn_EmergencyStop_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(783, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(269, 754);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label26);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.btn_DistanceSet_0001);
            this.groupBox5.Controls.Add(this.btn_DistanceSet_01);
            this.groupBox5.Controls.Add(this.btn_DistanceSet_1);
            this.groupBox5.Controls.Add(this.btn_DistanceSet_001);
            this.groupBox5.Controls.Add(this.btn_DistanceSet_10);
            this.groupBox5.Controls.Add(this.tb_Distance);
            this.groupBox5.Controls.Add(this.tb_CustomMove);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.btn_Custom_Z_Minus);
            this.groupBox5.Controls.Add(this.btn_Custom_Z_Plus);
            this.groupBox5.Controls.Add(this.btn_Custom_X_Minus);
            this.groupBox5.Controls.Add(this.btn_Custom_Y_Minus);
            this.groupBox5.Controls.Add(this.btn_Custom_X_Plus);
            this.groupBox5.Controls.Add(this.btn_Custom_Y_Plus);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(6, 342);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(433, 249);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "커스텀 이동";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(54, 209);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 11;
            this.label26.Text = "이동거리";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(315, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 12);
            this.label25.TabIndex = 11;
            this.label25.Text = "이동거리(mm)";
            // 
            // btn_DistanceSet_0001
            // 
            this.btn_DistanceSet_0001.Location = new System.Drawing.Point(300, 191);
            this.btn_DistanceSet_0001.Name = "btn_DistanceSet_0001";
            this.btn_DistanceSet_0001.Size = new System.Drawing.Size(113, 23);
            this.btn_DistanceSet_0001.TabIndex = 6;
            this.btn_DistanceSet_0001.Tag = "0.001";
            this.btn_DistanceSet_0001.Text = "0.001";
            this.btn_DistanceSet_0001.UseVisualStyleBackColor = true;
            this.btn_DistanceSet_0001.Click += new System.EventHandler(this.btn_DistanceSet_Click);
            // 
            // btn_DistanceSet_01
            // 
            this.btn_DistanceSet_01.Location = new System.Drawing.Point(300, 133);
            this.btn_DistanceSet_01.Name = "btn_DistanceSet_01";
            this.btn_DistanceSet_01.Size = new System.Drawing.Size(113, 23);
            this.btn_DistanceSet_01.TabIndex = 7;
            this.btn_DistanceSet_01.Tag = "0.1";
            this.btn_DistanceSet_01.Text = "0.1";
            this.btn_DistanceSet_01.UseVisualStyleBackColor = true;
            this.btn_DistanceSet_01.Click += new System.EventHandler(this.btn_DistanceSet_Click);
            // 
            // btn_DistanceSet_1
            // 
            this.btn_DistanceSet_1.Location = new System.Drawing.Point(300, 104);
            this.btn_DistanceSet_1.Name = "btn_DistanceSet_1";
            this.btn_DistanceSet_1.Size = new System.Drawing.Size(113, 23);
            this.btn_DistanceSet_1.TabIndex = 8;
            this.btn_DistanceSet_1.Tag = "1";
            this.btn_DistanceSet_1.Text = "1";
            this.btn_DistanceSet_1.UseVisualStyleBackColor = true;
            this.btn_DistanceSet_1.Click += new System.EventHandler(this.btn_DistanceSet_Click);
            // 
            // btn_DistanceSet_001
            // 
            this.btn_DistanceSet_001.Location = new System.Drawing.Point(300, 162);
            this.btn_DistanceSet_001.Name = "btn_DistanceSet_001";
            this.btn_DistanceSet_001.Size = new System.Drawing.Size(113, 23);
            this.btn_DistanceSet_001.TabIndex = 9;
            this.btn_DistanceSet_001.Tag = "0.01";
            this.btn_DistanceSet_001.Text = "0.01";
            this.btn_DistanceSet_001.UseVisualStyleBackColor = true;
            this.btn_DistanceSet_001.Click += new System.EventHandler(this.btn_DistanceSet_Click);
            // 
            // btn_DistanceSet_10
            // 
            this.btn_DistanceSet_10.Location = new System.Drawing.Point(300, 75);
            this.btn_DistanceSet_10.Name = "btn_DistanceSet_10";
            this.btn_DistanceSet_10.Size = new System.Drawing.Size(113, 23);
            this.btn_DistanceSet_10.TabIndex = 10;
            this.btn_DistanceSet_10.Tag = "10";
            this.btn_DistanceSet_10.Text = "10";
            this.btn_DistanceSet_10.UseVisualStyleBackColor = true;
            this.btn_DistanceSet_10.Click += new System.EventHandler(this.btn_DistanceSet_Click);
            // 
            // tb_Distance
            // 
            this.tb_Distance.Location = new System.Drawing.Point(317, 39);
            this.tb_Distance.Name = "tb_Distance";
            this.tb_Distance.ReadOnly = true;
            this.tb_Distance.Size = new System.Drawing.Size(76, 21);
            this.tb_Distance.TabIndex = 5;
            this.tb_Distance.Text = "1";
            this.tb_Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_CustomMove
            // 
            this.tb_CustomMove.Location = new System.Drawing.Point(129, 206);
            this.tb_CustomMove.Name = "tb_CustomMove";
            this.tb_CustomMove.Size = new System.Drawing.Size(100, 21);
            this.tb_CustomMove.TabIndex = 4;
            this.tb_CustomMove.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(49, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 12);
            this.label10.TabIndex = 3;
            this.label10.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "Y";
            // 
            // btn_Custom_Z_Minus
            // 
            this.btn_Custom_Z_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_Z_Minus.Location = new System.Drawing.Point(185, 140);
            this.btn_Custom_Z_Minus.Name = "btn_Custom_Z_Minus";
            this.btn_Custom_Z_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_Z_Minus.TabIndex = 1;
            this.btn_Custom_Z_Minus.Tag = "3,1";
            this.btn_Custom_Z_Minus.Text = "-";
            this.btn_Custom_Z_Minus.UseVisualStyleBackColor = true;
            this.btn_Custom_Z_Minus.Click += new System.EventHandler(this.CustomMove);
            // 
            // btn_Custom_Z_Plus
            // 
            this.btn_Custom_Z_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_Z_Plus.Location = new System.Drawing.Point(185, 29);
            this.btn_Custom_Z_Plus.Name = "btn_Custom_Z_Plus";
            this.btn_Custom_Z_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_Z_Plus.TabIndex = 1;
            this.btn_Custom_Z_Plus.Tag = "3,0";
            this.btn_Custom_Z_Plus.Text = "+";
            this.btn_Custom_Z_Plus.UseVisualStyleBackColor = true;
            this.btn_Custom_Z_Plus.Click += new System.EventHandler(this.CustomMove);
            // 
            // btn_Custom_X_Minus
            // 
            this.btn_Custom_X_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_X_Minus.Location = new System.Drawing.Point(25, 140);
            this.btn_Custom_X_Minus.Name = "btn_Custom_X_Minus";
            this.btn_Custom_X_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_X_Minus.TabIndex = 1;
            this.btn_Custom_X_Minus.Tag = "1,1";
            this.btn_Custom_X_Minus.Text = "-";
            this.btn_Custom_X_Minus.UseVisualStyleBackColor = true;
            this.btn_Custom_X_Minus.Click += new System.EventHandler(this.CustomMove);
            // 
            // btn_Custom_Y_Minus
            // 
            this.btn_Custom_Y_Minus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_Y_Minus.Location = new System.Drawing.Point(103, 140);
            this.btn_Custom_Y_Minus.Name = "btn_Custom_Y_Minus";
            this.btn_Custom_Y_Minus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_Y_Minus.TabIndex = 1;
            this.btn_Custom_Y_Minus.Tag = "2,1";
            this.btn_Custom_Y_Minus.Text = "-";
            this.btn_Custom_Y_Minus.UseVisualStyleBackColor = true;
            this.btn_Custom_Y_Minus.Click += new System.EventHandler(this.CustomMove);
            // 
            // btn_Custom_X_Plus
            // 
            this.btn_Custom_X_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_X_Plus.Location = new System.Drawing.Point(25, 29);
            this.btn_Custom_X_Plus.Name = "btn_Custom_X_Plus";
            this.btn_Custom_X_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_X_Plus.TabIndex = 1;
            this.btn_Custom_X_Plus.Tag = "1,0";
            this.btn_Custom_X_Plus.Text = "+";
            this.btn_Custom_X_Plus.UseVisualStyleBackColor = true;
            this.btn_Custom_X_Plus.Click += new System.EventHandler(this.CustomMove);
            // 
            // btn_Custom_Y_Plus
            // 
            this.btn_Custom_Y_Plus.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Custom_Y_Plus.Location = new System.Drawing.Point(103, 29);
            this.btn_Custom_Y_Plus.Name = "btn_Custom_Y_Plus";
            this.btn_Custom_Y_Plus.Size = new System.Drawing.Size(62, 51);
            this.btn_Custom_Y_Plus.TabIndex = 1;
            this.btn_Custom_Y_Plus.Tag = "2,0";
            this.btn_Custom_Y_Plus.Text = "+";
            this.btn_Custom_Y_Plus.UseVisualStyleBackColor = true;
            this.btn_Custom_Y_Plus.Click += new System.EventHandler(this.CustomMove);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 108);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "Z";
            // 
            // btn_Sequence1
            // 
            this.btn_Sequence1.Location = new System.Drawing.Point(719, 792);
            this.btn_Sequence1.Name = "btn_Sequence1";
            this.btn_Sequence1.Size = new System.Drawing.Size(73, 81);
            this.btn_Sequence1.TabIndex = 11;
            this.btn_Sequence1.Text = "시퀀스1";
            this.btn_Sequence1.UseVisualStyleBackColor = true;
            this.btn_Sequence1.Click += new System.EventHandler(this.btn_Sequence1_Click);
            // 
            // btn_Sequence2
            // 
            this.btn_Sequence2.Location = new System.Drawing.Point(810, 792);
            this.btn_Sequence2.Name = "btn_Sequence2";
            this.btn_Sequence2.Size = new System.Drawing.Size(73, 81);
            this.btn_Sequence2.TabIndex = 11;
            this.btn_Sequence2.Text = "시퀀스2";
            this.btn_Sequence2.UseVisualStyleBackColor = true;
            this.btn_Sequence2.Click += new System.EventHandler(this.btn_Sequence2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 100);
            this.button1.TabIndex = 12;
            this.button1.Text = "테스트_사진1장";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(36, 122);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(44, 12);
            this.label27.TabIndex = 13;
            this.label27.Text = "label27";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 100);
            this.button2.TabIndex = 12;
            this.button2.Text = "정지";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 100);
            this.button3.TabIndex = 12;
            this.button3.Text = "컨투어 테스트";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(123, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 100);
            this.button4.TabIndex = 12;
            this.button4.Text = "테스트버튼";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(318, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(459, 758);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tb_SaveName);
            this.tabPage1.Controls.Add(this.btn_PositionSave);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox9);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(451, 732);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "모터";
            // 
            // btn_PositionSave
            // 
            this.btn_PositionSave.Location = new System.Drawing.Point(364, 698);
            this.btn_PositionSave.Name = "btn_PositionSave";
            this.btn_PositionSave.Size = new System.Drawing.Size(75, 23);
            this.btn_PositionSave.TabIndex = 11;
            this.btn_PositionSave.Text = "위치 저장";
            this.btn_PositionSave.UseVisualStyleBackColor = true;
            this.btn_PositionSave.Click += new System.EventHandler(this.button7_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.button6);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label27);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(451, 732);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "카메라";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(334, 6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(111, 100);
            this.button6.TabIndex = 16;
            this.button6.Text = "이미지저장";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.label29);
            this.tabPage3.Controls.Add(this.label30);
            this.tabPage3.Controls.Add(this.label28);
            this.tabPage3.Controls.Add(this.btn_PathSetting);
            this.tabPage3.Controls.Add(this.tb_Offset);
            this.tabPage3.Controls.Add(this.tb_EmptyCount);
            this.tabPage3.Controls.Add(this.tb_SizeOfArr);
            this.tabPage3.Controls.Add(this.tb_Path);
            this.tabPage3.Controls.Add(this.tb_ExposureTime);
            this.tabPage3.Controls.Add(this.btn_Constants_Change);
            this.tabPage3.Controls.Add(this.label34);
            this.tabPage3.Controls.Add(this.label31);
            this.tabPage3.Controls.Add(this.label32);
            this.tabPage3.Controls.Add(this.label33);
            this.tabPage3.Controls.Add(this.tb_ROUND_HIGH);
            this.tabPage3.Controls.Add(this.tb_ROUND_LOW);
            this.tabPage3.Controls.Add(this.tb_AREA_HIGH);
            this.tabPage3.Controls.Add(this.tb_AREA_LOW);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(451, 732);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "세부 설정";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(186, 102);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(133, 12);
            this.label29.TabIndex = 23;
            this.label29.Text = "첫열에 빠지는 니들갯수";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(274, 22);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 12);
            this.label30.TabIndex = 24;
            this.label30.Text = "OffSet";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(283, 60);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 25;
            this.label28.Text = "N*N";
            // 
            // btn_PathSetting
            // 
            this.btn_PathSetting.Location = new System.Drawing.Point(359, 229);
            this.btn_PathSetting.Name = "btn_PathSetting";
            this.btn_PathSetting.Size = new System.Drawing.Size(75, 23);
            this.btn_PathSetting.TabIndex = 22;
            this.btn_PathSetting.Text = "경로설정";
            this.btn_PathSetting.UseVisualStyleBackColor = true;
            this.btn_PathSetting.Click += new System.EventHandler(this.btn_PathSetting_Click);
            // 
            // tb_Offset
            // 
            this.tb_Offset.Location = new System.Drawing.Point(334, 19);
            this.tb_Offset.Name = "tb_Offset";
            this.tb_Offset.Size = new System.Drawing.Size(100, 21);
            this.tb_Offset.TabIndex = 18;
            this.tb_Offset.Text = "161.8";
            this.tb_Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_EmptyCount
            // 
            this.tb_EmptyCount.Location = new System.Drawing.Point(406, 99);
            this.tb_EmptyCount.Name = "tb_EmptyCount";
            this.tb_EmptyCount.Size = new System.Drawing.Size(28, 21);
            this.tb_EmptyCount.TabIndex = 19;
            this.tb_EmptyCount.Text = "3";
            this.tb_EmptyCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_SizeOfArr
            // 
            this.tb_SizeOfArr.Location = new System.Drawing.Point(406, 57);
            this.tb_SizeOfArr.Name = "tb_SizeOfArr";
            this.tb_SizeOfArr.Size = new System.Drawing.Size(28, 21);
            this.tb_SizeOfArr.TabIndex = 20;
            this.tb_SizeOfArr.Text = "11";
            this.tb_SizeOfArr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_ExposureTime
            // 
            this.tb_ExposureTime.Location = new System.Drawing.Point(334, 132);
            this.tb_ExposureTime.Name = "tb_ExposureTime";
            this.tb_ExposureTime.Size = new System.Drawing.Size(100, 21);
            this.tb_ExposureTime.TabIndex = 21;
            this.tb_ExposureTime.Text = "3000";
            this.tb_ExposureTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Constants_Change
            // 
            this.btn_Constants_Change.Location = new System.Drawing.Point(20, 164);
            this.btn_Constants_Change.Name = "btn_Constants_Change";
            this.btn_Constants_Change.Size = new System.Drawing.Size(414, 45);
            this.btn_Constants_Change.TabIndex = 11;
            this.btn_Constants_Change.Text = "변경";
            this.btn_Constants_Change.UseVisualStyleBackColor = true;
            this.btn_Constants_Change.Click += new System.EventHandler(this.btn_Constants_Change_Click);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(18, 135);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(69, 12);
            this.label34.TabIndex = 8;
            this.label34.Text = "둘레 최댓값";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 99);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(69, 12);
            this.label31.TabIndex = 8;
            this.label31.Text = "둘레 최솟값";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(18, 60);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(69, 12);
            this.label32.TabIndex = 9;
            this.label32.Text = "넓이 최댓값";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 22);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(69, 12);
            this.label33.TabIndex = 10;
            this.label33.Text = "넓이 최솟값";
            // 
            // tb_ROUND_HIGH
            // 
            this.tb_ROUND_HIGH.Location = new System.Drawing.Point(104, 132);
            this.tb_ROUND_HIGH.Name = "tb_ROUND_HIGH";
            this.tb_ROUND_HIGH.Size = new System.Drawing.Size(76, 21);
            this.tb_ROUND_HIGH.TabIndex = 5;
            this.tb_ROUND_HIGH.Text = "320";
            this.tb_ROUND_HIGH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_ROUND_LOW
            // 
            this.tb_ROUND_LOW.Location = new System.Drawing.Point(104, 96);
            this.tb_ROUND_LOW.Name = "tb_ROUND_LOW";
            this.tb_ROUND_LOW.Size = new System.Drawing.Size(76, 21);
            this.tb_ROUND_LOW.TabIndex = 5;
            this.tb_ROUND_LOW.Text = "170";
            this.tb_ROUND_LOW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_AREA_HIGH
            // 
            this.tb_AREA_HIGH.Location = new System.Drawing.Point(104, 57);
            this.tb_AREA_HIGH.Name = "tb_AREA_HIGH";
            this.tb_AREA_HIGH.Size = new System.Drawing.Size(76, 21);
            this.tb_AREA_HIGH.TabIndex = 6;
            this.tb_AREA_HIGH.Text = "3800";
            this.tb_AREA_HIGH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_AREA_LOW
            // 
            this.tb_AREA_LOW.Location = new System.Drawing.Point(104, 19);
            this.tb_AREA_LOW.Name = "tb_AREA_LOW";
            this.tb_AREA_LOW.Size = new System.Drawing.Size(76, 21);
            this.tb_AREA_LOW.TabIndex = 7;
            this.tb_AREA_LOW.Text = "2300";
            this.tb_AREA_LOW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(247, 135);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 23;
            this.label35.Text = "조리개설정";
            // 
            // btn_Expanded
            // 
            this.btn_Expanded.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_Expanded.Location = new System.Drawing.Point(6, 20);
            this.btn_Expanded.Name = "btn_Expanded";
            this.btn_Expanded.Size = new System.Drawing.Size(63, 56);
            this.btn_Expanded.TabIndex = 17;
            this.btn_Expanded.Text = "확대";
            this.btn_Expanded.UseVisualStyleBackColor = false;
            this.btn_Expanded.Click += new System.EventHandler(this.btn_Expanded_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.tb_Expanded);
            this.groupBox6.Controls.Add(this.btn_Fullscreen);
            this.groupBox6.Controls.Add(this.btn_Expanded);
            this.groupBox6.Location = new System.Drawing.Point(171, 318);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(141, 159);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "확장";
            // 
            // btn_Fullscreen
            // 
            this.btn_Fullscreen.Location = new System.Drawing.Point(6, 87);
            this.btn_Fullscreen.Name = "btn_Fullscreen";
            this.btn_Fullscreen.Size = new System.Drawing.Size(129, 56);
            this.btn_Fullscreen.TabIndex = 17;
            this.btn_Fullscreen.Text = "전체화면";
            this.btn_Fullscreen.UseVisualStyleBackColor = true;
            this.btn_Fullscreen.Click += new System.EventHandler(this.btn_Fullscreen_Click);
            // 
            // tb_Expanded
            // 
            this.tb_Expanded.Location = new System.Drawing.Point(75, 39);
            this.tb_Expanded.Name = "tb_Expanded";
            this.tb_Expanded.Size = new System.Drawing.Size(36, 21);
            this.tb_Expanded.TabIndex = 18;
            this.tb_Expanded.Text = "150";
            this.tb_Expanded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(117, 44);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(15, 12);
            this.label36.TabIndex = 19;
            this.label36.Text = "%";
            // 
            // tb_Path
            // 
            this.tb_Path.Location = new System.Drawing.Point(20, 230);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.ReadOnly = true;
            this.tb_Path.Size = new System.Drawing.Size(333, 21);
            this.tb_Path.TabIndex = 21;
            this.tb_Path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel_SaveXYZ
            // 
            this.panel_SaveXYZ.AutoScroll = true;
            this.panel_SaveXYZ.Location = new System.Drawing.Point(17, 638);
            this.panel_SaveXYZ.Name = "panel_SaveXYZ";
            this.panel_SaveXYZ.Size = new System.Drawing.Size(295, 132);
            this.panel_SaveXYZ.TabIndex = 19;
            // 
            // tb_SaveName
            // 
            this.tb_SaveName.Location = new System.Drawing.Point(364, 671);
            this.tb_SaveName.Name = "tb_SaveName";
            this.tb_SaveName.Size = new System.Drawing.Size(75, 21);
            this.tb_SaveName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 656);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "저장할이름";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 901);
            this.Controls.Add(this.panel_SaveXYZ);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_Sequence2);
            this.Controls.Add(this.btn_Sequence1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_EmergencyStop);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Axis3_ServoOFF;
        private System.Windows.Forms.Button btn_Axis2_ServoOFF;
        private System.Windows.Forms.Button btn_Axis1_ServoOFF;
        private System.Windows.Forms.Button btn_Axis3_ServoON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Axis2_ServoON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Axis1_ServoON;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_Position_X;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Position_Z;
        private System.Windows.Forms.TextBox tb_Position_Y;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_Jog_Z_Minus;
        private System.Windows.Forms.Button btn_Jog_Z_Plus;
        private System.Windows.Forms.Button btn_Jog_Y_Minus;
        private System.Windows.Forms.Button btn_Jog_Y_Plus;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_PositionMove_Z;
        private System.Windows.Forms.TextBox tb_PositionMove_Y;
        private System.Windows.Forms.TextBox tb_PositionMove_X;
        private System.Windows.Forms.Button btn_PositionMove;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tb_Speed_Now;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_Tcd_Now;
        private System.Windows.Forms.TextBox tb_Tca_Now;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btn_SpeedSetUp;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox tb_Tcd_Target;
        private System.Windows.Forms.TextBox tb_Tca_Target;
        private System.Windows.Forms.TextBox tb_Speed_Target;
        private System.Windows.Forms.Button btn_EmergencyStop;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_Jog_X_Minus;
        private System.Windows.Forms.Button btn_Jog_X_Plus;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn_Custom_Z_Minus;
        private System.Windows.Forms.Button btn_Custom_Z_Plus;
        private System.Windows.Forms.Button btn_Custom_X_Minus;
        private System.Windows.Forms.Button btn_Custom_Y_Minus;
        private System.Windows.Forms.Button btn_Custom_X_Plus;
        private System.Windows.Forms.Button btn_Custom_Y_Plus;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_CustomMove;
        private System.Windows.Forms.Button btn_DistanceSet_0001;
        private System.Windows.Forms.Button btn_DistanceSet_01;
        private System.Windows.Forms.Button btn_DistanceSet_1;
        private System.Windows.Forms.Button btn_DistanceSet_001;
        private System.Windows.Forms.Button btn_DistanceSet_10;
        private System.Windows.Forms.TextBox tb_Distance;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btn_Sequence1;
        private System.Windows.Forms.Button btn_Sequence2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tb_ROUND_HIGH;
        private System.Windows.Forms.TextBox tb_ROUND_LOW;
        private System.Windows.Forms.TextBox tb_AREA_HIGH;
        private System.Windows.Forms.TextBox tb_AREA_LOW;
        private System.Windows.Forms.Button btn_Constants_Change;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btn_PathSetting;
        private System.Windows.Forms.TextBox tb_Offset;
        private System.Windows.Forms.TextBox tb_EmptyCount;
        private System.Windows.Forms.TextBox tb_SizeOfArr;
        private System.Windows.Forms.TextBox tb_ExposureTime;
        private System.Windows.Forms.Button btn_PositionSave;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button btn_Expanded;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_Fullscreen;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tb_Expanded;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Panel panel_SaveXYZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_SaveName;
    }
}

