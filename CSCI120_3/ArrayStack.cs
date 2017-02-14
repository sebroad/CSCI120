using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_3
{
	public class ArrayStack : IList, IArrayBased
	{
		private int length; // how long is the used portion of the array?
		private object[] data; // the array
		private int counter; // how many operations have we done?

		public ArrayStack()
		{
			Initialize();
		}

		public int Length
		{
			get
			{
				return length;
			}
		}

		public int Operations
		{
			get
			{
				return counter;
			}
		}

		public void Add(int i, object x)
		{
			// resize if needed 
			if (length == data.Length)
			{
				Resize(2 * data.Length);
			}

			// shift to the right
			for (int idx = length - 1; idx >= i; idx--)
			{
				counter++;
				data[idx + 1] = data[idx];
			}

			// add in the new item
			Set(i, x);

			// add one to length
			length++;
		}

		public void Clear()
		{
			length = 0;
		}

		public object Get(int i)
		{
			counter++;
			return data[i];
		}

		public void Initialize()
		{
			length = 0;
			counter = 0;
			data = new object[10];
		}

		public void Remove(int i)
		{
			// shift everything to the left
			for (int idx = i; idx < length - 1; idx++)
			{
				counter++;
				data[idx] = data[idx + 1];
			}

			// reduce the length of the list by 1
			length--;

			// resize
			if (data.Length >= 3 * length)
			{
				Resize(2 * length);
			}
		}

		// resets the amount of operations done to 0
		public void ResetOperations()
		{
			counter = 0;
		}

		// resizes the array to size n
		// and copies all the data
		public void Resize(int n)
		{
			object[] temp = new object[n];
			for (int i = 0; i < length; i++)
			{
				counter++;
				temp[i] = data[i];
			}

			data = temp;
		}

		public void Set(int i, object x)
		{
			counter++;
			data[i] = x;
		}
	}
}
