using KIDevTeamManagementRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDevTeamManagementApp
{
    public class ProgramUI
    {
        
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();

        static void center(string RunMenu)
        {
            int screenWidth = Console.WindowWidth;
            int stringWidth = RunMenu.Length;
            int spaces = (screenWidth / 2) + (stringWidth / 2);
        }
        public void Run()
        {
            RunMenu(true);
            
        }
       
        private void RunMenu(bool isRunning)
        {
            
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(" \n\n\n" + "********************* Welcome to the Komodo Insurance Developer Team Management Application. ************************ \n\n\n\n\n\n" + "   Select an option below: \n\n\n" + "       1. Individual Developer \n\n\n" + "       2. Development Team \n\n\n"    );

                string userInput = Console.ReadLine();

                Console.Beep(500, 25);
                switch (userInput)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DevTeamMenu();
                        break;
                    default:
                        Console.WriteLine("    Please enter a valid number 1-2. \n\n" + "    Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DeveloperMenu()
        {

        }
        private void DevTeamMenu()
        {

        }
        
    }
}
