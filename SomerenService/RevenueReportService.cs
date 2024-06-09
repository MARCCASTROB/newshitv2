using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class RevenueReportService
    {
        RevenueReportDao revenueReportDao;

        public RevenueReportService() 
        {
            revenueReportDao = new RevenueReportDao();  
        }

        public List<RevenueReport> GenerateRevenueReport(DateTime startDate, DateTime endDate)
        {
             return revenueReportDao.GetRevenueRecords( startDate,  endDate);             
        }
        // revenue 
      
        public List<Orders> GetOrders()
        {
            return OrderDao.GetAllOrders();
        }

        public int CountAmountOfClients(DateTime startDate, DateTime endDate)
        {
            return OrderDao.CountAmountOfClients(startDate, endDate);
        }

        public bool RightDates(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return false;
            }

            return true;
        }

        public void DisplayNumberOfCustomers(DateTime startDate, DateTime endDate, out string numberOfCustomers)
        {
            int studentCount = CountAmountOfClients(startDate, endDate);

            numberOfCustomers = $"{studentCount} Customers";
        }

        public void DisplayTurnover(List<Orders> orders, DateTime startDate, DateTime endDate, out string turnover)
        {
            decimal totalRevenue = 0m;

            foreach (var revenueReport in orders)
            {
                if (order.OrderDateTime >= startDate && order.OrderDateTime <= endDate)
                    totalRevenue += order.Quantity * order.DrinkID.Price;
            }

            turnover = $"€{totalRevenue} Earned";
        }

        public void DisplayTotalSales(List<Orders> orders, DateTime startDate, DateTime endDate, out string totalSales)
        {
            int totalSoldDrinks = 0;

            foreach (var order in orders)
            {
                if (order.OrderDateTime >= startDate && order.OrderDateTime <= endDate)
                    totalSoldDrinks += order.Quantity;
            }

            totalSales = $"{totalSoldDrinks} Drinks sold";
        }
    }
}
