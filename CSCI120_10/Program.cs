using System;
using CSCI120;
using CSCI120.Generic;

namespace CSCI120_10
{

	class LinearHashTable<T> : IHashtable<T>
	{
		private T[] data = new T[100];
		private bool[] filled_data = new bool[100];
		private bool[] del_data = new bool[100];
		private int length = 0;
		private int counter = 0;

		#region IHashtable implementation

		public int Hash (T x)
		{
			return x.GetHashCode() % data.Length;
		}

		public int Length
		{
			get
			{
				return length; 
			}
		}
		
		public void Add (T x)
		{
			// 0. resize if needed
			if (length >= data.Length)
				Resize(10 * data.Length);

			// 1. Hash the new item
			int hash = Hash(x);

			for (int shift = 0; shift < data.Length; shift++)
			{
				int pos = (hash + shift) % data.Length; // 4. modulus shift
				counter++; // about to examine the array

				// 2. check for collisions
				if (!filled_data[pos] || del_data[pos])
				{
					// 3. find an available spot
					data[pos] = x;
					filled_data[pos] = true;
					del_data[pos] = false;
					break;
				}
			}

			// 5. Add to length
			length++;
		}

		public void Remove (T x)
		{
			throw new NotImplementedException ();
		}

		public T Find (T x)
		{
			throw new NotImplementedException ();
		}

		public int Length {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IArrayBased implementation

		public void Initialize ()
		{
			throw new NotImplementedException ();
		}

		public void Resize (int n)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IOperationCounter implementation

		public void ResetOperations ()
		{
			throw new NotImplementedException ();
		}

		public int Operations {
			get {
				throw new NotImplementedException ();
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
			LinearHashTable<Int32> lht = new LinearHashTable<Int32> ();
			System.Collections.Generic.List<Int32> al = new System.Collections.Generic.List<int> ();

			Random gen = new Random ();
			for (int idx = 0; idx < 10; idx++) {
				int nxt = gen.Next ();
				lht.Add (nxt);
				al.Add (nxt);
			}

			int ops = lht.Operations;
			TestStatement (lht.Length == 10, "Added 10 items", ref score, ref total);
			Console.WriteLine ("\t*** Used {0} operations", lht.Operations);
			TestStatement (lht.Operations >= 10, "At least 10 operations", ref score, ref total);
			TestStatement (lht.Operations <= 12, "Very unlikely there will be more than 12 operations", ref score, ref total);

			lht.ResetOperations ();

			foreach (int item in al) {
				int x = lht.Find (item);
				TestStatement (item == x, string.Format("Found {0}", item), ref score, ref total);
			}
			Console.WriteLine ("Used {0} more operations.", lht.Operations);
			TestStatement (ops == lht.Operations, "Operations should be same to find as to add.", ref score, ref total);
		}
	}
}
