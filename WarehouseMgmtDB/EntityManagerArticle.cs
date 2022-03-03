using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManagerArticle
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

        public static List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public static Article GetFirstArticle(int id)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Id == id).FirstOrDefault();
            }
        }

        public static Article GetFirstArticle(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Name == name).FirstOrDefault();
            }
        }

        public static List<Article> GetAllArticle()
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.ToList();
            }
        }
        public static List<Article> GetAllArticle(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.Articles.Where(x => x.Name.Contains(name)).ToList();
            }
        }

        public string GetArticleGroupName(int articleGroupId)
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.Where(x => x.Id == articleGroupId).Select(x => x.Name).FirstOrDefault();
            }
        }


        public int AddArticle(string name, decimal price, int articleGroupId)
        {
            using (var context = new WarehouseContext())
            {
                int articleGroupCount = context.ArticleGroups.Where(x => x.Id == articleGroupId).Count();

                var articlegroup = new ArticleGroup();
                if (articleGroupCount > 0)
                {
                    articlegroup = context.ArticleGroups.Where(x => x.Id == articleGroupId).FirstOrDefault();
                }

                var article = new Article()
                {
                    Name = name,
                    Price = price,
                    ArticleGroup = articlegroup
                };


                context.Articles.Add(article);
                context.SaveChanges();

                return article.Id;
            }
        }

        public bool EditArticle(Article articleChanges)
        {
            using (var context = new WarehouseContext())
            {
                var article = context.Articles.Where(x => x.Id == articleChanges.Id).FirstOrDefault();

                article.Name = articleChanges.Name;
                article.Price = articleChanges.Price;
                //article.ArticleGroup = articleChanges.ArticleGroup;
                article.ArticleGroupId = articleChanges.ArticleGroupId;

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

        public bool DeleteArticle(Article articleToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var article = context.Articles.Where(x => x.Id == articleToDelete.Id).FirstOrDefault();

                context.Articles.Remove(article);

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

