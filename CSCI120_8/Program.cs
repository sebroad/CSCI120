using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_8
{

	/***
	 * Implement the IDeque interface in a class called LinkedDeque
	 **/
	class Lab8 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab8 ()).Exec ("Linked list IDeque implementation");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oDeque = new ArrayList ();
			Random gen = new Random ();

			// Test object
			IDeque deque = null;
			deque = (IDeque)(Activator.CreateInstanceFrom ("CSCI120_8.exe", "CSCI120_8.DoublyLinkedDeque").Unwrap());
			TestStatement (deque != null, "Created an Deque object", ref score, ref total);

			// Alternate between add first and add last
			for (int i = 0; i < 20; i++) {
				int x = gen.Next(10000);
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
