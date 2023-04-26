using CRUD_Sklep.Context;
using CRUD_Sklep.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=tcp:testdatabasemysql.database.windows.net,1433;Initial Catalog=CRUD_database_sklep;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";"));
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server = (localdb)\\mysql; Database = CRUD_Store; Trusted_Connection = True; MultipleActiveResultSets = true"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=ListProducts}/{id?}");

app.Run();
