using System;
using CSCI120;
using CSCI120.Untyped;
namespace CSCI120_3
{
	public class ArrayStack : IList, IArrayBased
	{
		private int length; //how long is the used portion of the array
		private object[] data; //the array
		private int counter;  //how many operations have we done
		private object[] new_data; //temp data
		public ArrayStack()
		{
			Initialize();
		}
		#region IArrayBased implementation
		public void Initialize()
		{
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
			for (int idx = 0; idx < length; idx++) {
				counter++;
			}
				

		}
		#endregion
		#region IList implementation
		public object Get(int i)
		{
			counter++;
			return data[i];
		}
		public void Set(int i, object x)
		{
			counter++;
			data[i] = x;
		}
		public void Add(int i, object x)
		{
			//resize
			if (length == data.Length) {
				Resize(2 * data.Length);
			}
			//shift to the right
			for (int idx = length -1; idx >= i; idx--)
			{
				counter++;
				data[idx + 1] = data[idx];
			}
			//add in the new item
			Set(i, x);

			//add one to length
			length++;

		}
		public void Remove(int i)
		{
			//shift everything to the left
			for (int idx = i; idx < length - 1; idx++){
				counter++;
				data[idx] = data[idx + 1];
			}

			//reduce the length of the list by one
			length--;

			//resize
			if (data.Length >= 3 * length) { 
				Resize(2 * length);
			}
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
		#endregion 
		#region IOperationCounter implementation
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
		#endregion
	}
}
