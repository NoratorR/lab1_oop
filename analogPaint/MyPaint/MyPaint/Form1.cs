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
        private bool press = false;
        private Point one;
        private Point two;
        private Color Current = Color.Black;
        private Shape temp;
        private int x, y, w, h;

        public Form1()
        {
            InitializeComponent();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true; 
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (temp != null && press)
            {
                
            }
        }

    

        private void button1_Click_1(object sender, EventArgs e)
        {
            DrawLine temp = new DrawLine();
            this.temp = temp;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DrawCiricle temp = new DrawCiricle(Current);
            this.temp = temp;
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrawRectangle temp = new DrawRectangle(Current);
            this.temp = temp;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DrawTriangle temp = new DrawTriangle();
            this.temp = temp;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawStar temp = new DrawStar();
            this.temp = temp;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            DrawStrangefigure  temp = new DrawStrangefigure();
            this.temp = temp;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            Bmp.Dispose();
            shp.Clear();
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Bmp = bmp;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dlg = colorDialog1.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                Current = colorDialog1.Color;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (temp != null && press)
            {
                two = e.Location;

                pictureBox1.Refresh();
               

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (temp != null && press)
            {
                 countCanvasPoints();
                temp.DrawE(x,y,h,w,e);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (temp != null)
            {
                press = false;
              
                Bmp = temp.Draw(Bmp, x, y, h, w, one, two);
                pictureBox1.Image = Bmp;

            }
           
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (temp != null)
            {
                press = true;
                one = e.Location;
           
            
            }
        }


        public void countCanvasPoints()
        {
            x = Math.Min(one.X, two.X);
            y = Math.Min(one.Y, two.Y);
            h = Math.Abs(one.X - two.X);
            w = Math.Abs(one.Y - two.Y);
        }

      
    }
}
