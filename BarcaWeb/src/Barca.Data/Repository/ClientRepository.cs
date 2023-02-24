using Barca.Business.Interfaces.IRepository;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Dev.Data.Context;
using Dev.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Data.Repository
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(EfContext efContext) : base(efContext) { }
    }
}
