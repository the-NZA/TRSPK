using System;

namespace Task3_6
{
	class Rectangle
	{
		private (double x, double y)[] _coords;

		public Rectangle(params (double, double)[] arr)
		{
			if (arr.GetLength(0) != 4)
			{
				throw new Exception("Передано число точек не равно 4-м");
			}

			_coords = arr;
		}

		private double distance((double x, double y) p, (double x, double y) c)
		{
			double x = p.x - c.x;
			x *= x;

			double y = p.y - c.y;
			y *= y;

			return x + y;
		}

		private bool isRectangle()
		{
			// Центральная координата по x
			double xAvg = 0;
			for (int i = 0; i < _coords.GetLength(0); i++)
			{
				xAvg += _coords[i].x;
			}

			xAvg /= 4;

			// Центральная координата по y
			double yAvg = 0;
			for (int i = 0; i < _coords.GetLength(0); i++)
			{
				yAvg += _coords[i].y;
			}

			yAvg /= 4;

			// Находим расстояния от каждой точки до центра
			double[] distances = new double[4];
			for (int i = 0; i < _coords.GetLength(0); i++)
			{
				distances[i] = distance(_coords[i], (xAvg, yAvg));
			}

			// Проверяем равны ли расстояния для каждой точки
			return distances[0] == distances[1] && distances[0] == distances[2] &&
			       distances[0] == distances[3];
		}

		public bool PerimAndArea(out double perim, out double area)
		{
			// Если не прямоугольник
			if (!isRectangle())
			{
				perim = 0;
				area = 0;

				return false;
			}

			// Длина по y
			int idxByX = Array.FindIndex(_coords, 1, v => v.x == _coords[0].x);
			double a = Math.Abs(_coords[0].y - _coords[idxByX].y);

			// Длина по x
			int idxByY = Array.FindIndex(_coords, 1, v => v.y == _coords[0].y);
			double b = Math.Abs(_coords[0].x - _coords[idxByY].x);

			perim = (a + b) * 2;
			area = a * b;

			return true;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Rectangle rect = new Rectangle((1.0, 1.0), (7.0, 1.0), (1.0, 5.0), (7.0, 5.0));
				double perim = 0.0;
				double area = 0.0;

				if (rect.PerimAndArea(out perim, out area))
				{
					Console.WriteLine("Периметр: {0}, Площадь: {1}", perim, area);
				}
				else
				{
					Console.WriteLine("Невозможно построить прямоугольник");
				}

				rect = new Rectangle((3.0, 3.0), (3.0, 0.0), (0.0, 0.0), (0.0, 3.0));
				if (rect.PerimAndArea(out perim, out area))
				{
					Console.WriteLine("Периметр: {0}, Площадь: {1}", perim, area);
				}
				else
				{
					Console.WriteLine("Невозможно построить прямоугольник");
				}
				
				rect = new Rectangle((3.0, 2.0), (3.0, 0.0), (0.0, 0.0), (0.0, 3.0));
				if (rect.PerimAndArea(out perim, out area))
				{
					Console.WriteLine("Периметр: {0}, Площадь: {1}", perim, area);
				}
				else
				{
					Console.WriteLine("Невозможно построить прямоугольник");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}