using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class TaxReportDao : BaseDao
    {
        public List<string> GetAllOrderYears()
        {
            string query = "SELECT DISTINCT YEAR(OrderDateTime) AS OrderYear FROM Orders;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters); 

            return ReadTablesOrderYears(dataTable);
        }

        private List<string> ReadTablesOrderYears(DataTable dataTable)
        {
            List<string> yearsList = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                string year = dr["OrderYear"].ToString();

                yearsList.Add(year);
            }
            return yearsList;
        }

      
        public List<TaxReport> GetTaxReport(DateTime startDate, DateTime endDate)
        {
            string query = @"
	                    SELECT  
		                        DISTINCT D.VATType, 
		                        SUM (((D.Price * O.AmountConsumed) * D.VATtype) / 100) AS TotalSalesVAT
	                    FROM 
			                    DRINK D
			                    JOIN ORDERS O ON D.DrinkID = O.DrinkID 
	                    WHERE 
		                    O.OrderDateTime BETWEEN  @startDate AND @endDate 
	
	                    GROUP BY 
		                        D.VATType 

	                    ORDER BY
		                        D.VATType DESC        

            ";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@startDate", startDate),
                new SqlParameter("@endDate", endDate)
            };
            DataTable dataTable = ExecuteSelectQuery(query, sqlParameters);

            return ReadTableSalesVAT(dataTable);
        }

        private List<TaxReport> ReadTableSalesVAT(DataTable dataTable)
        {
            List<TaxReport> taxReportList = new List<TaxReport>();

            foreach (DataRow dr in dataTable.Rows)
            {
                TaxReport taxReport = new TaxReport(
                    dr["VATType"].ToString(),
                     (decimal)dr["TotalSalesVAT"]
                    );

                taxReportList.Add(taxReport);
            }
            return taxReportList;
        }
    }
}
