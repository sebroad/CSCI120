using System;

namespace CSCI120_3
{

	/***
	 * Define the ArrayStack class in namespace CSCI120_3,
	 * implementing the interfaces 
	 *  + CSCI120.IOperationCounter
	 *  + CSCI120.Untyped.IList
	 * 
	 * using CSCI120;
	 * using CSCI120.Untyped;
	 * 
	 * public ArrayStack : IOperationCounter, IList
	 * { ... }
	 **/
	class Lab3
	{
		public static void Main (string[] args)
		{
			int score = 0;
			int total = 0;

			// create an object
			CSCI120.Untyped.IList arrayStack = (CSCI120.Untyped.IList)(Activator.CreateInstanceFrom ("CSCI120_3.exe", "CSCI120_3.ArrayStack").Unwrap());
			TestStatement (arrayStack != null, "Created an arrayStack class", ref score, ref total);

			/*
			// create an array
			object[] myArray = arrayLab.MakeArray(20);
			TestStatement (myArray.Length == 20, "Created an array of length 20", ref score, ref total);
			TestStatement (arrayLab.Count (myArray) == 0, "Array is all null", ref score, ref total);
			TestStatement (arrayLab.MakeString (myArray).Length == 0, "MakeString is empty", ref score, ref total);
			*/

			Console.Write ("Press a key to exit...");

			Console.ReadKey ();
		}

		public static void TestStatement(bool value, string item, ref int score, ref int total)
		{
			total ++;
			if (value) score ++;
			Console.WriteLine ("\t'{0}' {1} ({2}/{3})", item, value ? "Passed" : "Failed", score, total);
		}
	}
}
