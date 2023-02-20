using Barca.Business.Interfaces.IRepository;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.Business.Models.Validations;
using Dev.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository, INotificador notificador) : base(notificador)
        {
            _orderRepository= orderRepository;
        }
        public async Task Adicionar(Order order)
        {
            if (!ExecutarValidacao(new OrderValidations(), order))
            {
                return;
            }

            await _orderRepository.Add(order);
        }
        public async Task Atualizar(Order order)
        {
            if (!ExecutarValidacao(new OrderValidations(), order))
            {
                return;
            }

            await _orderRepository.Update(order);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
