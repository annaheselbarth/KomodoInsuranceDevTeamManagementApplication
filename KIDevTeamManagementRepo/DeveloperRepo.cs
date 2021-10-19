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
        public List<Developer> _developerList = new List<Developer>();
        public void AddDeveloperToList(Developer developerInfo)
        {
            _developerList.Add(developerInfo);
        }

        //Read
        public List<Developer> GetDeveloperList()
        {
            return _developerList;
        }

        //Update
        public bool UpdateExistingDeveloper(int id, Developer newDev)
        {
            Developer oldDev = GetDeveloperById(id);
            if(oldDev != null)
            {
                oldDev.FullName = newDev.FullName;
                oldDev.IdNumber = newDev.IdNumber;
                oldDev.Pluralsight = newDev.Pluralsight;
                return true;
            }
            return false;
        }

    }
}
