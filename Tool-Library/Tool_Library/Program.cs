using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{
    class Program
    {
        static public Collections aCollection = new Collections();

        static void Main(string[] args)
        {
            int mainMenu = 3;
            int menu = mainMenu;
            int[] menuSelec;
            

            while(true)
            {
                menuSelec = MainMenu.Menu_Selection(menu);
                MainMenu.RunCommand(menuSelec);
                menu = menuSelec[0];
            }
        }
    }
}
