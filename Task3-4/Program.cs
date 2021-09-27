using System;

namespace Task3_4
{
	static class Ops
	{
		public static int Sum(params int[] arr)
		{
			int sum = 0;

			foreach (int v in arr)
			{
				sum += v;
			}

			return sum;
		}
	}
	
	class Program
	{
		
		static void Main()
		{
			int sum = Ops.Sum(1, 2, 3, 4, 5);
			Console.WriteLine("Sum of 1,2,3,4,5 = {0}" , sum);
		}
	}
}