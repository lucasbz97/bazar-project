using ApiMyTask.Controllers;
using AutoMapper;
using Barca.Business.Interfaces.IRepository;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.Business.Services;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barca.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : MainController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IOrderRepository orderRepository, IMapper mapper, INotificador notificador) : base (notificador) {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderViewModel>> ObterTodos(User user)
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderRepository.
                Buscar(x => x.User.Id == user.Id));
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewModel>> Adicionar(OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var order = _mapper.Map<Order>(orderViewModel);
            await _orderService.Adicionar(order);

            return CustomResponse(orderViewModel);
        }
    }
}
