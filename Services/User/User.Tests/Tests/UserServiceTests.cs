using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using User.API.Services;
using User.API.Utils.Mappings;
using User.Model.RequestModels;
using User.Tests.Mock;

namespace User.Tests.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly IMapper _mapper;
        public UserServiceTests()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            _mapper = mappingConfig.CreateMapper();
        }

        [TestMethod]
        public async Task GetUserByUserIdAsync_ValidUserId_ShouldReturnUserModel()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;

            UserFakeRepository repository = new UserFakeRepository();
            repository.Mock.Setup(s => s.GetUserByUserIdAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(new Data.Models.User()
                {
                    UserId = validGuid,
                    Name = "Egor",
                    Surname = "Danilkov",
                    CreationDate = сreationDate
                }));

            UserService service = new UserService(repository.Repository, _mapper);

            var user = await service.GetUserByUserIdAsync(validGuid);

            Assert.IsNotNull(user);
            Assert.AreEqual("Danilkov", user.Surname);
            Assert.AreEqual("Egor", user.Name);
            Assert.AreEqual(сreationDate, user.CreationDate);
            Assert.AreEqual(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), user.UserId);
        }

        [TestMethod]
        public async Task GetUserByUserIdAsync_InvalidUserId_ShouldThrowArgumentException()
        {
            Guid invalidGuid = new Guid("c56a4280-65aa-42ec-a945-5fd21dec0538");
            var mockDbSet = new Mock<Data.Models.User>();

            // Arrange
            var fakeRepository = new UserFakeRepository();
            fakeRepository.Mock.Setup(s => s.GetUserByUserIdAsync(invalidGuid))
                .Returns(Task.FromResult(null as Data.Models.User));

            UserService service = new UserService(fakeRepository.Repository, _mapper);

            // Act
            try
            {
                var response = await service.GetUserByUserIdAsync(invalidGuid);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Not found user with userId: c56a4280-65aa-42ec-a945-5fd21dec0538", ex.Message);
            }
        }

        [TestMethod]
        public async Task GetUserByUserIdAsync_ServiceReturnsUser_ShouldThrowException()
        {
            Guid validGuid = new Guid("c56a4280-65aa-42ec-a945-5fd21dec0538");
            var mockDbSet = new Mock<Data.Models.User>();

            // Arrange
            var fakeRepository = new UserFakeRepository();
            fakeRepository.Mock.Setup(s => s.GetUserByUserIdAsync(validGuid))
                .Throws(new Exception());

            UserService service = new UserService(fakeRepository.Repository, _mapper);

            // Act
            try
            {
                var response = await service.GetUserByUserIdAsync(validGuid);
                Assert.Fail($"Expected exception, but got user with userId: {response.UserId}");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
            }
        }

        [TestMethod]
        public async Task CreateUserAsync_ValidData_ShouldReturnUserModel()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;
            AddUserModel addUserModel = new AddUserModel()
            {
                Name = "Egor",
                Surname = "Danilkov"
            };

            UserFakeRepository repository = new UserFakeRepository();
            repository.Mock.Setup(s => s.CreateUserAsync(It.IsAny<AddUserModel>()))
                .Returns(Task.FromResult(new Data.Models.User()
                {
                    UserId = validGuid,
                    Name = "Egor",
                    Surname = "Danilkov",
                    CreationDate = сreationDate
                }));

            UserService service = new UserService(repository.Repository, _mapper);

            var user = await service.CreateUserAsync(addUserModel);

            Assert.IsNotNull(user);
            Assert.AreEqual("Danilkov", user.Surname);
            Assert.AreEqual("Egor", user.Name);
            Assert.AreEqual(сreationDate, user.CreationDate);
            Assert.AreEqual(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), user.UserId);
        }

        [TestMethod]
        public async Task CreateUserAsync_InvalidData_ShouldThrowArgumentNullException()
        {
            AddUserModel addUserModel = null;

            // Arrange
            UserFakeRepository repository = new UserFakeRepository();

            UserService service = new UserService(repository.Repository, _mapper);

            // Act
            try
            {
                var response = await service.CreateUserAsync(addUserModel);
                Assert.Fail($"Expected ArgumentNullException, but got user with userId: {response.UserId}");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
            }
        }

        [TestMethod]
        public async Task CreateUserAsync_ServiceCreatesUser_ShouldThrowException()
        {
            AddUserModel addUserModel = new AddUserModel()
            {
                Name = "Egor",
                Surname = "Danilkov"
            };

            // Arrange
            UserFakeRepository repository = new UserFakeRepository();
            repository.Mock.Setup(s => s.CreateUserAsync(addUserModel))
                .Throws(new Exception());

            UserService service = new UserService(repository.Repository, _mapper);

            // Act
            try
            {
                var response = await service.CreateUserAsync(addUserModel);
                Assert.Fail($"Expected exception, but got user with userId: {response.UserId}");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Exception));
            }
        }
    }
}
