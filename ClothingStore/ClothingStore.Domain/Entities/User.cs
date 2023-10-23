namespace ClothingStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
        public List <Role> Roles { get; set; }
        public Session Session { get; set; }        
        

        public User()
        {
            ShoppingCarts = new List<ShoppingCart>();
            Roles = new List<Role>();
        }

    }
}
