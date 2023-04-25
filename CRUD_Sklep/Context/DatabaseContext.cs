using CRUD_Sklep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Sklep.Context
{
    public class DatabaseContext : DbContext 
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //To bedzie dbset i entity sobie ogarnie
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopingCart> ShopingCarts{ get; set; }

    }
}
