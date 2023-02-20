using Barca.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Interfaces.IService
{
    public interface IOrderService : IDisposable
    {
        Task Adicionar(Order order);

        Task Atualizar(Order order);
    }
}
