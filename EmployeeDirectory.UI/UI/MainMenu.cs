using EmployeeDirectory.UI.Menus;

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
            int mainMenuOptionChoice= Parser.ParseToInt(Console.ReadLine()!);
            if (mainMenuOptionChoice==-1)
            {
                Console.WriteLine("Invalid Choice Select Again");
                DisplayMainMenuOptions();
            }
            else
            {
                switch (mainMenuOptionChoice)
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
}
