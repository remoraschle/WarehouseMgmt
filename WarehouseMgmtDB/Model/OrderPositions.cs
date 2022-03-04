using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB.Model
{
    public class OrderPositions
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ArticleId { get; set; }



        [ForeignKey("OrderId")]
        public virtual Orders Orders { get; set; }

        [ForeignKey("ArticleId")]
        public virtual Article Article { get; set; }


        public int Quantity { get; set; }

    }
}
