using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IColorRepository
    {
        public List<Color> GetAll();
        public Color GetById(int colorId);
        public Color GetByName(string name);
        public List<string> GetNonExistentColors(List<string> colorNames);
    }
}
