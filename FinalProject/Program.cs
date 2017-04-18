using System;
using CSCI120;
using CSCI120.Untyped;

namespace FinalProject
{
	class Queue : IQueue, IArrayBased

	{

		private int beginning; //where the beginning of the list is
		private int length; //how long is the used portion of the array
		private object temp; //temporary variable
		private object[] data; //the array
		private int counter;  //how many operations have we done

		#region IArrayBased implementation

		public void Initialize()
		{
			beginning = 0;
			length = 0;
			counter = 0;
			data = new object[10];
		}

		public void Resize(int n)
		{
			if (n < 1)
				return;
			n = Math.Max(length, n);
			object[] new_data = new object[n];
			for (int idx = 0; idx < length; idx++)
			{
			counter++;
			new_data[idx] = data[idx];
			}

			data = new_data;
		}

		#endregion


		#region IQueue implementation

		public void Enqueue(object x)
		{
			length++;
			data[(length - 1)] = x;
			counter++;
		}

		public object Dequeue()
		{
			if (length == 0)
			{
				return null;
			}
			else
			{
				temp = data[beginning];
				beginning++;
				length--;
				counter++;
				return temp;
			}
		}

		#endregion

		#region IOperationCounter implementation

		public void ResetOperations()
		{
			counter = 0;
		}

		public int Operations
		{
			get
			{
				return counter;
			}
		}

		#endregion
	}
}