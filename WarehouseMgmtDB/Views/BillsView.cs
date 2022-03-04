using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB.Views
{
    public class BillsView
    {
        public int CustomerId { get;set; }
        public string CustomerName { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public DateTime BillDate { get; set; }
        public int BillNumber { get; set; }
        public decimal BillCostBrutto { get; set; }
        public decimal BillCostNetto { get; set; }
    }
}
