using System;
using CSCI120;
using CSCI120.Untyped;
using System.IO;

namespace FinalProject
{
	class Queue : IQueue, IArrayBased

	{

		private int beginning; //where the beginning of the list is
		private int length; //how long is the used portion of the array
		private object temp; //temporary variable
		private object[] data; //the array
		private int counter;  //how many operations have we done

		#region IArrayBased implementation

		public void Initialize()
		{
			beginning = 0;
			length = 0;
			counter = 0;
			data = new object[10];
		}

		public void Resize(int n)
		{
			if (n < 1)
				return;
			n = Math.Max(length, n);
			object[] new_data = new object[n];
			for (int idx = 0; idx < length; idx++)
			{
				counter++;
				new_data[idx] = data[idx];
			}

			data = new_data;
		}

		#endregion


		#region IQueue implementation

		public void Enqueue(object x)
		{
			length++;
			data[(length - 1)] = x;
			counter++;
		}

		public object Dequeue()
		{
			if (length == 0)
			{
				return null;
			}
			else
			{
				temp = data[beginning];
				beginning++;
				length--;
				counter++;
				return temp;
			}
		}

		#endregion

		#region IOperationCounter implementation

		public void ResetOperations()
		{
			counter = 0;
		}

		public int Operations
		{
			get
			{
				return counter;
			}
		}
	}


	#endregion

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
<<<<<<< Updated upstream
					string line = rdr.ReadLine();
					string[] fields = line.Split(',');
					if (fields[0].Length > 0)
					{
						Console.WriteLine(new Pair(fields[0], fields[1], fields[2]));
					}
=======
					Convert.ToInt32(user);
>>>>>>> Stashed changes
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
							Console.ReadKey();
						}
					}
				}

				Convert.ToString (user);
			}
			Console.ReadKey();
		}
	}
}