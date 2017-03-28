using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawRectangle : Shape
    {

        protected Color clr;
        protected int pWidth;

        public DrawRectangle()
        { }

     
        public override Bitmap Draw(Bitmap bmp, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            graph.DrawRectangle(pen, Math.Min(first.X, second.X), Math.Min(first.Y, second.Y), Math.Abs(first.X - second.X), Math.Abs(first.Y - second.Y));
            graph.Save();
            
     
            return bmp;
        }
        public override void DrawE( Point first, Point second, PaintEventArgs e)
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
            graph.FillRectangle(brush,new Rectangle (Math.Min(svd.one.X, svd.two.X), Math.Min(svd.one.Y, svd.two.Y), Math.Abs(svd.one.X - svd.two.X), Math.Abs(svd.one.Y - svd.two.Y)));
            return bmp;

        }

    }

    
}
