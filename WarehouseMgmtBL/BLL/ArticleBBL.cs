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
        /// <summary>
        /// returns all articles
        /// </summary>
        public List<Article> GetArticles()
        {
            return EntityManager.GetArticle();
        }

        /// <summary>
        /// returns the article with the specifed article id
        /// </summary>
        /// <param name="id"></param>
        public Article GetArticleByArticleID(int id)
        {
            return EntityManager.GetArticle(id);
        }

        /// <summary>
        /// returns all articles with Articlename like name
        /// </summary>
        /// <param name="name"></param>
        public Article GetArticleByArticleName(string name)
        {
            return EntityManager.GetArticle(name);
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

    }
}
