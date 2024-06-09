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
    public class RevenueReportDao : BaseDao
    {
        public List<RevenueReport> GetRevenueRecords(DateTime startDate, DateTime endDate)
        {
            // Increment endDate by one day
            endDate = endDate.AddDays(1);

            string query = @"
                        SELECT 
                            COUNT(DISTINCT O.StudentNumber) AS TotalCustomers, 
                            SUM(O.AmountConsumed) AS TotalAmountConsumed, 
                            SUM(D.Price * O.AmountConsumed) AS TotalSales 
                        FROM 
                            Orders O 
                            JOIN Drink D ON O.DrinkID = D.DrinkID 
                        WHERE 
                            O.OrderDateTime BETWEEN @startDate AND @endDate 
                        GROUP BY 
                            O.DrinkID, D.Price, D.VATType;
            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);
           
            return ReadTablesRevenue(dataTable);
        }


        private List<RevenueReport> ReadTablesRevenue(DataTable dataTable)
        {
            List<RevenueReport> revenueRecordList = new List<RevenueReport>();

            foreach (DataRow dr in dataTable.Rows)
            {
                RevenueReport revenueRecord = new RevenueReport(
                    (int)dr["TotalCustomers"],
                    (int)dr["TotalAmountConsumed"],
                     (decimal)dr["TotalSales"]
               );
                revenueRecordList.Add(revenueRecord);
            }
            return revenueRecordList;
        }
    }
}
