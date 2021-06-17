using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using User.Data.Context;
using User.Data.Repositories.Abstracts;
using User.Model;

namespace User.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<UserModel> GetUserByUserIdAsync(Guid userId)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<UserModel> CreateUserAsync(string userName)
        {
            var userDto = new UserModel()
            {
                Name = userName,
                CreationDate = new DateTime()
            };
            var newUser = await _userContext.Users.AddAsync(userDto);
            await _userContext.SaveChangesAsync();
            return newUser.Entity;
        }
    }
}
