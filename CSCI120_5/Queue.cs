using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_5
{
	public class Queue : IQueue, IArrayBased
	{
		private int length = 0; 	// length of the items in the array
		private int counter = 0;	// Counts the number of operations
		private int beginning = 0; 	// Keeps track of the beginning of the array, "front of the line"
		private object[] data; 		// the array


		#region IArrayBased implementation

		public void Initialize ()
		{
			length = 0;
			counter = 0;
			beginning = 0; 
			data = new object[0]; 
		}

		public void Resize (int n)
		{
			object[] temp = new object[n]; // Allocate temp array

			for (int idx = 0; idx < length; idx++) {
				counter++;
				temp [idx] = data [idx]; // Copy array "data" to larger "temp" array
			}
			data = temp; // Re-assign array
		}

		#endregion

		#region IQueue implementation

		public void Enqueue (object x)
		{
			data[(beginning + length) % data.Length] = x;
			length++;
			counter++;
		}

		public object Dequeue ()
		{
			// If the array Queue is empty return null
			if (length == 0)
				return null; 
			// returning null exits Dequeue function
			
			object x = data [beginning];
			beginning = (beginning + 1) % data.Length;
			length--;
			counter++;
			return x;
		}

		#endregion

		#region IOperationCounter implementation

		public void ResetOperations ()
		{
			counter = 0;
		}

		public int Operations {
			get {
				return counter;
			}
		}

		#endregion

		public Queue () 
		{
			Initialize ();
		}
	}
}

