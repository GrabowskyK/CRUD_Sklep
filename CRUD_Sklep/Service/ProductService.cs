using CRUD_Sklep.Context;
using CRUD_Sklep.Models;

namespace CRUD_Sklep.Service
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _databaseContext;

        public ProductService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IEnumerable<Product> GetAllProducts() => _databaseContext.Products;

        public void AddProduct(Product newProduct)
        {
            //Product product = new(newProduct.Name, newProduct.Description, newProduct.Category, newProduct.Amount, newProduct.Price);
            _databaseContext.Add(newProduct);
            _databaseContext.SaveChanges();
        }

        public void RemoveProduct(Product product) {
            var item = _databaseContext.Products.FirstOrDefault(p => p.Id == product.Id);
            _databaseContext.Remove(item);
            _databaseContext.SaveChanges();
        }
    }
}
