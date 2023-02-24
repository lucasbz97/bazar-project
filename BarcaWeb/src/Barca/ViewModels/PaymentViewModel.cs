using Barca.Business.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Barca.ViewModels
{
    public class PaymentViewModel
    {
        [Key]
        public Guid ID { get; set; }
        public string Description { get; set; }
        public TypePayment TypePayment { get; set; }
        public double Amount { get; set; }
        public string CardNumber { get; set; }
        public int Mounth { get; set; }
        public int Year { get; set; }
        public string Cvc { get; set; }
        public string Value { get; set; }

    }
}
