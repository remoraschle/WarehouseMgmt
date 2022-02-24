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
                var sqlvalues = context.Articles;

                List<Article> articleList = new List<Article>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {
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


        public void AddArticle()
        {
            using (var context = new WarehouseContext())
            {
                var articlegroup1 = new ArticleGroup()
                {
                    Name = "ArticleGroup1"
                };

                var article1 = new Article()
                {
                    Name = "Article1",
                    ArticleGroup = articlegroup1
                };


                context.Articles.Add(article1);
                context.SaveChanges();
            }
        }
    }
}

