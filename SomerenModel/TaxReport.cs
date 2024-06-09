using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class TaxReport
    {
        public string VAT;
        public decimal totalVAT2pay;

        public TaxReport(string vat, decimal totalsalesVAT2pay) 
        {
            this.VAT = vat;
            this.totalVAT2pay = totalsalesVAT2pay;
        }
    }
}
