using _4Gewinnt.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        IMainViewViewModel _mainViewViewModel;

        public MainWindow()
        {
            InitializeComponent();
            InitGame();
        }

        //Initialisieren der Spielfläche und des Status
        private void InitGame()
        {
            var players = new List<IPlayerViewModel>();
            players.Add(new PlayerViewModel("Spieler 1", Color.FromRgb(255, 0, 0)));
            players.Add(new PlayerViewModel("Spieler 2", Color.FromRgb(0,255, 0)));
            _mainViewViewModel = new MainViewViewModel(players);
            DrawBoard();
            CurrentPlayer.Content = "Spieler 1 ist an der Reihe";
        }

        //Restebutton wurde gedrückt
        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
            RefreshStatusText();
        }

        private void Reset()
        {
            InitGame();
        }
        //Statustext aktualisieren
        private void RefreshStatusText()
        {
            if (_mainViewViewModel.PlayBoard.Winner != "")
            {
                Textblock_Status.Text = _mainViewViewModel.PlayBoard.Winner + " hat gewonnen!";
            }
            else
            {
                Textblock_Status.Text = "";
            }
        }

        //Spielfeld darstellen
        public void DrawBoard()
        {
            for (int x = 0; x < 7; x++)
            {
                int count = 5;
                for (int y = 0; y < 6; y++)
                {
                    
                    Brush brush = _mainViewViewModel.PlayBoard.GetPlaceFromBoard(x,count);
                    var place = grid.grid.Children.Cast<Border>().First(e => Grid.GetRow(e) == y && Grid.GetColumn(e) == x);
                    place.Background = brush;
                    count--;
                }
            }
            RefreshStatusText();
        }

        private void grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var point = Mouse.GetPosition(grid.grid);
            int col = 0;
            double accumulatedWidth = 0.0;
            foreach (var columnDefinition in grid.grid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
            PlaceStone(col);
        }

        private void PlaceStone(int Column)
        {
            _mainViewViewModel.PlayBoard.PlaceStoneInRow(Column);
            CurrentPlayer.Content = _mainViewViewModel.PlayBoard.Players.Where(x => x.IsActive == true).FirstOrDefault().Name + " ist an der Reihe";
            DrawBoard();

        }
    }
}
