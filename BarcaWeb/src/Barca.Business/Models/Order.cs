using Barca.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class Order : Entity
    {
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public StatusOrder Status { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Guid ProductID { get; set; }
        public User User { get; set; }
        public double TotalPrice { get; set; }
        public Payment Payment { get; set; }
    }
}
