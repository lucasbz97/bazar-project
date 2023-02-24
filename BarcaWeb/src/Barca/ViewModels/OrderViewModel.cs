using Barca.Business.Models;
using Barca.Business.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Barca.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public Guid ID { get; set; }

        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public StatusOrder Status { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public Guid UserID { get; set; }
        public Client User { get; set; }
            
    }
}
