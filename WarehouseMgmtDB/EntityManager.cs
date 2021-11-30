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

