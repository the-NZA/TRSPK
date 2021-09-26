using System;
using System.Text;

namespace Task3_1
{
	class Task
	{
		private int[,] _arr; // Массив
		private readonly Random _rg; // Генератор случайных чисел

		public Task()
		{
			_rg = new Random(DateTime.Now.Millisecond); // Инициализация генератора случайных чисел
		}

		public void Run()
		{
			try
			{
				Console.Write("Введите количество строк: ");
				int row = Convert.ToInt32(Console.ReadLine());

				Console.Write("Введите количество колонок: ");
				int col = Convert.ToInt32(Console.ReadLine());

				_arr = new int[row, col]; // Массив с полученными измерениями

				this.FillArray(); // Заполняем массив случайными числами
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private void FillArray()
		{
			for (int i = 0; i < _arr.GetLength(0); i++)
			{
				try
				{
					Console.Write("Введите нижнюю границу: ");
					int min = Convert.ToInt32(Console.ReadLine());

					Console.Write("Введите верхнюю границу: ");
					int max = Convert.ToInt32(Console.ReadLine());

					if (min > max)
					{
						throw new Exception("Нижняя граница не может быть больше верхней");
					}

					for (int j = 0; j < _arr.GetLength(1); j++)
					{
						_arr[i, j] = _rg.Next(min, max);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		public void ShowArray()
		{
			Console.WriteLine(this);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("Полученный массив:\n[\n");

			for (int i = 0; i < _arr.GetLength(0); ++i)
			{
				sb.Append("\t[");
				
				for (int j = 0; j < _arr.GetLength(1); ++j)
				{
					sb.Append(String.Format(j + 1 == _arr.GetLength(1) ? "{0}" : "{0}, ",
						_arr[i, j]));
				}

				sb.Append("]\n");
			}

			sb.Append("]");

			return sb.ToString();
		}
	}

	class Program
	{
		static void Main()
		{
			Task t = new Task();
			t.Run();
			Console.WriteLine(t);
		}
	}
}