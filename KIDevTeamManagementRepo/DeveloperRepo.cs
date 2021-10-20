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
        public void AddDev(Developer devInfo)
        {
            _developerList.Add(devInfo);
        }

        public void CreateNewDev(Developer devInfo)
        {
            
            _developerList.Add(devInfo);
           
        }
        
       
        //Read
        public List<Developer> GetDevList()
        {
            return _developerList;
        }

        //Update
        public bool UpdateExistingDev(int id, Developer newDev)
        {
            Developer oldDev = GetDevById(id);
            if(oldDev != null)
            {
                oldDev.FirstName = newDev.FirstName;
                oldDev.LastName = newDev.LastName;
                oldDev.Id = newDev.Id;
                oldDev.Pluralsight = newDev.Pluralsight;
                return true;
            }
            return false;
        }

        //Delete

        public bool RemoveDev(int id)
        {
            Developer dev = GetDevById(id);
            if (dev != null)
            {
                int initialCount = _developerList.Count;
                _developerList.Remove(dev);
                if(initialCount > _developerList.Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;

        }

        public Developer GetDevById(int id)
        {
            foreach(Developer dev in _developerList)
            {
                if(dev.Id == id)
                {
                    return dev;
                }
            }
            return null;
        }

    }
}
