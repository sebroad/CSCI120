using System;
using CSCI120;
using CSCI120.Untyped;
using System.IO;
using System.Collections.Generic;

namespace FinalProject
{
	
	class Pokemon : IList , IArrayBased
	{
		private int length;
		private int counter;
		private object[] pokedex;

		public int Length
		{
			get
			{
				return length;
			}
		}

		public int Operations
		{
			get
			{
				return counter;
			}
		}

		public void Add(int i, object x)
		{
						//resize
			if (length == pokedex.Length) {
                Resize(2 * pokedex.Length);
			}
			//shift to the right
			for (int idx = length - 1; idx >= i; idx--)
			{
				counter++;
				pokedex[idx + 1] = pokedex[idx];
			}
			//add in the new item
			Set(i, x);

			//add one to length
			length++;

		}

		public void Clear()
		{
			length = 0;
		}

		public object Get(int i)
		{
			counter++;
			return pokedex[i];
		}

		public void Remove(int i)
		{
			//shift everything to the left
			for (int idx = i; idx<length - 1; idx++){
				counter++;
				pokedex[idx] = pokedex[idx + 1];
			}

			//reduce the length of the list by one
			length--;

			//resize
			if (pokedex.Length >= 3 * length) { 
				Resize(2 * length);
			}		
		}

		public void ResetOperations()
		{
			counter = 0;
		}

		public void Set(int i, object x)
		{
			counter++;
			pokedex[i] = x;		
		}

		public void Initialize()
		{
			length = 0;
			counter = 0;
			pokedex = new object[151];
		}

		public void Resize(int n)
		{
			if (n < 1)
				return;
			n = Math.Max(length, n);
			object[] new_data = new object[n];
			for (int idx = 0; idx<length; idx++) {
				counter++;
				new_data[idx] = pokedex[idx];
			}

			pokedex = new_data;
		}
	}
	class Pair
	{
		private string number;
		private string name;
		private string type;
		public Pair(string Number, string Name, string Type)
		{
			number = Number;
			name = Name;
			type = Type;
		}

		public override string ToString()
		{
			return string.Format("Entry {0}, {1}, {2}", number, name, type);
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			string user = "0";

			while (user.ToLower() != "quit")
			{
				user = "0";
				Console.Write("Please enter a Pokedex number or enter QUIT to quit: ");
				user = Console.ReadLine();
			
				if (user != "quit")
				{
					Convert.ToInt32(user);
				}

			
				using (StreamReader rdr = new StreamReader("../../Pokedex.txt"))
				{
					rdr.ReadLine(); // skip column headers
					while (!rdr.EndOfStream)
					{
						string line = rdr.ReadLine();
						string[] fields = line.Split(',');
					
						if (fields[0] == user)
						{
							Console.WriteLine(new Pair(fields[0], fields[1], fields[2]));
						}
					}
				}

				Convert.ToString (user);
			}
		}
	}
}