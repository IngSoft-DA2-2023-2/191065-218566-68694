using ClothingStore.Domain.Entities;
using ClothingStore.Models.DTO.ShoppingCartDTO;
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
        public IEnumerable<UserResponseDTO> GetAll();
        public UserResponseDTO GetById(int id);
        public UserResponseDTO GetByEmail(string email);
        public void Update(UserUpdateDTO userUpdate);
        public void Delete(int id);
    }
}
