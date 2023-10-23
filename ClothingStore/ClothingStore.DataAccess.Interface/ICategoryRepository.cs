using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string name);        
    }
}
