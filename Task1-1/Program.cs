using System;

namespace Task1_1
{
    // Вспомагательный класс для объевления констант
    static class Constants
    {
        // Размер массива для списка по-умолчанию
        public const int ListDefaultSize = 25;
    }
    
    // Класс для управления списком строк
    class StringList
    {
        private string[] _list;     // Внутренний массив строк для организации списка
        private int _currentPos;    // Начальная позиция, равная 0 по-умолчанию

        // Конструктор по-умолчанию
        public StringList()
        {
            // Создаем массив с размером по-умолчанию
            _list = new string[Constants.ListDefaultSize];
        }

        // Конструктор с задания начального кол-ва элементов
        public StringList(int size)
        {
            // Если переданный размер отрицательный или ноль
            if (size <= 0)
            {
                // То создаем массив с размером по-умолчанию
                _list = new string[Constants.ListDefaultSize];
                return;
            }
            
            _list = new string[size];
        }

        public void PrintList()
        {
            Console.WriteLine("list array len: {0}", _list.Length);
            for (int i = 0; i < _currentPos; i++)
            {
                Console.Write("{0}, ", _list[i]); 
            }
            
            Console.Write("\n");
        }
        
        public int Insert(string s)
        {
            // Если позиция для вставки превышает или равна размему массива
            if (_currentPos >= _list.Length)
            {
                // Увеличиваем размер массива в 2 раза
                Array.Resize(ref _list, _list.Length * 2);
            }
            
            // Вставляем новые элемент
            _list[_currentPos] = s;
            
            // Возвращаем позицию и затем увеличиваем её на единицу
            return _currentPos++;
        }

        public void Delete(int pos)
        {
            if (pos < 0 || pos >= _currentPos) return;
            
            // Создаем новый массив
            string[] newList = new string[_currentPos - 1];

            for (int i = 0, j = 0 ; i < _currentPos; i++)
            {
                if (pos == i) continue;
                    
                newList[j] = _list[i];
                j++;
            }

            // Сохраняем новый массив
            _list = newList;
            // Уменьшаем текущую позицию на единицу
            _currentPos--;
        }

        public int Search(string s)
        {
            for (int i = 0; i < _currentPos; i++)
            {
                // Если нашли элемент, то возвращаем его индекс
                if (_list[i] == s) return i;
            }
            
            // Возвращает -1, если элемента не нашлось
            return -1;
        }

        public void Update(int pos, string s)
        {
            // Если pos находится в пределах от 0 до _currentPos
            if (pos >= 0 && pos < _currentPos)
            {
                // Обновляем значение
                _list[pos] = s;
            }
        }

        public string GetAt(int pos)
        {
            // Если pos не в пределах от 0 до _currentPos
            if (pos < 0 || pos >= _currentPos)
            {
                // Возвращаем null
                return null;
            }
            
            // Возвращаем элемент с позицией pos 
            return _list[pos];
        }
    }
    
    class Program
    {
        static void Main()
        {
            StringList list = new StringList(3);
            
            var insertedPos = list.Insert("first");
            Console.WriteLine(insertedPos);
            
            insertedPos = list.Insert("two");
            Console.WriteLine(insertedPos);
            
            insertedPos = list.Insert("third");
            Console.WriteLine(insertedPos);
            
            insertedPos = list.Insert("four");
            Console.WriteLine(insertedPos);
            
            Console.WriteLine("two found at: {0}", list.Search("two"));
            Console.WriteLine("Item on third position: {0}", list.GetAt(3));
            
            list.Update(1, "updated first");
            Console.WriteLine("Item on first position: {0}", list.GetAt(1));
            Console.WriteLine("Item on fourth position: {0}", list.GetAt(4) ?? "there is no item");
            
            list.PrintList();
            
            list.Delete(3);
            Console.WriteLine("Item on third position: {0}", list.GetAt(3) ?? "There is no items");
            list.PrintList();
        }
    }
}