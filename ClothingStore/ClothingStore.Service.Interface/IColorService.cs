using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IColorService
    {
        public List<Color> GetAll();
        public Color GetById(int colorId);
        public Color GetByName(string name);        
    }
}
