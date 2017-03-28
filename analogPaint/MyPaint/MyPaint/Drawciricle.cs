using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    [Serializable]
    public class DrawCiricle : Shape
    {

        private Color clr;
        private int pWidth;

        public DrawCiricle()
        { }


        public override Bitmap Draw(Bitmap bmp, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(Math.Min(first.X, second.X), Math.Min(first.Y, second.Y), Math.Abs(first.X - second.X), Math.Abs(first.Y - second.Y));
            graph.DrawEllipse(pen, rect);
            graph.Save();


            return bmp;
        }



        public override void DrawE(Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(Math.Min(first.X,second.X), Math.Min(first.Y,second.Y), Math.Abs(first.X - second.X), Math.Abs(first.Y - second.Y));
            e.Graphics.DrawEllipse(pen, rect);
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
            graph.FillEllipse(brush, new Rectangle (svd.one.X, svd.one.Y, svd.two.X, svd.two.Y));
            return bmp;

        }

    }

    }
