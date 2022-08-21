using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entities
{
    public class Product:BaseEntity
    {
        public int Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}
