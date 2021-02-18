using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TrainTicketReservationConsoleApplication
{
    class PassengerDetail
    {
       
        string _passengerId,_name;
        DateTime _dateOfBirth;

        public enum Places
        {
            Chennai =1 ,
            Erode,
            Bangalore
        }

        public Places Source , Destination;

        //Dictionary for Ticket Category
        protected static Dictionary<string, int> TicketCategoryDictionary = new Dictionary<string, int>() {
            {"AC" , 1500  },
            {"First Class Sleeper" , 1000 },
            {"Second Class Sleeper" , 750 },
            {"Third Class Sleeper" , 500 }
        };

        //List for Passengers
        static List<PassengerDetail> PassengerDetailList = new List<PassengerDetail>();

        //Properties

        public string PassengerID
        {
            get => _passengerId; set => _passengerId = value;
        }

        public string Name{ get { return _name; }  set{ _name = value; } }

        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }

        public string TicketCategory { get; set; }

        //Constructor for PassengerDetail

        public PassengerDetail() { }

        public PassengerDetail(string id , string name , DateTime dob , Places src, Places dest , string ticketCategory)
        {
            this.PassengerID = id;
            this.Name = name;
            this.DateOfBirth = dob;
            this.Source = src;
            this.Destination = dest;
            this.TicketCategory = ticketCategory;

        }

        // For Adding Passengers
        public static void AddPassenger()
        {
            Console.WriteLine("\nAdd Passenger ");
            Console.WriteLine("-------------\n");

            string id = default, name = default,ticketCategory= default;
            DateTime dob = default;
            Places src = default, dest = default;

            try
            {
                // Input of Passenger ID and Validation
                Console.WriteLine("Enter Passenger ID : ");
                id = Console.ReadLine();
                if (!PassengerDetailVerification.CheckPassengerId(id))
                {
                    Console.WriteLine("Passenger ID Verification failed !!!\n");
                    return;
                }
                if (!Validate(id)) { Console.WriteLine("Passenger ID cannot be Empty !!"); return; }

                // Input of Passenger Name and Validation
                Console.WriteLine("Enter Passenger Name : ");
                name = Console.ReadLine();
                if (!Validate(name)) { Console.WriteLine("Passenger Name cannot be Empty !!\n"); return; }
                Regex rgx = new Regex(@"^[a-zA-Z]+\s*[a-zA-Z]*$");

                if (!rgx.IsMatch(name))
                {
                    throw new FormatException();
                }

                //Input of Date of Birth
                Console.WriteLine("Enter Date of Birth :");
                dob = DateTime.Parse(Console.ReadLine());
                if(dob>DateTime.Now)
                {
                    throw new FormatException();
                }

                //Input of Source Station
                Console.WriteLine("Enter Source Option : ");
                foreach (int i in Enum.GetValues(typeof(Places)))
                {
                    Console.WriteLine("{0} - {1} ", i, (Places)i);
                }
                int srcIndex = Int32.Parse(Console.ReadLine());
                src = (Places)srcIndex;

                //Input of Destination Station 
                Console.WriteLine("Enter Destination Option : ");
                foreach (int i in Enum.GetValues(typeof(Places)))
                {
                    Console.WriteLine("{0} - {1} ", i, (Places)i);
                }
                int destIndex = Int32.Parse(Console.ReadLine());
                dest = (Places)destIndex;

                //Input of Ticket Category
                int num = 1;
                Console.WriteLine(" Enter Ticket Category : ");
                foreach (KeyValuePair<string, int> tc in TicketCategoryDictionary)
                {
                    Console.WriteLine($" {num++} - {tc.Key} (Price : {tc.Value})");
                }
                int tcIndex = Int32.Parse(Console.ReadLine());
                ticketCategory = TicketCategoryDictionary.ElementAt(tcIndex - 1).Key;
            }
            catch(FormatException)
            {
                Console.WriteLine("Invalid Format !!! \n");
                return;
            }
            

            //Adding Passenger object in PassengerDetailList
            PassengerDetailList.Add(new PassengerDetail(id, name, dob, src, dest, ticketCategory));
            Console.WriteLine("Passenger Added Successfully ... \n");

            Console.WriteLine("Passenger Travel Details : \n");

            foreach(PassengerDetail passenger in PassengerDetailList)
            {
                if(passenger.PassengerID == id)
                {
                    string ageCategory = PassengerDetailVerification.CheckAgeCategory(passenger.DateOfBirth);
                    Console.WriteLine("Age Category : " + ageCategory);

                    int discount = TicketCostCalculation.CalculateDiscountPercentage(ageCategory);
                    Console.WriteLine("Discount % : " + discount + " %");


                    double totalCost = TicketCostCalculation.CalculateTicketCost(discount, passenger.Source
                                                    , passenger.Destination, passenger.TicketCategory);
                    Console.WriteLine("Total Ticket Cost : " + totalCost + "\n");
                }
            }

        }

        // For Displaying all Passengers Details
        public static void ShowDetails()
        {

            Console.WriteLine("Displaying Passenger Details : ");

            foreach(PassengerDetail passenger in PassengerDetailList)
            {
                Console.WriteLine("ID : " + passenger.PassengerID);
                Console.WriteLine("Name : " + passenger.Name);
                Console.WriteLine("Date of Birth  : " + passenger.DateOfBirth.ToString("dd-MM-yyyy"));
                Console.WriteLine("Source : " + passenger.Source);
                Console.WriteLine("Destination : " + passenger.Destination);
                Console.WriteLine("Ticket Category : " + passenger.TicketCategory);

                string ageCategory = PassengerDetailVerification.CheckAgeCategory(passenger.DateOfBirth);
                Console.WriteLine("Age Category : " + ageCategory);

                int discount = TicketCostCalculation.CalculateDiscountPercentage(ageCategory);
                Console.WriteLine("Discount % : " + discount +" %");


                double totalCost = TicketCostCalculation.CalculateTicketCost(discount, passenger.Source
                                                , passenger.Destination, passenger.TicketCategory);
                Console.WriteLine("Total Ticket Cost : " + totalCost + "\n");
            }
        }

        public static Boolean Validate(string str)
        {
            if(String.IsNullOrEmpty(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
