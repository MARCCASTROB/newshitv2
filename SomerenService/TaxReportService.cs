using System;
using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class TaxReportService
    {
        public TaxReportDao TaxReportDao;

        public TaxReportService() 
        {
            TaxReportDao = new TaxReportDao();  
        }

        public List<string> GetAllOrderYears()
        {
            return TaxReportDao.GetAllOrderYears();
        }

        public List<TaxReport> GetQuartalTaxReport(DateTime startDate, DateTime endate)
        {
            return TaxReportDao.GetTaxReport(startDate, endate);
        }
    }
}
