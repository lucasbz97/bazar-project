using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Dev.Business.Interfaces;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        public PaymentService(INotificador noficador) : base(noficador)
        {
        }

        public void Dispose()
        {
        }

        public async Task<dynamic> PayCredit(Payment payment)
        {
            try 
            {
                StripeConfiguration.ApiKey = "https://dashboard.stripe.com/test/payments";

                var optionToken = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = payment.CardNumber,
                        Cvc = payment.Cvc,
                        ExpMonth = payment.Mounth,
                        ExpYear = payment.Year,
                    }
                };

                var tokenService = new TokenService();
                var stripToken = await tokenService.CreateAsync(optionToken);

                var options = new ChargeCreateOptions
                {
                    Amount = (long) payment.Amount,
                    Currency = "brl",
                    Description = "Playstation 5 da feira",
                    Source = stripToken.Id,
                };

                var chargeService = new ChargeService();
                Charge charge = await chargeService.CreateAsync(options);

                if (charge.Paid)
                {
                    return "Deu Bom";
                }
                else
                {
                    return "Deu ruim";
                }
            }
            catch 
            {
                return "Deu ruim demais";
            }
        }
    }
}
