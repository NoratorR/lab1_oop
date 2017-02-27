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
        public List<Shape> shp = new List<Shape>();
        private Shape temp;

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

        private void exportDataToController(Shape tmp)
        {
            Bmp = tmp.Draw(Bmp);
            shp.Add(tmp);
            pictureBox1.Image = Bmp;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Draw_Line temp = new Draw_Line();
            exportDataToController(temp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawCiricle temp = new DrawCiricle();
            exportDataToController(temp);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawRectangle temp = new DrawRectangle();
            exportDataToController(temp);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawTriangle temp = new DrawTriangle();
            exportDataToController(temp);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawStar temp = new DrawStar();
            exportDataToController(temp);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            DrawStrangefigure temp = new DrawStrangefigure();
            exportDataToController(temp);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bmp.Dispose();
            shp.Clear();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }
    }
}
