using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_6 {
	
	public class Deque : IDeque, IArrayBased {

		// Counts operations done
		private int counter;
		// Stores the array
		private object[] data;
		// Stores the start of the array
		private int start;
		// Stores the length of the array
		private int length;

		public Deque() {
		}

		// Returns amount of operations 
		public int Operations {
			get {
				return counter;
			}
		}

		// Adds an element to the position start - 1
		// Loops to the other end of list if neccesary
		public void AddFirst(object x) {
			
			// Assures enough space in the array
			if (length >= data.Length) {
				Resize(2 * length);
			}
			// In case start == 0, add data.length and then
			// Use modulus to make sure -1 % n > 1 ever comes up
			// Because that could either equal length - 1 or just -1
			data[(start + data.Length - 1) % data.Length] = x;

			counter++;
			length++;
			start = (start + data.Length - 1) % data.Length;
		}

		// Adds element to position start + length
		// Loops to beginning of array if necessary
		public void AddLast(object x) {
			
			// Assures enough space in array
			if (length >= data.Length) {
				Resize(2 * length);
			}

			data[(start + length) % data.Length] = x;
			counter++;
			length++;
		}

		// Sets all variables to a default value
		public void Initialize() {
			data = new object[8];
			counter = 0;
			start = 0;
			length = 0;
		}

		// Removes the first element from an array
		// And returns that value
		public object RemoveFirst() {
			object removed = data[start];
			start = (start + 1) % data.Length;
			counter++;
			length--;

			if (length * 3 <= data.Length) {
				Resize(length * 2);
			}

			return removed;
		}

		// Removes the last element from an array
		// And returns that value
		public object RemoveLast() {
			object removed = data[(start + length - 1) % data.Length];
			counter++;
			length--;

			return removed;
		}

		// Resets the counter for operations
		public void ResetOperations() {
			counter = 0;
		}

		// Resizes the array to size n
		// Orders the array in order starting
		// at position [0]
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
