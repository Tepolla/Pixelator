using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pixelator
{
    public partial class FullImagePixelation : Form
    {
        public FullImagePixelation(string address)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(address);
        }

    }
}
