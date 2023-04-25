using CRUD_Sklep.Models;

namespace CRUD_Sklep.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        void AddProduct(Product product);
    }
}
