using System;

namespace CSCI120_2
{
	public class ArrayLab : IArrayLab
	{
		public object[] MakeArray(int length)
		{
			return new object[length];
		}

		public void Add(object value, object[] data)
		{
			data [Count (data)] = value;
		}

		public void Clear(object[] data)
		{
			for (int idx = 0; idx < data.Length; idx++) {
				data [idx] = null;
			}
		}

		public int Count(object[] data)
		{
			int nonNull = 0;
			foreach (object item in data) {
				if (item != null)
					nonNull++;
			}
			return nonNull;
		
		}

		public int IndexOf(object value, object[] data)
		{
			for (int idx = 0; idx < data.Length; idx++) {
				if (data [idx] == value)
					return idx;
			}

			return -1;
		}

		public string MakeString(object[] data)
		{
			return MakeString (data, "");
		}

		public string MakeString(object[] data, string sep)
		{
			string result = "";

			for (int idx = 0; idx < data.Length; idx++) {
				if (data [idx] != null) {
					if (idx > 0) {
						result += sep.ToString ();
					}
					result += data [idx].ToString ();
				}
			}
			return result;
		}

		public void Remove(int index, object[] data)
		{
			if (index >= 0 && index < Count (data)) {
				data [index] = data [Count (data) - 1];
				data [Count (data) - 1] = null;
			}
		}
	}

}