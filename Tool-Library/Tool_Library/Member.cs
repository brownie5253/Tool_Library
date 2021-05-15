using System;
using System.Collections.Generic;

namespace Assignment
{
    //The specification of Member ADT
    class Member : iMember
    {
        private List<iTool> toolsBorrowed = new List<iTool>();

        public string FirstName  //get and set the first name of this member
        {
            get;
            set;
        }
        public string LastName //get and set the last name of this member
        {
            get;
            set;
        }

        public string ContactNumber //get and set the contact number of this member
        {
            get;
            set;
        }

        public string PIN //get and set the password of this member
        {
            get;
            set;
        }

        public List<iTool> ToolsBorrowed
        {
            get { return toolsBorrowed; }
        }

        public string[] Tools //get a list of tools that this memebr is currently holding
        {
            get { return ToolList(); }
        }

        public void addTool(iTool aTool) //add a given tool to the list of tools that this member is currently holding
        {
            toolsBorrowed.Add(aTool);
        }

        public void deleteTool(iTool aTool) //delete a given tool from the list of tools that this member is currently holding
        {
            if (toolsBorrowed.Remove(aTool) == false)
            {
                Console.Write("The tool selected is not borrowed by this member, press anykey to return...");
                Console.ReadKey();
            }
        }

        override public string ToString() //return a string containing the first name, lastname, and contact phone number of this memeber
        {
            return $"First Name: {FirstName}\nLast Name: {LastName}\nContact Number: {ContactNumber}\nPassword: {PIN}"; //outputStr;
        }

        private string[] ToolList()
        {
            string[] strArray = new string[toolsBorrowed.Count];
            int iterator = 0;

            foreach (var tool in toolsBorrowed)
            {
                string ToolName = tool.Name;
                strArray[iterator] = ToolName;
                iterator++;
            }

            return strArray;
        }
    }
}
