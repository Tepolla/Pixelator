using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixelator
{
    public partial class FullImagePixelation : Form
    {

        private string address = string.Empty;

        public FullImagePixelation(string address)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(address);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.address = address;
        }

        private int previousValue = 0;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int currentValue = trackBar1.Value;
            if (currentValue != previousValue)
            {
                Bitmap bmp = new Bitmap(this.address);

                // Using 1000.0 allows for a smaller and more specific range of pixelation
                double heightDivisor = (trackBar1.Value / 1000.0) * bmp.Height;
                double widthDivisor = (trackBar1.Value / 1000.0) * bmp.Width;

            int newHeight = (int)Math.Ceiling(bmp.Height / heightDivisor);
            int newWidth = (int)Math.Ceiling(bmp.Width / widthDivisor);

        Bitmap newBmp = new Bitmap(newWidth, newHeight);

        for (int y = 0; y < newHeight; y++)
        {
            for (int x = 0; x < newWidth; x++)
            {
                // Scale indices back to original bitmap dimensions.
                int origX = x * bmp.Width / newWidth;
                int origY = y * bmp.Height / newHeight;
                Color pixelColor = bmp.GetPixel(origX, origY);
                newBmp.SetPixel(x, y, pixelColor);
            }
        }

        pictureBox1.Image = newBmp;
        pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

        previousValue = currentValue;
            }
        }


    }
}