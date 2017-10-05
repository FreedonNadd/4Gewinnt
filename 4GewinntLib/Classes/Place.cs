using _4GewinntLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GewinntLib.Classes
{
    public class Place : IPlace
    {
        int _x;
        int _y;
        IStone _content;

        public Place(int X, int Y)
        {
            _x = X;
            _y = Y;
        }

        public IStone Content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
        }
        
        public int Y
        {
            get
            {
                return _y;
            }
        }
        
    }
}
