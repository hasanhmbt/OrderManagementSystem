using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entities
{
    public class Product : BaseEntities
    {

        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime AddDate { get; set; }



    }
}
