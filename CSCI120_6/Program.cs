using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_6
{

	class Queue : IDeque, IArrayBased {

		private int beginning; //where the beginning of the list is
		private int end; //where the end of the list is
		private int length; //how long is the used portion of the array
		private object temp; //temporary variable
		private object[] data; //the array
		private int counter;  //how many operations have we done
		
		#region IArrayBased implementation

		public void Initialize ()
		{
			beginning = 0;
			end = 0;
			length = 0;
			counter = 0;
			data = new object[10];
		}

		public void Resize (int n)
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

		#region IDeque implementation

		public void AddLast (object x)
		{
			length++;
			data [(length-1)] = x;
			counter++;
		}

		public void AddFirst (object x)
		{
			if (length == 0) {
				data [beginning] = x;
				counter++;
			} else {
				beginning--;
				data [beginning] = x;
				counter++
				;
			}
		}

		public object RemoveLast ()
		{
			if (length == 0) {
				return null;
			} else {
				end--;
				counter++;
				return end;
			}
		}

		public object RemoveFirst ()
		{
			if (length == 0) {
				return null;
			} else {
				temp = data [beginning];
				beginning++;
				length--;
				counter++;
				return temp;
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

	class Lab6 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab6 ()).Exec ("Implement IDeque");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oDeque = new ArrayList ();
			Random gen = new Random ();

			// Test object
			IDeque deque = null;
			deque = (IDeque)(Activator.CreateInstanceFrom ("CSCI120_6.exe", "CSCI120_6.Deque").Unwrap());
			TestStatement (deque != null, "Created an Deque object", ref score, ref total);

			((IArrayBased)deque).Initialize ();
			((IArrayBased)deque).Resize (20);

			// Alternate between add first and add last
			for (int i = 0; i < 20; i++) {
				int x = i;
				if (i % 2 == 0) {
					deque.AddFirst (x);
					oDeque.Insert (0, x);
				} else {
					deque.AddLast (x);
					oDeque.Add (x);
				}
			}

			// Match from the front
			for (int i = 0; i < 10; i++) {
				int mine = Convert.ToInt32 (deque.RemoveFirst ());
				int theirs = Convert.ToInt32 (oDeque [i]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
			}

			// Match from the back
			for (int i = oDeque.Count - 1; i >= 10; i--) {
				int mine = Convert.ToInt32 (deque.RemoveLast ());
				int theirs = Convert.ToInt32 (oDeque [i]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
			}

			// Each addition and removal should take one operation, hence 40 total
			TestStatement(deque.Operations == 40, "Forty operations", ref score, ref total);

		}
	}
}
