using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MyPaint;

namespace Interfase
{
    public interface ISelected
    {
        bool isSelected(Point shpSel, SaveData shpCheck);
    }
}
