using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_7
{

	class LinkedList : IList
	{

		private Node head = null;
		private int length = 0;
		private int counter = 0;

		private void getNode(int i, out Node prev, out Node curr)
		{
			prev = null;
			curr = head;
			int idx = 0;

			// find the location to add the node
			while (curr != null && idx < i) {
				prev = curr;
				curr = curr.Next;
				counter++;	// for examining the node
				idx++;		// move our count forward
			}
		}

		#region IList implementation
		public void Add (int i, object x)
		{
			
			Node prev, curr;
			getNode (i, prev, curr);
			if (prev == null) {
				// add at the beginning
				head = new Node(x, curr);
			} else {
				// Add elsewhere
				prev.Next = new Node(x, curr);
			}

			counter++; // for the addition of the item
			length++;  // we've added an item
				
		}
		public void Remove (int i)
		{
			// if there is nothing in the list, exit
			if (head == null)
				return;
			
			Node prev, curr;
			getNode (i, prev, curr);

			if (curr == null) {
				// nothing to delete
				return;
			} else if (prev == null) {
				// delete from beginning
				head = head.Next;
			} else {
				prev.Next = curr.Next;
			}

			counter++;
			length--;
		}
		public object Get (int i)
		{
			Node prev, curr;
			getNode (i, prev, curr);

			return curr.Data;
		}
		public void Set (int i, object x)
		{
			Node prev, curr;
			getNode (i, prev, curr);

			curr.Data = x;
		}
		public void Clear ()
		{
			head = null;
			length = 0;
		}
		public int Length {
			get {
				return length;
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
		
	}

	/***
	 * Implement the IList interface in a class called LinkedList.
	 * (No need for the IArrayBased interface this time.)
	 * 
	 * Utilize the CSCI120.Untyped.Node class.
	 **/
	class Lab7 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab7 ()).Exec ("Singly linked list IList");
		}


	}
}
