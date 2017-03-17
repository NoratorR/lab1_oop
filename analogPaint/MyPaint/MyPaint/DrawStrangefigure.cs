using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawLine : Shape
    {

        private Color clr;
        private int pWidth;

        public DrawLine()
        { }

       
        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            graph.DrawLine(pen, first.X, first.Y, second.X, second.Y);
            return bmp;

        }
        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            e.Graphics.DrawLine(pen, first.X,first.Y,second.X,second.Y);
        }

        public override void getAtributs(Color clr, int pWidth)
        {
            this.pWidth = pWidth;
            this.clr = clr;

        }
    }
}
