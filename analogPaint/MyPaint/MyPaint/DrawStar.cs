using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawStar : Shape
    {
        private Color clr;
        private int pWidth;

        public override Bitmap Draw(Bitmap bmp, Point first, Point second)
        {

            return bmp;
        }
        public override void DrawE(Point first, Point second, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
          
        
        }
        public override void getAtributs(Color clr, int pWidth)
        {
            this.pWidth = pWidth;
            this.clr = clr;

        }
        public override Bitmap ChangeColor(Bitmap bmp, Color Current, SaveData svd)
        {
            
            return bmp;

        }
    }
}
