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

        string searchArticleNumberString;
        public string SearchArticleNumberString
        {
            get => searchArticleNumberString;
            set
            {
                if (searchArticleNumberString != value)
                {
                    searchArticleNumberString = value;

                    int number;
                    bool check = int.TryParse(value, out number);
                    if (check)
                    {
                        SearchArticleNumber = number;
                    }
                    else
                    {
                        SearchArticleNumber = null;
                    }
                }
            }
        }

        public string SearchArticleName { get; set; }
        public bool SetChange { get; set; }



        /// <summary>
        /// returns all articles
        /// </summary>
        public List<ArticleBLL> GetArticles(int? id, string name)
        {
            List<Article> article = new List<Article>();

            if (id != null && name == null)
            {
                Article firstArticle = EntityManagerArticle.GetFirstArticle((int)id);
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
                        article = EntityManagerArticle.GetAllArticle();
                    }
                    else
                    {
                        article = EntityManagerArticle.GetAllArticle(name);
                    }
                }
                else
                {
                    article = EntityManagerArticle.GetAllArticle();
                }
            }
               
            

            List<ArticleBLL> list = new List<ArticleBLL>();
            EntityManagerArticle entityManagerArticle = new EntityManagerArticle();

            foreach (var v in article)
            {
                ArticleBLL articleBLL = new ArticleBLL();
                articleBLL.Id = v.Id;
                articleBLL.Name = v.Name;
                articleBLL.Price = v.Price;
                articleBLL.ArticleGroupId = v.ArticleGroupId;

                
                articleBLL.ArticleGroupName = entityManagerArticle.GetArticleGroupName(articleBLL.ArticleGroupId);//v.ArticleGroup.Name; --> Not possible because of Lazy loading

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
            return (ArticleBLL)EntityManagerArticle.GetFirstArticle(id);
        }

       

        /// <summary>
        /// returns all articles with Articlename like name
        /// </summary>
        /// <param name="name"></param>
        public ArticleBLL GetArticleByArticleName(string name)
        {
            return (ArticleBLL)EntityManagerArticle.GetFirstArticle(name);
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
            EntityManagerArticle entity = new EntityManagerArticle();
            return entity.AddArticle(name, price);
        }


        /// <summary>
        /// inserts a new article into the databse using the values passed-in; returns the Article id of the newly inserted record
        /// </summary>
        public bool EditArticle(ArticleBLL article)
        {
            EntityManagerArticle entity = new EntityManagerArticle();
            return entity.EditArticle(article);
        }


        /// <summary>
        /// inserts a new article into the databse using the values passed-in; returns the Article id of the newly inserted record
        /// </summary>
        public bool DeleteArticle(ArticleBLL article)
        {
            EntityManagerArticle entity = new EntityManagerArticle();
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
