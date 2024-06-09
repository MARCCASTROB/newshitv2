using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel  
{
    public class RevenueReport 
    {
        public int totalConsumedDrink;
        public decimal totalTurnover;
        public int totalCustomers;
        public int price;

        public RevenueReport(int totalCustomers, int totalConsumedDrink, decimal totalTurnover, int price  ) 
        {
            this.totalCustomers = totalCustomers;
            this.totalConsumedDrink = totalConsumedDrink;
            this.totalTurnover = totalTurnover; 
            this.price = price;
        }
    }
}
