using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
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

