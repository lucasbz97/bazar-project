using ApiMyTask.Controllers;
using AutoMapper;
using Barca.Business.Interfaces;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.Business.Services;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;
using System.Reflection.Metadata;

namespace Barca.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryService categoryService, IProductService productService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> ObterTodos()
        {
            IEnumerable<CategoryViewModel> task = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());
            
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Adicionar(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryService.Adicionar(category);

            return CustomResponse(categoryViewModel);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryViewModel>> Deletar(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryService.Deletar(category);

            return CustomResponse(categoryViewModel);
        }

        [HttpPut]
        public async Task<ActionResult<CategoryViewModel>> Atualizar(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryViewModel);
            await _categoryService.Atualizar(category);

            return CustomResponse(categoryViewModel);
        }

        [HttpGet("withProducts/{limit}")]
        public async Task<IEnumerable<CategoryViewModel>> GetGetgoryWithProducts([FromRoute] int limit)
        {
            IEnumerable<CategoryViewModel> task = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());

            foreach (CategoryViewModel category in task)
            {
                category.Products = _mapper.Map<IEnumerable<ProductViewModel>>(await _productService.ObterProdutosPorCategoria(category.Id, limit));
            }

            return task;
        }
    }
}
