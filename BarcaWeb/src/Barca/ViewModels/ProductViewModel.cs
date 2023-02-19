using System.ComponentModel.DataAnnotations;

namespace Barca.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public string Images { get; set; }
    }
}
