using _4GewinntLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4GewinntLib.Classes
{
    public class Player : IPlayer
    {
        Color _color;
        string _name;
        bool _active;

        public Player(string Name, Color Color)
        {
            _name = Name;
            _color = Color;
            _active = false;
        }

        public Color PlayerColor
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
    }
}
