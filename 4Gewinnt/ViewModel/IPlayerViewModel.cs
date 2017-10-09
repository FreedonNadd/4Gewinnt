using _4GewinntLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4Gewinnt.ViewModel
{
    public interface IPlayerViewModel
    {
        IPlayer Player { get; }
        Brush PlayerBrush { get; }
    }
}
