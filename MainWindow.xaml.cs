using _4Gewinnt.GameObjects;
using _4Gewinnt.Manager;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _4Gewinnt
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BoardSizes currentBoardSize;

        public MainWindow()
        {
            InitializeComponent();
            currentBoardSize = BoardSizes.Classic;
            this.InitGame();
        }

        //Initialisieren der Spielfläche und des Status
        private void InitGame()
        {
            GameManager.instance.ResetGame();
            CreateBoardControls();
            DrawBoard();
            RefreshStatusText();
            
        }

        //Für das Spielfeld die Steuerelemte erstellen
        private void CreateBoardControls()
        {
            int BoardWidth = GameManager.instance.GameBoard.GetBoardSize()[0];
            int BoardHeight = GameManager.instance.GameBoard.GetBoardSize()[1];
            Board.Children.Clear();
            Board.Columns = BoardWidth;
            Board.Rows = BoardHeight;
            for (int x = BoardHeight - 1; x >= 0; x--)
            {
                for (int y = 0; y < BoardWidth; y++)
                {
                    var ellipse = new Ellipse() { Name = "R" + x + "C" + y, Stroke = Brushes.Black, StrokeThickness = 0.1, Margin = new Thickness(1), Fill = Brushes.White };
                    ellipse.MouseDown += Ellipse_MouseDown;
                    Board.Children.Add(ellipse);
                }
            }
        }

        //Optionen aufrufen
        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            Options dialog = new Options(GameManager.instance.BoardSize);
            dialog.ShowDialog();

            if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
            {
                currentBoardSize = dialog.ChoosenSize;
                Reset();
            }
        }

        //Restebutton wurde gedrückt
        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        //Mauseingabe bearbeiten
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Bestimmung des Feldes welches geklickt wurde
            var FieldName = ((Ellipse)sender).Name;
            //Übergabe des Inputs an den GameManager
            GameManager.instance.BoardMousInput(FieldName);

            //Aktualisierung der UI
            this.RefreshStatusText();
            DrawBoard();

        }

        private void Reset()
        {
            GameManager.instance.SetNewBoardSize(currentBoardSize);
            CreateBoardControls();
            DrawBoard();
            RefreshStatusText();
        }
        //Statustext aktualisieren
        private void RefreshStatusText()
        {
            this.Textblock_Status.Text = GameStateManager.instance.GetStatusText();
        }

        //Spielfeld darstellen
        public void DrawBoard()
        {
            for (int y = 0; y < GameManager.instance.GameBoard.MaxRow; y++)
            {
                for (int x = 0; x < GameManager.instance.GameBoard.MaxCol; x++)
                {
                    Stone stone = GameManager.instance.GameBoard.board[GameManager.instance.GameBoard.MaxRow - y - 1, x];
                    Brush brush;
                    switch (stone)
                    {
                        case Stone.PlayerOne:
                            brush = Brushes.Red;
                            break;
                        case Stone.PlayerTwo:
                            brush = Brushes.Yellow;
                            break;
                        default:
                            brush = Brushes.LightBlue;
                            break;
                    }
                    var index = y * GameManager.instance.GameBoard.MaxCol + x;
                    Ellipse circle = (Ellipse)Board.Children[index];
                    circle.Fill = brush;
                }
            }
        }
    }
}
