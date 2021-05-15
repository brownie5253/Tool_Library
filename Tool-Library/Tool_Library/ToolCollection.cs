using System;
using System.Collections.Generic;

namespace Assignment
{
    //The specification of ToolCollection ADT, which is used to store and manipulate a collection of tools
    class ToolCollection : iToolCollection
    { 
        private List<iTool> toolCollection = new List<iTool>();

        public List<iTool> ToolCollectionList
        {
            get { return toolCollection; }
        }

        public int Number // get the number of the types of tools in the community library
        {
            get { return toolCollection.Count; }
        }

        public void add(iTool aTool) //add a given tool to this tool collection
        {
            bool matched = false;
            foreach (Tool tool in toolCollection)
            {
                if (aTool.Name == tool.Name)
                {
                    tool.Quantity = aTool.Quantity;
                    matched = true;
                    break;
                }
            }
            if (!matched)
            {
                toolCollection.Add(aTool);
            }
        }

        public void delete(iTool aTool) //delete a given tool from this tool collection
        {
            bool matched = false;
            foreach (Tool tool in toolCollection)
            {
                if (aTool == tool)
                {
                    toolCollection.Remove(aTool);
                    matched = true;
                    break;
                }
            }
            if (!matched)
            {
                Console.Write("\nThe heck?!? it wasnt found,npress anykey to continue...");
                Console.ReadKey();
            }
        }

        public Boolean search(iTool aTool) //search a given tool in this tool collection. Return true if this tool is in the tool collection; return false otherwise
        {            
            return toolCollection.Contains(aTool);
        }

        public iTool[] toArray() // output the tools in this tool collection to an array of iTool
        {
            iTool[] toolCollectionArray = toolCollection.ToArray();
            return toolCollectionArray;
        }
    }
}
