using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        public int DrinkID;
        public string DrinkName;
        public decimal Price;
        public string VATtype;
        public int AmountInStock;
        public int TotalConsumed;
        public string StockStatus;

        public Drink(int drinkID, string drinkName, decimal price, string vatType,  int amountInStock) 
        {
            this.DrinkID = drinkID;
            this.DrinkName = drinkName;
            this.Price = price;
            this.VATtype = vatType;
            this.AmountInStock = amountInStock;           
        }

        public Drink(int drinkID, string drinkName, decimal price, string vatType, int amountInStock, int totalConsumed, string stockStatus)
              : this(drinkID, drinkName, price, vatType, amountInStock)
        {
            this.TotalConsumed = totalConsumed;
            this.StockStatus = stockStatus;
        }

        public Drink( string drinkName, decimal price, string vatType, int amountInStock)
        : this(0, drinkName, price, vatType, amountInStock)
        {

        }


        public override string ToString()
        {
            return $"{DrinkID} {DrinkName} {Price} {VATtype}  {AmountInStock} {TotalConsumed} {StockStatus}";
        }
    }
}
