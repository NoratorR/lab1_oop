using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{ 
   [Serializable]
   public  class SaveData
    {
        public string clr;
        public int pWidth;
        public int x;
        public int y;
        public int h;
        public int w;

        public Point one;

        public Point two; 

        public string temp;

        public SaveData() { }

        public SaveData(int x, int y, int w, int h, Point one, Point two, Shape temp, int pWidth, string clr  )
        {
            this.temp = temp.ToString();
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.one = one;
            this.two = two;
            this.pWidth = pWidth;
            this.clr = clr;

        }


    }
}
