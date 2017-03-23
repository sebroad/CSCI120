using System;
using CSCI120;
using CSCI120.Generic;

namespace CSCI120_11
{

	class BinaryTree<T> : IOperationCounter
	{
		private int counter = 0;
		public delegate void TreeNodeAction();

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
			throw new NotImplementedException ();
		}

		public TreeNode<T> Find(TreeNode<T> root)
		{
			throw new NotImplementedException ();
		}

		public void Traverse(TreeNode<T> Root, TreeNodeAction Action)
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
			TreeNode<object> root = null;

			Random gen = new Random ();
			for (int idx = 0; idx < 5; idx++) {
				object x = gen.Next ();
				int path = gen.Next ();
				tree.Insert (ref root, x, path);
			}

			TestStatement (tree.Count (root) == 5, "All inserted", ref score, ref total);

		}
	}
}
