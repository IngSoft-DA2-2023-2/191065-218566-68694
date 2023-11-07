using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Moq;

namespace ClothingStore.Service.Test
{
    [TestClass]
    public class RoleServiceTest
    {
        private IRoleRepository roleRepository;
        private Role roleTest;

        [TestInitialize]
        public void InitTest()
        {
            var roleRepositoryMock = new Mock<IRoleRepository>();

            roleTest = new Role
            {
                Id = 1,
                Name = "Test Name"
            };
            var roles = new List<Role>() { roleTest };
            roleRepositoryMock.Setup(x => x.GetAll()).Returns(roles);
            roleRepository = roleRepositoryMock.Object;
        }

        [TestMethod]
        public void GetAllRoleTest()
        {
            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repo => repo.GetAll())
            .Returns(new List<Role>
            {
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Client" },
            });
            var roleService = new RoleService(roleRepositoryMock.Object);
            var roles = roleService.GetAll();
            Assert.IsNotNull(roles);
            Assert.AreEqual(2, roles.Count());
        }

        [TestMethod]
        public void GetByIdRoleTest()
        {
            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repo => repo.GetById(roleTest.Id)).Returns(roleTest);
            var roleService = new RoleService(roleRepositoryMock.Object);
            var result = roleService.GetById(roleTest.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(roleTest.Id, result.Id);
            Assert.AreEqual(roleTest.Name, result.Name);
            roleRepositoryMock.Verify(repo => repo.GetById(roleTest.Id), Times.Once);
        }

        [TestMethod]
        public void GetByNameRoleTest()
        {
            var roleRepositoryMock = new Mock<IRoleRepository>();
            roleRepositoryMock.Setup(repo => repo.GetByName(roleTest.Name)).Returns(roleTest);
            var roleService = new RoleService(roleRepositoryMock.Object);
            var result = roleService.GetByName("Test Name");

            Assert.AreEqual(roleTest.Id, result.Id);
            Assert.AreEqual(roleTest.Name, result.Name);
            roleRepositoryMock.Verify(repo => repo.GetByName(roleTest.Name), Times.Once);
        }
    }
}



