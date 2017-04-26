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
		private int number;
		private string name;
		private string type;
		public Pair(string Name, string Value)
		{
			name = Name;
			value = Value;
		}

		public override string ToString()
		{
			return string.Format("[Pair {0}, {1}]", name, value);
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			using (StreamReader rdr = new StreamReader("../../Pokedex.txt"))
			{
				rdr.ReadLine(); // skip column headers
				while (!rdr.EndOfStream)
				{
					string line = rdr.ReadLine();
					string[] fields = line.Split(',');

					Console.WriteLine(new Pair(fields[0], fields[1]));
					Console.ReadKey();
				}
			}
		}
	}
}