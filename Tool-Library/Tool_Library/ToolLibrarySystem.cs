using System;
using System.Collections.Generic;
using Interfaces;

namespace Assignment
{
    class ToolLibrarySystem : iToolLibrarySystem
    {
        public void add(iTool aTool) // add a new tool to the system
        {
            iToolCollection currentToolCollection = MainMenu.currentToolType;
            Console.WriteLine(aTool.ToString());
            currentToolCollection.add(aTool);
        }

        public void add(iTool aTool, int quantity) //add new pieces of an existing tool to the system
        {
            iToolCollection currentToolCollection = MainMenu.currentToolType;
            List<iTool> toolList = currentToolCollection.ToolCollectionList;

            iTool[] toolArray = currentToolCollection.toArray();
            int i = 0;
            foreach (var tool in toolArray)
            {
                if (tool.Name == aTool.Name)
                {
                    break;
                }
                i++;
            }

            toolList[i].Quantity = quantity;
        }

        public void delete(iTool aTool) //delte a given tool from the system
        {
            iToolCollection currentToolCollection = MainMenu.currentToolType;
            Console.WriteLine(aTool.ToString());
            currentToolCollection.delete(aTool);
        }

        public void delete(iTool aTool, int quantity)                                                                                                                                                                         
        {
            iToolCollection currentToolCollection = MainMenu.currentToolType;
            List<iTool> toolList = currentToolCollection.ToolCollectionList;

            iTool[] toolArray = currentToolCollection.toArray();
            int i = 0;
            foreach (var tool in toolArray)
            {
                if (tool.Name == aTool.Name)
                {
                    break;
                }
                i++;
            }

            toolList[i].Quantity = -quantity;
        }

        public void add(iMember aMember) //add a new memeber to the system
        {
            bool found = Program.aCollection.GetMemberCollection.search(aMember);

            if (found)
            {
                Console.Write("Error the given member is already registered, press any key to return...");
                Console.ReadKey();
            }
            else
            {
                Program.aCollection.GetMemberCollection.add(aMember);
            }
        }

        public void delete(iMember aMember) //delete a member from the system
        {
            bool found = Program.aCollection.GetMemberCollection.search(aMember);

            if (!found || aMember.Tools.Length > 0)
            {
                Console.Write("Error the given member is not registered or has outstanding tools, " +
                    "press any key to return...");
                Console.ReadKey();
            }
            else
            {
                Program.aCollection.GetMemberCollection.delete(aMember);
            }
        }

        public void displayBorrowingTools(iMember aMember) //given a member, display all the tools that the member are currently renting
        {
            Console.Clear();
            int num = 1;
            string[] borrowedTools = listTools(aMember);
            Console.WriteLine($"{aMember.FirstName}'s Borrowed Tools\n" +
                "=========================");
            if (borrowedTools.Length == 0)
            {
                Console.WriteLine("\nNothing to show");
            }
            else
            {
                foreach (string tool in borrowedTools)
                {
                    Console.WriteLine($"{num}\n{tool}");
                    num++;
                }
            }

            Console.Write("=========================\nPress anykey to continue...");
            Console.ReadKey();

        }

        public void displayTools(string aToolType) // display all the tools of a tool type selected by a member
        {
            iTool[] array = MainMenu.currentToolType.toArray();
            if (array.Length < 1)
            {
                Console.WriteLine("Tool type is currently empty");
            }

            int numValues = 0;
            Console.Clear();
            Console.WriteLine($"Tool Type {aToolType}\n=========================\n");
            foreach (Tool tool in array)
            {
                numValues++;
                Console.WriteLine($"{numValues} ");
                Console.WriteLine(tool.ToString());
                Console.WriteLine();
            }
            Console.Write("=========================\nPress any key to continue...");
            Console.ReadKey();
        }

        public void borrowTool(iMember aMember, iTool aTool) //a member borrows a tool from the tool library
        {
            if(aMember.Tools.Length >= 3)
            {
                Console.Write("You currently have three(3) tools on loan, please return one before renting another. " +
                    "Press anykey to return...");
                Console.ReadKey();
                return;
            }
            else if (aTool.AvailableQuantity <= 0)
            {
                Console.Write("The tool selected is unavalible, please wait for someone to return this tool. " +
                    "Press anykey to return...");
                Console.ReadKey();
                return;
            }
            else
            {
                aMember.addTool(aTool);
                aTool.addBorrower(aMember);
            }
        }

        public void returnTool(iMember aMember, iTool aTool) //a member return a tool to the tool library
        {
                aMember.deleteTool(aTool);
                aTool.deleteBorrower(aMember);
        }

        public string[] listTools(iMember aMember) //get a list of tools that are currently held by a given member
        {
            return aMember.Tools;
        }

        public void displayTopTHree() //Display top three most frequently borrowed tools by the members in the descending order by the number of times each tool has been borrowed.
        {
            iTool[] toolSort = Program.aCollection.InitaliseToolList();
            if (toolSort.Length <= 0)
            {
                Console.WriteLine("\nNo tools are in the system");
            }
            else
            {
                toolSort = MergeSort.mergeSort(toolSort);
                List<iTool> topThree = new List<iTool>();
                int nextIndex = 1;

                Console.Write("Top three borrowed tools by Members\n=========================\n\n");
                for (int index = 0; index < 3; index++)
                {
                    if (toolSort[index].NoBorrowings == 0)
                    {
                        Console.WriteLine($"\n There were only {index} tools with more than zero borrows");
                        break;
                    }
                    Console.WriteLine($"\n{index+1}\nTool borrowed {toolSort[index].NoBorrowings} times:");
                    Console.WriteLine($"{toolSort[index].Name}");

                    if(toolSort[index + nextIndex].NoBorrowings == toolSort[index].NoBorrowings)
                    {
                        Console.WriteLine($"Tools borrowed an equivalent amount to 3rd most borrowed tool:");
                        while (toolSort[index + nextIndex].NoBorrowings == toolSort[index].NoBorrowings)
                        {
                            Console.Write($"{toolSort[index + nextIndex].Name}\t");
                            nextIndex++;
                        }
                        Console.WriteLine();
                    }
                }
                //toolSort = MergeSort.mergeSort(toolSort);
                //List<iTool> topThree = new List<iTool>();
                //int currentIndex = 0;
                //int currentBorrowIndex = 0;

                //Console.Write("Top three borrowed tools by Members\n=========================\n\n");
                //for (int i = 1; i <= 3; i++)
                //{
                //    Console.WriteLine($"{i}\nTools borrowed {toolSort[currentIndex].NoBorrowings} times:");
                //    while (toolSort[currentIndex].NoBorrowings == toolSort[currentBorrowIndex].NoBorrowings)
                //    {
                //        Console.Write($"{toolSort[currentBorrowIndex].Name}\t");
                //        currentIndex++;
                //        if (currentIndex >= toolSort.Length)
                //        {
                //            break;
                //        }
                //    }
                //    currentBorrowIndex = currentIndex;

                //}   
            }
            Console.Write("\n=========================\nPress any key to continue...");
            Console.ReadKey();

        }
    }
}
