using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Views;
using WarehouseMgmtDB;

namespace WarehouseMgmtBL.BLL
{
    public class ViewsBLL : BillsView
    {
        public static List<ViewsBLL> GetBillView()
        {
            var viewsBill = EntityManagerLists.GetBills();

            List<ViewsBLL> viewsBLLList = new List<ViewsBLL>();
            foreach (var item in viewsBill)
            {
                ViewsBLL viewsBLL = new ViewsBLL();

                viewsBLL.CustomerId = item.CustomerId;
                viewsBLL.CustomerName = item.CustomerName;
                viewsBLL.Street = item.Street;
                viewsBLL.Zip = item.Zip;
                viewsBLL.City = item.City;
                viewsBLL.BillDate = item.BillDate;
                viewsBLL.BillNumber = item.BillNumber;
                viewsBLL.BillCostBrutto = item.BillCostBrutto;
                viewsBLL.BillCostNetto = item.BillCostNetto;

                viewsBLLList.Add(viewsBLL);
            }

            return viewsBLLList;
        }
    }
}
