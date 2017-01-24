using System;

namespace CSCI120
{
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

