using System;
using System.Collections.Generic;
using System.IO;

namespace Task3_0
{
	class Helpers
	{
		public static string inputFile = "/Users/romankozlov/RiderProjects/TRSPK/Task3-0/INPUT.txt";
		public static string outputFile = "/Users/romankozlov/RiderProjects/TRSPK/Task3-0/OUTPUT.txt";
		
		public static string InvalidNumberOfCells = "Неверно задано количество клеток";
		public static string InvalidCoordsString = "Неверно заданa строка с координатами";
		public static string InvalidCoords = "Координаты ячеек должны быть между 1 и 8";
	}
	
	class PerCalc
	{
		private int _n;
		private string _inputFile;
		private string _outputFile;
		private List<int> _xArr = new List<int>();
		private List<int> _yArr = new List<int>();

		public PerCalc()
		{
			_inputFile = Helpers.inputFile;
			_outputFile= Helpers.outputFile;
		}

		public PerCalc(string inputFile, string outputFile)
		{
			_inputFile = String.IsNullOrWhiteSpace(inputFile) ? Helpers.inputFile : inputFile; // Имя файла для чтения информации
			_outputFile = String.IsNullOrWhiteSpace(outputFile) ? Helpers.outputFile : outputFile; // Имя файла для записи информации
		}

		private void ReadCoords()
		{
			 string[] lines = File.ReadAllLines(_inputFile); // Читаем все строки из файла

			 _n = Convert.ToInt32(lines[0]); // Получаем количество вырезанных клеток

			 // Если указано некоректное число клеток
			 if (_n < 1)
			 {
				 throw new Exception(Helpers.InvalidNumberOfCells);
			 }
			 
			 for (int i = 1; i < lines.Length; i++)
			 {
				 string[] coords = lines[i].Split(' '); // Разбиваем строку по символу пробела

				 // Если считано НЕ две координаты
				 if (coords.Length != 2)
				 {
					 throw new Exception(Helpers.InvalidCoordsString);
				 }

				 int c = Convert.ToInt32(coords[0]);
				 if (c < 1 || c > 8)
				 {
					 throw new Exception(Helpers.InvalidCoords);
				 }
				 
				 _xArr.Add(c); // Сохраняем координату по x

				 c = Convert.ToInt32(coords[1]);
				 if (c < 1 || c > 8)
				 {
					 throw new Exception(Helpers.InvalidCoords);
				 }
				 
				 _yArr.Add(c); // Сохраняем координату по y
			 }
		}

		public int Calculate()
		{ 
			ReadCoords(); // Читаем координаты из файла

			int maxPerimeter = 4 * _n; // Максимально возможный периметр для _n клеток
			
			// Считаем количество дублей по оси х
			for (int i = 0; i < _xArr.Count -1 ; i++)
			{
				for (int j = i + 1; j < _xArr.Count; j++)
				{
					if (_xArr[i] == _xArr[j])
					{
						maxPerimeter -= 2;
						break;
					}
				}
			}

			// Считаем количество дублей по оси y
			for (int i = 0; i < _yArr.Count - 1; i++)
			{
				for (int j = i + 1; j < _yArr.Count; j++)
				{
					if (_yArr[i] == _yArr[j])
					{
						maxPerimeter -= 2;
						break;
					}
				}
			}
			
			File.WriteAllText(_outputFile, $"{maxPerimeter}"); // Записываем результата в файл
			 
			return maxPerimeter;
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				PerCalc p = new PerCalc();
				Console.WriteLine(p.Calculate());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}