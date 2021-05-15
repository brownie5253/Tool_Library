using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Tool : iTool
    {
        private int quantity = 0;
        private int numBorrowed = 0;
        private List<iMember> Borrowers = new List<iMember>();


        public string Name // get and set the name of this tool
        {
            get;
            set;
        }
        public int Quantity //get and set the quantity of this tool
        {
            get { return quantity; }
            set { quantity += value; }
        }

        public int AvailableQuantity //get and set the quantity of this tool currently available to lend
        {
            get { return quantity - Borrowers.Count; }
            set {; }
        }

        public int NoBorrowings //get and set the number of times that this tool has been borrowed
        {
            get { return numBorrowed; }
            set { numBorrowed += value; }
        }  

        public iMemberCollection GetBorrowers  //get all the members who are currently holding this tool
        {

            get{ return initaliseMemberCollection();  }
        }

        public void addBorrower(iMember aMember) //add a member to the borrower list
        {
            Borrowers.Add(aMember);

            NoBorrowings = 1;
        }

        public void deleteBorrower(iMember aMember) //delte a member from the borrower list
        {
            if (Borrowers.Remove(aMember) == false)
            {
                Console.Write("The member selected is not borroweer of this tool, press anykey to return...");
                Console.ReadKey();
            }
        }

        override public string ToString() //return a string containning the name and the available quantity quantity this tool 
        {
            //string outputStr = $"Name: {Name}\nQuantity: {Quantity}\nAvalible Quantity: {AvailableQuantity}\nNumber of Borrowings: {NoBorrowings}";
            return $"Name: {Name}\nQuantity: {Quantity}\nAvalible Quantity: {AvailableQuantity}\nNumber of Borrowings: {NoBorrowings}";
        }
        private iMemberCollection initaliseMemberCollection()
        {
            iMemberCollection BorrowerMembers = new MemberCollection();
            foreach (var aMember in Borrowers)
            {
                BorrowerMembers.add(aMember);
            }

            return BorrowerMembers;
        }
    }
}
