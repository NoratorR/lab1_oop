using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    public class Move : IEditable
    {
        public SaveData MoveToNextPosition(Point shpSel, SaveData shp)
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

          public  List<SaveData> DelateFromList(List<SaveData> svd, SaveData figg)
        {
            foreach(SaveData sd in svd)
                if(figg == sd)
                {
                   // svd.Remove(figg);
                    break;
                }
            return svd;
        }
         

        }

      
           
        
    }

