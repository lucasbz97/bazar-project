using ApiMyTask.Controllers;
using AutoMapper;
using Barca.Business.Interfaces;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Barca.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : MainController
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository, IProductService productService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _productRepository = productRepository;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet, Authorize]
        public async Task<IEnumerable<ProductViewModel>> ObterTodos()
        {
            var tasks = _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetAll());

            return tasks;
        }

        [HttpPost]
        public async Task<ActionResult<ProductViewModel>> Adicionar(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var products = _mapper.Map<Product>(productViewModel);
            await _productService.Adicionar(products);

            return CustomResponse(productViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<ProductViewModel>> AtualizarProduto(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var products = _mapper.Map<Product>(productViewModel);
            await _productService.Atualizar(products);

            return CustomResponse(productViewModel);
        }
    }
}
