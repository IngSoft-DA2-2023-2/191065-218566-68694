using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IRoleRepository
    {
        public List<Role> GetAll();
        public Role GetById(int id);
        public Role GetByName(string name);
        public bool ExistsRole(string name);
    }
}
