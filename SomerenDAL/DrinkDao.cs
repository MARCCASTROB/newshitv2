using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao
    {
        public List<Drink> GetAllDrinks()
        {
            string query = @" WITH DrinkSales AS (SELECT D.DrinkID, D.DrinkName, D.Price, D.VATtype, D.AmountInStock, COALESCE(SUM(O.AmountConsumed), 0) AS TotalConsumed FROM DRINK D LEFT JOIN ORDERS O ON D.DrinkID = O.DrinkID GROUP BY D.DrinkID, D.DrinkName, D.Price, D.VATtype, D.AmountInStock), DrinkInventory AS (SELECT DrinkID, DrinkName, Price, VATtype, AmountInStock, TotalConsumed, CASE WHEN AmountInStock < 10 THEN 'Stock nearly depleted' ELSE 'Stock sufficient' END AS StockStatus FROM DrinkSales) SELECT DI.DrinkID, DI.DrinkName, DI.Price, CASE WHEN DI.VATtype = 9 THEN 'Non Alcoholic' WHEN DI.VATtype = 21 THEN 'Alcoholic' END AS VATtype, DI.AmountInStock, DI.TotalConsumed, DI.StockStatus FROM DrinkInventory DI ORDER BY DI.DrinkName;";
            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            return ReadTablesDrinks(dataTable);

        }

        public void CreateNewDrink(Drink newDrink)
        {
            string query = @"
                            INSERT INTO DRINK (DrinkName, VATtype, Price, AmountInStock)
                            VALUES (@DrinkName, @VATtype, @Price, @AmountInStock); 
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                    new SqlParameter("@DrinkName", newDrink.DrinkName),
                    new SqlParameter("@VATtype", newDrink.VATtype),
                    new SqlParameter("@Price", newDrink.Price),
                    new SqlParameter("@AmountInStock", newDrink.AmountInStock)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }



        public void UpdateDrinkData(Drink oldDrink, Drink updateDrink)
        {
            string query = @"
                            UPDATE DRINK 
                            SET DrinkName=@DrinkName,  VATtype=@VATtype, Price=@Price, AmountInStock= @AmountInStock
                            WHERE DrinkID = @DrinkID;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkName", updateDrink.DrinkName),
                new SqlParameter("@VATtype", updateDrink.VATtype),
                new SqlParameter("@Price", updateDrink.Price),
                new SqlParameter("@AmountInStock", updateDrink.AmountInStock),
                new SqlParameter("@DrinkID", oldDrink.DrinkID)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }

       

        public void DeleteDrinkData(Drink drinkToDelete)
        {
            string query = @"ALTER TABLE ORDERS NOCHECK CONSTRAINT FK__ORDERS__DrinkID; DECLARE @NextDrinkID INT; SELECT @NextDrinkID = ISNULL(MAX(DrinkID) + 1, 1000) FROM ORDERS WHERE DrinkID >= 1000 AND DrinkID <> @DrinkID; UPDATE ORDERS SET DrinkID = @NextDrinkID WHERE DrinkID = @DrinkID; DELETE FROM DRINK WHERE DrinkID = @DrinkID; ALTER TABLE ORDERS CHECK CONSTRAINT FK__ORDERS__DrinkID;";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkID", drinkToDelete.DrinkID),
                new SqlParameter("@DrinkName", drinkToDelete.DrinkName)
               
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }




        private List<Drink> ReadTablesDrinks(DataTable dataTable)
        {
            List<Drink> drinkList = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink(
                   (int)dr["DrinkID"],
                   dr["DrinkName"].ToString(),
                    (decimal)dr["Price"],
                   dr["VATtype"].ToString(),
                   (int)dr["AmountInStock"],
                   (int)dr["TotalConsumed"],
                   dr["StockStatus"].ToString()

               );
                drinkList.Add(drink);
            }
            return drinkList;
        }
    }
}