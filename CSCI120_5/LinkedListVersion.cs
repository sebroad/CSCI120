using System;
using CSCI120;
using CSCI120.Untyped;
using System.Collections;

namespace CSCI120_5
{

	class Queue : IQueue, IArrayBased {

		private Node head;
		private Node tail;
		private int counter;
		private int length;

		public Queue()
		{
			head = null;
			tail = null;
			length = 0;
			counter = 0;
		}

		#region IArrayBased implementation

		public void Initialize ()
		{

		}

		public void Resize (int n)
		{

		}

		#endregion


		#region IQueue implementation

		public void Enqueue (object x)
		{
			// 1. Create a new node for x
			Node new_guy = new Node(x, null);

			// 2. If tail not null, tail.Next = the new guy
			if (tail != null) {
				tail.Next = new_guy;
			}

			// 3. Move tail to the new guy
			tail = new_guy;

			// 4. If head is null, point head to the new guy
			if (head == null) {
				head = new_guy;
			}

			// 5. length++
			length++;

			// 6. counter++
			counter ++;
		}

		public object Dequeue ()
		{
			// 1. if head is null, exit with a null
			if (head == null) {
				return null;
			} else {
				// 2. Otherwise, store the head value
				object ret_val = head.Data;

				// 3. Move head forward
				head = head.Next;

				// 4. Counter++
				counter++;

				// 5. Length--
				length--;

				// 6. Return stored
				return ret_val;

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

	class Lab5 : CSCI120.TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab5 ()).Exec ("IQueue implementation");
		}

		public override void RunTests (ref int score, ref int total)
		{
			// Comparison objects
			ArrayList oQueue = new ArrayList ();
			Random gen = new Random ();

			// Test object
			CSCI120.Untyped.IQueue queue = null;
			queue = (CSCI120.Untyped.IQueue)(Activator.CreateInstanceFrom ("CSCI120_5.exe", "CSCI120_5.Queue").Unwrap());
			TestStatement (queue != null, "Created an Queue object", ref score, ref total);

			((IArrayBased)queue).Initialize ();
			((IArrayBased)queue).Resize (20);

			TestStatement (queue.Dequeue() == null, "Empty queue", ref score, ref total);

			for (int i = 0; i < 20; i++) {
				int x = gen.Next();
				queue.Enqueue (x);
				oQueue.Add (x);
			}

			while (oQueue.Count > 0) {
				int mine = Convert.ToInt32 (queue.Dequeue ());
				int theirs = Convert.ToInt32 (oQueue [0]);
				TestStatement (mine == theirs, string.Format ("{0}=={1}", mine, theirs), ref score, ref total);
				oQueue.RemoveAt (0);
			}

			TestStatement (total == 22, "Twenty tests were run", ref score, ref total);
			TestStatement (queue.Operations == 40, "Forty operations were counted.", ref score, ref total); 

			// Put 15 items in the queue
			for (int i = 0; i < 15; i++)
				queue.Enqueue (gen.Next ());

			queue.ResetOperations ();
			((IArrayBased)queue).Resize (100);
			TestStatement (queue.Operations == 15, "Resize costs 15", ref score, ref total);

			for (int i = 0; i < 85; i++)
				queue.Enqueue (gen.Next ());

			int capacity = 0;
			for (object obj = queue.Dequeue (); obj != null; obj = queue.Dequeue ())
				capacity++;

			TestStatement (capacity == 100, "Stack has capacity for 100 items", ref score, ref total);

		}

	}
}
