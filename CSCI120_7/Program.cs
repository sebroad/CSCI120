using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_7 {


	/***
	 * Implement the IStack interface in a class called LinkedList.
	 * (No need for the IArrayBased interface this time.)
	 * 
	 * Utilize the CSCI120.Untyped.Node class.
	 **/
	class Lab7 : TestClass {
		public static void Main(string[] args) {
			(new Lab7()).Exec("Singly linked list IList");
		}

		public override void RunTests(ref int score, ref int total) {
			// Comparison objects
			ArrayList oStack = new ArrayList();
			Random gen = new Random();

			// Test object
			CSCI120.Untyped.IStack stack = null;
			stack = (CSCI120.Untyped.IStack) (Activator.CreateInstanceFrom("CSCI120_7.exe", "CSCI120_7.LinkedList").Unwrap());
			TestStatement(stack != null, "Created an Stack object", ref score, ref total);

			TestStatement(stack.Top == null, "Empty stack", ref score, ref total);

			for (int i = 0; i < 20; i++) {
				int x = gen.Next();
				stack.Push(x);
				oStack.Add(x);
			}

			while (stack.Top != null) {
				int mine = Convert.ToInt32(stack.Top);
				int theirs = Convert.ToInt32(oStack[oStack.Count - 1]);
				TestStatement(mine == theirs, string.Format("{0}=={1}", mine, theirs), ref score, ref total);
				stack.Pop();
				oStack.RemoveAt(oStack.Count - 1);
			}

			TestStatement(total == 22, "Twenty tests were run", ref score, ref total);
			TestStatement(stack.Operations == 80, "Eighty operations were counted.", ref score, ref total);

			// Put 30 items in the 
			for (int i = 0; i < 15; i++)
				stack.Push(gen.Next());

			stack.ResetOperations();

			for (int i = 0; i < 85; i++)
				stack.Push(gen.Next());

			int capacity = 0;
			while (stack.Top != null) {
				capacity++;
				stack.Pop();
			}
			TestStatement(capacity == 100, "Stack has capacity for 100 items", ref score, ref total);

		}
	}
}