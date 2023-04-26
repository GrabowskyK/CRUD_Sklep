using System.Globalization;

namespace CRUD_Sklep.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; } //Tutaj jest problem


        public Product() { }
        public Product(string name, string description, string category, int amount, float price)
        {
            Name = name;
            Description = description;
            Category = category;
            Amount = amount;
            Price = price;
        }
    }
}
