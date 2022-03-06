using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseMgmtDB.Model;

namespace WarehouseMgmtDB
{
    public class EntityManagerArticleGroup
    {
        public static List<ArticleGroup> GetArticleGroup()
        {
            using (var context = new WarehouseContext())
            {
                var sqlvalues = context.ArticleGroups.Select(x=>x);

                List<ArticleGroup> articleGroupList = new List<ArticleGroup>();

                if (sqlvalues != null)
                {
                    foreach (var item in sqlvalues)
                    {
                        articleGroupList.Add(item);
                    }
                }

                return articleGroupList;
            }
        }


        public static ArticleGroup GetFirstArticleGroup(int id)
        {
            using (var context = new WarehouseContext())
            {
                ArticleGroup test = context.ArticleGroups.Where(x => x.Id == id).FirstOrDefault();
                return test;
            }
        }

        public static ArticleGroup GetFirstArticleGroup(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.Where(x => x.Name == name).FirstOrDefault();
            }
        }

        public static List<ArticleGroup> GetAllArticleGroup()
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.ToList();
            }
        }
        public static List<ArticleGroup> GetAllArticleGroup(string name)
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.Where(x => x.Name.Contains(name)).ToList();
            }
        }

        public static List<ArticleGroup> GetAllParentArticleGroup()
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.Where(x=>x.ArticleGroupParentId == null).ToList();
            }
        }

        private string ArticleGroupTree { get; set; }
        private int ArticleGroupTreeDeep { get; set; }
        public string GetArticleGroupTree(int? id)
        {
            using (var context = new WarehouseContext())
            {
                //Parent
                ArticleGroup ag = context.ArticleGroups.Where(x => x.Id == id).FirstOrDefault();


                if (ag != null)
                {
                    ArticleGroupTreeDeep++;
                    string deep = "";
                    for (int i = 0; i < ArticleGroupTreeDeep; i++)
                    {
                        deep += "    ";
                    }
                    ArticleGroupTree += ag.Name + deep + Environment.NewLine;

                    var childsCount = context.ArticleGroups.Where(x => x.ArticleGroupParentId == ag.Id).FirstOrDefault();

                    if (childsCount != null)
                    {

                        var childs = context.ArticleGroups.Where(x => x.ArticleGroupParentId == ag.Id);

                        foreach (var item in childs)
                        {
                            GetArticleGroupTree(item.Id);
                        }
                    }


                }
                
                return ArticleGroupTree;
            }
        }

        /// <summary>
        /// If there is no ParentGroup, then articleGroupParentId shoud be NULL
        /// </summary>
        /// <param name="name"></param>
        /// <param name="articleGroupParentId"></param>
        /// <returns></returns>
        public int AddArticleGroup(string name, int? articleGroupParentId)
        {
            using (var context = new WarehouseContext())
            {
                var articleGroup = new ArticleGroup()
                {
                    Name = name,
                    ArticleGroupParentId = articleGroupParentId
                };


                context.ArticleGroups.Add(articleGroup);
                context.SaveChanges();

                return articleGroup.Id;
            }
        }

        public bool EditArticleGroup(ArticleGroup articleGroupChanges)
        {
            using (var context = new WarehouseContext())
            {
                var articleGroup = context.ArticleGroups.Where(x => x.Id == articleGroupChanges.Id).FirstOrDefault();

                articleGroup.Name = articleGroupChanges.Name;

                int countParents = context.ArticleGroups.Where(x => x.Id == articleGroupChanges.ArticleGroupParentId).Count();
                if (countParents > 0)
                {
                    articleGroup.ArticleGroupParentId = articleGroupChanges.ArticleGroupParentId;
                }

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

        public bool DeleteArticleGroup(ArticleGroup articleGroupToDelete)
        {
            using (var context = new WarehouseContext())
            {
                var articleGroup = context.ArticleGroups.Where(x => x.Id == articleGroupToDelete.Id).FirstOrDefault();

                if (articleGroup != null)
                {
                    bool removedAllChild = true;
                    var childs = GetAllChildArticleGroups(articleGroup);
                    if (childs.Count() > 0)
                    {
                        foreach (var child in childs)
                        {
                            removedAllChild = DeleteParentReferenz(child);
                        }
                    }

                    if (removedAllChild == true)
                    {
                        context.ArticleGroups.Remove(articleGroup);

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
                else
                {
                    return false;
                }
                
            }
        }

        public List<ArticleGroup> GetAllChildArticleGroups(ArticleGroup articleGroupParent)
        {
            using (var context = new WarehouseContext())
            {
                return context.ArticleGroups.Where(x => x.ArticleGroupParentId == articleGroupParent.Id).ToList();
            }
        }

        public bool DeleteParentReferenz(ArticleGroup articleGroupChild)
        {
            using (var context = new WarehouseContext())
            {
                var articleGroup = context.ArticleGroups.Where(x => x.Id == articleGroupChild.Id).FirstOrDefault();

                if (articleGroup != null)
                {
                    articleGroup.ArticleGroupParentId = null;

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

