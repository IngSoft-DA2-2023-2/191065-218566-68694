using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClothingStore.Models.DTO.UserDTOs
{
    public class UserRequestDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }        
        public List<string> Roles { get; set; } 


        public User ToEntity()
        {
            return new User()
            {
                Email = Email,
                Password = Password,
                Address = Address,
            };
        }
    }
}
