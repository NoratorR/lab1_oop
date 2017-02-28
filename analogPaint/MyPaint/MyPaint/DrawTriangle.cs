using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawTriangle : Shape
    {
       
        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Pen pen = new Pen(Color.Green);
            Point[] point = { new Point(300, 300), new Point(100, 300), new Point(200, 150) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);
            graph.Save();

            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            /*
            Pen pen = new Pen(Color.Green);
            PointF[] point = { new Point(300, 300), new Point}

            e.Graphics.DrawPolygon(pen, Point);
            */
        }
    }
}
