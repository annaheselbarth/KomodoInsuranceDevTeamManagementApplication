﻿using System;
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
        //private List<DevTeam> _devTeamRepo = new List<DevTeam>();
        //public List<DevTeam> DevTeamList = new List<DevTeam>();
        
        
        DevTeam team = new DevTeam();
        private List<DevTeam> _devTeamRepo = new List<DevTeam>();
        int counter1;
        //int counter1 = _devTeamRepo.Count;
        

        public void CreateDevTeam(DevTeam devTeamInfo)
        
        {
            
            counter1 = _devTeamRepo.Count +1;
            devTeamInfo.TeamId = counter1;

            _devTeamRepo.Add(devTeamInfo);
        }
        //Create

        
        /*public void AddDev(DevTeam devTeamInfo)
        {

            _devTeamRepo.Add(devTeamInfo);

        }*/
        /*public void AddDevTeam(DevTeam team)
        {
            _devTeamRepo.Add(team);
        }*/

        //Read

        public List<DevTeam> TeamList()
        {
            return _devTeamRepo;
        }

        //Update

        public bool UpdateTeam(DevTeam devTeam, DevTeam newTeam)
        {
            //DevTeam oldTeam = GetTeamById(devTeamId);
            if(devTeam != null)
            {
                devTeam.TeamId = newTeam.TeamId;
                devTeam.TeamName = newTeam.TeamName;
                devTeam.TeamMembers = newTeam.TeamMembers;
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        public bool AddDevToTeam(int devTeamid, Developer developer)
        {
            DevTeam team = GetTeamById(devTeamid);
            if(team != null)
            {
                    _devTeamRepo.Add(devTeam);
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

        DevTeam devTeam = new DevTeam();
       
       
        public void AddDev(DevTeam team)
        {
            team.TeamId = counter1++;

            devTeam.TeamList.Add(team);
        }

        /*public void AddDevToTeam(int TeamId, Developer developer)
        {
            DevTeam devTeam = GetOneTeam(TeamId);
            devTeam.TeamMembers.Add(developer);
        }*/

        //Delete

        public bool DeleteDevTeam(int teamId)
        {
            DevTeam team = GetTeamById(teamId);
            if(team != null)
            {
                int initialCount = devTeam.TeamList.Count;
                devTeam.TeamList.Remove(team);
                if(initialCount > devTeam.TeamList.Count)
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

        /*public void UpdateTeam(DevTeam targetDevTeam, DevTeam updateDevTeam)
        {
            throw new NotImplementedException();
        }*/

        public void DeleteDevTeam(DevTeam devTeam)
        {
            bool result = _devTeamRepo.Remove(devTeam);
            return;
        }
    }
}
