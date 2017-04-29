using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Interfase;


namespace MyPaint
{
    [Serializable]
    public abstract class Shape : ISelected, IEditable
    {
        public abstract Bitmap Draw(Bitmap bmp, Point first, Point second);
        public abstract void DrawE(Point first, Point second, PaintEventArgs e);
        public abstract void getAtributs(Color clr, int pwidth);
        public abstract Bitmap ChangeColor(Bitmap bmp, Color Current, SaveData svd);

        public abstract string GetName(); 

        public bool isSelected(Point point, SaveData shpCheck)
        {
            return false;
        }



        public SaveData MoveToNextPosition(Point shpSel, SaveData shp)
        {
            return shp;
        }
    }


}



