using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using User.Data.Context;
using User.Data.Repositories.Abstracts;
using User.Model.RequestModels;

namespace User.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<Models.User> GetUserByUserIdAsync(Guid userId)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<Models.User> CreateUserAsync(AddUserModel addUserModel)
        {
            var user = new Models.User()
            {
                Name = addUserModel.Name,
                Surname = addUserModel.Surname,
                CreationDate = DateTime.Now
            };
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
            return user;
        }
    }
}
