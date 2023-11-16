using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        

    }
}
