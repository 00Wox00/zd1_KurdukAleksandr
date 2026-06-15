using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Product
    {
        // Название товара
        public string Name { get; set; }

        // Цена товара
        public decimal Price { get; set; }

        // Конструктор — принимает название и цену
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        // Возвращает строку с информацией о товаре
        public string GetInfo()
        {
            return "Наименование: " + Name + "; Цена: " + Price + " руб.";
        }
    }
}