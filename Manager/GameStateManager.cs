using _4Gewinnt.GameObjects;

namespace _4Gewinnt.Manager
{
    //Singleton als GameStateManger damit es immer nur einen gültigen Zustand gibt
    public sealed class GameStateManager
    {
        public static readonly GameStateManager instance = new GameStateManager();
        private Gamestates _state;
        //Status nur lesend von extern machen
        public Gamestates GameState { get { return _state; } }

        GameStateManager()
        {
            _state = Gamestates.PlayerOneNext;
        }

        //Spieler wechseln
        public void ChangePlayer()
        {
            if (_state == Gamestates.PlayerOneNext)
            {
                _state = Gamestates.PlayerTwoNext;
                return;
            }

            if (_state == Gamestates.PlayerTwoNext)
            {
                _state = Gamestates.PlayerOneNext;
                return;
            }
        }

        public void ResetState()
        {
            _state = Gamestates.PlayerOneNext;
        }

        //Gewinner festlegen
        public void ChooseWinner()
        {
            switch (_state)
            {
                case Gamestates.PlayerOneNext:
                    _state = Gamestates.PlayerOneWins;
                    break;
                case Gamestates.PlayerTwoNext:
                    _state = Gamestates.PlayerTwoWins;
                    break;
                default:
                    break;
            }
        }

        //Den Status für die Anzeige übersetzen
        public string GetStatusText()
        {
            switch (_state)
            {
                case Gamestates.PlayerOneNext:
                    return "Spieler 1 ist am Zug ...";
                case Gamestates.PlayerTwoNext:
                    return "Spieler 2 ist am Zug ...";
                case Gamestates.PlayerOneWins:
                    return "Spieler 1 hat gewonnen!";
                case Gamestates.PlayerTwoWins:
                    return "Spieler 2 hat gewonnen!";
                default:
                    return "";
            }
        }
    }
}
