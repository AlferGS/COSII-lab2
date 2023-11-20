
namespace Interface
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minBrightnessTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxBrightnessTextBox = new System.Windows.Forms.TextBox();
            this.linearContrastingButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.maxFilterButton = new System.Windows.Forms.Button();
            this.minMaxFilterButton = new System.Windows.Forms.Button();
            this.minFilterButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.sourceButton = new System.Windows.Forms.Button();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.processedPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.showRgbCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.plotView1 = new OxyPlot.WindowsForms.PlotView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.clusteringButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.accumulativeProcessing = new System.Windows.Forms.CheckBox();
            this.checkBinarizationButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ClusteringLog = new System.Windows.Forms.Label();
            this.classesNumberTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.sourcePictureBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(271, 940);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.minBrightnessTextBox);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.maxBrightnessTextBox);
            this.groupBox6.Controls.Add(this.linearContrastingButton);
            this.groupBox6.Location = new System.Drawing.Point(7, 749);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Size = new System.Drawing.Size(258, 185);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Maximum brightness(0 - 255):";
            // 
            // minBrightnessTextBox
            // 
            this.minBrightnessTextBox.Enabled = false;
            this.minBrightnessTextBox.Location = new System.Drawing.Point(211, 26);
            this.minBrightnessTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.minBrightnessTextBox.Name = "minBrightnessTextBox";
            this.minBrightnessTextBox.Size = new System.Drawing.Size(41, 27);
            this.minBrightnessTextBox.TabIndex = 11;
            this.minBrightnessTextBox.Text = "0";
            this.minBrightnessTextBox.Leave += new System.EventHandler(this.MinBrightnessTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Minimum brightness(0 - 255):";
            // 
            // maxBrightnessTextBox
            // 
            this.maxBrightnessTextBox.Enabled = false;
            this.maxBrightnessTextBox.Location = new System.Drawing.Point(211, 64);
            this.maxBrightnessTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maxBrightnessTextBox.Name = "maxBrightnessTextBox";
            this.maxBrightnessTextBox.Size = new System.Drawing.Size(41, 27);
            this.maxBrightnessTextBox.TabIndex = 12;
            this.maxBrightnessTextBox.Text = "255";
            this.maxBrightnessTextBox.Leave += new System.EventHandler(this.MaxBrightnessTextBox_Leave);
            // 
            // linearContrastingButton
            // 
            this.linearContrastingButton.Enabled = false;
            this.linearContrastingButton.Location = new System.Drawing.Point(6, 116);
            this.linearContrastingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.linearContrastingButton.Name = "linearContrastingButton";
            this.linearContrastingButton.Size = new System.Drawing.Size(246, 59);
            this.linearContrastingButton.TabIndex = 2;
            this.linearContrastingButton.Text = "Linear contrasting";
            this.linearContrastingButton.UseVisualStyleBackColor = true;
            this.linearContrastingButton.Click += new System.EventHandler(this.LinearContrastingButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.maxFilterButton);
            this.groupBox5.Controls.Add(this.minMaxFilterButton);
            this.groupBox5.Controls.Add(this.minFilterButton);
            this.groupBox5.Location = new System.Drawing.Point(7, 434);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Size = new System.Drawing.Size(258, 305);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // maxFilterButton
            // 
            this.maxFilterButton.Enabled = false;
            this.maxFilterButton.Location = new System.Drawing.Point(6, 21);
            this.maxFilterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maxFilterButton.Name = "maxFilterButton";
            this.maxFilterButton.Size = new System.Drawing.Size(246, 59);
            this.maxFilterButton.TabIndex = 1;
            this.maxFilterButton.Text = "Max filter";
            this.maxFilterButton.UseVisualStyleBackColor = true;
            this.maxFilterButton.Click += new System.EventHandler(this.MaxFilterButton_Click);
            // 
            // minMaxFilterButton
            // 
            this.minMaxFilterButton.Enabled = false;
            this.minMaxFilterButton.Location = new System.Drawing.Point(6, 164);
            this.minMaxFilterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.minMaxFilterButton.Name = "minMaxFilterButton";
            this.minMaxFilterButton.Size = new System.Drawing.Size(246, 59);
            this.minMaxFilterButton.TabIndex = 4;
            this.minMaxFilterButton.Text = "Min-max filter";
            this.minMaxFilterButton.UseVisualStyleBackColor = true;
            this.minMaxFilterButton.Click += new System.EventHandler(this.MinMaxFilterButton_Click);
            // 
            // minFilterButton
            // 
            this.minFilterButton.Enabled = false;
            this.minFilterButton.Location = new System.Drawing.Point(6, 92);
            this.minFilterButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.minFilterButton.Name = "minFilterButton";
            this.minFilterButton.Size = new System.Drawing.Size(246, 59);
            this.minFilterButton.TabIndex = 3;
            this.minFilterButton.Text = "Min filter";
            this.minFilterButton.UseVisualStyleBackColor = true;
            this.minFilterButton.Click += new System.EventHandler(this.MinFilterButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sourceButton);
            this.groupBox4.Location = new System.Drawing.Point(7, 339);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(258, 92);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // sourceButton
            // 
            this.sourceButton.Enabled = false;
            this.sourceButton.Location = new System.Drawing.Point(6, 21);
            this.sourceButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(246, 59);
            this.sourceButton.TabIndex = 5;
            this.sourceButton.Text = "Source picture";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.SourceButton_Click);
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Image = global::Interface.Properties.Resources.image;
            this.sourcePictureBox.InitialImage = null;
            this.sourcePictureBox.Location = new System.Drawing.Point(7, 21);
            this.sourcePictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(258, 315);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Controls.Add(this.processedPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(282, 34);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(797, 940);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // processedPictureBox
            // 
            this.processedPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processedPictureBox.Image = global::Interface.Properties.Resources.image;
            this.processedPictureBox.Location = new System.Drawing.Point(6, 21);
            this.processedPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.processedPictureBox.Name = "processedPictureBox";
            this.processedPictureBox.Size = new System.Drawing.Size(785, 906);
            this.processedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.processedPictureBox.TabIndex = 0;
            this.processedPictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Controls.Add(this.showRgbCheckBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.plotView1);
            this.groupBox3.Location = new System.Drawing.Point(1085, 34);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(347, 545);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // showRgbCheckBox
            // 
            this.showRgbCheckBox.AutoSize = true;
            this.showRgbCheckBox.Location = new System.Drawing.Point(9, 492);
            this.showRgbCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.showRgbCheckBox.Name = "showRgbCheckBox";
            this.showRgbCheckBox.Size = new System.Drawing.Size(18, 17);
            this.showRgbCheckBox.TabIndex = 11;
            this.showRgbCheckBox.UseVisualStyleBackColor = true;
            this.showRgbCheckBox.CheckedChanged += new System.EventHandler(this.ShowRgbCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(38, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Show rgb brightness levels";
            // 
            // plotView1
            // 
            this.plotView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.plotView1.ForeColor = System.Drawing.SystemColors.Window;
            this.plotView1.Location = new System.Drawing.Point(9, 32);
            this.plotView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plotView1.Name = "plotView1";
            this.plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView1.Size = new System.Drawing.Size(329, 425);
            this.plotView1.TabIndex = 0;
            this.plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1439, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.openToolStripMenuItem.Text = "Open file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.saveToolStripMenuItem.Text = "Save file";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.closeToolStripMenuItem.Text = "Close file";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JPEG images|*.jpg;*.jpeg|PNG images|*.png|Bitmap images|*.bmp|All files|*.*";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG images|*.jpg;*.jpeg|PNG images|*.png|Bitmap images|*.bmp";
            // 
            // clusteringButton
            // 
            this.clusteringButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clusteringButton.Location = new System.Drawing.Point(6, 136);
            this.clusteringButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clusteringButton.Name = "clusteringButton";
            this.clusteringButton.Size = new System.Drawing.Size(332, 52);
            this.clusteringButton.TabIndex = 4;
            this.clusteringButton.Text = "Clustering";
            this.clusteringButton.UseVisualStyleBackColor = true;
            this.clusteringButton.Click += new System.EventHandler(this.СlusteringButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.accumulativeProcessing);
            this.groupBox7.Controls.Add(this.checkBinarizationButton);
            this.groupBox7.Location = new System.Drawing.Point(1085, 818);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Size = new System.Drawing.Size(347, 156);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(38, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Check to work processed image";
            // 
            // accumulativeProcessing
            // 
            this.accumulativeProcessing.AutoSize = true;
            this.accumulativeProcessing.ForeColor = System.Drawing.SystemColors.Window;
            this.accumulativeProcessing.Location = new System.Drawing.Point(9, 100);
            this.accumulativeProcessing.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.accumulativeProcessing.Name = "accumulativeProcessing";
            this.accumulativeProcessing.Size = new System.Drawing.Size(18, 17);
            this.accumulativeProcessing.TabIndex = 1;
            this.accumulativeProcessing.UseVisualStyleBackColor = true;
            // 
            // checkBinarizationButton
            // 
            this.checkBinarizationButton.Location = new System.Drawing.Point(6, 30);
            this.checkBinarizationButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBinarizationButton.Name = "checkBinarizationButton";
            this.checkBinarizationButton.Size = new System.Drawing.Size(332, 52);
            this.checkBinarizationButton.TabIndex = 0;
            this.checkBinarizationButton.Text = "Show binarization";
            this.checkBinarizationButton.UseVisualStyleBackColor = true;
            this.checkBinarizationButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CheckBinarizationButton_MouseDown);
            this.checkBinarizationButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CheckBinarizationButton_MouseUp);
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox8.Controls.Add(this.ClusteringLog);
            this.groupBox8.Controls.Add(this.classesNumberTextBox);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.clusteringButton);
            this.groupBox8.Controls.Add(this.label4);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Location = new System.Drawing.Point(1085, 596);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox8.Size = new System.Drawing.Size(347, 214);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            // 
            // ClusteringLog
            // 
            this.ClusteringLog.AutoSize = true;
            this.ClusteringLog.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClusteringLog.Location = new System.Drawing.Point(9, 190);
            this.ClusteringLog.Name = "ClusteringLog";
            this.ClusteringLog.Size = new System.Drawing.Size(18, 20);
            this.ClusteringLog.TabIndex = 13;
            this.ClusteringLog.Text = "...";
            // 
            // classesNumberTextBox
            // 
            this.classesNumberTextBox.Enabled = false;
            this.classesNumberTextBox.Location = new System.Drawing.Point(297, 92);
            this.classesNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.classesNumberTextBox.Name = "classesNumberTextBox";
            this.classesNumberTextBox.Size = new System.Drawing.Size(41, 27);
            this.classesNumberTextBox.TabIndex = 12;
            this.classesNumberTextBox.Text = "2";
            this.classesNumberTextBox.Leave += new System.EventHandler(this.ClassesNumberTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(6, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Number of clustering classes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(88, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "occurs at a given level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(26, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 40);
            this.label3.TabIndex = 0;
            this.label3.Text = "\r\nIn the process of clustering, binarization\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1439, 980);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(25, 11, 25, 11);
            this.MinimumSize = new System.Drawing.Size(1194, 935);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image processing";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox processedPictureBox;
        private System.Windows.Forms.Button sourceButton;
        private System.Windows.Forms.Button minMaxFilterButton;
        private System.Windows.Forms.Button minFilterButton;
        private System.Windows.Forms.Button linearContrastingButton;
        private System.Windows.Forms.Button maxFilterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox maxBrightnessTextBox;
        private System.Windows.Forms.TextBox minBrightnessTextBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button clusteringButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private System.Windows.Forms.Button checkBinarizationButton;
        private System.Windows.Forms.CheckBox accumulativeProcessing;
        private System.Windows.Forms.TextBox classesNumberTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox showRgbCheckBox;
        private System.Windows.Forms.Label ClusteringLog;
    }
}

