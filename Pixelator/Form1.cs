namespace Pixelator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Upon button click, the file explorer will be opened, and if a valid file is selected,
        // A new window containing the image and a slider will be opened while the current window,
        // is hidden. If an invalid file is selected, an error will be displayed as a message box.
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image Files(*.jpeg;*.jpg;*.png;*.gif;*.bmp)|*.jpeg;*.jpg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    if (filePath != null)
                    {
                        FullImagePixelation FIP = new FullImagePixelation(filePath);
                        FIP.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: Could not read file from disk. Original error: {ex.Message}");
                }
            }

            button1.Visible = false;

        }
    }
}