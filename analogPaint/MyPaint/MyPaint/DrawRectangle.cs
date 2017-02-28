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

        public DrawRectangle(Color clr)
        {
            this.clr = clr;
        }
        
        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            graph.DrawRectangle(pen, x,y,h,w);
            graph.Save();
          
            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawRectangle(pen, rect);
        }
    }
}
