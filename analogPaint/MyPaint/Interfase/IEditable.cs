using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPaint;
using System.Drawing;

namespace Interfase
{
    public interface IEditable
    {
        SaveData MoveToNextPosition(Point shpSel, SaveData shp);
    }
}
