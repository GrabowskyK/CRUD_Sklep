using CRUD_Sklep.Models;
using CRUD_Sklep.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace CRUD_Sklep.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private readonly IShoppingCartService _shopingCart;
        public ShoppingCartController(ILogger<ShoppingCartController> logger, IShoppingCartService shopingCart)
        {
            _logger = logger;
            _shopingCart = shopingCart;
        }

        public IActionResult ListCart()
        {
            List<ShopingCart> itemsInCart = _shopingCart.GetAllItems().ToList();

            return View(itemsInCart);
        }
        
        [HttpPost]
        public IActionResult AddToKoszyk(Product product, int amount)
        {
            
            if(_shopingCart.IsAlreadyExist(product.Id) == false)
            {
                if (_shopingCart.UpdateAmountInProducts(product.Id, amount) == true)
                {
                    _shopingCart.AddToCart(product, amount); // Add to database
                }
                
            }
            else
            {
                
                if(_shopingCart.UpdateAmountInProducts(product.Id, amount) == true)
                {
                    _shopingCart.UpdateAmountInCart(product.Id, amount);
                }
                
            }

            return RedirectToAction("ListCart");
            //return RedirectToAction("ListProducts", "Home");
        }


        public IActionResult Edit(int id)
        {
            List<ShopingCart> itemById = _shopingCart.GetItemById(id).ToList();
            return View(itemById);
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return RedirectToAction("ListCart");
        }
    }
}
