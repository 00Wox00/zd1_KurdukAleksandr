using System.Windows;

namespace shop
{
    public partial class ShopWindow : Window
    {
        // Объект магазина
        private Shop shop = new Shop();

        public ShopWindow()
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

        // Кнопка "Добавить товар"
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                decimal price = decimal.Parse(txtPrice.Text);
                int count = int.Parse(txtCount.Text);

                if (shop.FindByName(name) != null)
                {
                    txtStatus.Text = "Товар с таким именем уже существует!";
                    return;
                }

                shop.CreateProduct(name, price, count);
                txtStatus.Text = "Товар добавлен: " + name;
                RefreshList();
            }
            catch
            {
                txtStatus.Text = "Ошибка! Проверьте введённые данные.";
            }
        }

        // Кнопка "Продать"
        private void Sell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtSellName.Text;
                int count = int.Parse(txtSellCount.Text);

                string result;

                if (count > 1)
                    result = shop.Sell(name, count);
                else
                    result = shop.Sell(name);

                txtStatus.Text = result;
                txtProfit.Text = "Прибыль: " + shop.Profit + " руб.";
                RefreshList();
            }
            catch
            {
                txtStatus.Text = "Ошибка! Проверьте введённые данные.";
            }
        }

        // Кнопка "Обновить список"
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        // Обновляет ListBox
        private void RefreshList()
        {
            lstProducts.Items.Clear();
            foreach (string line in shop.GetAllProducts())
            {
                lstProducts.Items.Add(line);
            }
        }
    }
}