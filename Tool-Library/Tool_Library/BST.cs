using System;
using System.Collections.Generic;
//using BSTreeInterface;

namespace Assignment
{
	class BTreeNode
	{
		private iMember aMember;
		private IComparable fName;
		private IComparable lName;

		private BTreeNode lchild; // reference to its left child 
		private BTreeNode rchild; // reference to its right child

		public BTreeNode(iMember aMember)
		{
			fName = aMember.FirstName;
			lName = aMember.LastName;
			this.aMember = aMember;
			lchild = null;
			rchild = null;
		}

		public IComparable FName
		{
			get { return fName;  }
			set { fName = value; }
		}

		public IComparable LName
		{
			get { return lName; }
			set { lName = value; }
		}

		public iMember AMember
		{
			get { return aMember; }
			set { aMember = value; }
		}

		public BTreeNode LChild
		{
			get { return lchild; }
			set { lchild = value; }
		}

		public BTreeNode RChild
		{
			get { return rchild; }
			set { rchild = value; }
		}
	}


	class BSTree : IBSTree
	{
		private BTreeNode root;

		public BSTree()
		{
			root = null;
		}

		public bool IsEmpty()
		{
			return root == null;
		}

		public bool Login(string firstName, string lastName, string pin)
		{
			return Login(firstName, lastName, pin, root);
		}

