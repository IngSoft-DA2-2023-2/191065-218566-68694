using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ColorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IColorService
    {
        public List<ColorResponseDTO> GetAll();
        public ColorResponseDTO GetById(int colorId);
        public ColorResponseDTO GetByName(string name);
    }
}
