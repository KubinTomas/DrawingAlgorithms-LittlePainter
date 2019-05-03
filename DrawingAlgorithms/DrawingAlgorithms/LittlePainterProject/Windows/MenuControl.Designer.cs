namespace LittlePainterProject.Windows
{
    partial class MenuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.colorPickerBtn = new System.Windows.Forms.Button();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.sizeLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeTrBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.redrawBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.clearnBtn = new System.Windows.Forms.Button();
            this.saveImageBtn = new System.Windows.Forms.Button();
            this.triangleBtn = new System.Windows.Forms.Button();
            this.straightLine = new System.Windows.Forms.Button();
            this.circleBtn = new System.Windows.Forms.Button();
            this.penBtn = new System.Windows.Forms.Button();
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // colorPickerBtn
            // 
            this.colorPickerBtn.Location = new System.Drawing.Point(164, 19);
            this.colorPickerBtn.Name = "colorPickerBtn";
            this.colorPickerBtn.Size = new System.Drawing.Size(73, 46);
            this.colorPickerBtn.TabIndex = 1;
            this.colorPickerBtn.UseVisualStyleBackColor = true;
            this.colorPickerBtn.Click += new System.EventHandler(this.colorPickerBtn_Click);
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.sizeLbl);
            this.settingsGroupBox.Controls.Add(this.label1);
            this.settingsGroupBox.Controls.Add(this.sizeTrBar);
            this.settingsGroupBox.Controls.Add(this.colorPickerBtn);
            this.settingsGroupBox.Location = new System.Drawing.Point(420, 6);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(253, 138);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // sizeLbl
            // 
            this.sizeLbl.AutoSize = true;
            this.sizeLbl.Location = new System.Drawing.Point(44, 74);
            this.sizeLbl.Name = "sizeLbl";
            this.sizeLbl.Size = new System.Drawing.Size(13, 13);
            this.sizeLbl.TabIndex = 3;
            this.sizeLbl.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size:";
            // 
            // sizeTrBar
            // 
            this.sizeTrBar.LargeChange = 1;
            this.sizeTrBar.Location = new System.Drawing.Point(6, 93);
            this.sizeTrBar.Maximum = 20;
            this.sizeTrBar.Minimum = 1;
            this.sizeTrBar.Name = "sizeTrBar";
            this.sizeTrBar.Size = new System.Drawing.Size(231, 45);
            this.sizeTrBar.TabIndex = 0;
            this.sizeTrBar.Value = 1;
            this.sizeTrBar.ValueChanged += new System.EventHandler(this.sizeTrBar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.triangleBtn);
            this.groupBox1.Controls.Add(this.straightLine);
            this.groupBox1.Controls.Add(this.circleBtn);
            this.groupBox1.Controls.Add(this.penBtn);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 138);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.redrawBtn);
            this.groupBox2.Controls.Add(this.newBtn);
            this.groupBox2.Controls.Add(this.clearnBtn);
            this.groupBox2.Controls.Add(this.saveImageBtn);
            this.groupBox2.Location = new System.Drawing.Point(679, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(124, 138);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls";
            // 
            // redrawBtn
            // 
            this.redrawBtn.Image = global::LittlePainterProject.Properties.Resources.redrawIcon;
            this.redrawBtn.Location = new System.Drawing.Point(62, 71);
            this.redrawBtn.Name = "redrawBtn";
            this.redrawBtn.Size = new System.Drawing.Size(50, 50);
            this.redrawBtn.TabIndex = 7;
            this.redrawBtn.UseVisualStyleBackColor = true;
            // 
            // newBtn
            // 
            this.newBtn.Image = global::LittlePainterProject.Properties.Resources.newIcon;
            this.newBtn.Location = new System.Drawing.Point(6, 71);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(50, 50);
            this.newBtn.TabIndex = 6;
            this.newBtn.UseVisualStyleBackColor = true;
            // 
            // clearnBtn
            // 
            this.clearnBtn.Image = global::LittlePainterProject.Properties.Resources.clearicon;
            this.clearnBtn.Location = new System.Drawing.Point(62, 15);
            this.clearnBtn.Name = "clearnBtn";
            this.clearnBtn.Size = new System.Drawing.Size(50, 50);
            this.clearnBtn.TabIndex = 5;
            this.clearnBtn.UseVisualStyleBackColor = true;
            // 
            // saveImageBtn
            // 
            this.saveImageBtn.Image = global::LittlePainterProject.Properties.Resources.saveIcon1;
            this.saveImageBtn.Location = new System.Drawing.Point(6, 15);
            this.saveImageBtn.Name = "saveImageBtn";
            this.saveImageBtn.Size = new System.Drawing.Size(50, 50);
            this.saveImageBtn.TabIndex = 4;
            this.saveImageBtn.UseVisualStyleBackColor = true;
            // 
            // triangleBtn
            // 
            this.triangleBtn.Image = global::LittlePainterProject.Properties.Resources.triangleCursor;
            this.triangleBtn.Location = new System.Drawing.Point(174, 19);
            this.triangleBtn.Name = "triangleBtn";
            this.triangleBtn.Size = new System.Drawing.Size(50, 50);
            this.triangleBtn.TabIndex = 3;
            this.triangleBtn.UseVisualStyleBackColor = true;
            this.triangleBtn.Click += new System.EventHandler(this.triangleBtn_Click);
            // 
            // straightLine
            // 
            this.straightLine.Image = global::LittlePainterProject.Properties.Resources.straightLineCursor1;
            this.straightLine.Location = new System.Drawing.Point(62, 19);
            this.straightLine.Name = "straightLine";
            this.straightLine.Size = new System.Drawing.Size(50, 50);
            this.straightLine.TabIndex = 2;
            this.straightLine.UseVisualStyleBackColor = true;
            this.straightLine.Click += new System.EventHandler(this.straightLine_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.Image = global::LittlePainterProject.Properties.Resources.circleCursor1;
            this.circleBtn.Location = new System.Drawing.Point(118, 19);
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.Size = new System.Drawing.Size(50, 50);
            this.circleBtn.TabIndex = 1;
            this.circleBtn.UseVisualStyleBackColor = true;
            this.circleBtn.Click += new System.EventHandler(this.circleBtn_Click);
            // 
            // penBtn
            // 
            this.penBtn.Image = global::LittlePainterProject.Properties.Resources.pen1;
            this.penBtn.Location = new System.Drawing.Point(6, 19);
            this.penBtn.Name = "penBtn";
            this.penBtn.Size = new System.Drawing.Size(50, 50);
            this.penBtn.TabIndex = 0;
            this.penBtn.UseVisualStyleBackColor = true;
            this.penBtn.Click += new System.EventHandler(this.penBtn_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingsGroupBox);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(1500, 150);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeTrBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button penBtn;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Button colorPickerBtn;
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.Label sizeLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar sizeTrBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button circleBtn;
        private System.Windows.Forms.Button straightLine;
        private System.Windows.Forms.Button triangleBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveImageBtn;
        private System.Windows.Forms.Button redrawBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button clearnBtn;
    }
}
