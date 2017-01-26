using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_6
{

	/***
	 * Define the Deque class by implementing the 
	 * IDeque and IArrayBased interfaces.
	 **/
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
