using System;
using CSCI120;
using CSCI120.Untyped;
using System.IO;
using System.Collections.Generic;

namespace FinalProject
{
	
	class Pokemon : IList , IArrayBased
	{
		//Declare List Variables
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

			pokedex [0] = 0;
			length++;
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
		//Constructing a new object
		private string number;
		private string name;
		private string type1;
		private string type2;

		public Pair(string Number, string Name, string Type1, string Type2)
		{
			number = Number;
			name = Name;
			type1 = Type1;
			type2 = Type2;
		}
		// Formatting a string
		public override string ToString()
		{
			return string.Format("\nIndex:\t{0}\nName:\t{1}\nType 1:\t{2}\nType 2:\t{3}\n", number, name, type1, type2);
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			//Initialization
			string user = "0";
			int userInt = 0;
			int x = 0;
			Pokemon pokemon = new Pokemon();
			pokemon.Initialize ();
			//Constructing a list from a csv file.
			using (StreamReader rdr = new StreamReader("../../Pokedex.txt"))
			{
				rdr.ReadLine(); // skip column headers
				while (!rdr.EndOfStream)
				{
					string line = rdr.ReadLine();
					string[] fields = line.Split(',');

					pokemon.Add (pokemon.Length, fields [0]);
				}
			}

			while (user.ToLower() != "quit")
			{
				//asking for user input
				user = "0";
				userInt = 0;
				Console.Write("Please enter a Pokedex number or enter QUIT to quit: ");
				user = Console.ReadLine();
			
				if (user.ToLower() != "quit")
				{
					//Data
					if (Int32.TryParse(user, out x)) {
						userInt = Convert.ToInt32 (user);
						if (userInt > pokemon.Length || userInt < 1) {
							Console.WriteLine ("\nSorry, we could not find that Pokedex number.\n");
						}
					} else {
						Console.WriteLine ("\nSorry, we could not find that Pokedex number.\n");
					}
				}

				using (StreamReader rdr = new StreamReader("../../Pokedex.txt"))
				{
					rdr.ReadLine(); // skip column headers
					while (!rdr.EndOfStream)
					{
						string line = rdr.ReadLine();
						string[] fields = line.Split(',');
					
						if (fields[0] == pokemon.Get(userInt).ToString())
						{
							Console.WriteLine(new Pair(fields[0], fields[1], fields[2], fields[3]));
						}
					}
				}



				Convert.ToString (user);
			}
		}
	}
}