using System;
using System.Collections;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_4
{

	class Stack : IStack, IArrayBased
	{

		private int length; //how long is the used portion of the array
		private object[] data; //the array
		private int counter;  //how many operations have we done

		public int Operations

		{
			get
			{
				return counter;
			}
		}

		public object Top
		{
			get
			{
				if (length == 0)
					return null;
				else {
					counter++;
					return data[length - 1];
				}
			}
		}

		public void Initialize()
		{
			length = 0;
			counter = 0;
			data = new object[10];
		}

		public void Pop()
		{
			length--;
			counter++;
		}

		public void Push(object x)
		{
			data[length] = x;
			length++;
			counter++;
		}

		public void ResetOperations()
		{
			counter = 0;
		}

		public void Resize(int n)
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
	}
	/***
	 * Students will implement the Untyped.IStack interface in a
	 * class called Stack in the CSCI120_4 namespace.
	 **/
	class Lab4 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab4 ()).Exec ("IStack implementation");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oStack = new ArrayList ();
			Random gen = new Random ();

			// Test object
			CSCI120.Untyped.IStack stack = null;
			stack = (CSCI120.Untyped.IStack)(Activator.CreateInstanceFrom ("CSCI120_4.exe", "CSCI120_4.Stack").Unwrap());
			TestStatement (stack != null, "Created an Stack object", ref score, ref total);

			((IArrayBased)stack).Initialize ();
			((IArrayBased)stack).Resize (20);

			TestStatement (stack.Top == null, "Empty stack", ref score, ref total);

			for (int i = 0; i < 20; i++) {
				int x = gen.Next();
				stack.Push (x);
				oStack.Add (x);
			}

			while (stack.Top != null) {
				int mine = Convert.ToInt32 (stack.Top);
				int theirs = Convert.ToInt32 (oStack [oStack.Count - 1]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
				stack.Pop ();
				oStack.RemoveAt (oStack.Count - 1);
			}
				
			TestStatement (total == 22, "Twenty tests were run", ref score, ref total);
			TestStatement (stack.Operations == 80, "Eighty operations were counted.", ref score, ref total); 

			// Put 30 items in the 
			for (int i = 0; i < 15; i++)
				stack.Push (gen.Next ());
			
			stack.ResetOperations ();
			((IArrayBased)stack).Resize (100);
			TestStatement (stack.Operations == 15, "Resize costs 15", ref score, ref total);

			for (int i = 0; i < 85; i++)
				stack.Push (gen.Next ());

			int capacity = 0;
			while (stack.Top != null) {
				capacity++;
				stack.Pop ();
			}
			TestStatement (capacity == 100, "Stack has capacity for 100 items", ref score, ref total);

		}
	}
}
