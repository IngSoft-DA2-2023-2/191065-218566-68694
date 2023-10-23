using ClothingStore.DataAccess.Interface;
using ClothingStore.DataAccess.Repositories;
using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ProductDTOs;
using ClothingStore.Models.DTO.UserDTOs;
using ClothingStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service
{
    public class UserService : IUserService
    {                
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {            
            _userRepository = userRepository;
            _roleRepository = roleRepository;   
        }

        public void Create(UserRequestDTO userRequestDTO)
        {
            var existingUser = _userRepository.GetByEmail(userRequestDTO.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("Ya existe un usuario con ese email registrado");
            }
            User user = userRequestDTO.ToEntity();
            foreach (var role in userRequestDTO.Roles)
            {
                var existingRole = _roleRepository.GetByName(role);
                if (existingRole != null)
                {
                    user.Roles.Add(existingRole);
                }                
            }            
            _userRepository.Create(user);
        }

        public List<User> GetAll()
        {
            List<User> users = _userRepository.GetAll();            
            return users;
        }

        public User GetById(int id)
        {
            User user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentException($"No se puede obtener el usuario con ID {user.Id} porque no existe.");
            }            
            return user;
        }

        public User GetByEmail(string email)
        {
            User user = _userRepository.GetByEmail(email);            
            return user;
        }

        public void Update(User userUpdate)
        {
            var existingUser = _userRepository.GetById(userUpdate.Id);
            if (existingUser == null)
            {
                throw new ArgumentException($"No se puede actualizar el usuario con ID {userUpdate.Id} porque no existe.");
            }            
            _userRepository.Update(userUpdate);
        }

        public void Delete(int id)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser == null)
            {
                throw new ArgumentException($"No se puede eliminar el usuario con ID {id} porque no existe.");
            }
            _userRepository.Delete(id);
        }        
    }

}

