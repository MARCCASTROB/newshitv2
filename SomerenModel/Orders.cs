using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Orders
    {
        private int orderID;
        public int OrderID { get { return orderID; } set { orderID = value; } }

        public int DrinkID { get; set; }
        public int StudentID { get; set; }
        public int AmountConsumed { get; set; }
        public DateTime OrderDateTime { get; set; }

        public Orders(int orderID, int drinkId, int studentID, int amountConsumed, DateTime orderDateTime)
        {
            OrderID = orderID;
            DrinkID = drinkId;
            StudentID = studentID;
            AmountConsumed = amountConsumed;
            OrderDateTime = orderDateTime;
        }

        public Orders(int drinkId, int studentID, int amountConsumed, DateTime orderDateTime)
            : this (0,drinkId,studentID,amountConsumed, orderDateTime)
        {
            
        }
    }
}
