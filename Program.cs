using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketReservationConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean menuFlag = true;

            Console.WriteLine("Ticket Reservation Console \n");

            while(menuFlag)
            {
                Console.WriteLine(" Enter Your Choice : ");
                Console.WriteLine(" 1- Add Passenger\n 2- Show Passenger Details \n 3- Exit \n");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        PassengerDetail.AddPassenger();
                        break;
                    case 2:
                        PassengerDetail.ShowDetails();
                        break;
                    case 3:
                        menuFlag = false;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice !!!!");
                        break;
                }
                

            }
            Console.ReadKey();
        }
    }
}
