namespace ClothingStore.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        List<Product> Products { get; set; }

    }
}
