using System.Text.Json.Serialization;

namespace ClothingStore.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Color> Colors { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public int Stock { get; set; }
        public bool PromoAvailable { get; set; } = true;


        public Product()
        {
            Colors = new List<Color>();
            ShoppingCarts = new List<ShoppingCart>();
        }
    }
}
