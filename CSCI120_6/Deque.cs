using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_6 {
	
	public class Deque : IDeque, IArrayBased {

		private int counter;
		private object[] data;
		private int front;
		private int length;

		public Deque() {
		}

		// Return the counted operations
		public int Operations {
			get {
				return counter;
			}
		}
		// Adds to the front of the Deque
		public void AddFirst(object x) {
			
		// Resizes if array is full
			if (length >= data.Length) {
				Resize(2 * length);
			}
			// In case front == 0, add data.length and then
			// Use modulus to make sure -1 % n > 1 ever comes up
			// Because that could either equal length - 1 or just -1
			data[(front + data.Length - 1) % data.Length] = x;

			front = (front + data.Length - 1) % data.Length;
			length++;
			counter++;
		}

		// Adds to the end of the Deque
		public void AddLast(object x) {
			
		// Resizes if array is full
			if (length >= data.Length) {
				Resize(2 * length);
			}

			data[(front + length) % data.Length] = x;
			counter++;
			length++;
		}


		public void Initialize() {
			data = new object[8];
			front = 0;
			length = 0;
			counter = 0;
		}

		// Removes the first element from an array
		// And returns that value
		public object RemoveFirst() {
			object toRemove = data[front];
			front = (front + 1) % data.Length;
			length--;
			counter++;

			if (length * 3 <= data.Length) {
				Resize(length * 2);
			}

			return toRemove;
		}

		// Removes from the end of the deque and returns it's value
		public object RemoveLast() {
			object toRemove = data[(front + length - 1) % data.Length];
			length--;
			counter++;

			return toRemove;
		}

		// Resets the counted operations
		public void ResetOperations() {
			counter = 0;
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
	}
}

