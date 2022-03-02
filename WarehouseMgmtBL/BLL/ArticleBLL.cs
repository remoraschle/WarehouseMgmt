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
    public class ArticleBLL : Article
    {
        public string ArticleGroupName { get; set; }
        public int? SearchArticleNumber { get; set; }
        public string SearchArticleName { get; set; }



        /// <summary>
        /// returns all articles
        /// </summary>
        public List<ArticleBLL> GetArticles(int? id, string name)
        {
            List<Article> article = new List<Article>();

            if (id != null && name == null)
            {
                Article firstArticle = EntityManager.GetFirstArticle((int)id);
                if (firstArticle != null)
                {
                    article.Add(firstArticle);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (name != null)
                {
                    if (name.Trim() == "")
                    {
                        article = EntityManager.GetAllArticle();
                    }
                    else
                    {
                        article = EntityManager.GetAllArticle(name);
                    }
                }
                else
                {
                    article = EntityManager.GetAllArticle();
                }
            }
               
            

            List<ArticleBLL> list = new List<ArticleBLL>();

            foreach (var v in article)
            {
                ArticleBLL articleBLL = new ArticleBLL();
                articleBLL.Id = v.Id;
                articleBLL.Name = v.Name;
                articleBLL.Price = v.Price;
                articleBLL.ArticleGroupId = v.ArticleGroupId;
                articleBLL.ArticleGroupName = "Test"; //v.ArticleGroup.Name; // TODO

                list.Add(articleBLL);
            }

            return list;

        }



        /// <summary>
        /// returns the article with the specifed article id
        /// </summary>
        /// <param name="id"></param>
        public ArticleBLL GetArticleByArticleID(int id)
        {
            return (ArticleBLL)EntityManager.GetFirstArticle(id);
        }

       

        /// <summary>
        /// returns all articles with Articlename like name
        /// </summary>
        /// <param name="name"></param>
        public ArticleBLL GetArticleByArticleName(string name)
        {
            return (ArticleBLL)EntityManager.GetFirstArticle(name);
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


        /// <summary>
        /// inserts a new article into the databse using the values passed-in; returns the Article id of the newly inserted record
        /// </summary>
        public bool EditArticle(ArticleBLL article)
        {
            EntityManager entity = new EntityManager();
            return entity.EditArticle(article);
        }


        /// <summary>
        /// inserts a new article into the databse using the values passed-in; returns the Article id of the newly inserted record
        /// </summary>
        public bool DeleteArticle(ArticleBLL article)
        {
            EntityManager entity = new EntityManager();
            return entity.DeleteArticle(article);
        }


        //public static explicit operator ArticleBLL(Article v)
        //{
        //    ArticleBLL articleBBL = new ArticleBLL();
        //    articleBBL.Id = v.Id;
        //    articleBBL.Name = v.Name;
        //    articleBBL.Price = v.Price;
        //    articleBBL.ArticleGroupId = v.ArticleGroupId;
        //    articleBBL.ArticleGroupName = v.ArticleGroup.Name;

        //    return articleBBL;
        //}


    }
}
