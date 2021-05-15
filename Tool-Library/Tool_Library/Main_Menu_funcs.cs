using System;
using System.Collections.Generic;
using System.Text;
using Interfaces;

namespace Assignment
{
    class MainMenu
    {
        public static iToolCollection currentToolType;

        public static int[] Menu_Selection(int menu = 3)
        {
            int[] menuSelections = new int[2];
            int staff, member, mainMenu, menuSelection1, menuSelection2;
            menuSelection1 = 0;
            staff = menuSelection2 = 1;
            member= 2;
            mainMenu = 3;
            bool loggedIn;
            bool logIn;

            while (true)
            {
                loggedIn = false;
                if (menu != 3)
                {
                    loggedIn = true;
                }

                if (menu == mainMenu)
                {
                    menu = Main_Menu();
                }

                if (menu == staff)
                {
                    if (loggedIn == false)
                    {
                        logIn = Staff_Login();
                    }
                    else
                    {
                        logIn = true;
                    }

                    if (logIn)
                    {
                        menuSelections[menuSelection1] = staff;
                        menu = Staff_Menu();
                        menuSelections[menuSelection2] = menu;
                        if (menu > 0)
                        {
                            return menuSelections;
                        }
                    }
                }
                else if (menu == member)
                {
                    if (loggedIn == false)
                    {
                        logIn = Member_Login();
                    }
                    else
                    {
                        logIn = true;
                    }

                    if (logIn)
                    {
                        menuSelections[menuSelection1] = member;
                        menu = Member_Menu();
                        menuSelections[menuSelection2] = menu;
                        if (menu > 0)
                        {
                            return menuSelections;
                        }
                    }
                }
                else
                {
                    Environment.Exit(0);
                }

                menu = mainMenu;
            }
        }


