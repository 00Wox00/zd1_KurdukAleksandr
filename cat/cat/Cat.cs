using System;

namespace cat
{
    public class Cat
    {
        private string name;
        private double weight;

        public string Name
        {
            get { return name; }
            set
            {
                // Проверка: имя должно содержать только буквы
                bool onlyLetters = true;
                foreach (char ch in value)
                {
                    if (!char.IsLetter(ch))
                        onlyLetters = false;
                }
                if (onlyLetters)
                    name = value;
                else
                    Console.WriteLine(value + " - неправильное имя (только буквы)!");
            }
        }

        public double Weight
        {
            get { return weight; }
            set
            {
                // Вес должен быть строго положительным
                if (value > 0)
                    weight = value;
                else
                    Console.WriteLine(value + " - неправильный вес (должен быть > 0)!");
            }
        }

        // Конструктор — принимает имя и вес
        public Cat(string catName, double catWeight)
        {
            Name = catName;
            Weight = catWeight;
        }

        // Перегрузка 1: мяукает один раз
        public void Meow()
        {
            Console.WriteLine(name + ": МЯЯЯЯУ!!!!");
        }

        // Перегрузка 2: мяукает указанное количество раз
        public void Meow(int count)
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(name + ": МЯЯЯЯУ!!!!");
        }

        // Перегрузка 3: мяукает с заданным настроением
        public void Meow(string mood)
        {
            Console.WriteLine(name + " (" + mood + "): мяу...");
        }

        // Вывод информации о коте
        public void PrintInfo()
        {
            Console.WriteLine("Имя: " + name + ", Вес: " + weight + " кг");
        }
    }
}