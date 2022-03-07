using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtBL
{
    public class OrderPositionsBLL: OrderPositions
    {
        public string ArticleName { get; set; }

        public List<OrderPositionsBLL> GetOrderPositions(int orderId)
        {
            var list = EntityManagerOrderPositions.GetOrderPositions(orderId);

            List<OrderPositionsBLL> orderPositionsBLLs = new List<OrderPositionsBLL>();

            foreach (var item in list)
            {
                OrderPositionsBLL op = new OrderPositionsBLL();

                op.OrderId = item.OrderId;
                op.ArticleId = item.ArticleId;
                op.ArticleName = EntityManagerArticle.GetFirstArticle(item.ArticleId).Name;
                op.Quantity = item.Quantity;

                orderPositionsBLLs.Add(op);

            }

            return orderPositionsBLLs;
        }


        /// <summary>
        /// inserts a new orderPosition into the databse using the values passed-in;
        /// </summary>
        public void AddOrderPosition(int orderId, int articleId, int quantiy)
        {
            EntityManagerOrderPositions entity = new EntityManagerOrderPositions();
            entity.AddOrderPosition(orderId, articleId,quantiy);
        }

        /// <summary>
        /// inserts a new orderPosition into the databse using the values passed-in; returns the Order id of the newly inserted record
        /// </summary>
        public bool EditOrderPosition(OrderPositionsBLL orderPosition)
        {
            EntityManagerOrderPositions entity = new EntityManagerOrderPositions();
            return entity.EditOrderPosition(orderPosition);
        }


        /// <summary>
        /// inserts a new orderPosition into the databse using the values passed-in; returns the Order id of the newly inserted record
        /// </summary>
        public bool DeleteOrderPosition(OrderPositionsBLL orderPosition)
        {
            EntityManagerOrderPositions entity = new EntityManagerOrderPositions();
            return entity.DeleteOrderPosition(orderPosition);
        }

    }
}
