using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_7
{
	public class LinkedList : IStack
	{
		private Node head;
		private int counter;
		private int length;

		#region IStack implementation

		public void Push (object x)
		{
			head = new Node (x, head);
			length++;
			counter++;
		}

		public void Pop ()
		{
			if (head != null) {
				head = head.Next;
				counter++;
				length--;
			}

		}

		public object Top {
			get {
				if (head == null) {
					return null;
				} else {
					counter++;
					return head.Data;
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

		public LinkedList ()
		{
			head = null;
			length = 0;
			counter = 0;
		}
	}
}

