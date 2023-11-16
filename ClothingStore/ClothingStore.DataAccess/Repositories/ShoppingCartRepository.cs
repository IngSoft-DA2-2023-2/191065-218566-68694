using ClothingStore.DataAccess.Interface;
using ClothingStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingStore.DataAccess.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private DbContext _dbContext;
        private readonly DbSet<ShoppingCart> shoppingCarts;

        public ShoppingCartRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            shoppingCarts = _dbContext.Set<ShoppingCart>();
        }

        public int Create(ShoppingCart shoppingCart)
        {
            var shoppingCartRet = shoppingCarts.Add(shoppingCart);
            _dbContext.SaveChanges();

            return shoppingCartRet.Entity.Id;
        }

        public List<ShoppingCart> GetAll()
        {
            return shoppingCarts.ToList();
        }
              

        public ShoppingCart GetById(int id)
        {
            var shoppingCartFull = shoppingCarts.Where(sc => sc.Id == id).Include(sc => sc.Products).Include(sc => sc.User).FirstOrDefault();
            return shoppingCartFull;
        }

        public void Update(ShoppingCart shoppingCart)
        {
            var existingCart = shoppingCarts.FirstOrDefault(u => u.Id == shoppingCart.Id);
            if (existingCart != null)
            {
                _dbContext.Entry(existingCart).CurrentValues.SetValues(shoppingCart);
                _dbContext.SaveChanges();
            }
        }

        public List<ShoppingCart> GetSales()
        {
            var sales = shoppingCarts.Where(sc => sc.StateOrder == Domain.Enums.StateOrder.Finished)
                .Include(sc => sc.Products)
                .Include(sc => sc.Promotion);
            return sales.ToList();
        }

        public List<ShoppingCart> GetSalesByUserId(int userId)
        {
            var sales = shoppingCarts.Where(sc => sc.UserId == userId && sc.StateOrder == Domain.Enums.StateOrder.Finished)
                .Include(sc => sc.Products)
                .Include(sc => sc.Promotion);
            return sales.ToList();
        }

        public List<ShoppingCart> GetShoppingCartByUserId(int userId)
        {
            var shoppingCartsRet = shoppingCarts.Where(sc => sc.UserId == userId && sc.StateOrder == Domain.Enums.StateOrder.Pending).Include(s=>s.Products);
            return shoppingCartsRet.ToList();
        }
    }
}
