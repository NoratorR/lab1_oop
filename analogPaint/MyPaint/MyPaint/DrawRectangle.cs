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

        protected Color clr;
        protected int pWidth;

        public DrawRectangle()
        { }

     

        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            graph.DrawRectangle(pen, x, y, h, w);
            graph.Save();

            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawRectangle(pen, rect);
        }

        public override void getAtributs(Color clr, int pWidth)
        {
            this.pWidth = pWidth;
            this.clr = clr;

        }
    }

    
}
