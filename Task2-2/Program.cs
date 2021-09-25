using System;

namespace Task2._2
{
	class LongNumber
	{
		private bool sign;
		private readonly byte[] digits; //Массив цифр

		public LongNumber(bool sign, string value)
		{
			this.sign = sign;
			digits = new byte[value.Length];
			for (int i = value.Length - 1; i >= 0; i--) //Чем младше индекс - тем меньше цифра
			{
				char c = value[value.Length - i - 1];
				digits[i] = Byte.Parse(c.ToString());
			}
		}

		private LongNumber(bool sign, byte[] digits)
		{
			this.sign = sign;
			this.digits = digits;
		}

		//Копирующий конструктор
		public LongNumber(bool sign, LongNumber a1)
		{
			sign = a1.sign;
			digits = a1.digits;
			int Length1 = a1.digits.Length;
			for (int i = Length1 - 1; i >= 0; i--)
			{
				digits[i] = a1.digits[i];
			}
		}

		//Вывод
		public void writenumber()
		{
			if (!sign) Console.Write("-");
			for (int i = digits.Length - 1; i >= 0; i--)
			{
				Console.Write(digits[i]);
			}

			Console.WriteLine();
		}

		protected bool Equals(LongNumber other)
		{
			return Equals(digits, other.digits);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((LongNumber) obj);
		}

		public override int GetHashCode()
		{
			return (digits != null ? digits.GetHashCode() : 0);
		}

		public static LongNumber operator +(LongNumber a1, LongNumber a2)
		{
			int tmpLength = Math.Max(a1.digits.Length, a2.digits.Length);
			byte[] tmpDigits = new byte[tmpLength];
			byte overflow = 0;
			if (a1.sign == a2.sign)
			{
				for (int i = 0; i < tmpLength; i++)
				{
					byte result = overflow;
					if (a1.digits.Length > i) result += a1.digits[i];
					if (a2.digits.Length > i) result += a2.digits[i];
					if (result >= 10)
					{
						result -= 10;
						overflow = 1;
					}
					else
					{
						overflow = 0;
					}

					tmpDigits[i] = result;
				}

				if (overflow > 0)
				{
					Array.Resize(ref tmpDigits, tmpLength + 1);
					tmpDigits[tmpLength] = 1;
				}

				return new LongNumber(a1.sign, tmpDigits);
			}
			else
			{
				if (a1.sign == false)
				{
					a1.sign = true;
					return a2 - a1;
				}
				else
				{
					a2.sign = true;
					return a1 - a2;
				}
			}
		}

		// Максимум из двух чисел
		public static bool Max_number(LongNumber a1, LongNumber a2)
		{
			if (a1.digits.Length > a2.digits.Length) return true;
			if (a2.digits.Length < a2.digits.Length) return false;

			if (a1.digits == a2.digits) return true;
			if (a1.digits.Length == a2.digits.Length)
			{
				for (int i = a1.digits.Length - 1; i >= 0; i--)
				{
					if (a1.digits[i] > a2.digits[i]) return true;
				}
			}

			return false;
		}

		// удаляет ведущие нули
		private static LongNumber DeleteNull(LongNumber a1)
		{
			int k = 0;
			for (int i = a1.digits.Length - 1; i >= 0; i--)
			{
				if (a1.digits[i] == 0) k++;
				else break;
			}

			byte[] tmp = new byte[a1.digits.Length - k];
			for (int i = 0; i < tmp.Length; i++)
			{
				tmp[i] = a1.digits[i];
			}

			return new LongNumber(a1.sign, tmp);
		}

		public static LongNumber Minus(bool z, LongNumber a1, LongNumber a2)
		{
			int tmpLength = a1.digits.Length;
			byte[] tmpDigits = new byte[tmpLength];
			byte[] resultDigits = new byte[tmpLength];

			for (int i = 0; i < tmpLength; i++)
			{
				tmpDigits[i] = 9;
			}

			for (int i = 0; i < tmpLength; i++)
			{
				byte result = 0;
				result += tmpDigits[i];
				if (a2.digits.Length > i) result -= a2.digits[i];

				resultDigits[i] = result;
			}

			LongNumber resultTMP = new LongNumber(true, resultDigits);

			resultTMP = resultTMP + a1;

			LongNumber a4 = new LongNumber(true, "1");
			resultTMP = resultTMP + a4;

			Array.Resize(ref resultDigits, tmpLength + 1);
			resultTMP.digits[tmpLength] -= 1;

			resultTMP.sign = z;
			resultTMP = DeleteNull(resultTMP);
			return resultTMP;
		}

		public static LongNumber operator -(LongNumber a1, LongNumber a2)
		{
			if ((a1.sign == false && a2.sign == true) || (a1.sign == true && a2.sign == false))
			{
				a2.sign = !a2.sign;
				return a1 + a2;
			}

			if (a1.sign == a2.sign && a1.sign == true)
			{
				if (Max_number(a1, a2)) return Minus(true, a1, a2);
				else return Minus(false, a2, a1);
			}

			if (a1.sign == a2.sign && a1.sign == false)
			{
				if (Max_number(a2, a1)) return Minus(true, a2, a1);
				else return Minus(false, a1, a2);
			}

			return a1;
		}

		// Оператор умножения на число < 10;
		public static LongNumber operator *(LongNumber a, byte b)
		{
			byte[] tmpDigits = new byte[a.digits.Length];
			byte overflow = 0;

			for (int i = 0; i < a.digits.Length; i++)
			{
				byte result = overflow;
				result += (byte) (a.digits[i] * b);
				if (result >= 10)
				{
					overflow = (byte) (result / 10);
					result = (byte) (result % 10);
				}
				else
				{
					overflow = 0;
				}

				tmpDigits[i] = result;
			}

			if (overflow > 0)
			{
				Array.Resize(ref tmpDigits, a.digits.Length + 1);
				tmpDigits[a.digits.Length] = overflow;
			}

			return new LongNumber(true, tmpDigits);
		}


		public static LongNumber operator *(LongNumber a1, LongNumber a2)
		{
			byte[,] tmpDigits = new byte[a1.digits.Length, a1.digits.Length];
			LongNumber sum = new LongNumber(true, "0");
			for (int i = 0; i < a1.digits.Length; i++)
			{
				byte[] sumI = new byte[a2.digits.Length];
				sumI = (a2 * a1.digits[i]).digits;
				Array.Resize(ref sumI, sumI.Length + i);
				if (i > 0)
				{
					for (int j = sumI.Length - 1; j >= i; j--)
					{
						sumI[j] = sumI[j - i];
					}

					for (int j = 0; j < i; j++)
					{
						sumI[j] = 0;
					}
				}

				sum += new LongNumber(sum.sign, sumI);
			}

			if (a1.sign != a2.sign) sum.sign = false;
			else sum.sign = true;
			return sum;
		}


		public static bool operator ==(LongNumber a1, LongNumber a2)
		{
			int length1 = a1.digits.Length;
			int length2 = a2.digits.Length;
			if (a1.sign != a2.sign) return false;
			if (length1 != length2)
			{
				return false;
			}

			for (int i = 0; i < length1; i++)
			{
				if (a1.digits[i] != a2.digits[i]) return false;
			}

			return true;
		}

		public static bool operator !=(LongNumber a1, LongNumber a2)
		{
			return !(a1 == a2);
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			LongNumber a1 = new LongNumber(true, "10000");
			LongNumber a2 = new LongNumber(true, "200");
			LongNumber a3 = a1 - a2;
			a3.writenumber();
		}
	}
}