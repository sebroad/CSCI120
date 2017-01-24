using System;

namespace CSCI120
{
	public class TestClass
	{
		public void Exec(string scriptName)
		{
			// create an object
			int score = 0;
			int total = 0;

			Console.WriteLine ("**************************************************");
			Console.WriteLine ("\tTesting " + scriptName);
			Console.WriteLine ("**************************************************");

			try
			{
				RunTests(ref score, ref total);
			}
			catch (Exception ex) {
				TestStatement (false, ex.Message + "\n" + ex.StackTrace, ref score, ref total);
			}
				
			Console.Write ("Press a key to exit...");
			Console.ReadKey ();
		}

		virtual public void RunTests(ref int score, ref int total)
		{
			TestStatement (true, "Empty test script", ref score, ref score);
		}

		public static void TestStatement(bool value, string item, ref int score, ref int total)
		{
			total ++;
			if (value) score ++;
			Console.WriteLine ("\t'{0}' {1} ({2}/{3})", item, value ? "Passed" : "Failed", score, total);
		}
	}

	public interface IOperationCounter
	{
		// Allow access to the number of operations required by 
		// the Data Structure implementation
		int Operations { get; }

		// Reset the counter on the number of operations.
		void ResetOperations();
	}

	namespace Untyped
	{
		
		public interface IList : IOperationCounter
		{
			// The length of the list
			int Length { get; }

			// Initialize a blank list
			void Initialize();

			// Add an item x at position i
			void Add (int i, object x);

			// Remove the item at position i
			void Remove (int i);

			// Get the item at position i
			object Get (int i);

			// Set the value x at position i
			void Set(int i, object x);

			// Clear the list
			void Clear();

			// Resize the list to capacity n
			void Resize(int n);
		}

		public interface IStack : IOperationCounter
		{
			// Add an item to the top of the stack
			void Push(object x);

			// View the top item
			object Top { get; }

			// Remove the top item
			void Pop();
		}

		public interface IQueue : IOperationCounter
		{
			// Add an item to the end of the queue
			void Enqueue(object x);

			// Remove the item at the beginning of the queue
			object Dequeue();
		}

		public interface IDeque : IOperationCounter
		{
			
			// Add an item to the end
			void AddLast(object x);

			// Add an item to the beginning
			void AddFirst(object x);

			// Remove an item from the end
			object RemoveLast();

			// Remove an item from the beginning
			object RemoveFirst();

		}

	}
}

