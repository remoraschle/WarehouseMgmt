using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB.Model
{
    public class OrderPositions
    {
        public int Id { get; set; }

        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }
        public int Quantity { get; set; }

    }
}
