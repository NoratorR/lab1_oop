using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    [Serializable]
    public class SaveData
    {
        public int clr;
        public int pWidth;

        public Point one;

        public Point two;

        public string temp;

        public SaveData() { }
        public int fclr;

        public SaveData(Point one, Point two, Shape temp, int pWidth, int clr, int fclr)
        {
            this.temp = temp.ToString();
            this.one = one;
            this.two = two;
            this.pWidth = pWidth;
            this.clr = clr;
            this.fclr = fclr;

        }


    }
}
