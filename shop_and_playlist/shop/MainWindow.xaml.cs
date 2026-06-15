using System.Windows;

namespace shop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Открывает окно магазина
        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow sw = new ShopWindow();
            sw.Show();
        }

        // Открывает окно плейлиста
        private void OpenPlaylist_Click(object sender, RoutedEventArgs e)
        {
            PlaylistWindow pw = new PlaylistWindow();
            pw.Show();
        }
    }
}