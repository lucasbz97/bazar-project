using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class Sale: Entity
    {
        public string Description { get; set; }
        public Guid PaymentID { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public int UserID { get; set; }
        public Guid ProductID { get; set; }
    }
}
