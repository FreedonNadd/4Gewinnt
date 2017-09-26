using _4Gewinnt.GameObjects;

namespace _4Gewinnt.Manager
{
    public sealed class GameManager
    {
        public static readonly GameManager instance = new GameManager();
        private BoardSizes _boardSize;
        public BoardSizes BoardSize { get { return _boardSize; } }
        private Board _board;
        public Board GameBoard { get { return _board; } }

        GameManager()
        {
            _boardSize = BoardSizes.Classic;
            _board = new Board(BoardSizes.Classic);
        }

        public void ResetGame()
        {
            _board = new Board(_boardSize);
            GameStateManager.instance.ResetState();

        }

        public void SetNewBoardSize(BoardSizes Size)
        {
            _boardSize = Size;
            ResetGame();
        }

        public void BoardMousInput(string FieldName)
        {
            int row = FieldName[1] - '0';
            int col = FieldName[3] - '0';

            //Wenn Klick auf einem nicht gültigen Feld erfolgt ignorieren
            if (!IsValidInput(row, col))
            {
                return;
            }

            
            //Stein die Bahn runterfallen lassen
            for (int i = _board.MaxRow - 1; i >= 0; i--)
            {
                if (_board.board[i, col] == Stone.Empty)
                {
                    row = i;
                    continue;
                }
            }
            //Stein auf das Brett setzen
            switch (GameStateManager.instance.GameState)
            {
                case Gamestates.PlayerOneNext:
                    _board.LayStoneOnBoard(Stone.PlayerOne, col, row);
                    break;
                case Gamestates.PlayerTwoNext:
                    _board.LayStoneOnBoard(Stone.PlayerTwo, col, row);
                    break;
                default:
                    break;
            }

            //Zug auswerten
            if (_board.IsGameOver(row, col, _board.board[row, col]))
            {
                GameStateManager.instance.ChooseWinner();
            }
            else
            {
                GameStateManager.instance.ChangePlayer();
            }

        }

        private bool IsValidInput(int row, int col)
        {
            //Spielzug überprüfen

            //Eingabe ausserhalb des Spielfeldes
            if (row < 0 || col < 0 || row >= _board.MaxRow || col >= _board.MaxCol)
            {
                return false;
            }

            //Feld bereist belegt
            if (_board.board[row, col] != Stone.Empty)
            {
                return false;
            }

            //Spiel ist bereits beendet
            if (GameStateManager.instance.GameState == Gamestates.PlayerOneWins ||
                 GameStateManager.instance.GameState == Gamestates.PlayerTwoWins)
                return false;

            // position is okay
            return true;
        }
    }
}
