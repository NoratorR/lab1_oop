using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class DrawRectangle : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            graph.DrawRectangle(pen, 50, 50, 270, 300);
            return bmp;
        }
    }
}
