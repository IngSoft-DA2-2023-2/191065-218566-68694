using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ClothingStore.DataAccess.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<Color> colors;

        public ColorRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            colors = _dbContext.Set<Color>();            
        }

        public List<Color> GetAll()
        {
            return colors.ToList();
        }

        public Color GetById(int colorId)
        {
            return colors.Where(c => c.Id == colorId).FirstOrDefault();
        }

        public Color GetByName(string name)
        {
            return colors.Where(c => c.Name == name).FirstOrDefault();
        }

        public List<string> GetNonExistentColors(List<string> colorNames)
        {
            var existingColors = colors.Select(c => c.Name).ToList();
            return colorNames.Except(existingColors).ToList();
        }      
        
    }
}
