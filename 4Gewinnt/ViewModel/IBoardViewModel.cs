using _4GewinntLib.Interfaces;
using System.Collections.Generic;
using System.Windows.Media;

namespace _4Gewinnt.ViewModel
{
    public interface IBoardViewModel
    {
        SolidColorBrush GetPlaceFromBoard(int X, int Y);

        void PlaceStoneInRow(int Y);

        string Winner { get; }

        List<IPlayer> Players { get; }
    }
}