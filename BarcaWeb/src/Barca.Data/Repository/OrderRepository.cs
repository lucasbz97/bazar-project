using Barca.Business.Interfaces.IRepository;
using Barca.Business.Models;
using Dev.Business.Interfaces;
using Dev.Data.Context;
using Dev.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Data.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(EfContext efContext) : base(efContext) { }
    }
}
