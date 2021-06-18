using System;
using System.Threading.Tasks;
using User.Model.RequestModels;

namespace User.Data.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<Models.User> GetUserByUserIdAsync(Guid userId);

        Task<Models.User> CreateUserAsync(AddUserModel addUserModel);
    }
}
