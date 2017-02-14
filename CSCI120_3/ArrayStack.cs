using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_3
{
	public class ArrayStack : IList, IArrayBased
	{
		public ArrayStack()
		{
			Initialize();
		}
		private int length;
		private object[] data;
		private int counter;

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
			if (length == data.Length)
			{
				Resize(2 * data.Length);
			}

			for (int idx = length - 1; idx >= i; idx--)
			{
				counter++;
				data[idx + 1] = data[idx];
			}

			Set(i, x);

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
			for (int idx = i; idx < Length - 1; idx++)
			{
				counter++;
				data[idx] = data[idx + 1];

			}

			length--;

			if (data.Length >= 3 * length)
			{
				Resize(Length * 2);
			}
		}

		public void ResetOperations()
		{
			counter = 0;
		}

		public void Resize(int n)
		{
			if (n < 1)
				return;
			n = Math.Max(length, n);
			object[] new_data = new_data = new object[n];

			for (int idx = 0; idx < length; idx++)
			{
				counter++;
				new_data[idx] = data[idx];

			}

			data = new_data;
		}

		public void Set(int i, object x)
		{
			counter++;
			data[i]=x;
		}
	}
}
