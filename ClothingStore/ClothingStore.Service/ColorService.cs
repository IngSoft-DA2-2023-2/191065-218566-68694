using AutoMapper;
using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ColorDTOs;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IMapper _mapper;

        public ColorService(IMapper mapper, IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }
        public List<ColorResponseDTO> GetAll()
        {
            var colors = _colorRepository.GetAll();
            var colorsDTOs = _mapper.Map<List<ColorResponseDTO>>(colors);
            return colorsDTOs;
        }

        public ColorResponseDTO GetById(int colorId)
        {
            var color = _colorRepository.GetById(colorId);
            return _mapper.Map<ColorResponseDTO>(color);

        }

        public ColorResponseDTO GetByName(string name)
        {
            var color = _colorRepository.GetByName(name);
            return _mapper.Map<ColorResponseDTO>(color);

        }
    }
}
