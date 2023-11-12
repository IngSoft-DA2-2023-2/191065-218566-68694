using AutoMapper;
using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.CategoryDTOs;
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
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public List<CategoryResponseDTO> GetAll()
        {
            var categories = _categoryRepository.GetAll(); // Suponiendo que esto devuelve List<BrandResponseDTO>
            var categoriesDTO = _mapper.Map<List<CategoryResponseDTO>>(categories);
            return categoriesDTO;
        }

        public CategoryResponseDTO GetById(int id)
        {
            Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría");
            }
            return _mapper.Map<CategoryResponseDTO>(category); ;
        }

        public CategoryResponseDTO GetByName(string name)
        {
            Category category = _categoryRepository.GetByName(name);
            if (category == null)
            {
                throw new ArgumentException($"No se puede obtener la categoría");
            }
            return _mapper.Map<CategoryResponseDTO>(category); ;
        }
    }
}
