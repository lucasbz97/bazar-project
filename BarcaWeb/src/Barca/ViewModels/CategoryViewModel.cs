using System.ComponentModel.DataAnnotations;

namespace Barca.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O Campo precisar ter entre {2} e {1} caracteres0", MinimumLength = 2)]
        public string Name { get; set; }

        public IEnumerable<ProductViewModel>? Products { get; set; }
    }
}
