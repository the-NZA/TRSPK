using System;
using System.Collections.Generic;
using System.IO;

namespace Task3_0
{
	static class Helpers
	{
		public static readonly string InputFile = "/Users/romankozlov/RiderProjects/TRSPK/Task3-0/INPUT.txt";
		public static readonly string OutputFile = "/Users/romankozlov/RiderProjects/TRSPK/Task3-0/OUTPUT.txt";
		
		public static string InvalidNumberOfCells = "Неверно задано количество клеток";
		public static string InvalidCoordsString = "Неверно заданa строка с координатами";
		public static string InvalidCoords = "Координаты ячеек должны быть между 1 и 8";
	}
	
	class PerCalc
	{
		private int _n;
		private readonly string _inputFile;
		private readonly string _outputFile;
		private readonly List<(int x,int y)> _coords = new List<(int, int)>();

		public PerCalc()
		{
			_inputFile = Helpers.InputFile;
			_outputFile= Helpers.OutputFile;
		}

		public PerCalc(string inputFile, string outputFile)
		{
			_inputFile = String.IsNullOrWhiteSpace(inputFile) ? Helpers.InputFile : inputFile; // Имя файла для чтения информации
			_outputFile = String.IsNullOrWhiteSpace(outputFile) ? Helpers.OutputFile : outputFile; // Имя файла для записи информации
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

				 int x = Convert.ToInt32(coords[0]);
				 if (x < 1 || x > 8)
				 {
					 throw new Exception(Helpers.InvalidCoords);
				 }

				 int y = Convert.ToInt32(coords[1]);
				 if (y < 1 || y > 8)
				 {
					 throw new Exception(Helpers.InvalidCoords);
				 }
				 
				 _coords.Add((x,y));
			 }
		}

		public int Calculate()
		{ 
			ReadCoords(); // Читаем координаты из файла

			int maxPerimeter = 4 * _n; // Максимально возможный периметр для _n клеток

			// Просматриваем для X
			for (int i = 0; i < _coords.Count; i++)
			{
				for (int j = 0; j < _coords.Count; j++)
				{
					if (_coords[i].y == _coords[j].y && (_coords[i].x + 1) == _coords[j].x)
					{
						maxPerimeter -= 2;
						break;
					}
				}
			}
			
			// Просматриваем для Y
			for (int i = 0; i < _coords.Count; i++)
			{
				for (int j = 0; j < _coords.Count; j++)
				{
					if (_coords[i].x == _coords[j].x && (_coords[i].y + 1) == _coords[j].y)
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
		static void Main()
		{
			try
			{
				PerCalc p = new PerCalc(inputFile: Helpers.InputFile, outputFile: Helpers.OutputFile);
				Console.WriteLine(p.Calculate());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}