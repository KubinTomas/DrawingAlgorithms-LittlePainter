using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LittlePainterProject.Models.Share;
using LittlePainterProject.Models.Managers;

namespace LittlePainterProject.Windows
{
    public partial class MenuControl : UserControl
    {
        public PainterManager painterManager;

        public MenuControl()
        {
            InitializeComponent();

            Init();
        }
        private void Init()
        {
            colorPickerBtn.BackColor = Setting.DefaultColor;

            sizeLbl.Text = Setting.SelectedPixelSize.ToString();
            sizeTrBar.Value = Setting.DefaultPixelSize;

            penBtn.Image = LittlePainterProject.Properties.Resources.pen1;

            InitPreSelectedDefaultColorsBtn();
        }
        private void InitPreSelectedDefaultColorsBtn()
        {
            fastSavedColorBtn1.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn2.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn3.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn4.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn5.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn6.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn7.Click += new EventHandler(onFastSaveColorBtnClick);
            fastSavedColorBtn8.Click += new EventHandler(onFastSaveColorBtnClick);
        }

        private void onFastSaveColorBtnClick(object sender, EventArgs e)
        {
            colorPickerBtn.BackColor = ((Button)sender).BackColor;

            Setting.SelectedColor = ((Button)sender).BackColor;
        }
        private void colorPickerBtn_Click(object sender, EventArgs e)
        {
            colorPicker.AllowFullOpen = true;
   
            colorPicker.Color = colorPickerBtn.BackColor;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorPickerBtn.BackColor = colorPicker.Color;
                Setting.SelectedColor = colorPicker.Color;
            }
        }

        private void sizeTrBar_ValueChanged(object sender, EventArgs e)
        {
            Setting.SelectedPixelSize = sizeTrBar.Value;
            sizeLbl.Text = sizeTrBar.Value.ToString();
        }

        private void circleBtn_Click(object sender, EventArgs e)
        {
            painterManager.SetTool(CircleManager.Tool);
        }
        private void penBtn_Click(object sender, EventArgs e)
        {
            painterManager.SetTool(PenLineManager.Tool);
        }

        private void straightLine_Click(object sender, EventArgs e)
        {
            painterManager.SetTool(StraightLineManager.Tool);
        }

        private void triangleBtn_Click(object sender, EventArgs e)
        {
            painterManager.SetTool(TriangleManager.Tool);
        }

        private void seedFillAlgBtn_Click(object sender, EventArgs e)
        {
            painterManager.SetTool(ColorFillerManager.Tool);
        }
           
      
    }
}
