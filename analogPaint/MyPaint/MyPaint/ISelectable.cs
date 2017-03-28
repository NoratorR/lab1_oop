using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyPaint
{
    public interface ISelected
    {
        bool isSelected(Point shpSel, SaveData shpCheck);

    }

    public interface IEditable
    {
        SaveData MoveToNextPosition(Point shpSel,SaveData shp);
        
        
    }

    public interface IResizable
    {
        bool CheckIfResize(List<SaveData> svd, Point point);
    }
}
