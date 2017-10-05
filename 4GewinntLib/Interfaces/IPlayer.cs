using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4GewinntLib.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        Color PlayerColor { get; set; }
        bool IsActive { get; set; }

    }
}
