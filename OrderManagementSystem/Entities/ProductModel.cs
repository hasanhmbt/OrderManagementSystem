using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entities
{
    internal class ProductModel:BaseEntities
    {
        public decimal Price { get; set; }
        public int Remainder { get; set; }
    }
}
