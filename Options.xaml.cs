using _4Gewinnt.GameObjects;
using System.Windows;

namespace _4Gewinnt
{
    /// <summary>
    /// Interaktionslogik für Options.xaml
    /// </summary>
    public partial class Options : Window
    {
        public BoardSizes ChoosenSize;
         
        public Options(BoardSizes CurrentSize)
        {
            InitializeComponent();
            ChoosenSize = CurrentSize;
            switch (CurrentSize)
            {
                case BoardSizes.Classic:
                    this.RadioClassicSize.IsChecked = true;
                    break;
                case BoardSizes.Advanced:
                    this.RadioExtendedSize.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        //Bei Bestätigen mit OK Auswahl übernehmen und Dialogfenster schliessen
        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            if (this.RadioExtendedSize.IsChecked == true)
            {
                ChoosenSize = BoardSizes.Advanced;
            }
            else
            {
                ChoosenSize = BoardSizes.Classic;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
