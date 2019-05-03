namespace ImageProcessing
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sharpingBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.noiseReductionBtn = new System.Windows.Forms.Button();
            this.embossBtn = new System.Windows.Forms.Button();
            this.edgesDetecionBtn = new System.Windows.Forms.Button();
            this.upperMoveBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.warpingBtn = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImageProcessing.Properties.Resources.House_of_fraser_jellicoe_2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(642, 756);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sharpingBtn
            // 
            this.sharpingBtn.Location = new System.Drawing.Point(649, 64);
            this.sharpingBtn.Name = "sharpingBtn";
            this.sharpingBtn.Size = new System.Drawing.Size(123, 41);
            this.sharpingBtn.TabIndex = 1;
            this.sharpingBtn.Text = "Sharping";
            this.sharpingBtn.UseVisualStyleBackColor = true;
            this.sharpingBtn.Click += new System.EventHandler(this.sharpingBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(648, 12);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(123, 46);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // noiseReductionBtn
            // 
            this.noiseReductionBtn.Location = new System.Drawing.Point(649, 112);
            this.noiseReductionBtn.Name = "noiseReductionBtn";
            this.noiseReductionBtn.Size = new System.Drawing.Size(122, 42);
            this.noiseReductionBtn.TabIndex = 3;
            this.noiseReductionBtn.Text = "Noise reduction";
            this.noiseReductionBtn.UseVisualStyleBackColor = true;
            this.noiseReductionBtn.Click += new System.EventHandler(this.noiseReductionBtn_Click);
            // 
            // embossBtn
            // 
            this.embossBtn.Location = new System.Drawing.Point(649, 161);
            this.embossBtn.Name = "embossBtn";
            this.embossBtn.Size = new System.Drawing.Size(122, 44);
            this.embossBtn.TabIndex = 4;
            this.embossBtn.Text = "Emboss";
            this.embossBtn.UseVisualStyleBackColor = true;
            this.embossBtn.Click += new System.EventHandler(this.embossBtn_Click);
            // 
            // edgesDetecionBtn
            // 
            this.edgesDetecionBtn.Location = new System.Drawing.Point(649, 212);
            this.edgesDetecionBtn.Name = "edgesDetecionBtn";
            this.edgesDetecionBtn.Size = new System.Drawing.Size(123, 42);
            this.edgesDetecionBtn.TabIndex = 5;
            this.edgesDetecionBtn.Text = "Edges detection";
            this.edgesDetecionBtn.UseVisualStyleBackColor = true;
            this.edgesDetecionBtn.Click += new System.EventHandler(this.edgesDetecionBtn_Click);
            // 
            // upperMoveBtn
            // 
            this.upperMoveBtn.Location = new System.Drawing.Point(648, 261);
            this.upperMoveBtn.Name = "upperMoveBtn";
            this.upperMoveBtn.Size = new System.Drawing.Size(123, 38);
            this.upperMoveBtn.TabIndex = 6;
            this.upperMoveBtn.Text = "Upper move";
            this.upperMoveBtn.UseVisualStyleBackColor = true;
            this.upperMoveBtn.Click += new System.EventHandler(this.upperMoveBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(649, 377);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // warpingBtn
            // 
            this.warpingBtn.Location = new System.Drawing.Point(648, 468);
            this.warpingBtn.Name = "warpingBtn";
            this.warpingBtn.Size = new System.Drawing.Size(121, 38);
            this.warpingBtn.TabIndex = 8;
            this.warpingBtn.Text = "Warping";
            this.warpingBtn.UseVisualStyleBackColor = true;
            this.warpingBtn.Click += new System.EventHandler(this.warpingBtn_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(649, 419);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(121, 43);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.warpingBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.upperMoveBtn);
            this.Controls.Add(this.edgesDetecionBtn);
            this.Controls.Add(this.embossBtn);
            this.Controls.Add(this.noiseReductionBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.sharpingBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Window";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button sharpingBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button noiseReductionBtn;
        private System.Windows.Forms.Button embossBtn;
        private System.Windows.Forms.Button edgesDetecionBtn;
        private System.Windows.Forms.Button upperMoveBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button warpingBtn;
        private System.Windows.Forms.Button backButton;
    }
}