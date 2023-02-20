using ApiMyTask.Controllers;
using AutoMapper;
using Barca.Business.Interfaces;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.Business.Services;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Barca.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, ICategoryService categoryService, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> ObterTodos()
        {
            IEnumerable<CategoryViewModel> task = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());
            
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Adicionar(CategoryViewModel taskViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = _mapper.Map<Category>(taskViewModel);
            await _categoryService.Adicionar(task);

            return CustomResponse(taskViewModel);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryViewModel>> Deletar(CategoryViewModel taskViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var task = _mapper.Map<Category>(taskViewModel);
            await _categoryService.Deletar(task);

            return CustomResponse(taskViewModel);
        }
    }
}
