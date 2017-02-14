using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_3
{
	public class ArrayStack : IList, IArrayBased
	{
		private int length;
		private object[] data;
		private int counter;

		#region IArrayBased implementation

		public void Initialize ()
		{
			length = 0;
			counter = 0;
			data = new object[10];
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

		#region IList implementation

		public void Add (int i, object x)
		{
			if (length == data.Length) {
				Resize (2 * data.Length);
			}

			// Shift to the right
			for (int idx = length - 1; idx >= i; idx--) {
				counter++;
				data [idx + 1] = data [idx];
			}

			// Add in the new item
			Set(i, x);

			// Add one to lenght
			length++;
		}

		public void Remove (int i)
		{
			// First shift everything to the left
			for (int idx = i; idx < length - 1; idx++) {
				counter++;
				data [idx] = data [idx + 1]; // Data in idx become the data that was in the spot +1 from it
			}

			// Reduce length of the list by 1
			length--;
		
			// Resize
			if (data.Length >= 3 * length) {
				Resize (2 * length);
			}
		}

		public object Get (int i)			
		{
			counter++;
			return data [i];
		}

		public void Set (int i, object x)
		{
			counter++;
			data [i] = x;
		}

		public void Clear ()
		{
			length = 0;
		}

		public int Length {
			get {
				return length;
			}
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

		public ArrayStack ()
		{
			Initialize ();
		}
	}
}

