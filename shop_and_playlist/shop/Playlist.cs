using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Playlist
    {
        // Список песен плейлиста
        private List<Song> list;

        // Индекс текущей песни
        private int currentIndex;

        // Конструктор — инициализирует список и обнуляет индекс
        public Playlist()
        {
            list = new List<Song>();
            currentIndex = 0;
        }

        // Возвращает текущую песню, бросает исключение если плейлист пуст
        public Song CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        // Перегрузка 1: добавляет готовый объект Song в плейлист
        public void Add(Song song)
        {
            list.Add(song);
        }

        // Перегрузка 2: добавляет песню по отдельным полям
        public void Add(string author, string title, string filename)
        {
            Song song = new Song();  
            song.Author = author;
            song.Title = title;
            song.Filename = filename;
            list.Add(song);
        }

        // Переход к следующей песне — по достижении конца возвращается в начало
        public void Next()
        {
            if (list.Count == 0)
                return;

            if (currentIndex < list.Count - 1)
                currentIndex++;
            else
                currentIndex = 0; // возврат в начало
        }

        // Переход к предыдущей песне — по достижении начала переходит в конец
        public void Previous()
        {
            if (list.Count == 0)
                return;

            if (currentIndex > 0)
                currentIndex--;
            else
                currentIndex = list.Count - 1; // переход в конец
        }

        // Переход к песне по индексу с проверкой границ
        public void GoTo(int index)
        {
            if (index >= 0 && index < list.Count)
                currentIndex = index;
        }

        // Переход к первой песне в списке
        public void GoToStart()
        {
            currentIndex = 0;
        }

        // Перегрузка 1: удаляет песню по индексу
        public void Remove(int index)
        {
            if (index >= 0 && index < list.Count)
            {
                list.RemoveAt(index);

                // Если текущий индекс вышел за границы — сдвигаем назад
                if (currentIndex >= list.Count && list.Count > 0)
                    currentIndex = list.Count - 1;
            }
        }

        // Перегрузка 2: удаляет первое совпадение по значению Song
        public void Remove(Song song)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // Сравниваем по всем полям
                if (list[i].Author == song.Author &&
                    list[i].Title == song.Title &&
                    list[i].Filename == song.Filename)
                {
                    list.RemoveAt(i);

                    // Если текущий индекс вышел за границы — сдвигаем назад
                    if (currentIndex >= list.Count && list.Count > 0)
                        currentIndex = list.Count - 1;

                    return; // удаляем только первое совпадение
                }
            }
        }

        // Очищает весь плейлист и сбрасывает индекс
        public void Clear()
        {
            list.Clear();
            currentIndex = 0;
        }

        // Возвращает список строк для отображения всех песен
        public List<string> GetAllSongs()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                // Помечаем текущую песню стрелкой
                string marker = (i == currentIndex) ? "▶ " : "   ";
                result.Add(marker + i + ". " + list[i].Author + " — " + list[i].Title);
            }
            return result;
        }

        // Возвращает количество песен в плейлисте
        public int Count()
        {
            return list.Count;
        }
    }
}
