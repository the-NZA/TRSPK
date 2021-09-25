using System;

namespace Task3_1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите количество измерений: ");
			int x = Convert.ToInt32(Console.ReadLine());
			int []arr = new int[x];

			Random rg = new Random(); // Генератор случайных чисел

			for (int i = 0; i < x; i++)
			{
				Console.Write("Введите нижнюю границу: ");
				 int min = Convert.ToInt32(Console.ReadLine());
				 
				Console.Write("Введите верхнюю границу: ");
				 int max = Convert.ToInt32(Console.ReadLine());

				 if (min > max)
				 {
					 throw new Exception("Нижняя граница не может быть больше верхней");
				 }

				 arr[i] = rg.Next(min, max);
			}

			Console.Write("Полученный массив: [");
			for(int i = 0; i < arr.Length; ++i)
			{
				Console.Write(i + 1 == arr.Length ? "{0}" : "{0}, ", arr[i]);
			}
			Console.Write("]\n");
		}
	}
}