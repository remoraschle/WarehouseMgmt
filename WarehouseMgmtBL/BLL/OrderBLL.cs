using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtBL
{
    public class OrderBLL : Orders
    {
        public string OrderGroupName { get; set; }
        public int? SearchOrderNumber { get; set; }
        public DateTime SearchOrderDate { get; set; }
        public string CustomerName { get; set; }



        /// <summary>
        /// returns all orders
        /// </summary>
        public List<OrderBLL> GetOrders(int? id, DateTime date)
        {
            List<Orders> order = new List<Orders>();

            if (id != null && date == null)
            {
                Orders firstOrder = EntityManagerOrder.GetFirstOrder((int)id);
                if (firstOrder != null)
                {
                    order.Add(firstOrder);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                //DatumSuche einfügen
                if (date != null)
                {
                   order = EntityManagerOrder.GetAllOrders();
                }
                else
                {
                    order = EntityManagerOrder.GetAllOrders();
                }
            }
               
            

            List<OrderBLL> list = new List<OrderBLL>();

            foreach (var v in order)
            {
                OrderBLL orderBLL = new OrderBLL();
                orderBLL.Id = v.Id;
                orderBLL.Date = v.Date;
                orderBLL.CustomerId = v.CustomerId;
                orderBLL.CustomerName = EntityManagerOrder.GetOrderCustomerFullName(v.CustomerId);

                list.Add(orderBLL);
            }

            return list;

        }



        /// <summary>
        /// returns the order with the specifed order id
        /// </summary>
        /// <param name="id"></param>
        public OrderBLL GetOrderByOrderID(int id)
        {
            return (OrderBLL)EntityManagerOrder.GetFirstOrder(id);
        }

       

   

        

        ///// <summary>
        ///// returns all orders with the OrderGroupId
        ///// </summary>
        ///// <param name="orderGroupId"></param>
        //public Order GetOrderByOrderGroupId(int orderGroupId)
        //{
        //    return EntityManager.GetOrder();
        //}


        /// <summary>
        /// inserts a new order into the databse using the values passed-in; returns the Order id of the newly inserted record
        /// </summary>
        public int AddOrder(DateTime Date,int CustomerId)
        {
            EntityManagerOrder entity = new EntityManagerOrder();
            return entity.AddOrder(Date, CustomerId);
        }


        /// <summary>
        /// inserts a new order into the databse using the values passed-in; returns the Order id of the newly inserted record
        /// </summary>
        public bool EditOrder(OrderBLL order)
        {
            EntityManagerOrder entity = new EntityManagerOrder();
            return entity.EditOrder(order);
        }


        /// <summary>
        /// inserts a new order into the databse using the values passed-in; returns the Order id of the newly inserted record
        /// </summary>
        public bool DeleteOrder(OrderBLL order)
        {
            EntityManagerOrder entity = new EntityManagerOrder();
            return entity.DeleteOrder(order);
        }


        //public static explicit operator OrderBLL(Order v)
        //{
        //    OrderBLL orderBBL = new OrderBLL();
        //    orderBBL.Id = v.Id;
        //    orderBBL.Name = v.Name;
        //    orderBBL.Price = v.Price;
        //    orderBBL.OrderGroupId = v.OrderGroupId;
        //    orderBBL.OrderGroupName = v.OrderGroup.Name;

        //    return orderBBL;
        //}


    }
}
