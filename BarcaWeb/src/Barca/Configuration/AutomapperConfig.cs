using AutoMapper;
using Barca.Business.Models;
using Barca.ViewModels;

namespace Barca.Configuration
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
