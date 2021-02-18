using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace TrainTicketReservationConsoleApplication
{
    class PassengerDetailVerification 
    {

        // Validate Passenger ID
        public static Boolean CheckPassengerId(string passengerId)
        {
            Regex rgx = new Regex("^[A-Z]{2}[0-9]{5}[A-Z]{1}$");

            if (rgx.IsMatch(passengerId))
            {
                return true;
            }
            
                return false;
            
        }

        // Find Age Category
        public static string CheckAgeCategory(DateTime dob)
        {
            
            TimeSpan yeardiff = DateTime.Now - dob;
            int age = (new DateTime(yeardiff.Ticks).Year - 1);
            Console.WriteLine("Age : " + age); 

            if(age <= 12)
            {
                return "Children";
            }
            else if(age>12&& age<50)
            {
                return "Adult";
            }
            else
            {
                return "Senior Citizen";
            }
        }

        
    }
}
