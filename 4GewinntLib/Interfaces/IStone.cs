using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GewinntLib.Interfaces
{
    public interface IStone
    {
        IPlayer Owner { get; }
        IPlace Positon { get; }
    }
}
