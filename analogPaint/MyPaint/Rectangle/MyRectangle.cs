using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint;
using Interfase;
using System.Windows.Forms;
using System.Drawing;

namespace MyRectangle
{
    public class MyRectangle : Shape, ISelected, IEditable
    {
        protected Color clr;
        protected int pWidth;
        private string name = "MyRectangle";

        public MyRectangle()
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
            graph.DrawRectangle(pen, Math.Min(first.X, second.X), Math.Min(first.Y, second.Y), Math.Abs(first.X - second.X), Math.Abs(first.Y - second.Y));
            graph.Save();


            return bmp;
        }
        public override void DrawE(Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(Math.Min(first.X, second.X), Math.Min(first.Y, second.Y), Math.Abs(first.X - second.X), Math.Abs(first.Y - second.Y));
            e.Graphics.DrawRectangle(pen, rect);
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
            graph.FillRectangle(brush, new Rectangle(Math.Min(svd.one.X, svd.two.X), Math.Min(svd.one.Y, svd.two.Y), Math.Abs(svd.one.X - svd.two.X), Math.Abs(svd.one.Y - svd.two.Y)));
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
