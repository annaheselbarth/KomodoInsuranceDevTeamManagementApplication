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

       
        public void Run()
        {
            RunMenu(true);

        }
        public void RunMenu(bool continueToRun)
        {

        //}


        //private void RunMenu()
        //{
            //bool continueToRun = true;
            //Console.BackgroundColor = ConsoleColor.Gray;
            //Console.ForegroundColor = ConsoleColor.Black;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(" \n\n\n" + "********************* Welcome to the Komodo Insurance Developer Team Management Application. ************************ \n\n\n\n\n\n" + "   Select an option below: \n\n\n" + "       1. Individual Developer \n\n\n" + "       2. Development Team \n\n\n" + "        3. Exit\n\n\n");

                string userInput = Console.ReadLine();


                switch (userInput)
                {
                    case "1":
                        DeveloperMenu();
                        break;
                    case "2":
                        DevTeamMenu();
                        break;
                    case "3":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("    Please enter a valid number 1-3. \n\n" + "    Press any key to continue.");
                        Console.ReadKey();
                        break;
                }
            }
        }

            private void DeveloperMenu()
            {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool continueRunDev = true;
            while (continueRunDev)
            {
                Console.Clear();
                Console.WriteLine("******************* Developer Menu Options ******************** \n\n\n\n" + "  Select One Option Below  \n\n\n" + " 1. Create New Developer \n\n" + "  2. Create ID Number for Developer \n\n" + "  3. Remove Developer \n\n" + "4. Access to Pluralsight  \n\n" + "  5. Return to Main Menu  \n\n");


                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewDev();
                        break;
                    case "2":
                        ID();
                        break;
                    case "3":
                        RemoveDev();
                        break;
                    case "4":
                        Pluralsight();
                        break;
                    case "5":
                        continueRunDev = false;
                        break;
                    default:
                        Console.WriteLine("  \n Please enter a valid number between 1-6. \n\n" + "  Press any key to continue.");
                        break;
                        Console.ReadKey();

                }

            }
        }

        private void DevTeamMenu()
        {
            bool continueRunTeam = true;
            while (continueRunTeam)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n   Developer Team Menu  \n\n\n\n" + "     Select an option below:  \n\n\n" + "  1. Add Team \n\n" + "  2. Update Team \n\n" + "  3. Remove Team  \n\n" + "  4. Return to Main Menu  \n\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateDevTeam();
                        break;
                    case "2":
                        UpdateDevTeam();
                        break;
                    case "3":
                        RemoveDevTeam();
                        break;
                    case "4":
                        continueRunTeam = false;
                        break;
                    default:
                        Console.WriteLine("\n\n Please enter a valid number between 1-4. Press any key to continue \n");
                        Console.ReadKey();
                        break;


                }
            }
        }

        public void CreateNewDev()
        {
            Developer developer = new Developer();

            Console.WriteLine(" Enter in New Developer Information. \n\n" + "Please enter in the first name of the new developer:  \n\n");
            developer.FirstName = Console.ReadLine();
            _developerRepo.AddDev(developer);

            Console.WriteLine("Please enter in the last name of the new developer:  \n\n");
            developer.LastName = Console.ReadLine();
            _developerRepo.AddDev(developer);

            Console.WriteLine($" The new developer's name is: " + developer.FullName + "Is this correct? Answer Yes or No");
            string answer = Console.ReadLine().ToUpper();
            bool userInput = true;
            while (userInput)

            {
                if (answer == "yes")
                {
                    continue;
                }
                else if (answer == "no")
                {
                    Console.WriteLine(" Sorry to hear that. Press any key to continue.");
                }
                Console.ReadKey();
            }

            Console.WriteLine("Does this developer have access to pluralsight? Yes or No  \n\n");

            string userAnswer = Console.ReadLine().ToLower();
            developer.Pluralsight = access(userAnswer);
            _developerRepo.AddDev(developer);
            Console.Clear();
            Console.WriteLine("This developer was added.  \n\n");
            DisplayDevInfo(developer);
            Console.ReadKey();

        }

        private void DisplayDevInfo(Developer developer)
        {

        }

        private bool access(string userAnswer)
        {
            while (userAnswer != "true" && userAnswer != "false")
            {
                Console.Write("Please enter either True or False: ");
                userAnswer = Console.ReadLine().ToLower();
            }
            bool convertUserAnswer = Convert.ToBoolean(userAnswer);
            return convertUserAnswer;
        }

        public void ID()
        {
            Guid.NewGuid().ToString().GetHashCode().ToString();
        }

        /*public string generateID()
        {
            return Guid.NewGuid().ToString();
        }*/

        /*private void RemoveDev()
        {
            Console.WriteLine("Which developer would you like to remove?  Enter ID number. \n\n");
            List<Developer> developers = _developerRepo.GetDevList();
            int count = 0;
            foreach (Developer developer in developers)
            {
                count++;
                Console.WriteLine($"{count}. {developer.Id}");
            }

            int targetDeveloperId = int.Parse(Console.ReadLine());
            int targetIndex = targetDeveloperId - 1;
            if (targetIndex >= 0 && targetIndex < developers.Count)
            {
                Developer removeDeveloper = developers[targetIndex];
                if (_developerRepo.RemoveDev(removeDeveloper))
                {
                    Console.WriteLine($"{removeDeveloper.Id} successfully removed");
                }
                else
                {
                    Console.WriteLine("I'm sorry removal of this developer was unsuccessful.");
                }
            }
            else
            {
                Console.WriteLine("No developer has that ID");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }*/

        public void Pluralsight()
        {
            Console.Clear();
            Console.WriteLine("A list of Employees That Need the Pluralsight license:  \n\n");

            List<Developer> listOfAllDevelopers = _developerRepo.GetDevList();
            int index = 1;
            foreach (Developer developer in listOfAllDevelopers)
            {
                if (developer.Pluralsight == false)
                {
                    Console.WriteLine($"{index}. Full name: {developer.FullName}: Id: {developer.Id}");
                    index++;
                }

            }
        }

        private void RemoveDev()
        {
            bool removeDev = true;
            while (removeDev)
            {
                Console.Clear();

                GetDevList();
                List<Developer> listOfDevs = _developerRepo.GetDevList();
                if (listOfDevs.Count == 0)
                {
                    removeDev = false;
                }
                else
                {
                    Console.Write("\nPlease enter the Id number for the Employee you would like to remove: ");

                    //Make sure user gave a number
                    bool checkId = true;
                    while (checkId)
                    {
                        int uniqueId = Number();
                        Developer developer = _developerRepo.GetDevById(uniqueId);
                        if (developer == null)
                        {
                            Console.WriteLine("\nWe are not able to find that Employee Id.");
                            Console.ReadKey();
                            return;
                        }

                        Console.WriteLine($"\nAre you sure you want to delete {developer.FullName}?");
                        Console.Write("Please confirm with Yes or No: ");
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer == "yes")
                        {
                            Console.Clear();
                            //_developerRepo.RemoveDev();
                            Console.WriteLine("This developer was removed.   \n\n");
                            DisplayDevInfo(developer);
                        }
                        else if (userAnswer == "no")
                        {
                            Console.WriteLine($"\n{developer.FullName} was not deleted.");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            return;
                        }
                        Console.Write("\nWould you like to remove another Developer? Yes or No: ");
                        string answer = Console.ReadLine().ToUpper();
                        if (answer == "Yes")
                        {
                            continue;
                        }
                        else if (answer == "N0")
                        {
                            removeDev = false;
                        }
                        else
                        {
                            removeDev = false;

                        }
                    }

                }
            }
        }

        private int Number()
        {
            bool checkId = true;
            while (checkId)
            {
                string stringInput = Console.ReadLine();
                if (!int.TryParse(stringInput, out int Id))
                {

                    Console.Write("Please enter a number: ");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    return Int32.Parse(stringInput);
                }
            }
            return 0;
        }

        public void CreateDevTeam()
        {
            DevTeam devTeam = new DevTeam();
            Console.WriteLine("To create a team, first enter in the chosen team name:  \n\n");
            string TeamName = Console.ReadLine();
            devTeam.TeamName = Console.ReadLine();
            Console.WriteLine("Please enter in the Id number for the Team:  \n\n");
            int TeamId = Number();
            List<Developer> getDevs = _developerRepo.GetDevList();
            if (getDevs.Count() > 0)
            {
                bool addDevsToTeam = true;
                while (addDevsToTeam)
                {
                    Console.WriteLine(" Would you like to add developers to your team? Answer Yes or No  \n\n");
                    string addingDevs = Console.ReadLine().ToUpper();
                    if (addingDevs == "Yes")
                    {
                        Console.Clear();
                        GetDevList();
                        Console.WriteLine("Select a Developer by Id:  \n\n");

                        int Id = Number();
                        Developer developer = _developerRepo.GetDevById(Id);
                        //devTeam.TeamMembers(developer);
                    }
                    else
                    {
                        addDevsToTeam = false;
                    }
                }
            }

            DevTeam team = new DevTeam(TeamId, TeamName, getDevs);
            _devTeamRepo.AddDevTeam(devTeam);
            DisplayDevTeam(team);
            Console.ReadKey();
        }

        private void DisplayDevTeam(DevTeam devTeam)
        {
            Console.WriteLine($" {devTeam.TeamId} {devTeam.TeamId}");
        }

        public void UpdateDevTeam()
        {

        }

        public void RemoveDevTeam()
        {

        }

        private void GetDevList()
        {
            Console.WriteLine("A list of all Developers   \n\n");
            List<Developer> listOfDevs = _developerRepo.GetDevList();
            if (listOfDevs.Count == 0)
            {
                Console.WriteLine("Currently we don't have any Developers listed.");
            }
            else
            {
                int index = 1;
                foreach (Developer developer in listOfDevs)
                {
                    Console.WriteLine($"{index}. Full name: {developer.FullName}: Id: {developer.Id}");
                    index++;
                }
            }
        }
    }

}
