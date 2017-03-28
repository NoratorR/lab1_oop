using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MyPaint
{
   
    public class Selected : ISelected
    {
       public  bool isSelected(Point point, SaveData shpCheck)
        {
            if ((point.X >= shpCheck.one.X && point.X <= shpCheck.two.X) && (point.Y >= shpCheck.one.Y && point.Y <= shpCheck.two.Y))
                return true;
            else
                return false;
        }

        public SaveData ChooseSelectFig(Point point,ref List<SaveData> shp)
        {
            SaveData temp = null;
        
            try
            {
                foreach (SaveData svd in shp)
                {

                    if (isSelected(point, svd))
                    {
                        temp = svd;
                        break;
                    }
                 
                }
                return temp;
            }
            catch
            {
                return null;
            }
         
          
        }
    }
}
