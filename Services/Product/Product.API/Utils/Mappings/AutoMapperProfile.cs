using AutoMapper;
using Product.Model.ResponseModels;

namespace Product.API.Utils.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Models.Product, ProductModel>();
        }
    }
}
