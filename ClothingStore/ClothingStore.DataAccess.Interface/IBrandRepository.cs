using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IBrandRepository
    {
        List<Brand> GetAll();
        Brand GetById(int id);
        Brand GetByName(string name);
    }
}
