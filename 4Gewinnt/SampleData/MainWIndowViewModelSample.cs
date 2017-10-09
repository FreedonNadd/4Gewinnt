using _4Gewinnt.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4Gewinnt.SampleData
{
    public class MainWIndowViewModelSample : IMainViewViewModel
    {
        List<IPlayerViewModel> _playerViwModels;

        public MainWIndowViewModelSample()
        {
            _playerViwModels = new List<IPlayerViewModel>();
            _playerViwModels.Add(new SampleData.PlayerViewSampleData());
            _playerViwModels.Add(new SampleData.PlayerViewSampleData("Spieler 2",Color.FromRgb(0,255,0),false));
        }
        public IBoardViewModel PlayBoard
        {
            get
            {
                return null;
            }
        }

        public List<IPlayerViewModel> PlayerViewModels
        {
            get
            {
                return _playerViwModels;
            }
        }
    }
}
