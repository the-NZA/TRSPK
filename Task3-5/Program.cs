using System;

namespace Task3_5
{
	static class Swapper
	{
		public static void Swap(ref int a, ref int b)
		{
			(b, a) = (a, b); // Обмен через деконструкцию кортежа
		}
	}
	
	class Program
	{
		static void Main(string[] args)
		{
			int a = 33;
			int b = 98;
			Console.WriteLine("a is {0}, b is {1}", a, b);
			
			Swapper.Swap(ref a, ref b);	
			Console.WriteLine("a is {0}, b is {1}", a, b);
		}
	}
}