using CRUD_Sklep.Models;

namespace CRUD_Sklep.Service
{
    public interface IShoppingCartService
    {

        void AddToCart(Product product, int amount);
        IEnumerable<ShopingCart> GetAllItems();
        bool IsAlreadyExist(int id);
        bool UpdateAmountInProducts(int id, int amount);
        bool UpdateAmountInCart(int id, int amount);
        IEnumerable<ShopingCart> GetItemById(int id);
    }
}
