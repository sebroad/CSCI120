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

	public interface IArrayBased
	{
		// Initialize a blank list
		void Initialize();

		// Resize the list to capacity n
		void Resize(int n);
	}

	namespace Untyped
	{
		
		public interface IList : IOperationCounter
		{
			// The length of the list
			int Length { get; }

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

		public class Node
		{
			public Node(object x, Node next) {
				Data = x;
				Next = next;
			}
			public object Data { get; set; }
			public Node Next { get; set; }
		}

		public class DoubleNode
		{
			public DoubleNode(object x, DoubleNode prev, DoubleNode next) {
				Data = x;
				Prev = prev;
				Next = next;
			}
			public object Data { get; set; }
			public DoubleNode Next { get; set; }
			public DoubleNode Prev { get; set; }
		}

		public class TreeNode {
			public TreeNode(object x, TreeNode left, TreeNode right) {
				Data = x;
				Left = left;
				Right = right;
			}
			public object Data { get; set; }
			public TreeNode Left { get; set; }
			public TreeNode Right { get; set; }
		}
			
	}

	namespace Generic
	{
		public interface IList<T> : IOperationCounter
		{
			// The length of the list
			int Length { get; }

			// Add an item x at position i
			void Add (int i, T x);

			// Remove the item at position i
			void Remove (int i);

			// Get the item at position i
			T Get (int i);

			// Set the value x at position i
			void Set(int i, T x);

			// Clear the list
			void Clear();
		}

		public interface IStack<T> : IOperationCounter
		{
			// Add an item to the top of the stack
			void Push(T x);

			// Determine if the stack is empty
			bool IsEmpty { get; }

			// View the top item
			T Top { get; }

			// Remove the top item
			void Pop();

		}

		public interface IQueue<T> : IOperationCounter
		{
			// Add an item to the end of the queue
			void Enqueue(T x);

			// Remove the item at the beginning of the queue
			T Dequeue();

			// Determine if the stack is empty
			bool IsEmpty { get; }

		}

		public interface IDeque<T> : IOperationCounter
		{

			// Add an item to the end
			void AddLast(T x);

			// Add an item to the beginning
			void AddFirst(T x);

			// Remove an item from the end
			T RemoveLast();

			// Remove an item from the beginning
			T RemoveFirst();

			// Determine if the stack is empty
			bool IsEmpty { get; }

		}

		public interface IHashtable<T> : IOperationCounter, IArrayBased
		{
			// Hash a value
			int Hash(T x);

			// Add an item to the Hashtable
			void Add(T x);

			// Remove an item from the Hashtable
			void Remove(T x);

			// Find an item in the Hashtable
			T Find(T x);
		}

		public class Node<T>
		{
			public Node(T x, Node<T> next) {
				Data = x;
				Next = next;
			}
			public T Data { get; set; }
			public Node<T> Next { get; set; }
		}

		public class DoubleNode<T>
		{
			public DoubleNode (T x, DoubleNode<T> prev, DoubleNode<T> next)
			{
				Data = x;
				Prev = prev;
				Next = next;
			}
			public T Data { get; set; }
			public DoubleNode<T> Next { get; set; }
			public DoubleNode<T> Prev { get; set; }
		}

		public class TreeNode<T> {
			public TreeNode (T x, TreeNode<T> left, TreeNode<T> right)
			{
				Data = x;
				Left = left;
				Right = right;
			}
			public T Data { get; set; }
			public TreeNode<T> Left { get; set; }
			public TreeNode<T> Right { get; set; }
		}

	}
}

