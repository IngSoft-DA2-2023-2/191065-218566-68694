﻿using System.Text.Json.Serialization;

namespace ClothingStore.Domain.Entities
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
            
    }
}
