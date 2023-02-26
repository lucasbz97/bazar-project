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
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, INotificador notificador) : base(notificador)
        {
            _productRepository = productRepository;
        }
        public async Task Adicionar(Product product)
        {
            if (!ExecutarValidacao(new ProductValidations(), product))
            {
                return;
            }

            await _productRepository.Add(product);
        }

        public async Task Atualizar(Product product)
        {
            await _productRepository.Update(product);
        }

        public async Task Remover(Product product)
        {
            await _productRepository.Delete(product);
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
