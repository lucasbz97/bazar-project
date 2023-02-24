using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public IEnumerable<Order> Orders { get; set; }

    }
}
