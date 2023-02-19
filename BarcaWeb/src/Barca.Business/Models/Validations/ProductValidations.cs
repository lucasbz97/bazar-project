using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models.Validations
{
    public class ProductValidations : AbstractValidator<Product>
    {
        public ProductValidations()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(t => t.Price).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(t => t.CategoryID).NotEmpty().WithMessage("Produto precisa estar em alguma categoria");
        }
    }
}
