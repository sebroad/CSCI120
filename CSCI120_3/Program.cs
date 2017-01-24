using System;
using CSCI120.Untyped;

namespace CSCI120_3
{

	/***
	 * Define the ArrayStack class in namespace CSCI120_3,
	 * implementing the interfaces 
	 *  + CSCI120.Untyped.IList
	 * 
	 * This will also implement the inherited interface
	 * IOperationCounter. Whenever your list examines or
	 * changes the value of a position in the array, your 
	 * operation counter variable must increase by one. 
	 * Resetting the counter assigns the counter the value 0.
	 * 
	 * using CSCI120.Untyped;
	 * 
	 * public ArrayStack : IList
	 * {
	 * 	  private int counter = 0; // the operation counter
	 *    ...
	 * }
	 **/
	class Lab3 : CSCI120.TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab3()).Exec ("ArrayStack IList implementation");
		}

		override public void RunTests(ref int score, ref int total)
		{
			CSCI120.Untyped.IList arrayStack = null;
			arrayStack = (CSCI120.Untyped.IList)(Activator.CreateInstanceFrom ("CSCI120_3.exe", "CSCI120_3.ArrayStack").Unwrap());
			TestStatement (arrayStack != null, "Created an arrayStack class", ref score, ref total);

			// create an array
			arrayStack.Initialize();
			TestStatement (arrayStack.Length == 0, "Created a new array", ref score, ref total);
			TestStatement (arrayStack.Operations == 0, "So far, no operations", ref score, ref total);

			arrayStack.Add (0, 0);
			arrayStack.Add (1, 1);
			arrayStack.Add (2, 2);
			arrayStack.Add (3, 3);

			TestStatement (arrayStack.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (arrayStack.Operations == 4, "Used four operations", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(0)) == 0, "Zero in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(1)) == 1, "One in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(2)) == 2, "Two in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(3)) == 3, "Three in fourth position", ref score, ref total);
			TestStatement (arrayStack.Operations == 8, "Used eight operations", ref score, ref total);

			arrayStack.Set (0, 5);
			TestStatement (Convert.ToInt32(arrayStack.Get (0)) == 5, "Five in first position", ref score, ref total);
			TestStatement (arrayStack.Operations == 10, "Used ten operations", ref score, ref total);

			arrayStack.ResetOperations ();
			TestStatement (arrayStack.Operations == 0, "Reset operations", ref score, ref total);
			arrayStack.Resize (20);
			TestStatement (arrayStack.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (arrayStack.Operations == 4, "Used four operations", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(0)) == 5, "Five in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(1)) == 1, "One in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(2)) == 2, "Two in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(3)) == 3, "Three in fourth position", ref score, ref total);
			TestStatement (arrayStack.Operations == 8, "Used eight operations", ref score, ref total);

			arrayStack.Set (4, 6);
			TestStatement (arrayStack.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (arrayStack.Operations == 9, "Used nine operations", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(0)) == 5, "Five in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(1)) == 1, "One in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(2)) == 2, "Two in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(3)) == 3, "Three in fourth position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(4)) == 6, "Six in fictious fifth position", ref score, ref total);
			TestStatement (arrayStack.Operations == 14, "Used fourteen operations", ref score, ref total);

			arrayStack.Resize (21);
			TestStatement (arrayStack.Get(4) == null, "null in fictious fifth position", ref score, ref total);
			arrayStack.Remove (0);
			arrayStack.Remove (1);
			TestStatement (arrayStack.Length == 2, "Array has two items", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(0)) == 1, "One in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(1)) == 3, "Three in second position", ref score, ref total);

			arrayStack.Clear ();
			arrayStack.ResetOperations ();
			TestStatement (arrayStack.Length == 0, "Array was cleared", ref score, ref total);
			arrayStack.Add (0, 0);
			arrayStack.Add (0, 1);
			arrayStack.Add (0, 2);
			arrayStack.Add (0, 3);
			TestStatement (arrayStack.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (arrayStack.Operations == 10, "Used ten operations", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(0)) == 3, "Three in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(1)) == 2, "Two in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(2)) == 1, "One in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(arrayStack.Get(3)) == 0, "Zero in fourth position", ref score, ref total);
		}
	}
}
