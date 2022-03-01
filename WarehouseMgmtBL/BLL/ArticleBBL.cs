using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtBL
{
    public class ArticleBBL
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ArticleGroupId { get; set; }
        public string ArticleGroupName { get; set; }

        /// <summary>
        /// returns all articles
        /// </summary>
        public List<ArticleBBL> GetArticles()
        {
            List<Article> article =  EntityManager.GetArticle();

            List<ArticleBBL> list = new List<ArticleBBL>();

            foreach (var v in article)
            {
                ArticleBBL articleBBL = new ArticleBBL();
                articleBBL.Id = v.Id;
                articleBBL.Name = v.Name;
                articleBBL.Price = v.Price;
                articleBBL.ArticleGroupId = v.ArticleGroupId;
                articleBBL.ArticleGroupName = "Test"; //v.ArticleGroup.Name; // TODO

                list.Add(articleBBL);
            }

            return list;

        }

        /// <summary>
        /// returns the article with the specifed article id
        /// </summary>
        /// <param name="id"></param>
        public ArticleBBL GetArticleByArticleID(int id)
        {
            return (ArticleBBL)EntityManager.GetArticle(id);
        }

       

        /// <summary>
        /// returns all articles with Articlename like name
        /// </summary>
        /// <param name="name"></param>
        public ArticleBBL GetArticleByArticleName(string name)
        {
            return (ArticleBBL)EntityManager.GetArticle(name);
        }

        ///// <summary>
        ///// returns all articles with the ArticleGroupId
        ///// </summary>
        ///// <param name="articleGroupId"></param>
        //public Article GetArticleByArticleGroupId(int articleGroupId)
        //{
        //    return EntityManager.GetArticle();
        //}


        /// <summary>
        /// inserts a new article into the databse using the values passed-in; returns the Article id of the newly inserted record
        /// </summary>
        public int AddArticle(string name, decimal price)
        {
            EntityManager entity = new EntityManager();
            return entity.AddArticle(name, price);
        }


        public static explicit operator ArticleBBL(Article v)
        {
            ArticleBBL articleBBL = new ArticleBBL();
            articleBBL.Id = v.Id;
            articleBBL.Name = v.Name;
            articleBBL.Price = v.Price;
            articleBBL.ArticleGroupId = v.ArticleGroupId;
            articleBBL.ArticleGroupName = v.ArticleGroup.Name;

            return articleBBL;
        }


    }
}
