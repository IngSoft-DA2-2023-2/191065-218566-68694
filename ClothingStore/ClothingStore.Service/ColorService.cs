using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
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

        public ColorService(IColorRepository colorRepository)
        {            
            _colorRepository = colorRepository;
        }
        public List<Color> GetAll()
        {
            List<Color> colors = _colorRepository.GetAll();
            return colors;
        }

        public Color GetById(int colorId)
        {
            return _colorRepository.GetById(colorId);
        }

        public Color GetByName(string name)
        {
            return _colorRepository.GetByName(name);
        }
    }
}
