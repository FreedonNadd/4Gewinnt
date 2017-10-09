using _4Gewinnt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4GewinntLib.Interfaces;
using _4GewinntLib.Classes;
using System.Windows.Media;

namespace _4Gewinnt.SampleData
{
    public class PlayerViewSampleData : IPlayerViewModel
    {
        IPlayer _player;

        public PlayerViewSampleData()
            :this ("Spieler 1", Color.FromRgb(255, 0, 0), true)
        {

        }

        public PlayerViewSampleData(string Name, Color PlayerColor, bool Active)
        {
            _player = new Player(Name, PlayerColor);
            _player.IsActive = Active;
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
