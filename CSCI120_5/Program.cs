using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_5
{

	class Lab5 : CSCI120.TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab5 ()).Exec ("IQueue implementation");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oQueue = new ArrayList ();
			Random gen = new Random ();

			// Test object
			CSCI120.Untyped.IQueue queue = null;
			queue = (CSCI120.Untyped.IQueue)(Activator.CreateInstanceFrom ("CSCI120_5.exe", "CSCI120_5.Queue").Unwrap());
			TestStatement (queue != null, "Created an Queue object", ref score, ref total);

			((IArrayBased)queue).Initialize ();
			((IArrayBased)queue).Resize (20);

			TestStatement (queue.Dequeue() == null, "Empty queue", ref score, ref total);

			for (int i = 0; i < 20; i++) {
				int x = gen.Next();
				queue.Enqueue (x);
				oQueue.Add (x);
			}

			while (oQueue.Count > 0) {
				int mine = Convert.ToInt32 (queue.Dequeue ());
				int theirs = Convert.ToInt32 (oQueue [0]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
				oQueue.RemoveAt (0);
			}

			TestStatement (total == 22, "Twenty tests were run", ref score, ref total);
			TestStatement (queue.Operations == 40, "Forty operations were counted.", ref score, ref total); 

			// Put 15 items in the queue
			for (int i = 0; i < 15; i++)
				queue.Enqueue (gen.Next ());

			queue.ResetOperations ();
			((IArrayBased)queue).Resize (100);
			TestStatement (queue.Operations == 15, "Resize costs 15", ref score, ref total);

			for (int i = 0; i < 85; i++)
				queue.Enqueue (gen.Next ());

			int capacity = 0;
			for (object obj = queue.Dequeue (); obj != null; obj = queue.Dequeue ())
				capacity++;
			
			TestStatement (capacity == 100, "Stack has capacity for 100 items", ref score, ref total);

		}

	}
}
