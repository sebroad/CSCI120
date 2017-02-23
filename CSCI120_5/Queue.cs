using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_5 {
	
	public class Queue : IQueue, IArrayBased {

		// Counts how many operations are done
		private int counter;
		// Keeps track of the start of the array
		private int start;
		// Keeps track of the length of the array
		private int length;
		// Stores the array
		private object[] data;

		public Queue() {
		}

		// Returns number of operations up to this point
		public int Operations {
			get {
				return counter;
			}
		}

		// Removes the last element from an array
		// Returns that element
		public object Dequeue() {
			
			if (length == 0) {
				return null;
			}

			object removed = data[start];

			start = (start + 1) % data.Length;
			counter++;
			length--;

			return removed;
		}

		// Adds an element to the end of the array
		public void Enqueue(object x) {
			if (length >= data.Length) {
				Resize(2 * length);
			}

			data[(start + length) % data.Length] = x;
			counter++;
			length++;
		}

		// Sets all global variables to default values
		public void Initialize() {
			counter = 0;
			start = 0;
			length = 0;
			data = new object[8];
		}

		// Resets the amount of operations counted
		public void ResetOperations() {
			counter = 0;
		}

		// Resizes the array to size n
		// Old array is put in order into 
		// the new array starting from [0]
		public void Resize(int n) {
			object[] temp = new object[n];

			for (int i = 0; i < length; i++) {
				int position = (start + i) % data.Length;
				temp[i] = data[position];
				counter++;
			}

			data = temp;
			start = 0;
		}
	}
}
