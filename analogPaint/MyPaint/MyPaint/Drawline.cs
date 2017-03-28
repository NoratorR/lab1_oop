using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawPencil : Shape
    {
        private Color clr;
        private int pWidth;

        public   DrawPencil()
        { }

       
        public override Bitmap Draw(Bitmap bmp,  Point first, Point second)
        {

            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            graph.DrawLine(pen, first.X,first.Y,second.X,second.Y);
            graph.Save();
            return bmp;

        }
        public override void DrawE( Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            e.Graphics.DrawLine(pen, first.X,first.Y,second.X,second.Y);
        }

        public override void getAtributs(Color clr, int pWidth)
        {
            this.pWidth = pWidth;
            this.clr = clr;

        }
        public override Bitmap ChangeColor(Bitmap bmp, Color Current, SaveData svd)
        {
            Graphics graph = Graphics.FromImage(bmp);
            var brush = new SolidBrush(Current);
            PointF[] po = { new PointF(svd.one.X, svd.one.Y), new PointF(svd.two.X, svd.two.Y) };
            graph.FillPolygon(brush, po);
            return bmp;

        }
    }
}

