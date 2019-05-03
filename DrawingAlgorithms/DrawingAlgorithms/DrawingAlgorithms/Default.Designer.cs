namespace DrawingAlgorithms
{
    partial class Default
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveBtn = new System.Windows.Forms.Button();
            this.btnDrawCircle = new System.Windows.Forms.Button();
            this.btnNewBitmap = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.btnOpenFillWindow = new System.Windows.Forms.Button();
            this.openImageFilterFormBtn = new System.Windows.Forms.Button();
            this.curveFormBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.editablePolynomBtn = new System.Windows.Forms.Button();
            this.imgProcessingBtn = new System.Windows.Forms.Button();
            this.littlePainterBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 398);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(402, 125);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(648, 12);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(124, 56);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "Load image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;" +
    " *.png";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // comboBox
            // 
            this.comboBox.AllowDrop = true;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "Zoom",
            "Original size"});
            this.comboBox.Location = new System.Drawing.Point(648, 89);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 21);
            this.comboBox.TabIndex = 3;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog_FileOk);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(648, 129);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(124, 52);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "Save ";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // btnDrawCircle
            // 
            this.btnDrawCircle.Location = new System.Drawing.Point(648, 250);
            this.btnDrawCircle.Name = "btnDrawCircle";
            this.btnDrawCircle.Size = new System.Drawing.Size(120, 57);
            this.btnDrawCircle.TabIndex = 5;
            this.btnDrawCircle.Text = "Draw circle";
            this.btnDrawCircle.UseVisualStyleBackColor = true;
            this.btnDrawCircle.Click += new System.EventHandler(this.btnDrawCircle_Click);
            // 
            // btnNewBitmap
            // 
            this.btnNewBitmap.Location = new System.Drawing.Point(648, 187);
            this.btnNewBitmap.Name = "btnNewBitmap";
            this.btnNewBitmap.Size = new System.Drawing.Size(124, 57);
            this.btnNewBitmap.TabIndex = 6;
            this.btnNewBitmap.Text = "New bitmap";
            this.btnNewBitmap.UseVisualStyleBackColor = true;
            this.btnNewBitmap.Click += new System.EventHandler(this.btnNewBitmap_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(649, 314);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(123, 56);
            this.btnLock.TabIndex = 7;
            this.btnLock.Text = "Lock bits";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // btnOpenFillWindow
            // 
            this.btnOpenFillWindow.Location = new System.Drawing.Point(674, 687);
            this.btnOpenFillWindow.Name = "btnOpenFillWindow";
            this.btnOpenFillWindow.Size = new System.Drawing.Size(98, 62);
            this.btnOpenFillWindow.TabIndex = 8;
            this.btnOpenFillWindow.Text = "New fill form";
            this.btnOpenFillWindow.UseVisualStyleBackColor = true;
            this.btnOpenFillWindow.Click += new System.EventHandler(this.btnOpenFillWindow_Click);
            // 
            // openImageFilterFormBtn
            // 
            this.openImageFilterFormBtn.Location = new System.Drawing.Point(674, 632);
            this.openImageFilterFormBtn.Name = "openImageFilterFormBtn";
            this.openImageFilterFormBtn.Size = new System.Drawing.Size(98, 49);
            this.openImageFilterFormBtn.TabIndex = 9;
            this.openImageFilterFormBtn.Text = "New Image filter form";
            this.openImageFilterFormBtn.UseVisualStyleBackColor = true;
            this.openImageFilterFormBtn.Click += new System.EventHandler(this.openImageFilterFormBtn_Click);
            // 
            // curveFormBtn
            // 
            this.curveFormBtn.Location = new System.Drawing.Point(673, 583);
            this.curveFormBtn.Name = "curveFormBtn";
            this.curveFormBtn.Size = new System.Drawing.Size(95, 43);
            this.curveFormBtn.TabIndex = 10;
            this.curveFormBtn.Text = "Curves form";
            this.curveFormBtn.UseVisualStyleBackColor = true;
            this.curveFormBtn.Click += new System.EventHandler(this.curveFormBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 534);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Coons cubic";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // editablePolynomBtn
            // 
            this.editablePolynomBtn.Location = new System.Drawing.Point(673, 483);
            this.editablePolynomBtn.Name = "editablePolynomBtn";
            this.editablePolynomBtn.Size = new System.Drawing.Size(95, 45);
            this.editablePolynomBtn.TabIndex = 12;
            this.editablePolynomBtn.Text = "Editable polynom";
            this.editablePolynomBtn.UseVisualStyleBackColor = true;
            this.editablePolynomBtn.Click += new System.EventHandler(this.editablePolynomBtn_Click);
            // 
            // imgProcessingBtn
            // 
            this.imgProcessingBtn.Location = new System.Drawing.Point(673, 434);
            this.imgProcessingBtn.Name = "imgProcessingBtn";
            this.imgProcessingBtn.Size = new System.Drawing.Size(95, 43);
            this.imgProcessingBtn.TabIndex = 13;
            this.imgProcessingBtn.Text = "Image processing form";
            this.imgProcessingBtn.UseVisualStyleBackColor = true;
            this.imgProcessingBtn.Click += new System.EventHandler(this.imgProcessingBtn_Click);
            // 
            // littlePainterBtn
            // 
            this.littlePainterBtn.Location = new System.Drawing.Point(522, 687);
            this.littlePainterBtn.Name = "littlePainterBtn";
            this.littlePainterBtn.Size = new System.Drawing.Size(146, 62);
            this.littlePainterBtn.TabIndex = 14;
            this.littlePainterBtn.Text = "Open little painter";
            this.littlePainterBtn.UseVisualStyleBackColor = true;
            this.littlePainterBtn.Click += new System.EventHandler(this.littlePainterBtn_Click);
            // 
            // Default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.littlePainterBtn);
            this.Controls.Add(this.imgProcessingBtn);
            this.Controls.Add(this.editablePolynomBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.curveFormBtn);
            this.Controls.Add(this.openImageFilterFormBtn);
            this.Controls.Add(this.btnOpenFillWindow);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.btnNewBitmap);
            this.Controls.Add(this.btnDrawCircle);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.panel1);
            this.Name = "Default";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button btnDrawCircle;
        private System.Windows.Forms.Button btnNewBitmap;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnOpenFillWindow;
        private System.Windows.Forms.Button openImageFilterFormBtn;
        private System.Windows.Forms.Button curveFormBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button editablePolynomBtn;
        private System.Windows.Forms.Button imgProcessingBtn;
        private System.Windows.Forms.Button littlePainterBtn;
    }
}

