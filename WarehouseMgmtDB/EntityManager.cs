using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManager
    {
        public static List<Article> GetArticle()
        {
            using (var context = new WarehouseContext())
            {
                var sqlvalues = context.Articles.Select(x=>x);

                List<Article> articleList = new List<Article>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {
                        using (var context2 = new WarehouseContext())
                        {
                            item.ArticleGroup = context2.ArticleGroups.Where(x => x.Id == item.ArticleGroupId).FirstOrDefault(); //todooooo
                        }
                            
                        articleList.Add(item);
                    }
                }

                return articleList;
            }
        }
        public static Article GetArticle(int id)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static Article GetArticle(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Name == name).FirstOrDefault();
            }
        }


        public int AddArticle(string name, decimal price)
        {
            using (var context = new WarehouseContext())
            {
                var articlegroup1 = new ArticleGroup()
                {
                    Name = "ArticleGroup1"
                };

                var article1 = new Article()
                {
                    Name = name,
                    Price = price,
                    ArticleGroup = articlegroup1
                };


                context.Articles.Add(article1);
                context.SaveChanges();

                return article1.Id;
            }
        }
    }
}

