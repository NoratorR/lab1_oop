using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
   public abstract class Shape
    {
        public abstract Bitmap Draw(Bitmap bmp);
    }

    class Draw_Rectangle : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            graph.DrawRectangle(pen,50, 50, 270, 300);
            return bmp;
        }
    }

    class Draw_Ciricle : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Blue);
            Rectangle rect = new Rectangle(100, 100, 340, 310);
            graph.DrawEllipse(pen, rect);
            return bmp;
        }
    }

    class Draw_Line : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Red);
            graph.DrawLine(pen, 100, 50, 400, 300);
            return bmp;
              
        }
    }


}
