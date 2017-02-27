using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class DrawCiricle : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Blue);
            Rectangle rect = new Rectangle(100, 100, 340, 310);
            graph.DrawEllipse(pen, rect);
            return bmp;
        }
    }
}
