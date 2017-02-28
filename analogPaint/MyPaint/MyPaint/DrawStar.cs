using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawStar : Shape
    {

        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {

            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawEllipse(pen, rect);
        }
    }
}
