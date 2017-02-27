using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class DrawTriangle : Shape
    {

        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Green);
            Point[] point = { new Point(300, 300), new Point(100, 300), new Point(200, 150) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;
        }
    }
}
