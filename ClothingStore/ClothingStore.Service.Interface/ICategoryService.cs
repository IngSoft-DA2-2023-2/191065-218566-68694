using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface ICategoryService
    {
        List<CategoryResponseDTO> GetAll();
        CategoryResponseDTO GetById(int id);
        CategoryResponseDTO GetByName(string name);
    }
}
