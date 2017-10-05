using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GewinntLib.Interfaces
{
    public interface IPlace
    {
        int X { get; }
        int Y { get; }
        IStone Content { get; set; }
    }
}
