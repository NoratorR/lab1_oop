using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    public partial class Form1 : Form
    {
        private Bitmap Bmp;
        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Draw_Line line = new Draw_Line();
            Bmp = line.Draw(Bmp);
            pictureBox1.Image = Bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Draw_Ciricle crc = new Draw_Ciricle();
            Bmp = crc.Draw(Bmp);
            pictureBox1.Image = Bmp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Draw_Rectangle rect = new Draw_Rectangle();
            Bmp = rect.Draw(Bmp);
            pictureBox1.Image = Bmp;

        }
    }
}
