using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IRoleService
    {
        public List<Role> GetAll();
        public Role GetById(int id);
        public Role GetByName(string name);
    }
}
