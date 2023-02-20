using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models
{
    public class CreditInfo
    {
        public string Number { get; set; }
        public string FullName { get; set; }
        public string Validate { get; set; }
        public string Code { get; set; }
        public int Installment { get; set; }
        public string HolderCpf { get; set; }
    }
}
