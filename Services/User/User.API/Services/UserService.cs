using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.API.Services.Abstracts;
using User.Data.Repositories.Abstracts;
using User.Model;

namespace User.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> GetUserByUserIdAsync(Guid userId)
        {
            return await _userRepository.GetUserByUserIdAsync(userId);
        }

        public async Task<UserModel> CreateUserAsync(string userName)
        {
            return await _userRepository.CreateUserAsync(userName);
        }
    }
}
