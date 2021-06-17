using System;
using System.Threading.Tasks;
using User.Model;

namespace User.Data.Repositories.Abstracts
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByUserIdAsync(Guid userId);

        Task<UserModel> CreateUserAsync(string userName);
    }
}
