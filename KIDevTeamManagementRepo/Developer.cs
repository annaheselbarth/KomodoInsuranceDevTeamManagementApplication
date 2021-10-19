﻿using System;
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
        public Developer()
        {

        }
        public Developer(string firstName, string lastName, int idNumber, bool pluralsight)
        {
            FirstName = firstName;
            LastName = lastName;
            IdNumber = idNumber;
            Pluralsight = pluralsight;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                string fullName = FirstName + " " + LastName;
                return fullName;
            }
        }
        public int IdNumber { get; set; }
        public bool Pluralsight { get; set; }
    }   
}
