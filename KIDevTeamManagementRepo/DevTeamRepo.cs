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
            protected readonly List<DevTeam> _contentDevTeam = new List<DevTeam>();
            public void AddDevTeamContentToDirectory(DevTeam devTeamInfo)
            {
                _contentDevTeam.Add(devTeamInfo);
            }
        }
}
