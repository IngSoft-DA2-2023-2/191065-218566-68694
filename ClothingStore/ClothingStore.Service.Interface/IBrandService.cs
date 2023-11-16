using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IBrandService
    {
        List<BrandResponseDTO> GetAll();
        BrandResponseDTO GetById(int id);
        BrandResponseDTO GetByName(string name);
    }
}
