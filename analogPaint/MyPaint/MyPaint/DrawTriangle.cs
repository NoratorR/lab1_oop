﻿using System;
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

        private Color clr;
        private int pwidth;

        public DrawTriangle(Color clr, int pwidth)
        {
            this.clr = clr;
            this.pwidth = pwidth;
        }

        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Pen pen = new Pen(clr);
            pen.Width = pwidth;
            Point[] point = { new Point(first.X, first.Y), new Point(second.X, second.X), new Point(first.X, second.Y) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);
            graph.Save();

            return bmp;
        }
        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            
            Pen pen = new Pen(clr);
            pen.Width = pwidth;
            PointF[] point = { new PointF(first.X, first.Y), new PointF(second.X,second.X), new PointF(first.X, second.Y) };

            e.Graphics.DrawPolygon(pen, point);
            
        }
    }
}
