using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GewinntLib.Interfaces
{
    public interface IBoard
    {
        bool PlaceStone(int Y);

        IPlayer EvaluateWinner();

        List<List<IPlace>> PlayField { get; }

        IPlayer Winner { get; }

        List<IPlayer> Players { get; }
    }
}
