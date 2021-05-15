using System;

namespace Assignment
{
	// invariants: every node?s left subtree contains values less than or equal to 
	// the node?s value, and every node?s right subtree contains values 
	// greater than or equal to the node?s value
	interface IBSTree
	{
		// pre: true
		// post: return true if the binary tree is empty; otherwise, return false.
		bool IsEmpty();

		// pre: true
		// post: item is added to the binary search tree
		void Insert(iMember item);

		// pre: true
		// post: an occurrence of item is removed from the binary search tree 
		//		 if item is in the binary search tree
		void Delete(iMember item);

		// pre: true
		// post: return true if item is in the binary search true;
		//	     otherwise, return false.
		bool Search(iMember item);

		string SearchContact(string firstName, string lastName);


		bool Login(string firstName, string lastName, string pin);

		//// pre: true
		//// post: all the nodes in the binary tree are visited once and in in-order and then added to iMember array
		//void InOrderTraverse();
		iMember[] ArrayOutput();

		// pre: true
		// post: all the nodes in the binary tree are removed and the binary tree becomes empty
		void Clear();
	}
}
