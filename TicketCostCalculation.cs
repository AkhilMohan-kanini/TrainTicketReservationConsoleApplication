using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketReservationConsoleApplication
{
    class TicketCostCalculation : PassengerDetail
    {

        // Calculate Discount Percentage
        public static int CalculateDiscountPercentage(string ageCategory)
        {
            if(ageCategory == "Children")
            {
                return 100;
            }
            else if(ageCategory == "Senior Citizen")
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }

        //Calculate Ticket Cost
        public static double CalculateTicketCost(int discount, Places src ,Places dest , string ticketCategory )
        {
            double ticketCost;
            if( (src == Places.Chennai && dest == Places.Erode) || (src == Places.Erode && dest == Places.Chennai))
            {
                ticketCost = 500;
            }
            else if( (src == Places.Bangalore && dest == Places.Chennai ) || (src == Places.Chennai && dest == Places.Bangalore))
            {
                ticketCost = 600;
            }
            else if( (src == Places.Erode && dest == Places.Bangalore ) || (src== Places.Bangalore && dest== Places.Erode))
            {
                ticketCost = 800;
            }
            else
            {
                Console.WriteLine("Source and Destination are Same !!! They must be different");
                return 0; 
            }

            double totalTicketCost = ticketCost + TicketCategoryDictionary[ticketCategory];
            Console.WriteLine("Ticket Cost : {0} and Ticket Category Cost : {1}", ticketCost, TicketCategoryDictionary[ticketCategory]);

            if (discount == 0)
            {
                return totalTicketCost;
            }
            else if(discount==100)
            {
                return 0;
            }
            else 
            {
                return  totalTicketCost - (totalTicketCost * discount/100);
            }

        }
    }
}
