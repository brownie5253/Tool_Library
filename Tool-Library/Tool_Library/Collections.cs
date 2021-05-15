using System;
using System.Collections.Generic;

namespace Assignment
{
    class Collections
    {
        private iToolCollection[,] atoolMatrix = new iToolCollection[9, 6];
        private iMemberCollection aMemberCollection = new MemberCollection();
        //public  iToolCollection currentToolType;
        private iMember currentMember;
        private List<iTool> allToolList = new List<iTool>();

        public Collections()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    atoolMatrix[row, col] = new ToolCollection();
                }
            }
        }

        public iToolCollection[,] GetToolMatrix
        {
            get { return atoolMatrix; }
        }

        public iMemberCollection GetMemberCollection
        {
            get { return aMemberCollection; }
        }

        //public iToolCollection CurrentToolType
        //{
        //    set { currentToolType = value; }
        //    get { return currentToolType; }
        //}

        public iMember CurrentMember
        {
            set { currentMember = value; }
            get { return currentMember; }
        }

        //public List<iTool> AllToolList
        //{
        //    get { return allToolList; }
        //}

        public iTool[] InitaliseToolList()
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 6; col++)
                {
                    iTool[] temp = atoolMatrix[row, col].toArray();

                    if (temp.Length > 0)
                        allToolList.AddRange(atoolMatrix[row, col].toArray());
                }
            }
            return allToolList.ToArray();
        }
    }
}
