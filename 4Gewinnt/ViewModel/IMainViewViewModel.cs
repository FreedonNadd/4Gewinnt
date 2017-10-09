using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Gewinnt.ViewModel
{
    public interface IMainViewViewModel
    {
        IBoardViewModel PlayBoard { get; }
        List<IPlayerViewModel> PlayerViewModels { get; }
    }
}
