using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Shop
    {
        // Словарь: ключ — товар, значение — количество
        private Dictionary<Product, int> products;

        // Прибыль магазина — только для чтения снаружи
        public decimal Profit { get; private set; }

        // Конструктор — инициализирует словарь и обнуляет прибыль
        public Shop()
        {
            products = new Dictionary<Product, int>();
            Profit = 0;
        }

        // Создаёт новый товар и добавляет его в словарь
        public void CreateProduct(string name, decimal price, int count)
        {
            // Не добавляем если товар с таким именем уже существует
            if (FindByName(name) != null)
            {
                return;
            }
            products.Add(new Product(name, price), count);
        }

        // Добавляет уже существующий объект товара в словарь
        public void AddProduct(Product product, int count)
        {
            products.Add(product, count);
        }

        // Возвращает список строк со всеми товарами и их количеством
        public List<string> GetAllProducts()
        {
            List<string> result = new List<string>();
            foreach (var item in products)
            {
                result.Add(item.Key.GetInfo() + "; Количество: " + item.Value);
            }
            return result;
        }

        // Ищет товар по имени, возвращает null если не найден
        public Product FindByName(string name)
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                    return product;
            }
            return null;
        }

        // Перегрузка 1: продаёт один экземпляр товара по объекту Product
        public string Sell(Product product)
        {
            if (products.ContainsKey(product))
            {
                // Проверяем наличие товара
                if (products[product] == 0)
                {
                    return "Нет в наличии!";
                }
                else
                {
                    // Уменьшаем количество и увеличиваем прибыль
                    products[product]--;
                    Profit += product.Price;
                    return "Продано: " + product.Name;
                }
            }
            return "Товар не найден!";
        }

        // Перегрузка 2: продаёт один экземпляр товара по имени
        public string Sell(string productName)
        {
            // Ищем товар по имени и вызываем первую перегрузку
            Product toSell = FindByName(productName);
            if (toSell != null)
                return Sell(toSell);
            return "Товар не найден!";
        }

        // Перегрузка 3: продаёт несколько штук товара по имени
        public string Sell(string productName, int count)
        {
            Product toSell = FindByName(productName);
            if (toSell == null)
                return "Товар не найден!";

            // Проверяем достаточно ли товара на складе
            if (products[toSell] < count)
                return "Недостаточно товара! В наличии: " + products[toSell];

            // Уменьшаем количество и считаем прибыль за все штуки
            products[toSell] -= count;
            Profit += toSell.Price * count;
            return "Продано " + count + " шт.: " + toSell.Name;
        }
    }
}