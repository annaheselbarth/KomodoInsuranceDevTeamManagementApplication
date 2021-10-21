using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIDevTeamManagementRepo
{
    public class Developer
    {

        //Indentify 1 developer without mistaking the for another. Unique Identifier
        //Name
        //ID number
        //Whether they have access to pluralsight
            public Developer() { }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
            public string FullName
            {
            get
            {
                string FullName = FirstName + " " + LastName;
                return FullName;
            }
            }
            public int Id { get; set; }
            public bool Pluralsight { get; set; }
            //public List<Developer> DevList { get; set; }

        public Developer(string firstName, string lastName, int id, bool pluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Pluralsight = pluralsight;
        }

    }
    

}

