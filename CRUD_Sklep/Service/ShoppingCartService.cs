using CRUD_Sklep.Context;
using CRUD_Sklep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Sklep.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly DatabaseContext _databaseContext;

        public ShoppingCartService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<ShopingCart> GetAllItems() => _databaseContext.ShopingCarts.Include(sc => sc.Product);

        public void AddToCart(Product product, int amount)
        {
            ShopingCart item = new ShopingCart(product.Id, amount);
            _databaseContext.Add(item);

            _databaseContext.SaveChanges();
        }

        public bool IsAlreadyExist(int id)
        {
            var item = _databaseContext.ShopingCarts.Where(sc => sc.ProductId == id).FirstOrDefault();
            if (item == null)
            {
                return false;
            }
            return true;
        }

        public bool UpdateAmountInProducts(int id, int amount)
        {
            var sub = _databaseContext.Products.FirstOrDefault(p => p.Id == id);
            if (amount <= sub.Amount && amount > 0)
            {
                sub.Amount -= amount;
                _databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
 //Tutaj dodać message               
            }

        }

        public bool UpdateAmountInCart(int id, int amount)
        {
            var item = _databaseContext.ShopingCarts.FirstOrDefault(sc => sc.ProductId == id);
            if (amount <= item.Amount && amount > 0)
            {
                item.Amount += amount;
                _databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
                //Tutaj dodać message               
            }
        }

        public IEnumerable<ShopingCart> GetItemById(int id) => _databaseContext.ShopingCarts.Where(sc => sc.Id == id);

    }
}
