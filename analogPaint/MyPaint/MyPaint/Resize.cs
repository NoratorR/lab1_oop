using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    class Resize: IResizable
    {
        public bool CheckIfResize(List<SaveData> svd, Point point)
        {
            foreach(SaveData sv in svd)
            {
                if ((sv.one.X == point.X && sv.one.Y == point.Y) || (sv.two.X == point.X && sv.one.Y == point.Y) || (sv.two.X == point.X && sv.two.Y == point.Y) || (sv.one.X == point.X && sv.two.Y == point.Y))
                    return true; 
            }
            return false;
        }
    }
}
