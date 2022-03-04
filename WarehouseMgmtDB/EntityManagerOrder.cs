using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManagerOrder
    {
        public static List<Orders> GetOrders()
        {
            using (var context = new WarehouseContext())
            {
                var sqlvalues = context.Orders.Select(x => x);

                List<Orders> orderList = new List<Orders>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {

                        orderList.Add(item);
                    }
                }

                return orderList;
            }
        }



        public static Orders GetFirstOrder(int id)
        {
            using (var context = new WarehouseContext())
            {
                return context.Orders.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static string GetOrderCustomerFullName(int id)
        {
            using (var context = new WarehouseContext())
            {
                string first = context.Customers.Where(x => x.Id == id).Select(x => x.FirstName).FirstOrDefault();
                string last = context.Customers.Where(x => x.Id == id).Select(x => x.LastName).FirstOrDefault();
                return first + " " + last;
            }
        }

     

        public static List<Orders> GetAllOrders()
        {
            using (var context = new WarehouseContext())
            {
                return context.Orders.ToList();
            }
        }
        public static List<Orders> GetAllOrders(int customerId)
        {
            using (var context = new WarehouseContext())
            {
                return context.Orders.Where(x => x.CustomerId == customerId).ToList();
            }
        }


        public static List<Orders> GetAllOrdersFromDate(DateTime date1, DateTime date2)
        {
            using (var context = new WarehouseContext())
            {
                return context.Orders.Where(x => x.Date >= date1 || x.Date <= date2).ToList();
            }
        }
        public static List<Orders> GetAllOrdersFromDate(DateTime date)
        {
            return GetAllOrdersFromDate(Convert.ToDateTime(date.ToShortDateString()), Convert.ToDateTime(date.AddDays(1).ToShortDateString()));
        }

        public int AddOrder(DateTime date, int customerId)
        {
            using (var context = new WarehouseContext())
            {
                var order = new Orders()
                {
                Date = date,
                CustomerId = customerId
            };


                context.Orders.Add(order);
                context.SaveChanges();

                return order.Id;
            }
        }


        public int AddOrder(DateTime date, int customerId, List<OrderPositions> orderPositions)
        {
            using (var context = new WarehouseContext())
            {
               

                var order = new Orders()
                {
                    Date = date,
                    CustomerId = customerId
                };

                foreach (var item in orderPositions)
                {
                    var op = new OrderPositions()
                    {
                        ArticleId = item.ArticleId,
                        Quantity = item.Quantity
                    };
                }

                context.Orders.Add(order);
                context.SaveChanges();

                return order.Id;
            }
        }

        public bool EditOrder(Orders orderChanges)
        {
            using (var context = new WarehouseContext())
            {
                var order = context.Orders.Where(x => x.Id == orderChanges.Id).FirstOrDefault();

                order.Date = orderChanges.Date;
                order.CustomerId = orderChanges.CustomerId;

                int count = context.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteOrder(Orders orderToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var order = context.Orders.Where(x => x.Id == orderToDelete.Id).FirstOrDefault();

                context.Orders.Remove(order);

                int count = context.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}

