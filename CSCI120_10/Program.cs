using System;
using CSCI120;
using CSCI120.Generic;

namespace CSCI120_10
{
	class Veggie
	{
		private string name;
		private double weight;
		private int number;

		public Veggie(string Name, double Weight, int Number)
		{
			name = Name;
			weight = Weight;
			number = Number;
		}

		public string Name
		{
			get { return name; }
		}
		public int Number
		{
			get { return number; }
		}
		public string Weight
		{
			get { return weight; }
		}
		public override int GetHashCode ()
		{
			return Name.GetHashCode ();
		}
	}

	class LinearHashTable<T> : IHashtable<T>
	{
		private T[] data = new T[1000];
		private bool[] filled_data = new bool[1000];
		private bool[] del_data = new bool[1000];
		private int counter = 0;
		private int length = 0;

		#region IHashtable implementation
		public int Hash (T x)
		{
			return x.GetHashCode () % data.Length;
		}
		public void Add (T x)
		{
			int hash = Hash (x);
			data [hash] = x;
			filled_data [hash] = true;
			del_data [hash] = false;
			counter++;
			length++;
		}
		public void Remove (T x)
		{
			int hash = Hash (x);
			filled_data [hash] = false;
			del_data [hash] = true;
			length--;
			counter++;
		}
		public T Find (T x)
		{
			int hash = Hash (x);
			counter++;
			return data [hash];
		}
		#endregion

		#region IArrayBased implementation
		public void Initialize ()
		{
		}
		public void Resize (int n)
		{
			// copy the old array
			T[] old_data = data;
			bool[] old_filled = filled_data;
			bool[] old_del = del_data;

			// reallocate the array
			data = new T[n];
			filled_data = new bool[n];
			del_data = new bool[n];
			length = 0;

			// look for non-null, non-deleted values
			for (int idx =0; idx < old_data.Length; idx++)
			{
				if (old_filled[idx] && !old_del[idx])
				{
					// add them into the hashtable
					Add(old_data[idx]);
				}
			}
		}
		#endregion

		#region IOperationCounter implementation
		public void ResetOperations ()
		{
			counter = 0;
		}
		public int Operations {
			get {
				return counter;
			}
		}
		#endregion
	}

	/***
	 * Implement the Generic IHashtable interface
	 * in a class named LinearHashTable.
	 * 
	 * Also implement the IArrayBased.
	 **/ 
	class Lab10 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab10 ()).Exec ("Implement Linear Hashtable");
		}

		public override void RunTests (ref int score, ref int total)
		{
			LinearHashTable<Veggie> hashTable = new LinearHashTable<Veggie> ();

			TestStatement (hashTable != null, "Created as HashTable", ref score, ref total);

			Veggie v = new Veggie ("Carrot", 2.5, 25);
			hashTable.Add (v);

			Veggie w = hashTable.Find (v);

			TestStatement (w.Name == v.Name, "Did we find the carrot?", ref score, ref total);
		}
	}
}
