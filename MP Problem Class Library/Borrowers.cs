using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP_Problem_Class_Library
{
    internal class Borrowers
    {
        private string BorrowerID;
        private string[] BorrowerName = new string[2]; // [0] = LastName, [1] = FirstName

        // Constructor
        public Borrowers(string lastName, string firstName, int idNumber)
        {
            BorrowerName[0] = lastName;
            BorrowerName[1] = firstName;

            // BorrowerID pattern = L + number
            BorrowerID = "L" + idNumber;
        }

        // Getters
        public string getBorrowerID()
        {
            return BorrowerID;
        }

        public string getLastName()
        {
            return BorrowerName[0];
        }

        public string getFirstName()
        {
            return BorrowerName[1];
        }

        public string getFullName()
        {
            return BorrowerName[0] + ", " + BorrowerName[1];
        }
    }
}
