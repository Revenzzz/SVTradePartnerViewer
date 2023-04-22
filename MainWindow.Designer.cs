namespace SVTradePartnerViewer
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            InputSwitchIP = new TextBox();
            ButtonConnect = new Button();
            groupBox1 = new GroupBox();
            CheckAutoCopy = new CheckBox();
            OutVersion = new TextBox();
            CheckPSWiFi = new CheckBox();
            label5 = new Label();
            OutNID = new TextBox();
            label4 = new Label();
            OutTID = new TextBox();
            OutOT = new TextBox();
            OutGender = new TextBox();
            OutLanguage = new TextBox();
            label7 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ButtonCopy = new Button();
            ButtonStop = new Button();
            textLog = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // InputSwitchIP
            // 
            InputSwitchIP.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            InputSwitchIP.Location = new Point(263, 25);
            InputSwitchIP.Margin = new Padding(4);
            InputSwitchIP.Name = "InputSwitchIP";
            InputSwitchIP.Size = new Size(204, 25);
            InputSwitchIP.TabIndex = 0;
            InputSwitchIP.Text = "192.168.0.0";
            InputSwitchIP.TextAlign = HorizontalAlignment.Center;
            InputSwitchIP.TextChanged += InputSwitchIP_TextChanged;
            // 
            // ButtonConnect
            // 
            ButtonConnect.Location = new Point(13, 124);
            ButtonConnect.Margin = new Padding(4);
            ButtonConnect.Name = "ButtonConnect";
            ButtonConnect.Size = new Size(93, 29);
            ButtonConnect.TabIndex = 1;
            ButtonConnect.Text = "读取";
            ButtonConnect.UseVisualStyleBackColor = true;
            ButtonConnect.Click += ButtonConnect_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CheckAutoCopy);
            groupBox1.Controls.Add(OutVersion);
            groupBox1.Controls.Add(CheckPSWiFi);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(OutNID);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(OutTID);
            groupBox1.Controls.Add(OutOT);
            groupBox1.Controls.Add(OutGender);
            groupBox1.Controls.Add(OutLanguage);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(114, 86);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(578, 281);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "交易对象信息";
            // 
            // CheckAutoCopy
            // 
            CheckAutoCopy.AutoSize = true;
            CheckAutoCopy.Location = new Point(112, 223);
            CheckAutoCopy.Margin = new Padding(4);
            CheckAutoCopy.Name = "CheckAutoCopy";
            CheckAutoCopy.Size = new Size(91, 24);
            CheckAutoCopy.TabIndex = 4;
            CheckAutoCopy.Text = "自动复制";
            CheckAutoCopy.UseVisualStyleBackColor = true;
            CheckAutoCopy.CheckedChanged += CheckAutoCopy_CheckedChanged;
            // 
            // OutVersion
            // 
            OutVersion.Location = new Point(363, 170);
            OutVersion.Margin = new Padding(4);
            OutVersion.Name = "OutVersion";
            OutVersion.Size = new Size(170, 27);
            OutVersion.TabIndex = 5;
            // 
            // CheckPSWiFi
            // 
            CheckPSWiFi.AutoSize = true;
            CheckPSWiFi.Location = new Point(330, 223);
            CheckPSWiFi.Margin = new Padding(4);
            CheckPSWiFi.Name = "CheckPSWiFi";
            CheckPSWiFi.Size = new Size(119, 24);
            CheckPSWiFi.TabIndex = 5;
            CheckPSWiFi.Text = "PS! WiFi模式";
            CheckPSWiFi.UseVisualStyleBackColor = true;
            CheckPSWiFi.CheckedChanged += CheckPSWiFi_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(308, 173);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(58, 20);
            label5.TabIndex = 8;
            label5.Text = "版 本：";
            // 
            // OutNID
            // 
            OutNID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            OutNID.Location = new Point(363, 110);
            OutNID.Margin = new Padding(4);
            OutNID.Name = "OutNID";
            OutNID.Size = new Size(170, 25);
            OutNID.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(307, 113);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 20);
            label4.TabIndex = 6;
            label4.Text = "N I D：";
            // 
            // OutTID
            // 
            OutTID.Location = new Point(363, 50);
            OutTID.Margin = new Padding(4);
            OutTID.Name = "OutTID";
            OutTID.Size = new Size(170, 27);
            OutTID.TabIndex = 4;
            // 
            // OutOT
            // 
            OutOT.Location = new Point(84, 50);
            OutOT.Margin = new Padding(4);
            OutOT.Name = "OutOT";
            OutOT.Size = new Size(170, 27);
            OutOT.TabIndex = 3;
            // 
            // OutGender
            // 
            OutGender.Location = new Point(84, 110);
            OutGender.Margin = new Padding(4);
            OutGender.Name = "OutGender";
            OutGender.Size = new Size(170, 27);
            OutGender.TabIndex = 9;
            // 
            // OutLanguage
            // 
            OutLanguage.Location = new Point(84, 170);
            OutLanguage.Margin = new Padding(4);
            OutLanguage.Name = "OutLanguage";
            OutLanguage.Size = new Size(170, 27);
            OutLanguage.TabIndex = 10;
            // 
            // label7
            // 
            label7.Location = new Point(34, 174);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(58, 20);
            label7.TabIndex = 11;
            label7.Text = "语 言:";
            // 
            // label3
            // 
            label3.Location = new Point(34, 113);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 12;
            label3.Text = "性 别:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(297, 53);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "表里ID：";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 53);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "名 称：";
            // 
            // ButtonCopy
            // 
            ButtonCopy.Location = new Point(13, 252);
            ButtonCopy.Margin = new Padding(4);
            ButtonCopy.Name = "ButtonCopy";
            ButtonCopy.Size = new Size(93, 30);
            ButtonCopy.TabIndex = 2;
            ButtonCopy.Text = "复制信息";
            ButtonCopy.UseVisualStyleBackColor = true;
            ButtonCopy.Click += ButtonCopy_Click;
            // 
            // ButtonStop
            // 
            ButtonStop.Enabled = false;
            ButtonStop.Location = new Point(13, 162);
            ButtonStop.Margin = new Padding(4);
            ButtonStop.Name = "ButtonStop";
            ButtonStop.Size = new Size(93, 29);
            ButtonStop.TabIndex = 3;
            ButtonStop.Text = "停止";
            ButtonStop.UseVisualStyleBackColor = true;
            ButtonStop.Click += ButtonStop_Click;
            // 
            // textLog
            // 
            textLog.BackColor = SystemColors.Control;
            textLog.BorderStyle = BorderStyle.None;
            textLog.Location = new Point(208, 58);
            textLog.Margin = new Padding(4);
            textLog.Name = "textLog";
            textLog.ScrollBars = ScrollBars.Horizontal;
            textLog.Size = new Size(312, 20);
            textLog.TabIndex = 5;
            textLog.TextAlign = HorizontalAlignment.Center;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 401);
            Controls.Add(textLog);
            Controls.Add(groupBox1);
            Controls.Add(ButtonCopy);
            Controls.Add(InputSwitchIP);
            Controls.Add(ButtonStop);
            Controls.Add(ButtonConnect);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "MainWindow";
            Load += MainWindow_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputSwitchIP;
        private Button ButtonConnect;
        private GroupBox groupBox1;
        private TextBox OutVersion;
        private TextBox OutNID;
        private Label label4;
        private TextBox OutTID;
        private TextBox OutOT;
        private TextBox OutGender;
        private Label label2;
        private Label label1;
        private Button ButtonCopy;
        private Button ButtonStop;
        private CheckBox CheckAutoCopy;
        private CheckBox CheckPSWiFi;
        private Label label3;
        private TextBox OutLanguage;
        private Label label7;
        private TextBox textLog;
        private Label label5;
    }
}