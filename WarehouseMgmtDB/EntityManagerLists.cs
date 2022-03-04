using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;
using WarehouseMgmtDB.Views;

namespace WarehouseMgmtDB
{
    public class EntityManagerLists
    {
        public static List<BillsView> GetBills()
        {
            using (var context = new WarehouseContext())
            {
                List<BillsView> billsViews = new List<BillsView>();

                var view = (from order in context.Orders
                           join customer in context.Customers on order.CustomerId equals customer.Id
                           select new { order, customer});

                foreach (var item in view)
                {
                    BillsView billsView = new BillsView();

                    var customerHistory = new Customer();
                    using (var context2 = new WarehouseContext())
                    {
                        var iqueryCustomerHistory = context2.Customers.GetHistoryAtTime("Customers", item.customer.Id, item.order.Date);

                        foreach (var c in iqueryCustomerHistory)
                        {
                            customerHistory.Id = c.Id;
                            customerHistory.FirstName = c.FirstName;
                            customerHistory.LastName = c.LastName;
                            customerHistory.Street = c.Street;
                            customerHistory.Zip = c.Zip;
                            customerHistory.City = c.City;
                            customerHistory.Mail = c.Mail;
                            customerHistory.Url = c.Url;
                            customerHistory.Password = c.Password;
                        }
                        
                    }

                    if (customerHistory != null)
                    {


                        billsView.CustomerId = item.customer.Id;
                        billsView.CustomerName = customerHistory.FirstName + " " + customerHistory.LastName;
                        billsView.Street = customerHistory.Street;
                        billsView.Zip = customerHistory.Zip;
                        billsView.City = customerHistory.City;
                        billsView.BillDate = item.order.Date;
                        billsView.BillNumber = item.order.Id;

                        using (var context3 = new WarehouseContext())
                        {
                            billsView.BillCostBrutto = (from op in context3.OrderPositions
                                                        join article in context3.Articles on op.ArticleId equals article.Id
                                                        select new { op, article }).Sum(x => x.article.Price);
                        }

                        billsView.BillCostNetto = 0;

                        billsViews.Add(billsView);
                    }

                   
                }


                return billsViews;

            }
        }
    }
}

