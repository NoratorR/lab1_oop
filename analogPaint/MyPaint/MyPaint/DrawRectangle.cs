using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawRectangle : Shape
    {

        private Color clr;
        private int pwidth;

        public DrawRectangle(Color clr, int pwidth)
        {
            this.clr = clr;
            this.pwidth = pwidth;
        }
        
        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            pen.Width = pwidth;
            graph.DrawRectangle(pen, x,y,h,w);
            graph.Save();
          
            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pwidth;
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
