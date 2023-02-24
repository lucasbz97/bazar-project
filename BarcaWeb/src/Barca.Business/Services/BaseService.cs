using Barca.Business.Models;
using Dev.Business.Interfaces;
using Dev.Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        public BaseService(INotificador noficador)
        {
            _notificador = noficador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);
            return false;
        }

        protected bool ExecutarValidacaoByContext<TV, TE>(TV validacao, IEnumerable<TE> entidades) where TV : AbstractValidator<TE> where TE : Entity
        {
            foreach (var entidade in entidades)
            {
                var validator = validacao.Validate(entidade);

                if (!validator.IsValid)
                {

                    Notificar(validator);
                    return false;
                }
            }

            return true;
        }
    }
}
