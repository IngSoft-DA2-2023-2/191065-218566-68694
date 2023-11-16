using ClothingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Interface
{
    public interface IShoppingCartRepository
    {
        public int Create(ShoppingCart shoppingCart);
        public List<ShoppingCart> GetAll();        
        public ShoppingCart GetById(int id);
        public void Update(ShoppingCart shoppingCart);
        public List<ShoppingCart> GetSales();
        public List<ShoppingCart> GetSalesByUserId(int userId);
        public List<ShoppingCart> GetShoppingCartByUserId(int userId);

    }
}
