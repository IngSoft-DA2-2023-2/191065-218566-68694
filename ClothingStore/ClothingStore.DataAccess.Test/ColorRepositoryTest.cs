﻿using ClothingStore.DataAccess.Interface;
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
    public class ColorRepositoryTest
    {
        private IColorRepository colorRepository;
        private DataContext context;
        private Color testColor;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(databaseName: "database_name").Options;
            context = new DataContext(options);
            colorRepository = new ColorRepository(context);
            testColor = new Color()
            {
               Id = 1,
               Name = "Test Name",
            };
            context.Colors.Add(testColor);
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllColorTest()
        {
            List<Color> result = colorRepository.GetAll();
            Assert.IsTrue(result.ToArray().Length > 0);
        }

        [TestMethod]
        public void GetByIdColorTest()
        {
            var result = colorRepository.GetById(testColor.Id);
            Assert.IsTrue(testColor.Equals(result));
        }

        [TestMethod]
        public void GetByIdNotExistsColorTest()
        {
            var id = 2;
            var result = colorRepository.GetById(id);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetByNameColorTest()
        {
            var result = colorRepository.GetByName(testColor.Name);
            Assert.IsTrue(testColor.Equals(result));
        }

        [TestMethod]
        public void GetByNameNotExistsColorTest()
        {
            var name = "Test name 2";
            var result = colorRepository.GetByName(name);
            Assert.IsNull(result);
        }
        
        //public List<string> GetNonExistentColors(List<string> colorNames);
    }
}
