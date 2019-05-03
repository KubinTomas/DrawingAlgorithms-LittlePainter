using DrawingAlgorithms.Algorithms;
using DrawingAlgorithms.Settings;
using FillingAlgorithms;
using CoonsCubic;
using ImageFiltersAlgorithms;
using EditablePointsOnPolynom;
using Line.LineAlgorithms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingAlgorithms
{
    public partial class Default : Form
    {
        private Bresenham _bresenham;
        private CircleAlg _circleAlg;

        public Default()
        {
            InitializeComponent();
            this.InitSettings();

            _bresenham = new Bresenham();
            _circleAlg = new CircleAlg();

            CreateNewBitmap();

            //_bresenham.DrawLine();

        }


        private void InitSettings()
        {
            this.Size = WindowSetting.Size;
            this.StartPosition = WindowSetting.StartPosition;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            var bimap = new Bitmap(openFileDialog.OpenFile());

            pictureBox.Image = bimap;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ((ComboBox)sender).SelectedIndex;

            switch (selectedIndex)
            {
                case 0:
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = panel1.Size;
                    panel1.AutoScroll = false;
                    break;
                case 1:
                    pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox.Size = pictureBox.Image.Size;
                    panel1.AutoScroll = true;
                    break;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            using (Stream stream = saveFileDialog.OpenFile())
            {
                var bitmap = new Bitmap(pictureBox.Image);
                bitmap.Save(stream, ImageFormat.Bmp);
            }
        }

        private void btnDrawCircle_Click(object sender, EventArgs e)
        {
            var bitmap = (Bitmap)pictureBox.Image;
            var center = new Point(bitmap.Width / 2, bitmap.Height / 2);
            var circleRadius = 50;

            _circleAlg.Draw(center, circleRadius, bitmap);

            pictureBox.Image = bitmap;
        }

        private void btnNewBitmap_Click(object sender, EventArgs e)
        {
            CreateNewBitmap();
        }
        private void CreateNewBitmap()
        {
            var bitmap = new Bitmap(1, 1);
            bitmap.SetPixel(0, 0, Color.Black);

            var scaledBitmap = new Bitmap(bitmap, 400, 400);

            pictureBox.Image = scaledBitmap;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            var grapgics = e.Graphics;
            var image = (Bitmap)pictureBox.Image;

            var location = new Point(image.Width / 2, image.Height / 2);
            var circleRadius = 40;
            var radius = new Size(circleRadius, circleRadius);

            //center, circleRadius, bitmap
            grapgics.DrawEllipse(Pens.Blue, new RectangleF(location, radius));
        }

        /// <summary>
        /// Drawing ellipse on click
        /// Not working when img is zoomed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            var pen = Pens.Black;

            var mouseClickLocation = ((MouseEventArgs)e);

            var image = (Bitmap)pictureBox.Image;

            if (image == null) return;

            image.SetPixel(mouseClickLocation.X, mouseClickLocation.Y, Color.Blue);

            //Setting graphics relative to image 
            var graphics = Graphics.FromImage(image);

            var ellipseSize = 16;

            graphics.DrawEllipse(Pens.Red, mouseClickLocation.X - ellipseSize/2, mouseClickLocation.Y - ellipseSize/2, ellipseSize, ellipseSize);

            pictureBox.Refresh();


            //Setting graphics relative to picture box
            graphics = pictureBox.CreateGraphics();
            graphics.DrawEllipse(Pens.Red, mouseClickLocation.X - ellipseSize / 2, mouseClickLocation.Y - ellipseSize / 2, ellipseSize, ellipseSize);

        }
        /// <summary>
        /// This is correct and faster solutin to change pictures, dont use SET PIXELS, ...
        /// </summary>
        private void ChangeBits()       //(PaintEventArgs e)
        {
            Bitmap bmp = (Bitmap)pictureBox.Image;

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);        // uzamknut� bit� bitmapy v pameti
            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);  // metoda objektu Bitmap, vrac� strukturu pro pr�ci s bitmapou

            IntPtr ptr = bmpData.Scan0;                         // ukazatel na zacatek dat bitmapy - adresa prvn�ho pixelu (1. ��dek)

            int bytes = Math.Abs(bmpData.Stride) * bmp.Height;  // zjisteni velikosti: (3 x ���ka) x v��ka; stride z�porn�, kdy� obr. vzh�ru nohama
            byte[] RGB = new byte[bytes];                       // deklarace jednorozm�rn�ho pole pro byty bitmapy o velikosti bytes

            Marshal.Copy(ptr, RGB, 0, bytes);                   // kopirovat obsah pameti obrazku (unmanaged) do pole (RGB)

            for (int i = 1; i < RGB.Length; i += 3)             // vlastn�i operace s pixely; nap�. nastaven� v�ech G na 255
                RGB[i] = 255;

            Marshal.Copy(RGB, 0, ptr, bytes);                   // kopirovat hodnoty RGB zp�tky do bitmapy
            bmp.UnlockBits(bmpData);                            // unlock bit�

            pictureBox.Image = bmp;
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            ChangeBits();
        }

        private void btnOpenFillWindow_Click(object sender, EventArgs e)
        {
            var form = new FillingAlgorithms.Window().ShowDialog();
        }

        private void openImageFilterFormBtn_Click(object sender, EventArgs e)
        {
            var form = new ImageFiltersAlgorithms.Window().ShowDialog();
        }

        private void curveFormBtn_Click(object sender, EventArgs e)
        {
            var form = new Curves.Window().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new CoonsCubic.Window().ShowDialog();
        }

        private void editablePolynomBtn_Click(object sender, EventArgs e)
        {
            var form = new EditablePointsOnPolynom.Window().ShowDialog();
        }

        private void imgProcessingBtn_Click(object sender, EventArgs e)
        {
            var form = new ImageProcessing.Window().ShowDialog();
        }

        private void littlePainterBtn_Click(object sender, EventArgs e)
        {
            var form = new LittlePainterProject.MainWindow().ShowDialog();
        }
    }
}
