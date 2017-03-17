using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyPaint
{
   public interface ISelected 
    {
      bool isSelected( Shape shpSel, Shape  shpCheck);

    }


    public class Selected : ISelected
    {
       public  bool isSelected(Shape shpSel, Shape shpCheck)
        {

           return true;
        }
    }
}
