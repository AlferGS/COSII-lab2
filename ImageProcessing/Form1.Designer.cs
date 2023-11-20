namespace ImageProcessing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(5, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 701);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.minBrightnessTextBox);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.maxBrightnessTextBox);
            this.groupBox6.Controls.Add(this.linearContrastingButton);
            this.groupBox6.Location = new System.Drawing.Point(7, 548);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(258, 148);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Maximum brightness(0 - 255):";
            // 
            // minBrightnessTextBox
            // 
            this.minBrightnessTextBox.Enabled = false;
            this.minBrightnessTextBox.Location = new System.Drawing.Point(211, 21);
            this.minBrightnessTextBox.Name = "minBrightnessTextBox";
            this.minBrightnessTextBox.Size = new System.Drawing.Size(41, 22);
            this.minBrightnessTextBox.TabIndex = 11;
            this.minBrightnessTextBox.Text = "0";
            this.minBrightnessTextBox.Leave += new System.EventHandler(this.MinBrightnessTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Minimum brightness(0 - 255):";
            // 
            // maxBrightnessTextBox
            // 
            this.maxBrightnessTextBox.Enabled = false;
            this.maxBrightnessTextBox.Location = new System.Drawing.Point(211, 51);
            this.maxBrightnessTextBox.Name = "maxBrightnessTextBox";
            this.maxBrightnessTextBox.Size = new System.Drawing.Size(41, 22);
            this.maxBrightnessTextBox.TabIndex = 12;
            this.maxBrightnessTextBox.Text = "255";
            this.maxBrightnessTextBox.Leave += new System.EventHandler(this.MaxBrightnessTextBox_Leave);
            // 
            // linearContrastingButton
            // 
            this.linearContrastingButton.Enabled = false;
            this.linearContrastingButton.Location = new System.Drawing.Point(6, 93);
            this.linearContrastingButton.Name = "linearContrastingButton";
            this.linearContrastingButton.Size = new System.Drawing.Size(246, 47);
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
            this.groupBox5.Location = new System.Drawing.Point(7, 357);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 184);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // maxFilterButton
            // 
            this.maxFilterButton.Enabled = false;
            this.maxFilterButton.Location = new System.Drawing.Point(6, 15);
            this.maxFilterButton.Name = "maxFilterButton";
            this.maxFilterButton.Size = new System.Drawing.Size(246, 47);
            this.maxFilterButton.TabIndex = 1;
            this.maxFilterButton.Text = "Max filter";
            this.maxFilterButton.UseVisualStyleBackColor = true;
            this.maxFilterButton.Click += new System.EventHandler(this.MaxFilterButton_Click);
            // 
            // minMaxFilterButton
            // 
            this.minMaxFilterButton.Enabled = false;
            this.minMaxFilterButton.Location = new System.Drawing.Point(6, 129);
            this.minMaxFilterButton.Name = "minMaxFilterButton";
            this.minMaxFilterButton.Size = new System.Drawing.Size(246, 47);
            this.minMaxFilterButton.TabIndex = 4;
            this.minMaxFilterButton.Text = "Min-max filter";
            this.minMaxFilterButton.UseVisualStyleBackColor = true;
            this.minMaxFilterButton.Click += new System.EventHandler(this.MinMaxFilterButton_Click);
            // 
            // minFilterButton
            // 
            this.minFilterButton.Enabled = false;
            this.minFilterButton.Location = new System.Drawing.Point(6, 72);
            this.minFilterButton.Name = "minFilterButton";
            this.minFilterButton.Size = new System.Drawing.Size(246, 47);
            this.minFilterButton.TabIndex = 3;
            this.minFilterButton.Text = "Min filter";
            this.minFilterButton.UseVisualStyleBackColor = true;
            this.minFilterButton.Click += new System.EventHandler(this.MinFilterButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.sourceButton);
            this.groupBox4.Location = new System.Drawing.Point(7, 276);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 74);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // sourceButton
            // 
            this.sourceButton.Enabled = false;
            this.sourceButton.Location = new System.Drawing.Point(6, 17);
            this.sourceButton.Name = "sourceButton";
            this.sourceButton.Size = new System.Drawing.Size(246, 47);
            this.sourceButton.TabIndex = 5;
            this.sourceButton.Text = "Source picture";
            this.sourceButton.UseVisualStyleBackColor = true;
            this.sourceButton.Click += new System.EventHandler(this.SourceButton_Click);
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Image = global::ImageProcessing.Properties.Resources.image1;
            this.sourcePictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("sourcePictureBox.InitialImage")));
            this.sourcePictureBox.Location = new System.Drawing.Point(7, 17);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(258, 252);
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
            this.groupBox2.Location = new System.Drawing.Point(282, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(791, 701);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // processedPictureBox
            // 
            this.processedPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processedPictureBox.Image = global::ImageProcessing.Properties.Resources.image1;
            this.processedPictureBox.Location = new System.Drawing.Point(6, 17);
            this.processedPictureBox.Name = "processedPictureBox";
            this.processedPictureBox.Size = new System.Drawing.Size(779, 673);
            this.processedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.processedPictureBox.TabIndex = 0;
            this.processedPictureBox.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox3.Controls.Add(this.chart1);
            this.groupBox3.Location = new System.Drawing.Point(1079, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 436);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(6, 78);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(335, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1433, 30);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.openToolStripMenuItem.Text = "Open file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.saveToolStripMenuItem.Text = "Save file";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1178, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(1079, 589);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(347, 56);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Value = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1433, 733);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(25, 9, 25, 9);
            this.MinimumSize = new System.Drawing.Size(1194, 757);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox processedPictureBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

