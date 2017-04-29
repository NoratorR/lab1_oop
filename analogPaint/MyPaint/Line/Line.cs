using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint;
using Interfase;
using System.Windows.Forms;
using System.Drawing;

namespace Line
{
    [Serializable]
    public class Line : Shape, ISelected, IEditable
    {

        private Color clr;
        private int pWidth;
        private string name = "Line";

        public Line()
        { }


        public override string GetName()
        {
            return name;
        }

        public override Bitmap Draw(Bitmap bmp, Point first, Point second)
        {

            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            graph.DrawLine(pen, first.X, first.Y, second.X, second.Y);
            graph.Save();
            return bmp;

        }
        public override void DrawE(Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            e.Graphics.DrawLine(pen, first.X, first.Y, second.X, second.Y);
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
