using System;

namespace Binary
{
	class Binary
	{
		static string GetInput()
		{
			Console.Write("Enter numbers separated by spaces: ");
			return Console.ReadLine();
		}

		static bool IsInputValid(string input)
		{
			string[] text = input.Trim().Split(' ');
			int value = 0;
			foreach (string number in text)
			{
				if (!int.TryParse(number, out value))
				{
					Console.WriteLine("Invalid input, it should be in numerical separated by spaces!");
					return false;
				}

				if (int.Parse(number) < 1)
				{
					Console.WriteLine("Invalid Input, number should not be less than 1.");
					return false;
				}

				if (int.Parse(number) > 255)
				{
					Console.WriteLine("Invalid Input, number should not be over 255.");
					return false;
				}
			}
			return true;
		}

		static string[,] ConvertToBinary(string input)
		{
			string[] number = input.Split(' ');
			string[,] matrix = new string[number.Length + 1, 9];
			int m, i;

			for (int x = 1; x < number.Length + 1; x++)
			{
				matrix[x, 0] = number[x - 1];
				m = int.Parse(number[x-1]);

				int num = 128;
				matrix[0, 0] = "Numbers";
				for (int z = 1; z < 9; z++)
				{
					matrix[0, z] = num.ToString();
					num /= 2;
				}

				for (int y = 8; y > 0; y--)
				{
					matrix[x, y] = (m % 2).ToString();
					m /= 2;
				}
			}
			return matrix;
		}

		static void PrintMatrix(string[,] matrix)
        {
			for (int y = 0; y < matrix.GetLength(1); y++)
			{
				for (int x = 0; x < matrix.GetLength(0); x++)
				{
					Console.Write(matrix[x, y] + "\t");
				}
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			string[,] matrix;
			string number;
			do
			{
				number = GetInput();
			} while (!IsInputValid(number));
			matrix = ConvertToBinary(number);
			PrintMatrix(matrix);
		}
	}

}

