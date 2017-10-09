using _4GewinntLib.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _4Gewinnt.ViewModel
{
    public class BoardViewModel : IBoardViewModel, INotifyPropertyChanged
    {
        IBoard _board;

        public event PropertyChangedEventHandler PropertyChanged;
        private string _winner;
        public string Winner
        {
            get { return _winner; }
            private set
            {
                _winner = value;
                OnPropertyChanged("Winner");
            }
        }

        public List<IPlayer> Players
        {
            get
            {
                return _board.Players;
            }
        }

        public BoardViewModel(IBoard Board)
        {
            _board = Board;
            Winner = "";
        }

        public SolidColorBrush GetPlaceFromBoard(int X, int Y)
        {
            var content = _board.PlayField[Y][X].Content;
            if (content != null)
            {
                return new SolidColorBrush(content.Owner.PlayerColor);
            }
            else
            {
                return new SolidColorBrush(Colors.White);
            }
        }

        public void PlaceStoneInRow(int Y)
        {
            _board.PlaceStone(Y);
            var result = _board.EvaluateWinner();
            if (result != null)
            {
                Winner = result.Name;

            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
