using System;

namespace Task1_2
{
	class Team
	{
		public string Name = "Дети маминой подруги"; // Публичное поле класса
		public readonly int NumOfPeople = 5; // Публичное поле класса только для чтения
		private int _year = 2021; // Приватное поле
		public static string Discipline = "ТРСПК"; // Публичное статическое поле
		private static int CourseYear = 3; // Приватное статическое поле

		public Team()
		{
			
		}
		
		public Team(int newNumOfPeople)
		{
			NumOfPeople = newNumOfPeople;
		}
		public void SetYear(int newYear)
		{
			_year = newYear;
		}

		public override string ToString()
		{
			return $"{Name}:{NumOfPeople}:{Discipline}:{CourseYear}:{_year}";
		}
	}
	
	class Program
	{
		static void Main()
		{
			/* Обычные переменные и константы*/
			int variable = 5; // Простая переменная
			Console.WriteLine("Начальное значение переменной: {0}", variable);
			variable = 23; // Можно изменить
			Console.WriteLine("Измененное значение переменной: {0}",variable);
			
			const double smallPi= 3.14; // Простая константа
			Console.WriteLine("Значение константы: {0}\n",smallPi);
			// Нельзя изменить константу
			// smallPI = 22; // Выдаст ошибку

			/* Поля класса */
			Team team = new Team();
			Console.WriteLine("Экземляр класса\n{0}", team); // Вывод экземпляра класса
			
			Console.WriteLine("Начальное значение поля класса: {0}",team.Name); // Можно прочитать
			team.Name = team.Name + "!";  // Можно изменить
			Console.WriteLine("Измененное значение поля класса {0}",team.Name); 
			
			Console.WriteLine("Значение поля для чтения: {0}",team.NumOfPeople); // Только для чтения
			// team.NumOfPeople = 6; // Выдаст ошибку
			
			// Console.WriteLine(team._year); // Недоступное приватное поле
			team.SetYear(2022); // Обновление приватного поля
			
			Console.WriteLine("Значение статического поля: {0}",Team.Discipline); // Доступ к статическому полю
			// Console.WriteLine(Team.CourseYear); // Приватное статическое поле недоступно из вне
		}
	}
}