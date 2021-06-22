using Moq;
using User.Data.Repositories.Abstracts;

namespace User.Tests.Mock
{
    public class UserFakeRepository
    {
        public Mock<IUserRepository> Mock;
        public IUserRepository Repository;

        public UserFakeRepository()
        {
            Mock = new Mock<IUserRepository>();

            Repository = Mock.Object;
        }
    }
}
