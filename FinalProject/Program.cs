using System;
using CSCI120;
using CSCI120.Untyped;
using System.IO;
using System.Collections.Generic;

namespace FinalProject
{
	
	class Pokemon : IList
	{
		private int length = 0;
		private int counter = 0;
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
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public object Get(int i)
		{
			throw new NotImplementedException();
		}

		public void Remove(int i)
		{
			throw new NotImplementedException();
		}

		public void ResetOperations()
		{
			counter = 0;
		}

		public void Set(int i, object x)
		{
			throw new NotImplementedException();
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