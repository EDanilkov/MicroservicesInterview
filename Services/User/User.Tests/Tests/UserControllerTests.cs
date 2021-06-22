using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using User.API.Controllers;
using User.Model.ResponseModels;
using User.Tests.Mock;
using User.Model.RequestModels;

namespace User.Tests.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task GetUserByUserIdAsync_ValidUserId_ShouldReturnOk()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;

            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.GetUserByUserIdAsync(validGuid))
                .Returns(Task.FromResult(new UserModel()
                {
                    UserId = validGuid,
                    Name = "Egor",
                    Surname = "Danilkov",
                    CreationDate = сreationDate
                }));

            UsersController controller = new UsersController(fakeService.Service);

            var response = await controller.GetUserByUserIdAsync(validGuid);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(UserModel));

            var user = okResult.Value as UserModel;

            Assert.IsNotNull(user);

            Assert.AreEqual("Danilkov", user.Surname);
            Assert.AreEqual("Egor", user.Name);
            Assert.AreEqual(сreationDate, user.CreationDate);
            Assert.AreEqual(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), user.UserId);
        }

        [TestMethod]
        public async Task GetUserByUserIdAsync_InvalidUserId_ShouldReturnNotFoundResult()
        {
            Guid invalidGuid = new Guid("C56A4280-65AA-42EC-A945-5FD21DEC0538");

            // Arrange
            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.GetUserByUserIdAsync(invalidGuid))
                .Throws(new ArgumentException($"Not found user with userId: {invalidGuid}"));

            UsersController controller = new UsersController(fakeService.Service);

            // Act
            var response = await controller.GetUserByUserIdAsync(invalidGuid);

            // Arrange
            Assert.IsInstanceOfType(response, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetUserByUserIdAsync_ControllerReturnsUser_ShouldReturnStatusCodeResult500()
        {
            Guid invalidGuid = new Guid("C56A4280-65AA-42EC-A945-5FD21DEC0538");

            // Arrange
            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.GetUserByUserIdAsync(invalidGuid))
                .Throws(new Exception());

            UsersController controller = new UsersController(fakeService.Service);

            // Act
            var response = await controller.GetUserByUserIdAsync(invalidGuid);

            // Arrange
            Assert.IsInstanceOfType(response, typeof(StatusCodeResult));

            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }

        [TestMethod]
        public async Task CreateUserAsync_ValidData_ShouldReturnOk()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;
            AddUserModel addUserModel = new AddUserModel()
            {
                Name = "Egor",
                Surname = "Danilkov"
            };

            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.CreateUserAsync(addUserModel))
                .Returns(Task.FromResult(new UserModel()
                {
                    UserId = validGuid,
                    Name = "Egor",
                    Surname = "Danilkov",
                    CreationDate = сreationDate
                }));

            UsersController controller = new UsersController(fakeService.Service);

            var response = await controller.CreateUserAsync(addUserModel);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));

            var okResult = response as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);

            Assert.IsNotNull(okResult.Value);
            Assert.IsInstanceOfType(okResult.Value, typeof(UserModel));

            var user = okResult.Value as UserModel;

            Assert.IsNotNull(user);

            Assert.AreEqual("Danilkov", user.Surname);
            Assert.AreEqual("Egor", user.Name);
            Assert.AreEqual(сreationDate, user.CreationDate);
            Assert.AreEqual(new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538"), user.UserId);
        }

        [TestMethod]
        public async Task CreateUserAsync_InvalidData_ShouldReturnBadRequestResult()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;
            AddUserModel addUserModel = null;

            // Arrange
            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.CreateUserAsync(addUserModel))
                .Throws(new ArgumentNullException());

            UsersController controller = new UsersController(fakeService.Service);

            // Act
            var response = await controller.CreateUserAsync(addUserModel);

            // Arrange
            Assert.IsInstanceOfType(response, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task CreateUserAsync_ControllerCreatesUser_ShouldReturnStatusCodeResult500()
        {
            Guid validGuid = new Guid("C56A4180-65AA-42EC-A945-5FD21DEC0538");
            DateTime сreationDate = DateTime.Now;
            AddUserModel addUserModel = null;

            // Arrange
            var fakeService = new UserFakeService();
            fakeService.Mock.Setup(s => s.CreateUserAsync(addUserModel))
                .Throws(new Exception());

            UsersController controller = new UsersController(fakeService.Service);

            // Act
            var response = await controller.CreateUserAsync(addUserModel);

            // Arrange
            Assert.IsInstanceOfType(response, typeof(StatusCodeResult));

            var statusCodeResult = response as StatusCodeResult;
            Assert.AreEqual(500, statusCodeResult.StatusCode);
        }
    }
}
