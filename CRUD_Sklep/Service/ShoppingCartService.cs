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
//TODO: Add message           
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
                //TODO: Add message                    
            }
        }

        public bool UpdateAmountAfterEdit(int productId, int amount)
        {
            var item = _databaseContext.ShopingCarts.FirstOrDefault(sc => sc.ProductId == productId);
            var sub = _databaseContext.Products.FirstOrDefault(p => p.Id == productId);
            if ((amount <= sub.Amount + item.Amount) && amount > 0)
            {
                sub.Amount += item.Amount - amount;

                item.Amount = amount;
                _databaseContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
                //TODO: Add message                   
            }
        }

        public void Remove(int id)
        {
            var item = _databaseContext.ShopingCarts.FirstOrDefault(sc => sc.Id == id);
            var amount = item.Amount;
            var amountProducts = _databaseContext.Products.FirstOrDefault(p => p.Id == item.ProductId);
            amountProducts.Amount += amount;
            _databaseContext.Remove(item);
            _databaseContext.SaveChanges();
        }

        public void RemoveAll()
        {
            var items = _databaseContext.ShopingCarts.ToList();
            foreach (var item in items)
            {
                var sub = _databaseContext.Products.FirstOrDefault(p => p.Id == item.ProductId);
                sub.Amount += item.Amount;
                _databaseContext.SaveChanges();
            }
            _databaseContext.ShopingCarts.RemoveRange(items);
            _databaseContext.SaveChanges();
        }
    }
}
