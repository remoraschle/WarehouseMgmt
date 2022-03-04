using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseMgmtDB.Model
{
    public class Orders
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
     
        public virtual List<OrderPositions> OrderPositions { get; set; }
        //public int? OrderPositionsId { get; set; }
    }
}
