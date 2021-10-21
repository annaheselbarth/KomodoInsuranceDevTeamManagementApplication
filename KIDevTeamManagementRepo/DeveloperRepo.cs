using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDevTeamManagementRepo
{
    public class DeveloperRepo
    {
        //Create

        
        Developer dev = new Developer();
        public List<Developer> _developerRepo = new List<Developer>();
        int counter = 0;
        public void AddDev(Developer devInfo)
        {
            devInfo.Id = counter++;

            _developerRepo.Add(devInfo);
        }

        public void CreateNewDev(Developer devInfo)
        {

            _developerRepo.Add(devInfo);

        }

        public Developer GetDevById(int id)
        {
            foreach (Developer dev in _developerRepo)
            {
                if (dev.Id == id)
                {
                    return dev;
                }
            }
            return null;
        }

        
        //Read
        public List<Developer> GetDevList()
        {
            return _developerRepo;
        }

        //Update
        public bool UpdateExistingDev(Developer developer, Developer newDev)
        {
            //Developer oldDev = GetDevById(int id);
            if(developer != null)
            {
                developer.FirstName = newDev.FirstName;
                developer.LastName = newDev.LastName;
                developer.Id = newDev.Id;
                developer.Pluralsight = newDev.Pluralsight;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Delete

        public bool RemoveDev(Developer developer)
        {
            bool result = _developerRepo.Remove(developer);
            return result;
        }
        

       
    }
}
