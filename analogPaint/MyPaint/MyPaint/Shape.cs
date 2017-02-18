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

    class Draw_Triangle : Shape
    {

        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Green);
            Point[] point = { new Point(10, 10), new Point(100, 10), new Point(200, 150) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;
        }
    }

    class Draw_fiveAngel : Shape
    {

        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Yellow);
            Point[] point = { new Point(10, 10), new Point(100, 10), new Point(300, 250), new Point(150, 200), new Point(200, 150) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;
        }
    }

    class Draw_sixAngel : Shape
    {
        public override Bitmap Draw(Bitmap bmp)
        {
            Pen pen = new Pen(Color.Violet);
            Point[] point = { new Point(10, 10), new Point(100, 10), new Point(300, 250), new Point(400, 250), new Point(20, 100), new Point(150, 200) };

            Graphics graph = Graphics.FromImage(bmp);
            graph.DrawPolygon(pen, point);

            return bmp;

        }
    }
  }
    

    
