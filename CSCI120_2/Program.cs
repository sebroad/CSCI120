using System;

namespace CSCI120_2
{

	interface IArrayLab
	{

		// A method to make an array filled with nulls
		object [] MakeArray(int length);
			
		// A method to count the non-null items in an array
		int Count(object [] data);

		// A method to make a single string with all of the 
		// non-null values in the array separated with 'sep'
		// Use the String
		string MakeString(object [] data, string sep);
		
		// A method to make a single string with all of the 
		// non-null values in the array with no punctuation or spacing
		// HINT: use the first MakeString method
		string MakeString(object [] data);

		// A method to add an object to an array
		void Add(object value, object [] data);

		// A method to remove the object in a certain position
		// from an array by replacing it with the last object
		// and replacing the last object with null
		void Remove(int index, object [] data);

		// A method to find the location of a value in
		// an array. Returns -1 if the value not found.
		int IndexOf(object value, object [] data);

		// A method to clear all of the data from an array.
		void Clear(object [] data);

	}

	/***
	 * Working with arrays in C#
	 * 
	 * You will define a class with the interface IArrayLab above
	 * that will perform certain tasks with arrays of data.
	 * 
	 * Your class will be called ArrayLab. It will be in the
	 * namespace CSCI120_2.
	 * 
	 * The tasks themselves will be desribed in the array.
	 * 
	 **/
	class Lab2
	{
		public static void Main (string[] args)
		{
			int score = 0;
			int total = 0;

			// create an object
			IArrayLab arrayLab = (IArrayLab)(Activator.CreateInstanceFrom ("CSCI120_2.exe", "CSCI120_2.ArrayLab").Unwrap());
			TestStatement (arrayLab != null, "Created an arrayLab class", ref score, ref total);

			// create an array
			object[] myArray = arrayLab.MakeArray(20);
			TestStatement (myArray.Length == 20, "Created an array of length 20", ref score, ref total);
			TestStatement (arrayLab.Count (myArray) == 0, "Array is all null", ref score, ref total);
			TestStatement (arrayLab.MakeString (myArray).Length == 0, "MakeString is empty", ref score, ref total);

			// Add some data
			arrayLab.Add (12, myArray);
			arrayLab.Add ("Ice Cream", myArray);
			arrayLab.Add (4.612, myArray);
			TestStatement (myArray.Length == 20, "Array of length twenty", ref score, ref total);
			TestStatement (arrayLab.Count (myArray) == 3, "Added three items", ref score, ref total);
			TestStatement (arrayLab.MakeString (myArray) == "12Ice Cream4.612", "MakeString is '12Ice Cream4.612'", ref score, ref total);

			// Test the data
			TestStatement (arrayLab.IndexOf ("Ice Cream", myArray) == 1, "Find Ice Cream", ref score, ref total);
			TestStatement (arrayLab.IndexOf ("Ice", myArray) == -1, "Can't find Ice", ref score, ref total);
			TestStatement (arrayLab.IndexOf (4.612, myArray) == 2, "Float at the end", ref score, ref total);

			arrayLab.Remove (2, myArray);
			TestStatement (arrayLab.IndexOf (4.612, myArray) == -1, "Float is gone", ref score, ref total);

			arrayLab.Remove (0, myArray);
			arrayLab.Remove (0, myArray);
			TestStatement (arrayLab.Count (myArray) == 0, "Removed all of the data", ref score, ref total);


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
	