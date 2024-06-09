using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class OrderDao : BaseDao
    {
        public static List<Orders> GetAllOrders()
        {
            string query = "SELECT * FROM ORDERS";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTablesDrinks(ExecuteSelectQuery(query, sqlParameters));
        }

        public void CreateNewOrder(Orders newOrder)
        {
            string query = @"
                            INSERT INTO ORDERS(DrinkID,StudentNumber,AmountConsumed, OrderDateTime)
                            VALUES (@DrinkID, @StudentNumber, @AmountInStock, @OrderDateTime);
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkID", newOrder.DrinkID),
                new SqlParameter("@StudentNumber", newOrder.StudentID),
                new SqlParameter("@AmountInStock", newOrder.AmountConsumed),
                new SqlParameter("@OrderDateTime", newOrder.OrderDateTime)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

        public void UpdateStockInventory(int drinkID, int amountConsumed)
        {
            string query = @"
                        UPDATE DRINK
	                    SET AmountInStock -= @AmountConsumed
	                    WHERE DrinkID = @DrinkID
            ;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkID", drinkID),
                new SqlParameter("@AmountConsumed", amountConsumed),
                
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }
        


        public List<Orders> ReadTablesDrinks(DataTable dataTable)
        {
            List<Orders> ordersList = new List<Orders>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Orders order = new Orders(
                 (int) dr["OrderID"],
                 (int)dr["DrinkID"],
                   (int)dr["StudentNumber"],
                   (int)dr["AmountConsumed"],
                   (DateTime)dr["OrderDateTime"]
               );
                ordersList.Add(order);
            }
            return ordersList;
        }
        public static int CountAmountOfClients(DateTime startData, DateTime endData)
        {
            string query = "SELECT COUNT(DISTINCT StudentNumber) FROM ORDERS WHERE OrderDateTime BETWEEN @StartDate AND @EndDate";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StartDate", startData),
                new SqlParameter("@EndDate", endData)
            };
            return ExecuteCountQuery(query, sqlParameters);
        } 

    }
}
