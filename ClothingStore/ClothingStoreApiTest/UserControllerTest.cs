using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using ClothingStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ClothingStore.Models.DTO.UserDTOs;


namespace ClothingStoreApiTest
{
    [TestClass]
    public class UserControllerTest
    {
      /*  private Mock<IUserService> mock;
        private UserController api;        
        private User testUser;
        private UserRequestDTO testUserRequestDTO;
        private Role testRole;        
        private List<User> users;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IUserService>(MockBehavior.Strict);
            api = new UserController(mock.Object);

            testRole = new Role
            {
                Id = 1,
                Name = "Test Role"
            };          

            testUser = new User()
            {
                Id = 1,
                Email = "Test Email",
                Password = "Test Password",
                Address = "Test Address",
                Roles = new List<Role> { testRole}
            };

            testUserRequestDTO = new UserRequestDTO()
            {
                Email = "Test Email",
                Password = "Test Password",
                Address = "Test Address",
                Roles = new List<string> { "Test Role" }
            };

            users = new List<User>() { testUser };            
        }

        [TestMethod]
        public void GetAllUserOkTest()
        {
            mock.Setup(x => x.GetAll()).Returns(users);
            var result = api.GetAll();
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdUserOkTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(It.IsAny<User>());
            var result = api.GetById(testUser.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void PostUserOkTest()
        {
            mock.Setup(x => x.Create(It.IsAny<UserRequestDTO>())).Verifiable();
            var result = api.Post(testUserRequestDTO);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }
        
        [TestMethod]
        public void PutUserOkTest()
        {
            mock.Setup(x => x.Update(It.IsAny<User>())).Verifiable();
            var result = api.Put(testUser);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void DeleteUserOkTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Verifiable();
            var result = api.Delete(testUser.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        public void GetByIdUserFailTest()
        {
            mock.Setup(x => x.GetById(It.IsAny<int>())).Throws(new Exception());
            var result = api.GetById(testUser.Id);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

       [TestMethod]
        public void PostUserFailTest()
        {
            mock.Setup(x => x.Create(It.IsAny<UserRequestDTO>())).Throws(new Exception());
            var result = api.Post(It.IsAny<UserRequestDTO>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }

        [TestMethod]
        public void PutUserFailTest()
        {
            mock.Setup(x => x.Update(It.IsAny<User>())).Throws(new Exception());
            var result = api.Put(It.IsAny<User>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }


        [TestMethod]
        public void DeleteUserFailTest()
        {
            mock.Setup(x => x.Delete(It.IsAny<int>())).Throws(new Exception());
            var result = api.Delete(1);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult.StatusCode;
            mock.VerifyAll();
            Assert.AreEqual(400, statusCode);
        }
        
        //public IActionResult GetByEmail(string email)*/

    }
}
