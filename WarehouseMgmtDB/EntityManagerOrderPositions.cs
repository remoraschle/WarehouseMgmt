using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManagerOrderPositions
    {
   
        public static List<OrderPositions> GetOrderPositions(int orderId)
        {
            using (var context = new WarehouseContext())
            {
                return context.OrderPositions.Where(x => x.OrderId == orderId).ToList();
            }
        }

        public void AddOrderPosition(int orderId, int articelId, int quantity)
        {
            using (var context = new WarehouseContext())
            {
                int countOrderPositions = context.OrderPositions.Where(x => x.OrderId == orderId && x.ArticleId == articelId).Count();
                int countArticle = context.Articles.Where(x => x.Id == articelId).Count();

                if (countOrderPositions == 0 && orderId != 0 && countArticle > 0)
                {
                    var orderPositions = new OrderPositions()
                    {
                        ArticleId = articelId,
                        OrderId = orderId,
                        Quantity = quantity

                    };


                    context.OrderPositions.Add(orderPositions);
                    context.SaveChanges();
                }
                
            }
        }


        public bool EditOrderPosition(OrderPositions orderPositionChanges)
        {
            using (var context = new WarehouseContext())
            {
                var orderPosition = context.OrderPositions.Where(x => x.OrderId == orderPositionChanges.OrderId && x.ArticleId == orderPositionChanges.ArticleId).FirstOrDefault();

                if (orderPosition != null)
                {
                    orderPosition.Quantity = orderPositionChanges.Quantity;

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
                else
                {
                    return false;
                }
            }
        }

        public bool DeleteOrderPosition(OrderPositions orderPositionToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var orderPosition = context.OrderPositions.Where(x => x.OrderId == orderPositionToDelete.OrderId && x.ArticleId == orderPositionToDelete.ArticleId).FirstOrDefault();

                if (orderPosition != null)
                {


                    context.OrderPositions.Remove(orderPosition);

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
                else
                {
                    return false;
                }
            }
        }
    }
}

