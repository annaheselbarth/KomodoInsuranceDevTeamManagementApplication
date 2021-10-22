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
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(" \n\n\n" + "********************* Welcome to the Komodo Insurance Developer Team Management Application. ************************ \n\n\n\n\n\n" + "   Enter a number below for the option you would like to begin with: \n\n\n" + "       1. Individual Developer \n\n\n" + "       2. Development Team \n\n\n" + "       3. Exit\n\n\n");

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
                Console.WriteLine("\n\n\n********************************************* Developer Menu Options *********************************************** \n\n\n\n" + "  Enter a Number from the menu below of the Option you would like to begin with: \n\n\n" + "  1. Create New Developer \n\n" + "  2. Edit Developer Information \n\n" + "  3. Remove Developer \n\n" + "  4. Access to Pluralsight  \n\n" + "  5. List of Developers. \n\n" + "  6. Return to Main Menu  \n\n");


                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        CreateNewDev();
                        break;
                    case "2":
                        RemoveDev();
                        break;
                    case "3":
                        Pluralsight();
                        break;
                    case "4":
                        GetDevList();
                        break;
                    case "5":
                        continueRunDev = false;
                        break;
                    default:
                        Console.WriteLine("  \n Please enter a valid number between 1-6. \n\n" + "  Press any key to continue.");
                        break;
                        

                }
                Console.ReadKey();
            }
        }

        
        private void DevTeamMenu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool continueRunTeam = true;
            while (continueRunTeam)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n **************************  Developer Team Menu **************************** \n\n\n\n" + "     Select an option below:  \n\n\n" + "  1. Add Team \n\n" + "  2. List of Teams \n\n"  + "  3. Update Team \n\n" + "  4. Remove Team  \n\n" + "  5. Return to Main Menu  \n\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateDevTeam();
                        break;
                    case "2":
                        GetDevTeams();
                        break;
                    case "3":
                        UpdateTeam();
                        break;
                    case "4":
                        RemoveDevTeam();
                        break;
                    case "5":
                        continueRunTeam = false;
                        break;
                    default:
                        Console.WriteLine("\n\n Please enter a valid number between 1-5. Press any key to continue \n");
                        Console.ReadKey();
                        break;


                }
            }
        }

        public void CreateNewDev()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Developer developer = new Developer();
            Console.Clear();
            Console.WriteLine(" Enter in New Developer Information. \n\n" + "Please enter in the first name of the new developer:  \n\n");
            developer.FirstName = Console.ReadLine();
            

            Console.WriteLine("\n\n Please enter in the last name of the new developer:  \n\n");
            developer.LastName = Console.ReadLine();
           

            Console.WriteLine($"\n\n The new developer's name is: {developer.FullName} ");
            

            Console.WriteLine("Does this developer have access to pluralsight? True or False  \n\n");

            string userAnswer = Console.ReadLine().ToLower();
            developer.Pluralsight = Access(userAnswer);

            
            _developerRepo.AddDev(developer);
            Console.Clear();
            Console.WriteLine($"{developer.FullName} was added and given the ID number of {developer.Id} \n\n");
            DisplayDevInfo(developer);
            Console.ReadKey();
            return;

        }

        


        private void DisplayDevInfo(Developer developer)
        {

        }

       

        private bool Access(string userAnswer)
        {
            while (userAnswer != "true" && userAnswer != "false")
            {
                Console.Write("Please enter either True or False: ");
                userAnswer = Console.ReadLine().ToLower();
            }
            bool convertUserAnswer = Convert.ToBoolean(userAnswer);
            return convertUserAnswer;
        }

        
        
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
                    return;
                }

            }
        }

        private void RemoveDev()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool removeDev = true;
            while (removeDev)
            {
                Console.Clear();

                GetDevList();
                List<Developer> listOfDevs = _developerRepo.GetDevList();
                if (listOfDevs.Count == 0)
                {
                    removeDev = false;
                    return;
                }
                else
                {
                    Console.Write("\nPlease enter the Id number for the Employee you would like to remove: ");

                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    bool checkId = true;
                    while (checkId)
                    {
                        int uniqueId = Number();
                        Developer developer = new Developer();
                        if (developer == null)
                        {
                            Console.WriteLine("\nWe are not able to find that Employee Id.");
                            Console.ReadKey();
                            return;
                        }

                        Console.WriteLine($"\n Are you sure you want to delete {developer.FullName}?");
                        Console.Write("\n Please confirm with Yes or No: ");
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer == "yes")
                        {
                            Console.Clear();
                            Console.WriteLine("This developer was removed.   \n\n");
                            DisplayDevInfo(developer);
                            Console.ReadKey();
                            return;
                        }
                        else if (userAnswer == "no")
                        {
                            Console.WriteLine($"\n{developer.FullName} was not deleted.");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.ReadKey();
                            return;
                        }
                       
                    }

                }
            }
        }

        private int Number()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool checkId = true;
            while (checkId)
            {
                string stringInput = Console.ReadLine();
                if (!int.TryParse(stringInput, out int Id))
                {

                    Console.Write("Please enter a number: \n\n");
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
            bool addNewTeam = true;
            while (addNewTeam)
            {
                Console.Clear();
                DevTeam devTeam = new DevTeam();
                Console.WriteLine("To create a team, first enter in the chosen team name:  \n\n");
                devTeam.TeamName = Console.ReadLine();
                _devTeamRepo.CreateDevTeam(devTeam);
                Console.WriteLine($"\n\n Your new team is {devTeam.TeamName}");
                Console.Clear();
                Console.WriteLine($"{devTeam.TeamName} was added and given the ID number of {devTeam.TeamId} \n\n");

                DisplayDevTeam(devTeam);

                Console.WriteLine("Would you like to add developers to this team now?  \n\n");

                string answer = Console.ReadLine().ToUpper();


                bool continueToRun = true;
                while (continueToRun)

                {
                    if (answer == "YES")
                    {
                        GetDevList();
                        Console.WriteLine("Select a Developer by Id:  \n\n");
                        string input = Console.ReadLine();
                        var devId = int.Parse(input);
                        var developer = _developerRepo.GetDevById(devId);
                        _devTeamRepo.AddDevToTeam(devTeam.TeamId, developer);
                        return;
                        

                        
                    }
                    else if (answer == "NO")
                    {
                        Console.WriteLine(" Press any key to continue.");
                        return;
                    }
                    Console.ReadKey();
                    return;
                }


                DevTeam teamOfDevs = new DevTeam();
                _devTeamRepo.CreateDevTeam(devTeam);
                DisplayDevTeam(teamOfDevs);
                Console.ReadKey();
            }
        }
            

        private void DisplayDevTeam(DevTeam devTeam)
        {
            Console.WriteLine($" {devTeam.TeamId} {devTeam.TeamName}");
        }

        public void UpdateTeam()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool continueRunTeam = true;
            while (continueRunTeam)
            {
                Console.Clear();
            Console.WriteLine("\n\n\n How would you like to update the team? Enter a number below for the option you would like to begin with: \n\n\n" + "  1. Add New Developer to Team.  \n\n" + "  2. Remove a Developer from Team. \n\n" + "  3. Change Team Name  \n\n");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddDevToTeam();
                    break;
                case "2":
                    AddDevListToTeam();
                    break;
                case "3":
                    RemoveDevFromTeam();
                    break;
                case "4":
                    continueRunTeam = false;
                    break;
                default:
                    Console.WriteLine("\n\n Please enter a valid number between 1-4. Press any key to continue \n");
                    Console.ReadKey();
                    break;


            }
            bool updateDevTeam = true;
                while (updateDevTeam)
                {
                    Console.Clear();
                    GetDevTeams();

                    List<DevTeam> devTeams = _devTeamRepo.TeamList();
                    if (devTeams.Count == 0)
                    {
                        updateDevTeam = false;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("\n Please enter the Id number for the Team you would like to update:  \n");
                        var uniqueId = Number();
                        DevTeam targetDevTeam = _devTeamRepo.GetTeamById(uniqueId);

                        if (targetDevTeam == null)
                        {
                            Console.WriteLine("/n We are not able to find Team Id.  Press any key to continue.  \n\n");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
            }
        }

        public void AddDevToTeam()
        {
            Console.Clear();
            Console.WriteLine("What team would you like to add a developer too? Please enter team ID.");
            string inputTeamId = Console.ReadLine();
            var teamId = int.Parse(inputTeamId);
            var devTeam = _devTeamRepo.GetTeamById(teamId);

            Console.WriteLine(" Would you like to add a developer to this team. Answer Yes or No. ");
            string answer = Console.ReadLine().ToUpper();
            bool continueToRun = true;
            while (continueToRun)

            {
                if (answer == "YES")
                {
                    GetDevList();
                    Console.WriteLine("Select a Developer by Id:  \n\n");
                    string input = Console.ReadLine();
                    var devId = int.Parse(input);
                    var developer = _developerRepo.GetDevById(devId);
                    _devTeamRepo.AddDevToTeam(devTeam.TeamId, developer);
                    return;



                }
                else if (answer == "NO")
                {
                    Console.WriteLine(" Press any key to continue.");
                    return;
                }
                Console.ReadKey();
                return;
            }

        }

        public void AddDevListToTeam()
        {

        }

        public void RemoveDevFromTeam()
        {
            
            bool removeDevFromTeam = true;
            while (removeDevFromTeam)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                GetDevTeams();

                List<DevTeam> devTeams = _devTeamRepo.TeamList();
                if (devTeams.Count == 0)
                {
                    removeDevFromTeam = false;
                }
                else
                {
                    Console.WriteLine(" \n Please enter the Team Id number that you would like to remove a developer from:  \n\n");
                    var uniqueId = Number();
                    DevTeam devTeam = _devTeamRepo.GetTeamById(uniqueId);
                    if (devTeam == null)
                    {
                        Console.WriteLine("\n We are not able to find that Team.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine($"Enter in the Id number of the developer that you would like to remove from {devTeam.TeamName}? \n\n");
                    var removeDevId = Number();
                    Developer developer = _developerRepo.GetDevById(removeDevId);
                    if (developer == null)
                    {
                        Console.WriteLine("\n We are not able to find that Team.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine($"\n Would you like to remove {developer.Id} from the team? Enter Yes or No.  \n\n");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.Clear();
                        _developerRepo.RemoveDev(developer);
                        Console.WriteLine($"The {developer.Id} has been removed. Press any key to continue. \n\n");
                        return;

                    }
                    else if (answer == "no")
                    {
                        Console.WriteLine($"\n {developer.Id} was not deleted. Press any key to continue.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response. Press any key to continue. ");
                        Console.ReadKey();
                        return;
                    }
                    
                }

            }

        }

        public void RemoveDevTeam()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            bool removeDevTeam = true;
            while (removeDevTeam)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Clear();
                GetDevTeams();

                List<DevTeam> devTeams = _devTeamRepo.TeamList();
                if (devTeams.Count == 0)
                {
                    removeDevTeam = false;
                }
                else
                {
                    Console.WriteLine(" \n Please enter the Team Id number that you would like to remove:  \n\n");
                    var uniqueId = Number();
                    DevTeam devTeam = _devTeamRepo.GetTeamById(uniqueId);
                    if (devTeam == null)
                    {
                        Console.WriteLine("\n We are not able to find that Team.");
                        Console.ReadKey();
                        return;
                    }
                    Console.WriteLine($"Are you sure you want to delete {devTeam.TeamName}? Enter Yes or No");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "yes")
                    {
                        Console.Clear();
                        _devTeamRepo.DeleteDevTeam(devTeam);
                        Console.WriteLine($"The {devTeam.TeamName} team has been removed. Press any key to continue. \n\n");
                        Console.ReadKey();
                        return;

                    }
                    else if (answer == "no")
                    {
                        Console.WriteLine($"\n Team {devTeam.TeamName} was not deleted. Press any key to continue.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid response. Press any key to continue. ");
                        Console.ReadKey();
                        return;
                    }
                }

            }

        }

        private void GetDevList()
        {
            Console.Clear();
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

        private void GetDevTeams()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("****************************  List of Developer Teams  *************************  \n\n\n");
            List<DevTeam> devTeams = _devTeamRepo.TeamList();
            if (devTeams.Count == 0)
            {
                Console.WriteLine("There are No Teams currently.  \n\n");
            }
            else
            {
                var index = 1;
                foreach (DevTeam devTeam in devTeams)
                {
                    Console.WriteLine($"{index}. Team Name: {devTeam.TeamName}. Id: {devTeam.TeamId}"); 
                    index++;
                }
            }
        }


        
    }

}
