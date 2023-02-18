using Barca.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class Payment: Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePayment TypePayment { get; set; }
    }
}
