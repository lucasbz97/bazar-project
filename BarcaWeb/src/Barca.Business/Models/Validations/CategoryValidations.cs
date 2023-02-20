using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models.Validations
{
    public class CategoryValidations : AbstractValidator<Category>
    {
        public CategoryValidations() {
            RuleFor(c => c.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido");
        }
    }
}
