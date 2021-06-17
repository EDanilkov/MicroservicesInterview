using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Model;

namespace User.API.Services.Abstracts
{
    public interface IUserService
    {
        Task<UserModel> GetUserByUserIdAsync(Guid userId);

        Task<UserModel> CreateUserAsync(string userName);
    }
}
