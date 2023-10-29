using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ClothingStore.DataAccess.Repositories;

namespace ClothingStore.DataAccess.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        private IUserRepository userRepository;
        private DataContext context;
        private User testUser;
        private Role testRole;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            userRepository = new UserRepository(context);
            testRole = new Role()
            {
                Id = 1,
                Name = "Admin"
            };

            testUser = new User()
            {
                Id = 1,
                Email = "Test Email",
                Password = "Test Password",
                Address = "Test Address",
                Roles = new List<Role> { testRole },
            };
            context.Users.Add(testUser);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void CreateUserTest() 
        {            
            var testUser2 = new User()
            {
                Id = 2,
                Email = "Test Email 2",
                Password = "Test Password 2",
                Address = "Test Address",
                Roles = new List<Role> { testRole },
            };
            userRepository.Create(testUser2);
            context.SaveChanges();
            var result = userRepository.GetAll();
            Assert.IsTrue(new List<User>(result).Contains(testUser2));
        }

        [TestMethod]
        public void GetByIdUserTest()
        {
            var result = userRepository.GetById(testUser.Id);
            Assert.IsTrue(testUser.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsUserTest()
        {
            var id = 2;
            var result = userRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByEmailUserTest()
        {
            var result = userRepository.GetByEmail(testUser.Email);
            Assert.IsTrue(testUser.Equals(result));
        }

        [TestMethod]
        public void GetByMailNonExistsUserTest()
        {
            var email = "Test email 4";
            var result = userRepository.ExistsUser(email);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetAllUserTest()
        {
            IEnumerable<User> result = userRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var testUser3 = new User()
            {
                Id = 3,
                Email = "Test Email 3",
                Password = "Test Password 3",
                Address = "Test Address",
                Roles = new List<Role> { testRole },
            };
            userRepository.Create(testUser3);
            context.SaveChanges();
            userRepository.Delete(testUser3.Id);
            context.SaveChanges();
            var result = userRepository.GetAll();
            Assert.IsFalse(new List<User>(result).Contains(testUser3));
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            testUser.Password = "New Password";
            userRepository.Update(testUser);
            context.SaveChanges();
            var result = userRepository.GetAll();
            Assert.IsTrue(((User)result.ToArray().GetValue(0)).Password == testUser.Password);
        }

        [TestMethod]
        public void ExistsUserTest()
        {
            var result = userRepository.ExistsUser(testUser.Email);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidUserTest()
        {
            var email = "Test Email";
            var password = "Test Password";
            var result = userRepository.ValidUser(email,password);
            Assert.IsTrue(testUser.Equals(result));
        }

    }
}