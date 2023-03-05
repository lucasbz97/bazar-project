using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Models.Validations
{
    internal class ClientValidations: AbstractValidator<Client>
    {
        public ClientValidations()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(t => t.Email).NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
        }
    }
}
