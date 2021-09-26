using System;

namespace Task3_2
{
	// Вспомагательный класс 
	static class Helpers
	{
		public static string InvalidName = "Имя не может быть пустым";
		public static string InvalidTeenagerAge = "Возраст должен быть между 13 и 19 годами";
		public static string InvalidWorkerAge = "Возраст должен быть между 16 и 70 годами";
	}

	class Man // Класс Man
	{
		// Поля класса
		protected string Name;
		protected int Age;

		// Сокращенный синтаксис для свойств
		public string NameProp // Свойство Name
		{
			get => Name; // Возвращаем поле name

			set => SetName(value); // Устанавливаем новое значение для name
		}

		// Обычный синтаксис для свойств
		public int AgeProp // Свойство Age
		{
			get { return Age; }

			set { SetAge(value); }
		}

		public Man(string name)
		{
			if (IsInvalidName(name)) //проверка на пустую строку
			{
				throw new Exception(Helpers.InvalidName);
			}
			else
			{
				this.Name = name;
			}
		}

		public Man(string name, int age)
		{
			if (IsInvalidName(name))
			{
				throw new Exception(Helpers.InvalidName);
			}
			else
			{
				this.Name = name;
				this.Age = age;
			}
		}

		// Вспомогательный метод для валидации поля _name
		private bool IsInvalidName(string n)
		{
			return String.IsNullOrWhiteSpace(n);
		}

		// Геттер для имени
		public string GetName()
		{
			return this.Name;
		}

		// Геттер для возраста
		public int GetAge()
		{
			return this.Age;
		}

		// Метод изменения имени
		public void SetName(string n)
		{
			if (IsInvalidName(n))
			{
				throw new Exception(Helpers.InvalidName);
			}
			else
			{
				this.Name = n;
			}
		}

		// Метод изменения возраста
		public virtual void SetAge(int a)
		{
			this.Age = a;
		}

		// Текстовое представление класса Man
		public override string ToString()
		{
			return $"Человек, {Name}, {Age}";
		}
	}

	// Класс Teenager наследуем от Man
	class Teenager : Man
	{
		private string _school;

		public string SchoolProp // Свойство School
		{
			get => _school;

			set => SetSchool(value);
		}

		// Проверка возраста для Teenager
		private bool IsValidAge(int a)
		{
			return a > 12 && a < 20;
		}

		public Teenager(string name, int age, string school) : base(name)
		{
			if (IsValidAge(age))
			{
				this.Age = age;
				this._school = school;
			}
			else
			{
				throw new Exception("Ограничение по возрасту");
			}
		}

		public void SetSchool(string school)
		{
			this._school = school;
		}

		//Переопределение метода изменения поля возраста
		public override void SetAge(int a)
		{
			if (IsValidAge(a))
			{
				this.Age = a;
			}
			else
			{
				throw new Exception(Helpers.InvalidTeenagerAge);
			}
		}

		// Текстовое представление класса Teenager
		public override string ToString()
		{
			return $"Подросток, {Name}, {Age}, Место учебы: {_school}";
		}
	}

	class Worker : Man
	{
		private string _workPlace;

		public string WorkPlaceProp // Свойство WorkPlace
		{
			get => _workPlace;

			set => SetWorkPlace(value);
		}

		// Проверка возраста для Worker
		private bool IsValidAge(int a)
		{
			return a > 15 && a < 71;
		}

		public Worker(string name, int age, string workPlace) : base(name)
		{
			if (IsValidAge(age))
			{
				this.Age = age;
				this._workPlace = workPlace;
			}
			else
			{
				throw new Exception(Helpers.InvalidWorkerAge);
			}
		}

		public void SetWorkPlace(string workPlace)
		{
			this._workPlace = workPlace;
		}

		public override void SetAge(int a)
		{
			if (IsValidAge(a))
			{
				this.Age = a;
			}
			else
			{
				throw new Exception(Helpers.InvalidWorkerAge);
			}
		}

		public override string ToString()
		{
			return $"Работник, {Name}, {Age}, Место работы: {_workPlace}";
		}
	}

	class Program
	{
		static void Main()
		{
			try
			{
				/* Класс Man */
				// Man firstMan = new Man(""); // Выбросит исключение
				// Man secondMan = new Man("   "); // Выбросит исключение

				Man thirdMan = new Man("Jesus", 2021);
				Console.WriteLine(thirdMan);

				thirdMan.NameProp = "Thomas"; // Установка нового имени через свойство
				Console.WriteLine(thirdMan.NameProp); // Печать имени через свойство

				thirdMan.AgeProp = 34; // Установка нового возраста через свойство
				Console.WriteLine(thirdMan.AgeProp); // Печать возраста через свойство

				Console.WriteLine(thirdMan);

				/* Класс Teenager */
				// Teenager firstTeenager = new Teenager("", 13, "MBS #1"); // Выбросит исключение из-за имени
				// Teenager secondTeenager = new Teenager("J", 12, "MBS #1"); // Выбросит исключение из-за границ возраста

				Teenager thirdTeenager = new Teenager("Nimo", 14, "Private School №1");
				Console.WriteLine(thirdTeenager);

				Console.WriteLine(thirdTeenager.SchoolProp); // Печать свойтсва School
				thirdTeenager.SchoolProp = "Public School №1133"; // Установка нового значения через свойство
				thirdTeenager.AgeProp = 15; 
				
				Console.WriteLine(thirdTeenager);

				/* Класс Worker */
				// Worker firstWorker = new Worker("", 22, "UPMG"); // Выбросит исключение из-за имени
				// Worker secondWorker = new Worker("Abla", 14, "UPMG"); // Выбросит исключение из-за возраста 

				Worker thirdWorker = new Worker("Micki", 32, "Geoz");
				Console.WriteLine(thirdWorker);

				thirdWorker.WorkPlaceProp = "GCR";
				Console.WriteLine(thirdWorker.WorkPlaceProp);
			}
			catch (Exception e)
			{
				// Вывод исключений
				Console.WriteLine(e);
			}
		}
	}
}