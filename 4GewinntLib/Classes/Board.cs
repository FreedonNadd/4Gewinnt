using _4GewinntLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4GewinntLib.Classes
{
    public class Board : IBoard
    {
        List<List<IPlace>> _playField;
        List<IPlayer> _players;
        IStone LastStone;
        IPlayer _winner;

        public Board(IPlayer PlayerA, IPlayer PlayerB)
        {
            InitPlayField();
            _players = new List<IPlayer>()
            {
                PlayerA,
                PlayerB
            };
            _players[0].IsActive = true;
            _players[1].IsActive = false;
        }

        private void InitPlayField()
        {
            //Anlegen des Spielfeldes 6x7
            _playField = new List<List<IPlace>>();
            for (int y = 0; y < 6; y++)
            {
                var reihe = new List<IPlace>();
                for (int x = 0; x < 7; x++)
                {
                    reihe.Add(new Place(x,y));
                }
                _playField.Add(reihe);
            }
        }

        public List<List<IPlace>> PlayField
        {
            get
            {
                return _playField;
            }
        }

        public IPlayer Winner
        {
            get
            {
                return _winner;
            }
        }

        /// <summary>
        /// Gibt den gewinnden Spieler zurück
        /// </summary>
        /// <returns>NULL wenn kein Gewinner feststeht</returns>
        public IPlayer EvaluateWinner()
        {
            if (LastStone == null)
                return null;
            if (_winner != null)
                return _winner;
            //Vertikal Prüfen
            int count = 0;
            for (int y = 0; y < _playField.Count; y++)
            {
                if (_playField[y][LastStone.Positon.X].Content != null && _playField[y][LastStone.Positon.X].Content.Owner == LastStone.Owner)
                {
                    count++;
                    if (count == 4)
                    {
                        _winner = LastStone.Owner;
                        return _winner;
                    }
                        
                }
                else
                {
                    count = 0;
                }
            }

            //Horizontal prüfen

            count = 0;
            for (int x = 0; x < _playField.First().Count; x++)
            {
                if (_playField[LastStone.Positon.Y][x].Content != null && _playField[LastStone.Positon.Y][x].Content.Owner == LastStone.Owner)
                {
                    count++;
                    if (count == 4)
                    {
                        _winner = LastStone.Owner;
                        return _winner;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            //Diagonale 1 prüfen (links oben / rechts unten)
            count = 0;
            int delta1 = Math.Min(_playField[0].Count - LastStone.Positon.Y - 1, LastStone.Positon.X);
            int delta2 = Math.Min(LastStone.Positon.Y, _playField.Count - LastStone.Positon.X - 1);

            var row1 = LastStone.Positon.Y + delta1;
            var col1 = LastStone.Positon.X - delta1;
            var row2 = LastStone.Positon.Y - delta2;
            var col2 = LastStone.Positon.X + delta2;

            for (int i = row1, j = col1; i >= row2 && j <= col2; i--, j++)
            {
                if (_playField[j][i].Content != null && _playField[j][i].Content.Owner == LastStone.Owner)
                {
                    count++;
                    if (count == 4)
                    {
                        _winner = LastStone.Owner;
                        return _winner;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            //Diagonale 2 prüfen (links unten / rechts oben)
            delta1 = Math.Min(LastStone.Positon.Y, LastStone.Positon.X);
            delta2 = Math.Min(_playField.Count - LastStone.Positon.Y, _playField[0].Count - LastStone.Positon.X);
            row1 = LastStone.Positon.Y - delta1;
            col1 = LastStone.Positon.X - delta1;
            row2 = LastStone.Positon.Y + delta2;
            col2 = LastStone.Positon.X + delta2;
            count = 0;

            for (int i = row1, j = col1; i < row2 && j < col2; i++, j++)
            {
                if (_playField[j][i].Content != null && _playField[j][i].Content.Owner == LastStone.Owner)
                {
                    count++;
                    if (count == 4)
                    {
                        _winner = LastStone.Owner;
                        return _winner;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            return null;
        }

        public bool PlaceStone(int Y)
        {
            var activePlayer = _players.Where(x => x.IsActive == true).FirstOrDefault();
            if (activePlayer == null)
                return false;
            foreach (var row in _playField)
            {
                if (row[Y].Content == null)
                {
                    LastStone = new Stone(activePlayer, row[Y]);
                    row[Y].Content = LastStone;
                    SwitchActivePlayer();
                    return true;
                }
            }
            return false;
        }

        private void SwitchActivePlayer()
        {
            foreach (var player in _players)
            {
                if (player.IsActive)
                {
                    player.IsActive = false;
                }
                else
                {
                    player.IsActive = true;
                }
            }
        }
    }
}
