using Barca.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Interfaces.IService
{
    public interface IProductService : IDisposable
    {
        Task Adicionar(Product product);

        Task Atualizar(Product product);
        Task<IEnumerable<object>> ObterProdutosPorCategoria(Guid id);
        Task Remover(Product product);
    }
}