        public static int Main_Menu()
        {
            int number;
            string[] menuOptions = new string[] { "1. Add a new tool", "2. Add new peices of an exisiting tool", "3. Remove some peices of a tool",
            "4. Register a new member", "5. Remove a member", "6. Find the contact number of a membe", "0. Return to main menu"};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\n" +
                "===========Main Menu===========\n" +
                "1. Staff Login\n2. Member Login\n" +
                "0. Exit\n" +
                "===============================\n\n" +
                "Please make a selection (1-2, or 0 to exit):");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (success && number <= 2 && number >= 0)
                {

                    break;
                }
                else
                {
                    Console.Write("Your input was incorrect, it should be one of the options 0-2\n" +
                        "Press any key to try again... ");
                    Console.ReadKey();
                }
            }
            return number;
        }


        private static int Staff_Menu()
        {
            int number;
            string[] menuOptions = new string[] { "1. Add a new tool", "2. Add new peices of an exisiting tool", "3. Remove some peices of a tool",
            "4. Register a new member", "5. Remove a member", "6. Find the contact number of a membe", "0. Return to main menu"};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\n================Staff Menu================");
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(menuOptions[i]);
                }
                Console.WriteLine($"=========================================\n\nPlease make a selection " +
                    $"(1-{menuOptions.Length - 1}, or 0 to exit):");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (success && number < menuOptions.Length && number >= 0)
                {
                    break;
                }
                else
                {
                    Console.Write($"Your input was incorrect, it should be one of the options 0-{menuOptions.Length - 1}\n" +
                        "Press any key to try again... ");
                    Console.ReadKey();
                }
            }
            return number;
        }

        private static int Member_Menu()
        {
            int number;
            string[] menuOptions = new string[] { "1. Display all the tools of a tool type", "2. Borrow a tool", "3. Return a tool",
            "4. List all the tools that I am renting", "5. Display top three (3) most frequently used tools", "0. Return to main menu"};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Tool Library\n================Member Menu================");
                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine(menuOptions[i]);
                }
                Console.WriteLine($"=========================================\n\nPlease make a selection (1-{menuOptions.Length-1}, or 0 to exit):");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (success && number < menuOptions.Length && number >= 0)
                {
                    break;
                }
                else
                {
                    Console.Write($"Your input was incorrect, it should be one of the options 0-{menuOptions.Length - 1}\n" +
                        "Press any key to try again... ");
                    Console.ReadKey();
                }
            }
            return number;
        }

        private static bool Staff_Login()
        {
            Console.Clear();
            Console.Write("    Staff Login (staff today123)\n====================\nUsername: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string passWord = Console.ReadLine();

            if (userName == "staff" && passWord == "today123")
            {
                Console.Write("\nCorrect, press anykey to continue to staff menu... ");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.Write("\nUsername or Password incorrect, press anykey to return to main menu... ");
                Console.ReadKey();
                return false;
            }
        }

        private static bool Member_Login()
        {
            Console.Clear();
            Console.Write("    Member Login\n====================\nFirst Name: ");
            string fName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lName = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (Program.aCollection.GetMemberCollection.memberCollectionBST.Login(fName, lName, password))
            {
                Console.Write("\nCorrect, press anykey to continue to staff menu... ");
                Console.ReadKey();
                return true;
            }
            else
            {
                Console.Write("\nUsername or Password incorrect, press anykey to return to main menu... ");
                Console.ReadKey();
                return false;
            }
        }

        private static int ToolCategories()
        {
            int number;

            string[] ToolCat = new string[] { "1. Gardening tools", "2. Flooring tools", "3. Fencing tools",
            "4. Measuring tools", "5. Cleaning tool", "6. Painting tools", "7. Electronic tools", "8. Electricity tools",
            "9. Automotive tools"};

            while (true)
            {
                Console.Clear();
                Console.WriteLine("    Tool Categories\n=========================");
                for(int i = 0; i < ToolCat.Length; i++)
                {
                    Console.WriteLine(ToolCat[i]);
                }
                Console.WriteLine($"=========================\nPlease make a selection (1-{ToolCat.Length}):");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (success && number <= ToolCat.Length && number > 0)
                {
                    break;
                }
                else
                {
                    Console.Write($"Your input was incorrect, it should be one of the options 1-{ToolCat.Length}\n" +
                        "Press any key to try again... ");
                    Console.ReadKey();
                }
            }
            return number;
        }

        private static int ToolTypes(int CategorySelection, out string typeName)
        {
            int number;
            int toolTypeIndex = 0;
            string[][] ToolTypeArray =
            {
                new string[] { "Gardening Tools", "1. Line Trimmers", "2. Lawn Mowers", "3. Hand Tools",
                "4. Wheelbarrows", "5. Garden Power Tools"},

                new string[] { "Flooring Tools", "1. Scrapers", "2. Floor Lasers", "3. Floor Levelling Tools",
                "4. Floor Levelling Materials", "5. Floor Hand Tools", "6. Tiling Tools"},

                new string[] { "Fencing Tools", "1. Hand Tools", "2. Electric Fencing", "3. Steel Fencing Tools",
                "4. Power Tools", "5. Fencing Accessories"},

                new string[] { "Measuring Tools", "1. Distance Tools", "2. Laser Measurer", "3. Measuring Jugs",
                "4. Temperature & Humidity Tools", "5. Levelling Tools", "6. Markers"},

                new string[] { "Cleaning Tools", "1. Draining", "2. Car Cleaning", "3. Vacuum",
                "4. Pressure Cleaners", "5. Pool Cleaning", "6. Floor Cleaning"},

                new string[] { "Painting Tolls", "1. Sanding Tools", "2. Brushes", "3. Rollers",
                "4. Paint Removal Tools", "5. Paint Scrapers", "6. Sprayers"},

                new string[] { "Electronic Tools", "1. Voltage Tester", "2. Oscilloscopes", "3. Thermal Imaging",
                "4. Data Test Tool", "5. Insulation Testers"},

                new string[] { "Electricity Tools", "1. Test Equipment", "2. Safety Equipment", "3. Basic Hand tools",
                "4. Circuit Protection", "5. Cable Tools"},

                new string[] { "Automotive Tools", "1. Jacks", "2. Air Compressors", "3. Battery Chargers",
                "4. Socket Tools", "5. Braking", "6. Drivetrain"},

            };

            while (true)
            {
                Console.Clear();
                typeName = ToolTypeArray[CategorySelection - 1][toolTypeIndex];
                int arraySize = ToolTypeArray[CategorySelection - 1].Length;
                Console.WriteLine($"Tool Type: {typeName}\n=========================");
                for (int indexer = 1; indexer < arraySize; indexer++)
                {
                    Console.WriteLine(ToolTypeArray[CategorySelection - 1][indexer]);
                }
                Console.WriteLine($"=========================\nPlease make a selection (1-{arraySize}):");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (success && number <= 5 && number > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Your input was incorrect, it should be one of the options 1-9\n" +
                        "Press any key to try again... ");
                    Console.ReadKey();
                }
            }
            return number;
        }


        enum StaffCommands
        {
            returnMain,
            AddNewTool,
            AddExisitingTool,
            RemoveTool,
            RegisterMember,
            RemoveMember,
            ContactNumMember
        }
        enum MemberCommands
        {
            returnMain,
            DisplayAllToolsType,
            BorrowTool,
            ReturnTool,
            ListToolsRenting,
            DisplayTopThree
        }

        private static void printTools(int toolCat, int toolType, iToolCollection[,] toolMatrix)
        {
            iTool[] array = toolMatrix[toolCat - 1, toolType - 1].toArray();
            if (array.Length < 1)
            {
                Console.WriteLine("Tool type is currently empty");
            }

            int numValues = 0;
            Console.Clear();
            Console.WriteLine("    Tool Type\n=========================\n");
            foreach (Tool tool in array)
            {
                numValues++;
                Console.WriteLine($"{numValues} ");
                Console.WriteLine(tool.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("=========================");
        }

        private static int printMembers()
        {
            iMember[] array = Program.aCollection.GetMemberCollection.toArray();
            if (array.Length < 1)
            {
                Console.WriteLine("Member List is currently empty");
            }

            int numValues = 0;
            Console.Clear();
            Console.WriteLine("    Member List\n=========================\n");
            foreach (Member aMember in array)
            {
                numValues++;
                Console.WriteLine($"{numValues} ");
                Console.WriteLine(aMember.ToString());
                Console.WriteLine();
            }
            Console.WriteLine("=========================");
            return numValues;
        }

        private static int[] PickTool(bool remove = false, bool noQuantity = false, int numValues = -1)
        {
            int number;
            int toolChoice = 0;
            int[] existingTool = new int[2];
            if(numValues == -1)
            {
                numValues = currentToolType.toArray().Length;
            }
            string[] prompts = new string[] { $"\nPlease select a tool (1-{numValues}) or 0 to exit: ",
                    $"\nPlease choose a quantity of that tool to edit the Libary or 0 to exit: " };

            for (int indexer = 0; indexer < 2; indexer++)
            {
                if (indexer == 1 && noQuantity)
                {
                    existingTool[indexer] = 0;
                    return existingTool;
                }

                Console.Write($"{prompts[indexer]}");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (indexer == 1 && number > 0 && success)
                {
                    if (remove)
                    {
                        if (currentToolType.toArray()[existingTool[toolChoice] - 1].AvailableQuantity < number)
                        {
                            Console.Write($"Your input was incorrect, it should be less than or equal to the " +
                                $"current Avalible Quantity of that Tool\nPress any key to try again... ");
                            Console.ReadKey();
                            indexer--;
                        }
                        else
                        {
                            existingTool[indexer] = number;
                        }
                    }
                    else
                    {
                        existingTool[indexer] = number;
                    }
                    
                }
                else if (success && number <= numValues && number > 0)
                {
                    existingTool[indexer] = number;
                }
                else if (number == 0)
                {
                    Console.WriteLine($"You have chosen to exit\nPress any key to continue... ");
                    Console.ReadKey();
                    return null;
                }
                else
                {
                    Console.Write($"Your input was incorrect, it should be one of the options " +
                        $"(1-{numValues}) or a positve quanintity number\nPress any key to try again... ");
                    Console.ReadKey();
                    indexer--;
                }
            }
            return existingTool;
        }

        private static iMember PickMember()
        {
            int number;
            iMember[] array = Program.aCollection.GetMemberCollection.toArray();

            while(true)
            { 
                Console.WriteLine($"Please make a selection of a member to remove (1-{array.Length}) or 0 to exit:");

                string input = Console.ReadLine();

                bool success = Int32.TryParse(input, out number);

                if (number >= 0)
                {
                    Console.WriteLine($"You have chosen to exit\nPress any key to continue... ");
                    Console.ReadKey();
                    return null;
                }
                else if (success && array[number - 1].Tools.Length == 0 && number > 0)
                {
                    return array[number - 1]; ;
                }
                else
                {
                    Console.WriteLine($"Your input was incorrect, it should be one of the options " +
                        $"(1-{array.Length}) and the member must not have any tool loans \nPress any key to try again... ");
                    Console.ReadKey();
                }
            }
        }

        private static iTool CreateNewTool()
        {
            while (true)
            {
                iTool newTool = new Tool();
                Console.Write("Enter the details of your tool bellow:\n\nEnter the name of the tool: ");
                string toolName = Console.ReadLine();
                newTool.Name = toolName;

                while (true)
                {
                    Console.Write("Enter a quanity of the tool: ");
                    string input = Console.ReadLine();
                    int toolQuantity;

                    bool success = Int32.TryParse(input, out toolQuantity);

                    if (success && toolQuantity > 0)
                    {
                        newTool.Quantity = toolQuantity;
                        return newTool;
                    }
                    else
                    {
                        Console.Write($"Your input was incorrect, it should be a number greater than zero\n" +
                            "Press any key to try again... ");
                        Console.ReadKey();
                    }
                }
            }
        }

        private static iMember CreateMember()
        {
            while (true)
            {
                iMember newMember = new Member();
                Console.Write("Enter the details of the Member bellow:\n\nEnter the First Name of the member: ");
                string fName = Console.ReadLine();
                newMember.FirstName = fName;
                Console.Write("\nEnter the Last Name of the member: ");
                string lName = Console.ReadLine();
                newMember.LastName = lName;

                while (true)
                {
                    Console.Write("\nEnter member's contact number (8 digits): ");
                    string input = Console.ReadLine();
                    int contactNum;
                    bool success = Int32.TryParse(input, out contactNum);
                    int count = input.Length;

                    if (success && contactNum > 0 && count == 8)
                    {
                        newMember.ContactNumber = input;
                        break;
                    }
                    else
                    {
                        Console.Write($"Your input was incorrect, it should be 8 numbers\n" +
                            "Press any key to try again... ");
                        Console.ReadKey();
                    }
                }

                while (true)
                {
                    Console.Write("\nEnter member's password (4 digits): ");
                    string input = Console.ReadLine();
                    int pin;
                    int count = input.Length;

                    bool success = Int32.TryParse(input, out pin);

                    if (success && count == 4)
                    {
                        newMember.PIN = input;
                        break;
                    }
                    else
                    {
                        Console.Write($"Your input was incorrect, it should be 4 numbers\n" +
                            "Press any key to try again... ");
                        Console.ReadKey();
                    }
                }
                return newMember;
            }
        }

        private static void getContact()
        {
            iMember newMember = new Member();
            Console.Write("Enter the details of the Member bellow:\n\nEnter the First Name of the member: ");
            string fName = Console.ReadLine();
            Console.Write("\nEnter the Last Name of the member: ");
            string lName = Console.ReadLine();
            string ContactNum = Program.aCollection.GetMemberCollection.memberCollectionBST.SearchContact(fName, lName);
            Console.Write($"\n{ContactNum}\n\nPress anykey to continue...");
            Console.ReadKey();
        }

        private static void navigateToolMenu(out string toolTypeStr, iToolLibrarySystem libary)
        {
            iToolCollection[,] toolMatrix = Program.aCollection.GetToolMatrix;
            int toolCategory, toolType;
            toolCategory = ToolCategories();
            toolType = ToolTypes(toolCategory, out toolTypeStr);
            currentToolType = toolMatrix[toolCategory - 1, toolType - 1];
            libary.displayTools(toolTypeStr);
           
        }

        public static void RunCommand(int[] selection)
        {
            int staff, menuSelection1, menuSelection2;
            int[] changeTool;
            bool remove, noQuantity;
            iTool returnedTool;
            string toolTypeStr;
            menuSelection1 = 0;
            staff = menuSelection2 = 1;
            iToolLibrarySystem funcs = new ToolLibrarySystem();

            if (selection[menuSelection1] == staff)//staff
            {
                switch (selection[menuSelection2])
                {
                    case (int)StaffCommands.AddNewTool:
                        navigateToolMenu(out toolTypeStr, funcs);
                        returnedTool = CreateNewTool();
                        funcs.add(returnedTool);
                        funcs.displayTools(toolTypeStr);
                        break;

                    case (int)StaffCommands.AddExisitingTool:
                        navigateToolMenu(out toolTypeStr, funcs);
                        changeTool = PickTool();
                        if (changeTool != null)
                        {
                            returnedTool = currentToolType.toArray()[changeTool[0] - 1];
                            funcs.add(returnedTool, changeTool[1]);
                        }
                        
                        funcs.displayTools(toolTypeStr);
                        break;

                    case (int)StaffCommands.RemoveTool:
                        navigateToolMenu(out toolTypeStr, funcs);
                        bool removeExisting = true;
                        changeTool = PickTool(removeExisting);
                        if (changeTool != null)
                        {
                            returnedTool = currentToolType.toArray()[changeTool[0] - 1];
                            if (returnedTool.Quantity == changeTool[1])
                            {
                                funcs.delete(returnedTool);
                            }
                            else
                            {
                                funcs.delete(returnedTool, changeTool[1]);
                            }
                        }
                        funcs.displayTools(toolTypeStr);
                        break;

                    case (int)StaffCommands.RegisterMember:
                        printMembers();
                        iMember newMember = CreateMember();
                        funcs.add(newMember);
                        printMembers();
                        Console.Write("Press any Key to continue...");
                        Console.ReadKey();
                        break;

                    case (int)StaffCommands.RemoveMember:
                        printMembers();
                        iMember removeMember = PickMember();
                        funcs.delete(removeMember);
                        printMembers();
                        Console.Write("Press any Key to continue...");
                        Console.ReadKey();
                        break;

                    case (int)StaffCommands.ContactNumMember:
                        getContact();
                        break;

                    default:
                        Console.WriteLine("Error: switch failed :(");
                        break;
                }
            }
            else //member
            {
                switch (selection[menuSelection2])
                {
                    case (int)MemberCommands.DisplayAllToolsType:
                        navigateToolMenu(out toolTypeStr, funcs);
                        break;

                    case (int)MemberCommands.BorrowTool:
                        navigateToolMenu(out toolTypeStr, funcs);
                        remove = false;
                        noQuantity = true;
                        changeTool = PickTool(remove, noQuantity);
                        if (changeTool != null)
                        {
                            funcs.borrowTool(Program.aCollection.CurrentMember,
                                currentToolType.toArray()[changeTool[0] - 1]);
                        }
                        funcs.displayTools(toolTypeStr);
                        break;

                    case (int)MemberCommands.ReturnTool:
                        funcs.displayBorrowingTools(Program.aCollection.CurrentMember);
                        remove = false;
                        noQuantity = true;
                        Member replace = (Member)Program.aCollection.CurrentMember;
                        changeTool = PickTool(remove, noQuantity, Program.aCollection.CurrentMember.Tools.Length);
                        if (changeTool != null)
                        {
                            funcs.returnTool(Program.aCollection.CurrentMember,
                                replace.ToolsBorrowed[changeTool[0] - 1]);
                        }
                        funcs.displayBorrowingTools(Program.aCollection.CurrentMember);
                        break;

                    case (int)MemberCommands.ListToolsRenting:
                        funcs.displayBorrowingTools(Program.aCollection.CurrentMember);
                        break;

                    case (int)MemberCommands.DisplayTopThree:
                        funcs.displayTopTHree();   
                        break;
                    default:
                        Console.WriteLine("Error: switch failed :(");
                        break;
                }
            }
        }
    }
}