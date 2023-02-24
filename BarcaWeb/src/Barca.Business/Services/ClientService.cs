using Barca.Business.Interfaces.IRepository;
using Barca.Business.Interfaces.IService;
using Dev.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Services
{
    public class ClientService : BaseService, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository, INotificador notificador) : base(notificador)
        {
            _clientRepository = clientRepository;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
