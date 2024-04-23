using EmployeeDirectory.UI.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.UI
{
    public static class MainMenuOptions
    {
        public static void DisplayMainMenuOptions()
        {

            Console.WriteLine("1. Employee Management");
            Console.WriteLine("2. Role Management");
            Console.WriteLine("3. Exit");
            Console.Write("Choice = ");
            string mainMenuOptionChoiceStr = Console.ReadLine()!;
            int mainMenuOptionChoiceInt=int.Parse(mainMenuOptionChoiceStr);
            switch (mainMenuOptionChoiceInt)
            {
                case 1:
                    EmployeeManagementMenu.EmployeeManagmentMenuOptions();
                    break;
                case 2:
                    RoleManagmentMenu.RoleManagmentMenuOptions();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
        }
    }
}
