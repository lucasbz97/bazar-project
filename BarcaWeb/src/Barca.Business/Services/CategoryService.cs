using Barca.Business.Interfaces;
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
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, INotificador notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Adicionar(Category category)
        {
            if (!ExecutarValidacao(new CategoryValidations(), category))
            {
                return;
            }

            await _categoryRepository.Add(category);
        }

        public async Task Deletar(Category category) {
            if (!ExecutarValidacao(new CategoryValidations(), category))
            {
                return;
            }

            await _categoryRepository.Delete(category);
        }

        public async Task Atualizar(Category category)
        {
            if (!ExecutarValidacao(new CategoryValidations(), category))
            {
                return;
            }

            await _categoryRepository.Update(category);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}
