<<<<<<< HEAD
﻿using System;
using CSCI120;
using CSCI120.Untyped;

namespace CSCI120_7 {
	
	public class LinkedList : IStack {
		private Node head;
		private int counter;
		private int length;

		public int Operations {
			get {
				return counter;
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

		public void Pop() {
			if (head != null) {
				head = head.Next;
				counter++;
				length--;
			}
		}

		public void Push(object x) {
			head = new Node(x, head);
			length++;
			counter++;
		}

		public void ResetOperations() {
			counter = 0;
		}

		public LinkedList() {
			head = null;
			length = 0;
			counter = 0;

		}
	}
}
=======
﻿using System;

namespace CSCI120_7
{
	public class LinkedStack
	{
		public LinkedStack ()
		{
		}
	}
}

>>>>>>> refs/remotes/origin/master
