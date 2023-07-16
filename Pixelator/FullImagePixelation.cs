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
            /*
            // _____________________________________________________

            int currentValue = trackBar1.Value;
            if (currentValue != previousValue)
            {
                ///////////////////////////////////////////////////////

                double reducedXDouble = pictureBox1.Width / (double)trackBar1.Value;
                double reducedYDouble = pictureBox1.Height / (double)trackBar1.Value;
                int reducedX = (int)Math.Ceiling(reducedXDouble);
                int reducedY = (int)Math.Ceiling(reducedYDouble);

                // Load an image into a Bitmap object
                Bitmap bmp = new Bitmap(address);

                // Creating a new bitmap with specific dimensions
                Bitmap newBmp = new Bitmap(reducedX, reducedY);

                int row = 0;
                for (int x = 0; x < bmp.Width; x += reducedX, row++)
                {
                    int col = 0; // Reset column at the start of each new row
                    for (int y = 0; y < bmp.Height; y += reducedY, col++)
                    {
                        // Ensure we don't go out of bounds
                        int safeX = Math.Min(x, bmp.Width - 1);
                        int safeY = Math.Min(y, bmp.Height - 1);

                        // Access a pixel within the bitmap
                        Color pixelColor = bmp.GetPixel(safeX, safeY);

                        // Set a pixel color in the new bitmap
                        if (row < newBmp.Width && col < newBmp.Height)
                        {
                            newBmp.SetPixel(row, col, pixelColor);
                        }
                    }
                }

                pictureBox1.Image = newBmp; // set image to the new bitmap
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                ///////////////////////////////////////////////////////
                previousValue = currentValue;
            }
            // _____________________________________________________
            */



            int currentValue = trackBar1.Value;
            if (currentValue != previousValue)
            {





                Bitmap bmp = new Bitmap(this.address);

            // CONSIDER SWITCHING THE TYPE TO DOUBLE
            double heightDivisor = (trackBar1.Value / 100.0) * bmp.Height;
            double widthDivisor = (trackBar1.Value / 100.0) * bmp.Width;

            int newHeight = (int)Math.Ceiling(bmp.Height / heightDivisor);
            int newWidth = (int)Math.Ceiling(bmp.Width / widthDivisor);

            Bitmap newBmp = new Bitmap(newWidth, newHeight); // Creates new bitmap based on updated resolution

            int row = 0;
            for(int y = 0; y < newHeight; y++)
            {
                int col = 0;
                for(int x = 0; x < newWidth; x++)
                {
                    Color pixelColor = bmp.GetPixel(x, y);
                    newBmp.SetPixel(col, row, pixelColor);
                    col++;
                }
                row++;
            }

            pictureBox1.Image = newBmp;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;






            previousValue = currentValue;

                bmp.Dispose();  // Dispose the old bitmap
            }    

        }


    }
}



/*
private int previousValue = 0;

private void trackBar1_ValueChanged(object sender, EventArgs e)
{
    int currentValue = trackBar1.Value;
    if (currentValue != previousValue)
    {
        Bitmap bmp;
        try
        {
            bmp = new Bitmap(this.address);
        }
        catch
        {
            MessageBox.Show("Image file could not be opened.");
            return;
        }
        
        double heightDivisor = (trackBar1.Value / 100.0) * bmp.Height;
        double widthDivisor = (trackBar1.Value / 100.0) * bmp.Width;

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

        bmp.Dispose();  // Dispose the old bitmap
    }
}

 */