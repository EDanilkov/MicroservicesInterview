using System;
using System.Threading.Tasks;
using User.Model.RequestModels;
using User.Model.ResponseModels;

namespace User.API.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserModel> GetUserByUserIdAsync(Guid userId);

        Task<UserModel> CreateUserAsync(AddUserModel addUserModel);
    }
}
