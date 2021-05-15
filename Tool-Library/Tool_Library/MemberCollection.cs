using System;
using System.Collections.Generic;

namespace Assignment
{
    //The specification of MemberCollection ADT, which is used to store and manipulate a collection of members

    class MemberCollection : iMemberCollection
    {
        private IBSTree memberCollection = new BSTree(); //type interface, new derived class

        private int count = 0;

        public IBSTree memberCollectionBST
        {
           get {return memberCollection;}
        }

        public int Number // get the number of members in the community library
        {
            get { return count; }
        }

        public void add(iMember aMember) //add a new member to this member collection, make sure there are no duplicates in the member collection
        {
            memberCollection.Insert(aMember);
            count++;
        }

        public void delete(iMember aMember) //delete a given member from this member collection, a member can be deleted only when the member currently is not holding any tool
        {
            memberCollection.Delete(aMember);
            count--;
        }

        public Boolean search(iMember aMember) //search a given member in this member collection. Return true if this memeber is in the member collection; return false otherwise.
        {
            return memberCollection.Search(aMember);
        }

        public iMember[] toArray() //output the memebers in this collection to an array of iMember
        {
            return memberCollection.ArrayOutput();
        }
    }
}
