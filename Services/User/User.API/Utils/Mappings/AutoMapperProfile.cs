using AutoMapper;
using User.Model.ResponseModels;

namespace User.API.Utils.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Models.User, UserModel>();
        }
    }
}
