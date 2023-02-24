using Barca.Business.Interfaces.IService;
using Dev.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barca.Business.Services
{
    public class ExternalSocialService : BaseService, IExternalSocialService
    {
        public ExternalSocialService(INotificador notificador) : base(notificador)
        {

        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
