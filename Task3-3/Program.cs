using System;
using System.Text;

namespace Task3_3
{
	static class Helpers
	{
		public static readonly int ArrayDefaultSize = 2; // Размер массива по-умолчанию
		public static readonly string ErrorOutBound = "Переданный индекс превосходит размер массива";
		public static readonly string ErrorNonexistentName = "Передано несуществующее имя";
	}

	struct ArrEl
	{
		public string Name;
		public int Val;

		public ArrEl(string name, int val)
		{
			Name = name;
			Val = val;
		}

		public override string ToString()
		{
			return $"(Name:{Name}, Val:{Val})";
		}
	}

	class ArrElArray
	{
		private ArrEl[] _arr; // Массив элементов
		private int _currentPos; // Текущая позиция

		public ArrElArray()
		{
			_currentPos = 0;
			_arr = new ArrEl[Helpers.ArrayDefaultSize];
		}

		public ArrElArray(uint size)
		{
			_currentPos = 0;
			_arr = new ArrEl[size];
		}

		public ArrElArray(ArrEl[] arr)
		{
			_currentPos = arr.GetLength(0);
			_arr = arr;
		}

		public int Add(ArrEl item)
		{
			// Если позиция для вставки больше размерности массива
			if (_currentPos >= _arr.GetLength(0))
			{
				// Удваиваем размер
				Array.Resize(ref _arr, _arr.GetLength(0) * 2);
			}

			// Вставляем новый элемент
			_arr[_currentPos] = item;

			// Возвращаем позицию и затем увеличиваем на 1
			return _currentPos++;
		}

		// Индексатор по индексу массива
		public ArrEl this[int idx]
		{
			get
			{
				// Если переданный индекс выходит на границы массива
				if (idx < 0 || idx >= _currentPos)
				{
					throw new Exception(Helpers.ErrorOutBound);
				}

				// Возвращаем найденный элемент
				return _arr[idx];
			}
		}

		// Индексатор по имени элемента
		public ArrEl this[string name]
		{
			get
			{
				// Ищем индекс в массиве
				int idx = Array.FindIndex(_arr, v => v.Name == name);
				if (idx < 0)
				{
					// Выбрасываем исключение, если элемент с заданным именем не найден
					throw new Exception(Helpers.ErrorNonexistentName);
				}

				// Возвращаем искомый элемент
				return _arr[idx];
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("[");
			for (int i = 0; i < _currentPos; ++i)
			{
				sb.Append(String.Format(i + 1 == _currentPos ? "{0}: {1}" : "{0}: {1}, ",i, _arr[i]));
			}

			sb.Append("]");

			return sb.ToString();
		}
	}


	class Program
	{
		static void Main()
		{
			try
			{
				ArrElArray arr = new ArrElArray();
				arr.Add(new ArrEl("Test", 123));

				ArrEl s;
				s.Name = "Second";
				s.Val = 345;
				arr.Add(s);

				s.Name = "Third";
				s.Val = 88;
				arr.Add(s);

				Console.WriteLine(arr[2]); // Доступ по индексу
				Console.WriteLine(arr["Test"]); // Доступ по имени элемента
				Console.WriteLine(arr); // Вывод массива
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}