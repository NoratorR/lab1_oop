using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MyPaint
{
    class DrawStar : Shape, ISelected, IEditable
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
