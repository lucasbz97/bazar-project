using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class Product: Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Guid CategoryID { get; set; }
        public string Images { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
