using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using _4GewinntLib.Interfaces;
using _4GewinntLib.Classes;

namespace _4Gewinnt.ViewModel
{
    public class PlayerViewModel : IPlayerViewModel
    {
        IPlayer _player;
        public PlayerViewModel(string Name, Color PlayerColor)
        {
            _player = new Player(Name, PlayerColor);
        }
        public IPlayer Player
        {
            get
            {
                return _player;
            }
        }

        public Brush PlayerBrush
        {
            get
            {
                return new SolidColorBrush(_player.PlayerColor);
            }
        }
    }
}
