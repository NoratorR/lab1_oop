using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class DrawStar : Shape
    {

        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Magenta);
            Point[] point = { new Point(0, 0), new Point(100, 10), new Point(300, 250), new Point(150, 200), new Point(200, 150) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;
        }
    }
}
