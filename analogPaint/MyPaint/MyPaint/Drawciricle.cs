using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawCiricle : Shape
    {

        private Color clr;

        public DrawCiricle(Color clr)
        {
            this.clr = clr;
        }

        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(clr);
            Rectangle rect = new Rectangle(x, y, h, w);
            graph.DrawEllipse(pen, rect);
            graph.Save();

           
            return bmp;
        }

        public override void DrawE(int x, int y, int h, int w, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawEllipse(pen, rect);
        }
    }
}
