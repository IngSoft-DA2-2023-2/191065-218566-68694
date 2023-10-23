using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.Service.Interface
{
    public interface IUserService
    {
        public void Create(UserRequestDTO userRequestDto);
        public List<User> GetAll();
        public User GetById(int id);
        public User GetByEmail(string email);
        public void Update(User userUpdate);
        public void Delete(int id);
    }
}
