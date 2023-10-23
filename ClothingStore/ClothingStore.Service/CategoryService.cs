using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {            
            _categoryRepository = categoryRepository;
        }
        public List<Category> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            return categories;
        }

        public Category GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría");
            }
            return category;
        }

        public Category GetByName(string name)
        {
            Category category = _categoryRepository.GetByName(name);
            if (category == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría");
            }
            return category;
        }
    }
}
