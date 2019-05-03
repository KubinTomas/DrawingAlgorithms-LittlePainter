namespace CoonsCubic
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
            this.newCurveBtn = new System.Windows.Forms.Button();
            this.deleteCurveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newCurveBtn
            // 
            this.newCurveBtn.Location = new System.Drawing.Point(687, 703);
            this.newCurveBtn.Name = "newCurveBtn";
            this.newCurveBtn.Size = new System.Drawing.Size(85, 46);
            this.newCurveBtn.TabIndex = 0;
            this.newCurveBtn.Text = "New curve";
            this.newCurveBtn.UseVisualStyleBackColor = true;
            this.newCurveBtn.Click += new System.EventHandler(this.newCurveBtn_Click);
            // 
            // deleteCurveBtn
            // 
            this.deleteCurveBtn.Location = new System.Drawing.Point(687, 651);
            this.deleteCurveBtn.Name = "deleteCurveBtn";
            this.deleteCurveBtn.Size = new System.Drawing.Size(85, 46);
            this.deleteCurveBtn.TabIndex = 1;
            this.deleteCurveBtn.Text = "Delete curve";
            this.deleteCurveBtn.UseVisualStyleBackColor = true;
            this.deleteCurveBtn.Click += new System.EventHandler(this.deleteCurveBtn_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.deleteCurveBtn);
            this.Controls.Add(this.newCurveBtn);
            this.Name = "Window";
            this.Text = "Window";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Window_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newCurveBtn;
        private System.Windows.Forms.Button deleteCurveBtn;
    }
}