using System;
using CSCI120;
using CSCI120.Generic;

namespace CSCI120_11
{

	delegate object TreeNodeAction<T>(TreeNode<T> node, object val);

	class BinaryTree<T> : IOperationCounter
	{
		private int counter = 0;

		public void Insert (ref TreeNode<T> root, T x, int path)
		{
			TreeNode<T> parent = null;
			TreeNode<T> current = root;

			while (path > 0)
			{
				if (current == null) {
					break;
				} 

				counter++;
				parent = current;
				if (path % 2 == 0) {
					current = current.Left;
				} else {
					current = current.Right;
				}
				path /= 2;
			}

			if (parent == null) {
				if (path % 2 == 0) {
					root = new TreeNode<T> (x, root, null);
				} else {
					root = new TreeNode<T> (x, root, null);
				}
			} else {
				if (path % 2 == 0) {
					parent.Left = new TreeNode<T> (x, parent.Left, null);
				} else {
					parent.Right = new TreeNode<T> (x, parent.Right, null);
				}
			}
		}
			
		public int Depth(TreeNode<T> root)
		{
			if (root == null) {
				return 0;
			} else {
				return 1 + Math.Max (Depth (root.Left), Depth (root.Right));
			}
		}
		
		public int Count(TreeNode<T> root)
		{
			if (root == null) {
				return 0;
			} else {
				return 1 + Count (root.Left) + Count (root.Right);
			}
		}

		public TreeNode<T> Find(TreeNode<T> root, T x)
		{
			if (root == null) { // Base Case A: We're out of tree
				return null;
			}
			else if (root.Data.Equals (x)) { // Base Case B: We found it!
				return root;
			}

			// Smaller Caller A: Look left
			TreeNode<T> left = Find (root.Left, x);
			if (left == null) {
				// Smaller Caller B: Look right
				return Find (root.Right, x);
			}
			else {
				return left;
			}
		}

		public void Traverse(TreeNode<T> Root, TreeNodeAction<T> Action, ref object val)
		{
			if (Root != null) 
			{
				val = Action (Root, val);
				Traverse (Root.Left, Action, ref val);
				Traverse (Root.Right, Action, ref val);
			}
		}

		#region IOperationCounter implementation
		public void ResetOperations ()
		{
			throw new NotImplementedException ();
		}
		public int Operations {
			get {
				throw new NotImplementedException ();
			}
		}
		#endregion
		
	}

	class Lab11 : TestClass
	{
		public static void Main (string[] args)
		{
			(new Lab11 ()).Exec ("Test BinaryTree class");

		}


		public override void RunTests (ref int score, ref int total)
		{
			BinaryTree<object> tree = new BinaryTree<object> ();
			System.Collections.ArrayList list = new System.Collections.ArrayList();
			TreeNode<object> root = null;

			Random gen = new Random ();
			for (int idx = 0; idx < 20;
				idx++) {
				object x = gen.Next (1000);
				list.Add(x);
				int path = gen.Next ();
				tree.Insert (ref root, x, path);
			}

			TestStatement(tree.Count (root) == 20, "All inserted", ref score, ref total);
			TestStatement(tree.Depth (root) >= 5, "Depth at least 5", ref score, ref total);
			TestStatement(tree.Depth(root) <= 8, "Should be at most 8", ref score, ref total);

			foreach (object x in list) {
				TestStatement(tree.Find(root, x) != null, string.Format("Found {0}", x), ref score, ref total);
			}

			object sum = 0;
			tree.Traverse(root, Sum, ref sum);
			Console.WriteLine ("The total is {0}.", sum);

			sum = 0;
			tree.Traverse(root, Print, ref sum);
			Console.WriteLine ("The total is {0}.", sum);

			object max = 0;
			tree.Traverse(root, Maximum, ref max);

			Console.WriteLine ("The max is {0}.", max);

		}

		public object Sum(TreeNode<object> root, object val)
		{
			return Convert.ToInt32(root.Data) + Convert.ToInt32(val);
		}

		public object Print(TreeNode<object> root, object val)
		{
			Console.WriteLine (root.Data);
			return val;
		}

		public object Maximum(TreeNode<object> root, object val)
		{
			return Math.Max (Convert.ToInt32 (root.Data), Convert.ToInt32 (val));
		}

	}
}
