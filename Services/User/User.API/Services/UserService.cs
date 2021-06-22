using AutoMapper;
using System;
using System.Threading.Tasks;
using User.API.Services.Abstracts;
using User.Data.Repositories.Abstracts;
using User.Model.RequestModels;
using User.Model.ResponseModels;

namespace User.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserModel> GetUserByUserIdAsync(Guid userId)
        {
            var result = await _userRepository.GetUserByUserIdAsync(userId);

            if (result == null) 
            {
                throw new ArgumentException($"Not found user with userId: {userId}");
            }

            return _mapper.Map<UserModel>(result);
        }

        public async Task<UserModel> CreateUserAsync(AddUserModel addUserModel)
        {
            if (addUserModel == null)
            {
                throw new ArgumentNullException(nameof(addUserModel));
            }

            var result = await _userRepository.CreateUserAsync(addUserModel);

            return _mapper.Map<UserModel>(result);
        }
    }
}
