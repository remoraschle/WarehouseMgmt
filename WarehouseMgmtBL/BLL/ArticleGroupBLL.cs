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
    public class ArticleGroupBLL : ArticleGroup
    {
        public int? SearchArticleGroupNumber { get; set; }
        public string SearchArticleGroupName { get; set; }

        public string ArticleGroupParentName { get; set; }
        public string ArticleGroupTree { get; set; }


        /// <summary>
        /// returns all articleGroups
        /// </summary>
        public List<ArticleGroupBLL> GetArticleGroups(int? id, string name)
        {
            List<ArticleGroup> articleGroup = new List<ArticleGroup>();

            if (id != null && name == null)
            {
                ArticleGroup firstArticleGroup = EntityManagerArticleGroup.GetFirstArticleGroup((int)id);
                if (firstArticleGroup != null)
                {
                    articleGroup.Add(firstArticleGroup);
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
                        articleGroup = EntityManagerArticleGroup.GetAllArticleGroup();
                    }
                    else
                    {
                        articleGroup = EntityManagerArticleGroup.GetAllArticleGroup(name);
                    }
                }
                else
                {
                    articleGroup = EntityManagerArticleGroup.GetAllArticleGroup();
                }
            }


            return ConvertArticleGroupToBLL(articleGroup);



        }

        private static List<ArticleGroupBLL> ConvertArticleGroupToBLL(List<ArticleGroup> articleGroup)
        {
            List<ArticleGroupBLL> list = new List<ArticleGroupBLL>();

            foreach (var v in articleGroup)
            {
                ArticleGroupBLL articleGroupBLL = new ArticleGroupBLL();
                articleGroupBLL.Id = v.Id;
                articleGroupBLL.Name = v.Name;
                articleGroupBLL.ArticleGroupParentId = v.ArticleGroupParentId;

                list.Add(articleGroupBLL);
            }

            return list;
        }



        /// <summary>
        /// returns the articleGroup with the specifed articleGroup id
        /// </summary>
        /// <param name="id"></param>
        public ArticleGroupBLL  GetArticleGroupByArticleGroupID(int id)
        {
            return (ArticleGroupBLL)EntityManagerArticleGroup.GetFirstArticleGroup(id);
        }



        /// <summary>
        /// returns all articleGroups with ArticleGroupname like name
        /// </summary>
        /// <param name="name"></param>
        public ArticleGroupBLL GetArticleGroupByArticleGroupName(string name)
        {
            return (ArticleGroupBLL)EntityManagerArticleGroup.GetFirstArticleGroup(name);
        }




        ///// <summary>
        ///// returns all articleGroups with the ArticleGroupGroupId
        ///// </summary>
        ///// <param name="articleGroupGroupId"></param>
        //public ArticleGroup GetArticleGroupByArticleGroupGroupId(int articleGroupGroupId)
        //{
        //    return EntityManager.GetArticleGroup();
        //}


        /// <summary>
        /// inserts a new articleGroup into the databse using the values passed-in; returns the ArticleGroup id of the newly inserted record
        /// </summary>
        public int AddArticleGroup(string name, int? articleGroupParentId)
        {
            EntityManagerArticleGroup entity = new EntityManagerArticleGroup();
            return entity.AddArticleGroup(name, articleGroupParentId);
        }


        /// <summary>
        /// inserts a new articleGroup into the databse using the values passed-in; returns the ArticleGroup id of the newly inserted record
        /// </summary>
        public bool EditArticleGroup(ArticleGroupBLL articleGroup)
        {
            EntityManagerArticleGroup entity = new EntityManagerArticleGroup();
            return entity.EditArticleGroup(articleGroup);
        }


        /// <summary>
        /// inserts a new articleGroup into the databse using the values passed-in; returns the ArticleGroup id of the newly inserted record
        /// </summary>
        public bool DeleteArticleGroup(ArticleGroupBLL articleGroup)
        {
            EntityManagerArticleGroup entity = new EntityManagerArticleGroup();
            return entity.DeleteArticleGroup(articleGroup);
        }

        public static List<ArticleGroupBLL> GetArticleGroupTree()
        {
            List<ArticleGroupBLL> articleGroupBLLs = ConvertArticleGroupToBLL(EntityManagerArticleGroup.GetAllParentArticleGroup());

            foreach (var item in articleGroupBLLs)
            {
                EntityManagerArticleGroup emag = new EntityManagerArticleGroup();
                item.ArticleGroupTree = emag.GetArticleGroupTree(item.Id);
            }


            return articleGroupBLLs;
        }
    }
}
