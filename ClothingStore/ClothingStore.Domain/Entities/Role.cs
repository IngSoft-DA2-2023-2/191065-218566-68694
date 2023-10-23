using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClothingStore.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}
