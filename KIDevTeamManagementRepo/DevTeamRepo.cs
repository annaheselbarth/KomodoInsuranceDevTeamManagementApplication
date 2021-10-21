using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDevTeamManagementRepo
{
    //Create a Team (Id first than Name)
    //Client wants to be able to add and remove team members by their unique identifier
    //Should be able to see a list of existing developers to choose from and add to existing teams
    //Add developers individually from developer directory to team
    //Be able to add multiple developers to a team at once rather than one by one

   
    public class DevTeamRepo
    {
        public List<DevTeam> _devTeamRepo = new List<DevTeam>();

        //Create
        public void CreateDevTeam(DevTeam devTeamInfo)
        {

            _devTeamRepo.Add(devTeamInfo);

        }
        public void AddDevTeam(DevTeam team)
        {
            _devTeamRepo.Add(team);
        }

        //Read

        public List<DevTeam> TeamList()
        {
            return _devTeamRepo;
        }

        //Update

        public bool UpdateTeam(int devTeamId, DevTeam newTeam)
        {
            DevTeam oldTeam = GetTeamById(devTeamId);
            if(oldTeam != null)
            {
                oldTeam.TeamId = newTeam.TeamId;
                oldTeam.TeamName = newTeam.TeamName;
                oldTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            return false;
        }
        
        public bool AddDevToTeam(int devTeamid, Developer developer)
        {
            DevTeam team = GetTeamById(devTeamid);
            if(team != null)
            {
                    team.TeamMembers.Add(developer);
                    return true;
            }
            return false;
        }

        public bool AddDevListToTeam(int devTeamId, List<Developer> devs)
        {
            DevTeam team = GetTeamById(devTeamId);
            if(team != null)
            {
                foreach(Developer dev in devs)
                {
                    team.TeamMembers.Add(dev);
                }
                return true;
            }
            return false;
        }

        //Delete

        public bool DeleteDevTeam(int teamId)
        {
            DevTeam team = GetTeamById(teamId);
            if(team != null)
            {
                int initialCount = _devTeamRepo.Count;
                _devTeamRepo.Remove(team);
                if(initialCount > _devTeamRepo.Count)
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

        public DevTeam GetTeamById(int id)
        {
            foreach(DevTeam team in _devTeamRepo)
            {
                if(team.TeamId == id)
                {
                    return team;
                }
            }
            return null;
        }

        public DevTeam GetTeamById(object userInput)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeam(DevTeam targetDevTeam, DevTeam updateDevTeam)
        {
            throw new NotImplementedException();
        }

        public void DeleteDevTeam(DevTeam devTeam)
        {
            throw new NotImplementedException();
        }
    }
}
