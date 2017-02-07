using System;
namespace CSCI120_2
{
	public class ArrayLab : IArrayLab
	{

		public ArrayLab()
		{
		}

		// Loops through the given array and finds the first null value
		// Once found, the given value is placed in that array at the null position
		// The loop is broken after that
		public void Add(object value, object[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] == null)
				{
					data[i] = value;
					break;
				}
			}
		}

		// Loops through the entire array and sets all values to null
		public void Clear(object[] data)
		{
			for (int i = 0; i < data.Length; i++) 
			{
				data[i] = null;
			}
		}

		// Loops through a given array and returns the number of non-null elements
		public int Count(object[] data)
		{
			int total = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != null)
				{
					total++;
				}
			}
			return total;
		}

		// Loops through the data and if the value is found, then it returns the index
		// If nothing is found, it returns -1
		public int IndexOf(object value, object[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				
				if (data[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		public object[] MakeArray(int length)
		{
			return new object[length];
		}

		// Returns a string of all elements in an
		// Object with no seperators inbetween
		public string MakeString(object[] data)
		{
			return MakeString(data, "");
		}

		// Takes all the objects from an array and puts them
		// Into a string, with a seperator string in between
		// Each item (not before the first or after the last, though)
		public string MakeString(object[] data, string sep)
		{
			string result = "";
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != null)
				{
					result += data[i];
					if (i != data.Length - 1)
					{
						result += sep;
					}
				}
			}
			return result;
		}

		// Removes an element in an array and replaces it with
		// the current last element, and that last element is
		// set to null
		public void Remove(int index, object[] data)
		{
			int lastUsedIndex = 0;
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i] != null)
				{
					lastUsedIndex = i;
				}
			}

			data[index] = data[lastUsedIndex];
			data[lastUsedIndex] = null;
		}
	}
}
