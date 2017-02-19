using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_4
{
	public class Stack : IStack, IArrayBased

	{
		private int counter = 0;
		private int top = 0;
		private object[] data;


		#region IArrayBased implementation

		public void Initialize ()
		{
			top = 0;
			counter = 0;
			data = new object[0];
		}

		public void Resize (int n)
		{
			object[] temp = new object[n]; // Allocate temp array

			for (int idx = 0; idx < top; idx++) {
				counter++;
				temp [idx] = data [idx]; // Copy array "data" to larger "temp" array
			}
			data = temp; // Re-assign array
		}

		#endregion

		#region IStack implementation

		public void Push (object x)
		{
			data [top] = x;
			counter++;
			top++;
		}

		public void Pop ()
		{
			counter++;
			top--;
		}

		public object Top {
			get {
				if (top == 0) {
					return null;
				} else {
					counter++;
					return data [top - 1];
				}

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

		public Stack ()
		{
			Initialize ();
		}
	}
}

