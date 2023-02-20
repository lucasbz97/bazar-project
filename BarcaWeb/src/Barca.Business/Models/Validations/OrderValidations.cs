using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models.Validations
{
    public class OrderValidations : AbstractValidator<Order>
    {
        public OrderValidations() {

            RuleFor(t => t.Products).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
