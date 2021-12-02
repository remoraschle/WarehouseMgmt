using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB.Model
{
    public class ArticleGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ArticleGroupParentId { get; set; }
        public virtual ArticleGroup ParentArticleGroup { get; set; }
        public virtual ICollection<ArticleGroup> subGroups { get; set; }


    }
}
