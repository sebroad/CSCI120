using System;
using CSCI120;
using CSCI120.Generic;
using System.Collections;

namespace CSCI120_9
{
	class Stack<T> : IStack<T>
	{
		#region IStack implementation
		public void Push (T x)
		{
			throw new NotImplementedException ();
		}
		public void Pop ()
		{
			throw new NotImplementedException ();
		}
		public bool IsEmpty {
			get {
				throw new NotImplementedException ();
			}
		}
		public T Top {
			get {
				throw new NotImplementedException ();
			}
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
	 * Implement the IStack<T> interface in a generic class 
	 * called Stack. Use a linked list implementation.
	 * 
	 * Use the CSCI120.Generic.Node<t> class for nodes.
	 **/
	class Lab9 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab9 ()).Exec ("Generic Stack");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oStack = new ArrayList ();
			Random gen = new Random ();

			// Test object
			CSCI120.Generic.IStack<double> stack = new Stack<double>();
			TestStatement (stack != null, "Created an Stack object", ref score, ref total);

			TestStatement (stack.IsEmpty, "Empty stack", ref score, ref total);
			
			for (int i = 0; i < 20; i++) {
				int x = gen.Next();
				stack.Push (x);
				oStack.Add (x);
			}

			while (!stack.IsEmpty) {
				int mine = Convert.ToInt32 (stack.Top);
				int theirs = Convert.ToInt32 (oStack [oStack.Count - 1]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
				stack.Pop ();
				oStack.RemoveAt (oStack.Count - 1);
			}

			TestStatement (total == 22, "Twenty tests were run", ref score, ref total);
			TestStatement (stack.Operations == 60, "Sixty operations were counted.", ref score, ref total); 

			// Put 30 items in the 
			for (int i = 0; i < 100; i++)
				stack.Push (gen.Next ());

			int capacity = 0;
			while (!stack.IsEmpty) {
				capacity++;
				stack.Pop ();
			}
			TestStatement (capacity == 100, "Stack has capacity for 100 items", ref score, ref total);
		}
	}
}
