using System;

namespace CSCI120
{
	public interface IOperationCounter
	{
		int GetOperations();
		void ResetOperations();
	}

	namespace Untyped
	{
		
		public interface IList
		{
			// Add an item x at position i
			void Add (int i, object x);

			// Remove the item at position i
			void Remove (int i);

			// Get the item at position i
			object Get (int i);

			// Set the value x at position i
			void Set(int i, object x);
		}

		interface IStack
		{
			// Add an item to the top of the stack
			void Push(object x);

			// View the top item
			object Top();

			// Remove the top item
			void Pop();
		}

		interface IQueue
		{
			// Add an item to the end of the queue
			void Enqueue(object x);

			// Remove the item at the beginning of the queue
			object Dequeue();
		}
	}
}

