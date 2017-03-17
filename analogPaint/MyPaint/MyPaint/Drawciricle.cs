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
    public  class DrawCiricle : Shape
    {

        private Color clr;
        private int pWidth;
        
        public DrawCiricle()
        { }


        public override Bitmap Draw(Bitmap bmp, int x, int y, int h, int w, Point first, Point second)
        {
            Graphics graph = Graphics.FromImage(bmp);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(x, y, h, w);
            graph.DrawEllipse(pen, rect);
            graph.Save();
         
           
            return bmp;
        }

       

        public override void DrawE(int x, int y, int h, int w, Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(clr);
            pen.Width = pWidth;
            Rectangle rect = new Rectangle(x, y, h, w);
            e.Graphics.DrawEllipse(pen, rect);
        }

        public override void getAtributs(Color clr, int pWidth)
        {
            this.pWidth = pWidth;
            this.clr = clr;

        }
    }
}
