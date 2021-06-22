using Moq;
using User.API.Services.Abstracts;

namespace User.Tests.Mock
{
    public class UserFakeService
    {
        public Mock<IUserService> Mock;
        public IUserService Service;

        public UserFakeService()
        {
            Mock = new Mock<IUserService>();

            Service = Mock.Object;
        }
    }
}
