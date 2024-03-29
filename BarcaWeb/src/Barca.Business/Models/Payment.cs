﻿using Barca.Business.Models.Enums;
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
        public double Amount { get; set; }
        public string CardNumber { get; set; }
        public string Mounth { get; set; }
        public string Year { get; set; }
        public string Cvc { get; set; }
        public string Value { get; set; }
    }
}
