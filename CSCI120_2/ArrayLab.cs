using System;
namespace CSCI120_2
{
	public class ArrayLab : IArrayLab
	{
		
		public ArrayLab()
		{
		}

		// Uses count to see how many list spaces are used up
		// New element is added at the end of that list
		public void Add(object value, object[] data)
		{
			data[Count(data)] = value;
		}

		// Loops through the entire array and sets all values to null
		// Goes through entire array just in case there is a leftover
		// element that did not get removed properly
		public void Clear(object[] data)
		{
			for (int i = 0; i < data.Length; i++) 
			{
				data[i] = null;
			}
		}

		// Loops through a given array and counts nonNull elements
		// returns the total at the end of the loop
		public int Count(object[] data)
		{
			int nonNull = 0;
			foreach (object item in data)
			{
				if (item != null)
				{
					nonNull++;
				}
			}
			return nonNull;
		}

		// Loops through the data and if the value is found, then it returns the index
		// If nothing is found, it returns -1
		// NOTE: floats and doubles DO work
		public int IndexOf(object value, object[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				if (value is float && data[i] is float)
				{
					if (Math.Abs((float)data[i] - (float)value) <= float.Epsilon)
					{
						return i;
					}
				}
				else if (value is double && data[i] is double)
				{
					if (Math.Abs((double)data[i] - (double)value) <= double.Epsilon)
					{
						return i;
					}
				}
				else if (data[i] == value)
				{
					return i;
				}
			}
			return -1;
		}

		// Returns an empty array at the length provided
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
			for (int i = 0; i < Count(data); i++)
			{
				if (i > 0)
				{
					result += sep;
				}
				result += data[i];
			}
			return result;
		}

		// Removes an element in an array and replaces it with
		// the current last element, and that last element is
		// set to null
		public void Remove(int index, object[] data)
		{
			if (index >= 0 && index < Count(data))
			{
				data[index] = data[Count(data) - 1];
				data[Count(data) - 1] = null;
			}
		}
	}
}
