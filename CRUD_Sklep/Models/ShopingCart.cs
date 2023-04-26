﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_Sklep.Models
{
    public class ShopingCart
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Amount { get; set; } //ilość
        public float Sum
        {
            get
            {
                if (Product.Price != null)
                {
                    return (Product.Price * Amount * 100)/100;
                }
                return 0;
            }
        }


        public ShopingCart() { }

        public ShopingCart(int productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }
    }
}
