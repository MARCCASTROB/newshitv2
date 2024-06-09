using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class OrdersService
    {
        public OrderDao OrderDao;

        public OrdersService()
        {
            OrderDao = new OrderDao();
        }

        public void CreateOrder(Orders newOrder)
        {
            OrderDao.CreateNewOrder(newOrder);
        }

        public void UpdateStockInventory(int drinkID, int AmountConsumed) 
        {
            OrderDao.UpdateStockInventory(drinkID, AmountConsumed);
        }
    }
}
