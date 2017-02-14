﻿using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_7
{


	/***
	 * Implement the IStack interface in a class called LinkedList.
	 * (No need for the IArrayBased interface this time.)
	 * 
	 * Utilize the CSCI120.Untyped.Node class.
	 **/
	class Lab7 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab7 ()).Exec ("Singly linked list IList");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// create an object
			IList linked = (IList)(Activator.CreateInstanceFrom ("CSCI120_7.exe", "CSCI120_7.LinkedList").Unwrap());
			TestStatement (linked != null, "Created a Linked List", ref score, ref total);

			// create an array
			TestStatement (linked.Length == 0, "Created a new array", ref score, ref total);
			TestStatement (linked.Operations == 0, "So far, no operations", ref score, ref total);

			linked.Add (0, 0);
			linked.Add (1, 1);
			linked.Add (2, 2);
			linked.Add (3, 3);

			TestStatement (linked.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (linked.Operations == 10, "Used ten operations", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(0)) == 0, "Zero in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(1)) == 1, "One in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(2)) == 2, "Two in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(3)) == 3, "Three in fourth position", ref score, ref total);
			TestStatement (linked.Operations == 20, "Used twenty operations", ref score, ref total);

			linked.Set (0, 5);
			TestStatement (Convert.ToInt32(linked.Get (0)) == 5, "Five in first position", ref score, ref total);
			TestStatement (linked.Operations == 22, "Used twenty-two operations", ref score, ref total);

			linked.ResetOperations ();
			TestStatement (linked.Operations == 0, "Reset operations", ref score, ref total);
			TestStatement (linked.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(0)) == 5, "Five in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(1)) == 1, "One in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(2)) == 2, "Two in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(3)) == 3, "Three in fourth position", ref score, ref total);
			TestStatement (linked.Operations == 10, "Used ten operations", ref score, ref total);

			linked.Remove (0);
			linked.Remove (1);
			TestStatement (linked.Length == 2, "Array has two items", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(0)) == 1, "One in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(1)) == 3, "Three in second position", ref score, ref total);

			linked.Clear ();
			linked.ResetOperations ();
			TestStatement (linked.Length == 0, "Array was cleared", ref score, ref total);
			linked.Add (0, 0);
			linked.Add (0, 1);
			linked.Add (0, 2);
			linked.Add (0, 3);
			TestStatement (linked.Length == 4, "Array has four items", ref score, ref total);
			TestStatement (linked.Operations == 4, "Used four operations", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(0)) == 3, "Three in first position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(1)) == 2, "Two in second position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(2)) == 1, "One in third position", ref score, ref total);
			TestStatement (Convert.ToInt32(linked.Get(3)) == 0, "Zero in fourth position", ref score, ref total);
		}
	}
}
