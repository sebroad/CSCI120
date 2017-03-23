using System;
using CSCI120;
using CSCI120.Generic;

namespace CSCI120_11
{

	class BinaryTree<T> : IOperationCounter
	{
		private int counter = 0;

		public delegate object TreeNodeAction<T>(TreeNode<T> node, object val);
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
			throw new NotImplementedException ();
		}
		
		public int Count(TreeNode<T> root)
		{
			if (root == null) {
				return 0;
			} else {
				return 1 + Count (root.Left) + Count (root.Right);
		}

		public TreeNode<T> Find(TreeNode<T> root, T x)
		{
			throw new NotImplementedException ();
		}

		public void Traverse(TreeNode<T> Root, TreeNodeAction<T> Action)
		{
			throw new NotImplementedException ();
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
			for (int idx = 0; idx < 20; idx++) {
				object x = gen.Next ();
				list.Add(x);
				int path = gen.Next ();
				tree.Insert (ref root, x, path);
			}

			TestStatement(tree.Count (root) == 20, "All inserted", ref score, ref total);
			TestStatement(tree.Depth (root) >= 5, "Depth at least 5", ref score, ref total);
			TestStatement(tree.Depth(root) <= 8, "Should be less than 8", ref score, ref total);

			foreach (object x in list) {
				TestStatement(tree.Find(root, x) != null, string.Format("Found {0}", x), ref score, ref total);
			}

			tree.Traverse(root, (TreeNode<object> node, object val) => { Console.WriteLine(node.Data); return val; });
		}
	}
}
