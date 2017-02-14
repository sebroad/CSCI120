using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_3
{
	public class ArrayStack : IList, IArrayBased
	{
		private int length;
		private int counter;
		private object[] data;

		public ArrayStack()
		{
			Initialize();
		}

		public void Initialize()
		{
			data = new object[10];
			length = 0;
			counter = 0;
		}


		public void Clear()
		{
			length = 0;
		}

		public int Length
		{
			get
			{
				return length;
			}
		}


		public object Get(int i)
		{
			counter++;
			return data[i];
		}

		public int Operations
		{
			get
			{
				return counter;
			}
		}

		public void ResetOperations()
		{
			counter = 0;
		}

		public void Resize(int n)
		{
			object[] temp = new object[n];
			for (int i = 0; i < length; i++) 
			{
				temp[i] = data[i];
				counter++;
			}

			data = temp;
		}

		public void Set(int i, object x)
		{
			counter++;
			data[i] = x;
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

			// add one to Length
			length++;
		}

		public void Remove(int i)
		{
			// shift everything to the left
			for (int idx = i; idx < length - 1; idx++)
			{
				counter++;
				data[idx] = data [idx + 1];
			}
			// reduce length of the list by 1
			length--;

			//resize
			if (data.Length >= 3 * length)
			{
				Resize(length * 2);			
			}
		}
	}
}
