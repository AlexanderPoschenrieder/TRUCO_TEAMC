namespace Truco
{
    partial class Main
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
            this.comboBoxPlayerIZQ = new System.Windows.Forms.ComboBox();
            this.comboBoxPlayerDER = new System.Windows.Forms.ComboBox();
            this.LabelTantosIZQ = new System.Windows.Forms.Label();
            this.LabelTantosDER = new System.Windows.Forms.Label();
            this.labelenv1 = new System.Windows.Forms.Label();
            this.labelenv2 = new System.Windows.Forms.Label();
            this.labelmanoizq = new System.Windows.Forms.Label();
            this.labelmanoder = new System.Windows.Forms.Label();
            this.trackBarVel = new System.Windows.Forms.TrackBar();
            this.labelCantoDer = new System.Windows.Forms.Label();
            this.labelCantoIzq = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.tabPageDebug = new System.Windows.Forms.TabPage();
            this.buttonDebug = new System.Windows.Forms.Button();
            this.textBoxDebug = new System.Windows.Forms.TextBox();
            this.timerLabelIzq = new System.Windows.Forms.Timer(this.components);
            this.timerLabelDer = new System.Windows.Forms.Timer(this.components);
            this.PauseButton = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.pbJ2M3 = new System.Windows.Forms.PictureBox();
            this.pbJ1M3 = new System.Windows.Forms.PictureBox();
            this.pbJ2M2 = new System.Windows.Forms.PictureBox();
            this.pbJ1M2 = new System.Windows.Forms.PictureBox();
            this.pbJ2M1 = new System.Windows.Forms.PictureBox();
            this.pbJ1M1 = new System.Windows.Forms.PictureBox();
            this.carta13 = new System.Windows.Forms.PictureBox();
            this.carta23 = new System.Windows.Forms.PictureBox();
            this.carta22 = new System.Windows.Forms.PictureBox();
            this.carta12 = new System.Windows.Forms.PictureBox();
            this.carta21 = new System.Windows.Forms.PictureBox();
            this.carta11 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVel)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            this.tabPageDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta11)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxPlayerIZQ
            // 
            this.comboBoxPlayerIZQ.FormattingEnabled = true;
            this.comboBoxPlayerIZQ.Items.AddRange(new object[] {
            "TeamA",
            "TeamB",
            "TeamC",
            "TeamD",
            "Default"});
            this.comboBoxPlayerIZQ.Location = new System.Drawing.Point(16, 49);
            this.comboBoxPlayerIZQ.Name = "comboBoxPlayerIZQ";
            this.comboBoxPlayerIZQ.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlayerIZQ.TabIndex = 0;
            // 
            // comboBoxPlayerDER
            // 
            this.comboBoxPlayerDER.FormattingEnabled = true;
            this.comboBoxPlayerDER.Items.AddRange(new object[] {
            "TeamA",
            "TeamB",
            "TeamC",
            "TeamD",
            "Default"});
            this.comboBoxPlayerDER.Location = new System.Drawing.Point(753, 56);
            this.comboBoxPlayerDER.Name = "comboBoxPlayerDER";
            this.comboBoxPlayerDER.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPlayerDER.TabIndex = 1;
            // 
            // LabelTantosIZQ
            // 
            this.LabelTantosIZQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTantosIZQ.ForeColor = System.Drawing.Color.White;
            this.LabelTantosIZQ.Location = new System.Drawing.Point(143, 37);
            this.LabelTantosIZQ.Name = "LabelTantosIZQ";
            this.LabelTantosIZQ.Size = new System.Drawing.Size(72, 48);
            this.LabelTantosIZQ.TabIndex = 3;
            this.LabelTantosIZQ.Text = "0";
            this.LabelTantosIZQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelTantosDER
            // 
            this.LabelTantosDER.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTantosDER.ForeColor = System.Drawing.Color.White;
            this.LabelTantosDER.Location = new System.Drawing.Point(880, 40);
            this.LabelTantosDER.Name = "LabelTantosDER";
            this.LabelTantosDER.Size = new System.Drawing.Size(72, 48);
            this.LabelTantosDER.TabIndex = 4;
            this.LabelTantosDER.Text = "0";
            this.LabelTantosDER.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelenv1
            // 
            this.labelenv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelenv1.ForeColor = System.Drawing.Color.White;
            this.labelenv1.Location = new System.Drawing.Point(210, 136);
            this.labelenv1.Name = "labelenv1";
            this.labelenv1.Size = new System.Drawing.Size(72, 48);
            this.labelenv1.TabIndex = 32;
            this.labelenv1.Text = "0";
            this.labelenv1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelenv2
            // 
            this.labelenv2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelenv2.ForeColor = System.Drawing.Color.White;
            this.labelenv2.Location = new System.Drawing.Point(728, 136);
            this.labelenv2.Name = "labelenv2";
            this.labelenv2.Size = new System.Drawing.Size(72, 48);
            this.labelenv2.TabIndex = 33;
            this.labelenv2.Text = "0";
            this.labelenv2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelmanoizq
            // 
            this.labelmanoizq.AutoSize = true;
            this.labelmanoizq.Font = new System.Drawing.Font("Microsoft Sans Serif", 180F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmanoizq.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelmanoizq.Location = new System.Drawing.Point(240, 32);
            this.labelmanoizq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelmanoizq.Name = "labelmanoizq";
            this.labelmanoizq.Size = new System.Drawing.Size(169, 272);
            this.labelmanoizq.TabIndex = 34;
            this.labelmanoizq.Text = "l";
            this.labelmanoizq.Visible = false;
            // 
            // labelmanoder
            // 
            this.labelmanoder.AutoSize = true;
            this.labelmanoder.BackColor = System.Drawing.Color.Transparent;
            this.labelmanoder.Font = new System.Drawing.Font("Microsoft Sans Serif", 180F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmanoder.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelmanoder.Location = new System.Drawing.Point(579, 32);
            this.labelmanoder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelmanoder.Name = "labelmanoder";
            this.labelmanoder.Size = new System.Drawing.Size(169, 272);
            this.labelmanoder.TabIndex = 35;
            this.labelmanoder.Text = "l";
            this.labelmanoder.Visible = false;
            // 
            // trackBarVel
            // 
            this.trackBarVel.Location = new System.Drawing.Point(71, 77);
            this.trackBarVel.Minimum = 1;
            this.trackBarVel.Name = "trackBarVel";
            this.trackBarVel.Size = new System.Drawing.Size(193, 45);
            this.trackBarVel.TabIndex = 36;
            this.trackBarVel.Value = 3;
            // 
            // labelCantoDer
            // 
            this.labelCantoDer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantoDer.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelCantoDer.Location = new System.Drawing.Point(660, 571);
            this.labelCantoDer.Name = "labelCantoDer";
            this.labelCantoDer.Size = new System.Drawing.Size(294, 255);
            this.labelCantoDer.TabIndex = 38;
            this.labelCantoDer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCantoIzq
            // 
            this.labelCantoIzq.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCantoIzq.ForeColor = System.Drawing.Color.SandyBrown;
            this.labelCantoIzq.Location = new System.Drawing.Point(12, 571);
            this.labelCantoIzq.Name = "labelCantoIzq";
            this.labelCantoIzq.Size = new System.Drawing.Size(294, 255);
            this.labelCantoIzq.TabIndex = 39;
            this.labelCantoIzq.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageLog);
            this.tabControl1.Controls.Add(this.tabPageDebug);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(305, 686);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxLog);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageLog.Size = new System.Drawing.Size(297, 660);
            this.tabPageLog.TabIndex = 0;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.Silver;
            this.textBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.ForeColor = System.Drawing.Color.Black;
            this.textBoxLog.Location = new System.Drawing.Point(2, 2);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(293, 656);
            this.textBoxLog.TabIndex = 43;
            // 
            // tabPageDebug
            // 
            this.tabPageDebug.Controls.Add(this.buttonDebug);
            this.tabPageDebug.Controls.Add(this.textBoxDebug);
            this.tabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebug.Margin = new System.Windows.Forms.Padding(2);
            this.tabPageDebug.Name = "tabPageDebug";
            this.tabPageDebug.Padding = new System.Windows.Forms.Padding(2);
            this.tabPageDebug.Size = new System.Drawing.Size(297, 660);
            this.tabPageDebug.TabIndex = 1;
            this.tabPageDebug.Text = "Debug";
            this.tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // buttonDebug
            // 
            this.buttonDebug.ForeColor = System.Drawing.Color.Black;
            this.buttonDebug.Location = new System.Drawing.Point(102, 656);
            this.buttonDebug.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDebug.Name = "buttonDebug";
            this.buttonDebug.Size = new System.Drawing.Size(56, 19);
            this.buttonDebug.TabIndex = 45;
            this.buttonDebug.Text = "debug";
            this.buttonDebug.UseVisualStyleBackColor = true;
            // 
            // textBoxDebug
            // 
            this.textBoxDebug.AcceptsReturn = true;
            this.textBoxDebug.BackColor = System.Drawing.Color.White;
            this.textBoxDebug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebug.ForeColor = System.Drawing.Color.Black;
            this.textBoxDebug.Location = new System.Drawing.Point(2, 2);
            this.textBoxDebug.Multiline = true;
            this.textBoxDebug.Name = "textBoxDebug";
            this.textBoxDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDebug.Size = new System.Drawing.Size(293, 656);
            this.textBoxDebug.TabIndex = 44;
            this.textBoxDebug.Text = "7E6E3C7C1B3O\r\nRE1B3E7E6E3C\r\n3C7C3E3B7B3O\r\n1B7E3E1E7O3C\r\n1E7O2E1C2OSE\r\n7E6E3CRE1B3" +
    "E\r\n4E4C4B1E1B3E";
            // 
            // timerLabelIzq
            // 
            this.timerLabelIzq.Interval = 1000;
            this.timerLabelIzq.Tick += new System.EventHandler(this.timerLabelIzq_Tick);
            // 
            // timerLabelDer
            // 
            this.timerLabelDer.Interval = 1000;
            this.timerLabelDer.Tick += new System.EventHandler(this.timerLabelDer_Tick);
            // 
            // PauseButton
            // 
            this.PauseButton.BackColor = System.Drawing.Color.Transparent;
            this.PauseButton.Enabled = false;
            this.PauseButton.FlatAppearance.BorderSize = 0;
            this.PauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.PauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PauseButton.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseButton.ForeColor = System.Drawing.Color.Black;
            this.PauseButton.Image = global::Truco.Properties.Resources.pause;
            this.PauseButton.Location = new System.Drawing.Point(69, 12);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(42, 42);
            this.PauseButton.TabIndex = 43;
            this.PauseButton.Text = "| |";
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.FlatAppearance.BorderSize = 0;
            this.buttonStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStop.ForeColor = System.Drawing.Color.Black;
            this.buttonStop.Image = global::Truco.Properties.Resources.cancel;
            this.buttonStop.Location = new System.Drawing.Point(222, 11);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(42, 42);
            this.buttonStop.TabIndex = 42;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // pbJ2M3
            // 
            this.pbJ2M3.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ2M3.Location = new System.Drawing.Point(485, 571);
            this.pbJ2M3.Name = "pbJ2M3";
            this.pbJ2M3.Size = new System.Drawing.Size(166, 255);
            this.pbJ2M3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ2M3.TabIndex = 31;
            this.pbJ2M3.TabStop = false;
            this.pbJ2M3.Visible = false;
            // 
            // pbJ1M3
            // 
            this.pbJ1M3.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ1M3.Location = new System.Drawing.Point(313, 571);
            this.pbJ1M3.Name = "pbJ1M3";
            this.pbJ1M3.Size = new System.Drawing.Size(166, 255);
            this.pbJ1M3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ1M3.TabIndex = 30;
            this.pbJ1M3.TabStop = false;
            this.pbJ1M3.Visible = false;
            // 
            // pbJ2M2
            // 
            this.pbJ2M2.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ2M2.Location = new System.Drawing.Point(485, 310);
            this.pbJ2M2.Name = "pbJ2M2";
            this.pbJ2M2.Size = new System.Drawing.Size(166, 255);
            this.pbJ2M2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ2M2.TabIndex = 29;
            this.pbJ2M2.TabStop = false;
            this.pbJ2M2.Visible = false;
            // 
            // pbJ1M2
            // 
            this.pbJ1M2.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ1M2.Location = new System.Drawing.Point(313, 310);
            this.pbJ1M2.Name = "pbJ1M2";
            this.pbJ1M2.Size = new System.Drawing.Size(166, 255);
            this.pbJ1M2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ1M2.TabIndex = 28;
            this.pbJ1M2.TabStop = false;
            this.pbJ1M2.Visible = false;
            // 
            // pbJ2M1
            // 
            this.pbJ2M1.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ2M1.Location = new System.Drawing.Point(485, 49);
            this.pbJ2M1.Name = "pbJ2M1";
            this.pbJ2M1.Size = new System.Drawing.Size(166, 255);
            this.pbJ2M1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ2M1.TabIndex = 27;
            this.pbJ2M1.TabStop = false;
            this.pbJ2M1.Visible = false;
            // 
            // pbJ1M1
            // 
            this.pbJ1M1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pbJ1M1.Image = global::Truco.Properties.Resources.reverso;
            this.pbJ1M1.Location = new System.Drawing.Point(313, 49);
            this.pbJ1M1.Name = "pbJ1M1";
            this.pbJ1M1.Size = new System.Drawing.Size(166, 255);
            this.pbJ1M1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbJ1M1.TabIndex = 26;
            this.pbJ1M1.TabStop = false;
            this.pbJ1M1.Visible = false;
            // 
            // carta13
            // 
            this.carta13.Image = global::Truco.Properties.Resources.reverso;
            this.carta13.Location = new System.Drawing.Point(88, 288);
            this.carta13.Name = "carta13";
            this.carta13.Size = new System.Drawing.Size(166, 255);
            this.carta13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta13.TabIndex = 22;
            this.carta13.TabStop = false;
            // 
            // carta23
            // 
            this.carta23.Image = global::Truco.Properties.Resources.reverso;
            this.carta23.Location = new System.Drawing.Point(744, 288);
            this.carta23.Name = "carta23";
            this.carta23.Size = new System.Drawing.Size(166, 255);
            this.carta23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta23.TabIndex = 25;
            this.carta23.TabStop = false;
            // 
            // carta22
            // 
            this.carta22.Image = global::Truco.Properties.Resources.reverso;
            this.carta22.Location = new System.Drawing.Point(784, 208);
            this.carta22.Name = "carta22";
            this.carta22.Size = new System.Drawing.Size(166, 255);
            this.carta22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta22.TabIndex = 24;
            this.carta22.TabStop = false;
            // 
            // carta12
            // 
            this.carta12.Image = global::Truco.Properties.Resources.reverso;
            this.carta12.Location = new System.Drawing.Point(48, 208);
            this.carta12.Name = "carta12";
            this.carta12.Size = new System.Drawing.Size(166, 255);
            this.carta12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta12.TabIndex = 21;
            this.carta12.TabStop = false;
            // 
            // carta21
            // 
            this.carta21.Image = global::Truco.Properties.Resources.reverso;
            this.carta21.Location = new System.Drawing.Point(824, 128);
            this.carta21.Name = "carta21";
            this.carta21.Size = new System.Drawing.Size(166, 255);
            this.carta21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta21.TabIndex = 23;
            this.carta21.TabStop = false;
            // 
            // carta11
            // 
            this.carta11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.carta11.Image = global::Truco.Properties.Resources.reverso;
            this.carta11.Location = new System.Drawing.Point(8, 128);
            this.carta11.Name = "carta11";
            this.carta11.Size = new System.Drawing.Size(166, 255);
            this.carta11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carta11.TabIndex = 20;
            this.carta11.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Pause";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(164, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 45;
            this.label2.Text = "Cancel";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.startToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1431, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 46;
            this.label3.Text = "Speed";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1126, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 813);
            this.panel1.TabIndex = 47;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trackBarVel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.PauseButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonStop);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 686);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 126);
            this.panel2.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1431, 837);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelCantoIzq);
            this.Controls.Add(this.labelCantoDer);
            this.Controls.Add(this.labelenv2);
            this.Controls.Add(this.labelenv1);
            this.Controls.Add(this.pbJ2M3);
            this.Controls.Add(this.pbJ1M3);
            this.Controls.Add(this.pbJ2M2);
            this.Controls.Add(this.pbJ1M2);
            this.Controls.Add(this.pbJ2M1);
            this.Controls.Add(this.pbJ1M1);
            this.Controls.Add(this.carta13);
            this.Controls.Add(this.carta23);
            this.Controls.Add(this.carta22);
            this.Controls.Add(this.carta12);
            this.Controls.Add(this.carta21);
            this.Controls.Add(this.carta11);
            this.Controls.Add(this.LabelTantosDER);
            this.Controls.Add(this.LabelTantosIZQ);
            this.Controls.Add(this.comboBoxPlayerDER);
            this.Controls.Add(this.comboBoxPlayerIZQ);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.labelmanoder);
            this.Controls.Add(this.labelmanoizq);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "CodeCamp I - Truco";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVel)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageDebug.ResumeLayout(false);
            this.tabPageDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ2M1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbJ1M1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carta11)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPlayerIZQ;
        private System.Windows.Forms.ComboBox comboBoxPlayerDER;
        private System.Windows.Forms.Label LabelTantosIZQ;
        private System.Windows.Forms.Label LabelTantosDER;
        private System.Windows.Forms.PictureBox carta13;
        private System.Windows.Forms.PictureBox carta12;
        private System.Windows.Forms.PictureBox carta11;
        private System.Windows.Forms.PictureBox carta23;
        private System.Windows.Forms.PictureBox carta22;
        private System.Windows.Forms.PictureBox carta21;
        private System.Windows.Forms.PictureBox pbJ1M1;
        private System.Windows.Forms.PictureBox pbJ2M1;
        private System.Windows.Forms.PictureBox pbJ2M2;
        private System.Windows.Forms.PictureBox pbJ1M2;
        private System.Windows.Forms.PictureBox pbJ2M3;
        private System.Windows.Forms.PictureBox pbJ1M3;
        private System.Windows.Forms.Label labelenv1;
        private System.Windows.Forms.Label labelenv2;
        private System.Windows.Forms.Label labelmanoizq;
        private System.Windows.Forms.Label labelmanoder;
        private System.Windows.Forms.TrackBar trackBarVel;
        private System.Windows.Forms.Label labelCantoDer;
        private System.Windows.Forms.Label labelCantoIzq;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TabPage tabPageDebug;
        private System.Windows.Forms.Button buttonDebug;
        private System.Windows.Forms.TextBox textBoxDebug;
        private System.Windows.Forms.Timer timerLabelIzq;
        private System.Windows.Forms.Timer timerLabelDer;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

