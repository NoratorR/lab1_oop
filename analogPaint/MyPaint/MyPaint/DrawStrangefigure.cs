using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class DrawStrangefigure : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Gray);
            Point[] point = { new Point(50, 200), new Point(100, 10), new Point(300, 250), new Point(400, 250), new Point(20, 100), new Point(150, 200) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;

        }
    }
}
