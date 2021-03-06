﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint;
using Interfase;
using System.Windows.Forms;
using System.Drawing;



namespace Hexagon
{
    
        public class Hexagon : Shape, ISelected, IEditable
        {
            private Color clr;
            private int pWidth;
            private string name = "Hexagon";

            public Hexagon()
            { }

            public override string GetName()
            {
                return name;
            }


            public override Bitmap Draw(Bitmap bmp, Point first, Point second)
            {
                Pen pen = new Pen(clr);
                pen.Width = pWidth;
                Point point1 = new Point((first.X + second.X) / 2, first.Y);
                Point point2 = new Point(second.X, first.Y + (second.Y - first.Y) / 3);
                Point point3 = new Point(second.X, first.Y + (second.Y - first.Y) / 3 * 2);
                Point point4 = new Point((first.X + second.X) / 2, second.Y);
                Point point5 = new Point(first.X, first.Y + (second.Y - first.Y) / 3 * 2);
                Point point6 = new Point(first.X, first.Y + (second.Y - first.Y) / 3);
                Point[] points = { point1, point2, point3, point4, point5, point6 };

                Graphics graph = Graphics.FromImage(bmp);
                graph.DrawPolygon(pen, points);
                graph.Save();

                return bmp;
            }
            public override void DrawE(Point first, Point second, PaintEventArgs e)
            {

                Pen pen = new Pen(clr);
                pen.Width = pWidth;
                Point point1 = new Point((first.X + second.X) / 2, first.Y);
                Point point2 = new Point(second.X, first.Y + (second.Y - first.Y) / 3);
                Point point3 = new Point(second.X, first.Y + (second.Y - first.Y) / 3 * 2);
                Point point4 = new Point((first.X + second.X) / 2, second.Y);
                Point point5 = new Point(first.X, first.Y + (second.Y - first.Y) / 3 * 2);
                Point point6 = new Point(first.X, first.Y + (second.Y - first.Y) / 3);
                Point[] points = { point1, point2, point3, point4, point5, point6 };

                e.Graphics.DrawPolygon(pen, points);

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
                PointF[] po = { new PointF(svd.one.X, svd.one.Y), new PointF(svd.one.X, svd.two.X), new PointF(svd.one.X, svd.two.Y) };
                graph.FillPolygon(brush, po);
                return bmp;

            }
            public new bool isSelected(Point point, SaveData shpCheck)
            {
                if ((point.X >= shpCheck.one.X && point.X <= shpCheck.two.X) && (point.Y >= shpCheck.one.Y && point.Y <= shpCheck.two.Y))
                    return true;
                else
                    return false;
            }
            public new SaveData MoveToNextPosition(Point shpSel, SaveData shp)
            {
                try
                {
                    shp.two.X = shpSel.X + (Math.Abs(shp.one.X - shp.two.X));
                    shp.two.Y = shpSel.Y + (Math.Abs(shp.one.Y - shp.two.Y));
                    shp.one.X = shpSel.X; shp.one.Y = shpSel.Y;
                    return shp;
                }
                catch
                {
                    return null;
                }
            }
        }
}
