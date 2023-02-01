using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entities
{
    public class Sale : BaseEntities
    {

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int SaleCount { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ProductPrice { get; set; }
        public int  Remainder { get; set; }
        public DateTime SaleDate { get; set; }

    }
}
