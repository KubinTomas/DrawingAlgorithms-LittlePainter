namespace ImageFiltersAlgorithms
{
    partial class Window
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.editGradationBtn = new System.Windows.Forms.Button();
            this.thresholdingBtn = new System.Windows.Forms.Button();
            this.rndThresholdingBtn = new System.Windows.Forms.Button();
            this.matrixBtn = new System.Windows.Forms.Button();
            this.distributionBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::ImageFiltersAlgorithms.Properties.Resources.House_of_fraser_jellicoe_2;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 600);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(657, 13);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(115, 41);
            this.refreshBtn.TabIndex = 1;
            this.refreshBtn.Text = "Refresh image";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // editGradationBtn
            // 
            this.editGradationBtn.Location = new System.Drawing.Point(657, 61);
            this.editGradationBtn.Name = "editGradationBtn";
            this.editGradationBtn.Size = new System.Drawing.Size(115, 38);
            this.editGradationBtn.TabIndex = 2;
            this.editGradationBtn.Text = "Edit gradation";
            this.editGradationBtn.UseVisualStyleBackColor = true;
            this.editGradationBtn.Click += new System.EventHandler(this.editGradationBtn_Click);
            // 
            // thresholdingBtn
            // 
            this.thresholdingBtn.Location = new System.Drawing.Point(657, 106);
            this.thresholdingBtn.Name = "thresholdingBtn";
            this.thresholdingBtn.Size = new System.Drawing.Size(115, 35);
            this.thresholdingBtn.TabIndex = 3;
            this.thresholdingBtn.Text = "Thresholding";
            this.thresholdingBtn.UseVisualStyleBackColor = true;
            this.thresholdingBtn.Click += new System.EventHandler(this.thresholdingBtn_Click);
            // 
            // rndThresholdingBtn
            // 
            this.rndThresholdingBtn.Location = new System.Drawing.Point(657, 148);
            this.rndThresholdingBtn.Name = "rndThresholdingBtn";
            this.rndThresholdingBtn.Size = new System.Drawing.Size(115, 33);
            this.rndThresholdingBtn.TabIndex = 4;
            this.rndThresholdingBtn.Text = "Random thresholding";
            this.rndThresholdingBtn.UseVisualStyleBackColor = true;
            this.rndThresholdingBtn.Click += new System.EventHandler(this.rndThresholdingBtn_Click);
            // 
            // matrixBtn
            // 
            this.matrixBtn.Location = new System.Drawing.Point(657, 188);
            this.matrixBtn.Name = "matrixBtn";
            this.matrixBtn.Size = new System.Drawing.Size(115, 33);
            this.matrixBtn.TabIndex = 5;
            this.matrixBtn.Text = "Matrix";
            this.matrixBtn.UseVisualStyleBackColor = true;
            this.matrixBtn.Click += new System.EventHandler(this.matrixBtn_Click);
            // 
            // distributionBtn
            // 
            this.distributionBtn.Location = new System.Drawing.Point(657, 227);
            this.distributionBtn.Name = "distributionBtn";
            this.distributionBtn.Size = new System.Drawing.Size(115, 30);
            this.distributionBtn.TabIndex = 6;
            this.distributionBtn.Text = "Distribution";
            this.distributionBtn.UseVisualStyleBackColor = true;
            this.distributionBtn.Click += new System.EventHandler(this.distributionBtn_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.distributionBtn);
            this.Controls.Add(this.matrixBtn);
            this.Controls.Add(this.rndThresholdingBtn);
            this.Controls.Add(this.thresholdingBtn);
            this.Controls.Add(this.editGradationBtn);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "Window";
            this.Text = "Window";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button editGradationBtn;
        private System.Windows.Forms.Button thresholdingBtn;
        private System.Windows.Forms.Button rndThresholdingBtn;
        private System.Windows.Forms.Button matrixBtn;
        private System.Windows.Forms.Button distributionBtn;
    }
}