using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Test
{
    [TestClass]
    public class RoleRepositoryTest
    {
        private IRoleRepository roleRepository;
        private DataContext context;
        private Role testRole;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            roleRepository = new RoleRepository(context);
            testRole = new Role()
            {
                Id = 1,
                Name = "Test Name",
            };
            context.Roles.Add(testRole);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllRolesTest()
        {
            List<Role> result = roleRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdRoleTest()
        {
            var result = roleRepository.GetById(testRole.Id);
            Assert.IsTrue(testRole.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsRoleTest()
        {
            var id = 5;
            var result = roleRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNameRoleTest()
        {
            var result = roleRepository.GetByName(testRole.Name);
            Assert.IsTrue(testRole.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsColorTest()
        {
            var name = "Test name 2";
            var result = roleRepository.GetByName(name);
            Assert.IsNull(result);
        }       
                
        //public bool ExistsRole(string name);
    }
}
