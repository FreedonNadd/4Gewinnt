using _4GewinntLib.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt.ViewModel
{
    public class MainViewViewModel :IMainViewViewModel
    {
        List<IPlayerViewModel> _playerViewModels;
        IBoardViewModel _playBoard;

        public MainViewViewModel()
        {

        }
        public MainViewViewModel(List<IPlayerViewModel> Players)
        {
            _playerViewModels = Players;
            _playBoard = new BoardViewModel(new Board(_playerViewModels[0].Player, _playerViewModels[1].Player));
        }

        public IBoardViewModel PlayBoard
        {
            get
            {
                return _playBoard;
            }
        }

        public List<IPlayerViewModel> PlayerViewModels
        {
            get
            {
                return _playerViewModels;
            }
        }
    }
}
