using cat;
// Массив котов и счётчик заполненных ячеек
Cat[] cats = new Cat[100];
int catCount = 0;
int choice = 0;

// Главный цикл — крутится пока пользователь не выберет "Выход"
while (choice != 5)
{
    Console.WriteLine("\nМеню");
    Console.WriteLine("1. Добавить котов");
    Console.WriteLine("2. Мяукать (один раз)");
    Console.WriteLine("3. Мяукать несколько раз");
    Console.WriteLine("4. Мяукать с настроением");
    Console.WriteLine("5. Выход");
    Console.Write("Выберите пункт: ");

    try
    {choice = int.Parse(Console.ReadLine());}
    catch
    {Console.WriteLine("Введите число!");}

    if (choice == 1)
    {
        // Ввод количества котов, затем цикл ввода данных
        int n = 0;
        try { n = int.Parse(Console.ReadLine()); }
        catch { Console.WriteLine("Введите число!"); }
        for (int i = 0; i < n; i++)
        {
            Console.Write("Имя кота: ");
            string nm = Console.ReadLine();

            Console.Write("Вес кота (кг): ");

            double wt = 0;
            try { wt = double.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Введите число!"); }
            // Создаём объект и добавляем в массив
            cats[catCount] = new Cat(nm, wt);
            catCount++;
        }
    }
    else if (choice == 2)
    {
        // Проверка: есть ли коты в массиве
        if (catCount == 0)
        {
            Console.WriteLine("Сначала добавьте котов!");
        }
        else
        {
            for (int i = 0; i < catCount; i++)
                cats[i].Meow();
        }
    }
    else if (choice == 3)
    {
        if (catCount == 0)
        {
            Console.WriteLine("Сначала добавьте котов!");
        }
        else
        {
            Console.Write("Сколько раз мяукать? ");
            int times = 0;
            try { times = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Введите число!"); }
            for (int i = 0; i < catCount; i++)
                cats[i].Meow(times);
        }
    }
    else if (choice == 4)
    {
        if (catCount == 0)
        {
            Console.WriteLine("Сначала добавьте котов!");
        }
        else
        {
            Console.Write("Настроение (например: грустно, радостно): ");
            string mood = Console.ReadLine();
            for (int i = 0; i < catCount; i++)
                cats[i].Meow(mood);
        }
    }
    else if (choice != 5)
    {
        // Неверный пункт меню
        Console.WriteLine("Неверный пункт! Введите число от 1 до 5.");
    }
}

Console.WriteLine("До свидания!");