		private bool Login(IComparable aFirstName, IComparable aLastName, IComparable aPin, BTreeNode r)
		{
			if (r != null)
			{
				if (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) == 0 && aPin.CompareTo(r.AMember.PIN) == 0)
                {
					Program.aCollection.CurrentMember = r.AMember;
					return true;
				}
				else if ((aFirstName.CompareTo(r.FName) < 0) || (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) < 0))
					return Login(aFirstName, aLastName, aPin, r.LChild);
				else
					return Login(aFirstName, aLastName, aPin, r.RChild);
			}
			else
				return false;
		}

		public bool Search(iMember aMember)
		{
			return Search(aMember.FirstName, aMember.LastName, root);
		}

		private bool Search(IComparable aFirstName, IComparable aLastName, BTreeNode r)
		{
			if (r != null)
			{
				if (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) == 0 )//&& aContactNum.CompareTo(r.AMember.ContactNumber) == 0)
					return true;
				else if ((aFirstName.CompareTo(r.FName) < 0) || (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) < 0))
					return Search(aFirstName, aLastName, r.LChild);
				else
					return Search(aFirstName, aLastName, r.RChild);
			}
			else
				return false;
		}

		public string SearchContact(string fName, string lName)
		{
			return SearchContact(fName, lName, root);
		}

		private string SearchContact(IComparable aFirstName, IComparable aLastName, BTreeNode r)
		{
			if (r != null)
			{
				if (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) == 0)
					return "The users Contact number is " + r.AMember.ContactNumber;
				else if ((aFirstName.CompareTo(r.FName) < 0) || (aFirstName.CompareTo(r.FName) == 0 && aLastName.CompareTo(r.LName) < 0))
					return SearchContact(aFirstName, aLastName, r.LChild);
				else
					return SearchContact(aFirstName, aLastName, r.RChild);
			}
			else
				return "User Not Found";
		}

		public void Insert(iMember aMember)
		{
			if (root == null)
				root = new BTreeNode(aMember);
			else
				Insert(aMember, root);
		}

		// pre: ptr != null
		// post: item is inserted to the binary search tree rooted at ptr
		private void Insert(iMember aMember, BTreeNode ptr)
		{
			IComparable fName = aMember.FirstName;
			IComparable lName = aMember.LastName;
			if ((fName.CompareTo(ptr.FName) < 0) || (fName.CompareTo(ptr.FName) == 0 && lName.CompareTo(ptr.LName) < 0))
			{
				if (ptr.LChild == null)
					ptr.LChild = new BTreeNode(aMember);
				else
					Insert(aMember, ptr.LChild);
			}
			else
			{
				if (ptr.RChild == null)
					ptr.RChild = new BTreeNode(aMember);
				else
					Insert(aMember, ptr.RChild);
			}
		}

		// there are three cases to consider:
		// 1. the node to be deleted is a leaf
		// 2. the node to be deleted has only one child 
		// 3. the node to be deleted has both left and right children
		public void Delete(iMember aMember)
		{
			IComparable fName = aMember.FirstName;
			IComparable lName = aMember.LastName;

			// search for item and its parent
			BTreeNode ptr = root; // search reference
			BTreeNode parent = null; // parent of ptr
			while ((ptr != null) && (fName.CompareTo(ptr.FName) != 0))
			{
				parent = ptr;
				if ((fName.CompareTo(ptr.FName) < 0) || (fName.CompareTo(ptr.FName) == 0 &&
						lName.CompareTo(ptr.LName) < 0)) // move to the left child of ptr

					ptr = ptr.LChild;
				else
					ptr = ptr.RChild;
			}

			if (ptr != null) // if the search was successful
			{
				// case 3: item has two children
				if ((ptr.LChild != null) && (ptr.RChild != null))
				{
					// find the right-most node in left subtree of ptr
					if (ptr.LChild.RChild == null) // a special case: the right subtree of ptr.LChild is empty
					{
						ptr.FName = ptr.LChild.FName;
						ptr.LName = ptr.LChild.LName;
						ptr.AMember = ptr.LChild.AMember;

						ptr.LChild = ptr.LChild.LChild;
					}
					else
					{
						BTreeNode p = ptr.LChild;
						BTreeNode pp = ptr; // parent of p
						while (p.RChild != null)
						{
							pp = p;
							p = p.RChild;
						}
						// copy the item at p to ptr
						ptr.FName = p.FName;
						ptr.LName = p.LName;
						ptr.AMember = p.AMember;
						pp.RChild = p.LChild;
					}
				}
				else // cases 1 & 2: item has no or only one child
				{
					BTreeNode c;
					if (ptr.LChild != null)
						c = ptr.LChild;
					else
						c = ptr.RChild;

					// remove node ptr
					if (ptr == root) //need to change root
						root = c;
					else
					{
						if (ptr == parent.LChild)
							parent.LChild = c;
						else
							parent.RChild = c;
					}
				}

			}
			else
            {
				Console.Write("Sorry the member given wasn't found in the Data base, press anykey to return...");
				Console.ReadKey();
            }
		}

		//public void PreOrderTraverse()
		//{
		//	Console.Write("PreOrder: ");
		//	PreOrderTraverse(root);
		//	Console.WriteLine();
		//}

		//private void PreOrderTraverse(BTreeNode root)
		//{
		//	if (root != null)
		//	{
		//		Console.Write(root.AMember.ToString());
		//		PreOrderTraverse(root.LChild);
		//		PreOrderTraverse(root.RChild);
		//	}
		//}

		//public void InOrderTraverse()
		//{
		//	Console.Write("InOrder: ");
		//	InOrderTraverse(root);
		//	Console.WriteLine();
		//}

		//private void InOrderTraverse(BTreeNode root)
		//{
		//	if (root != null)
		//	{
		//		InOrderTraverse(root.LChild);
		//		Console.Write(root.AMember.ToString());
		//		InOrderTraverse(root.RChild);
		//	}
		//}

		//public void PostOrderTraverse()
		//{
		//	Console.Write("PostOrder: ");
		//	PostOrderTraverse(root);
		//	Console.WriteLine();
		//}

		//private void PostOrderTraverse(BTreeNode root)
		//{
		//	if (root != null)
		//	{
		//		PostOrderTraverse(root.LChild);
		//		PostOrderTraverse(root.RChild);
		//		Console.Write(root.AMember.ToString());
		//	}
		//}

		public void Clear()
		{
			root = null;
		}

		public iMember[] ArrayOutput()
		{
			List<iMember> memberList = new List<iMember>();
			return ArrayOutput(root, memberList);
		}

		private iMember[] ArrayOutput(BTreeNode root, List<iMember> memberList)
		{
			if (root != null)
			{
				ArrayOutput(root.LChild, memberList);
				memberList.Add(root.AMember);
				ArrayOutput(root.RChild,memberList);
			}

			iMember[] memberArray = memberList.ToArray();
			return memberArray;
		}
	}
}




