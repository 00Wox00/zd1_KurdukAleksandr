using System.Windows;

namespace shop
{
    public partial class PlaylistWindow : Window
    {
        // Объект плейлиста
        private Playlist playlist = new Playlist();

        public PlaylistWindow()
        {
            InitializeComponent();
        }

        // Пункт меню — открыть магазин
        private void OpenShop_Click(object sender, RoutedEventArgs e)
        {
            ShopWindow sw = new ShopWindow();
            sw.Show();
        }

        // Пункт меню — открыть плейлист
        private void OpenPlaylist_Click(object sender, RoutedEventArgs e)
        {
            PlaylistWindow pw = new PlaylistWindow();
            pw.Show();
        }

        // Кнопка "Добавить песню" — перегрузка Add(author, title, filename)
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string author = txtAuthor.Text;
            string title = txtTitle.Text;
            string filename = txtFilename.Text;

            // Проверка обязательных полей
            if (author == "" || title == "")
            {
                txtStatus.Text = "Заполните автора и название!";
                return;
            }

            // Добавляем песню через перегрузку с тремя параметрами
            playlist.Add(author, title, filename);
            txtStatus.Text = "Добавлено: " + author + " — " + title;
            RefreshList();
        }

        // Кнопка "Следующая"
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            playlist.Next();
            RefreshList();
            ShowCurrent();
        }

        // Кнопка "Предыдущая"
        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            playlist.Previous();
            RefreshList();
            ShowCurrent();
        }

        // Кнопка "В начало"
        private void GoToStart_Click(object sender, RoutedEventArgs e)
        {
            playlist.GoToStart();
            RefreshList();
            ShowCurrent();
        }

        // Кнопка "Перейти по индексу"
        private void GoTo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = int.Parse(txtIndex.Text);
                playlist.GoTo(index);
                RefreshList();
                ShowCurrent();
            }
            catch
            {
                txtStatus.Text = "Введите корректный индекс!";
            }
        }

        // Кнопка "Удалить по индексу" — перегрузка Remove(int)
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int index = int.Parse(txtRemoveIndex.Text);
                playlist.Remove(index);
                txtStatus.Text = "Удалено!";
                RefreshList();
                ShowCurrent();
            }
            catch
            {
                txtStatus.Text = "Введите корректный индекс!";
            }
        }

        // Кнопка "Очистить плейлист"
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            playlist.Clear();
            txtCurrent.Text = "Текущая: —";
            txtStatus.Text = "Плейлист очищен.";
            RefreshList();
        }

        // Обновляет ListBox — загружает все песни из плейлиста
        private void RefreshList()
        {
            lstSongs.Items.Clear();
            foreach (string line in playlist.GetAllSongs())
            {
                lstSongs.Items.Add(line);
            }
        }

        // Показывает текущую песню в TextBlock
        private void ShowCurrent()
        {
            try
            {
                Song s = playlist.CurrentSong();
                txtCurrent.Text = "Текущая: " + s.Author + " — " + s.Title;
                txtStatus.Text = "";
            }
            catch
            {
                txtCurrent.Text = "Текущая: —";
            }
        }
    }
}