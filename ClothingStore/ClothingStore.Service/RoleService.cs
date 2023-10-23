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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public List<Role> GetAll()
        {
            List<Role> roles = _roleRepository.GetAll();
            return roles;
        }

        public Role GetById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public Role GetByName(string name)
        {
            return _roleRepository.GetByName(name);
        }
    }
}
