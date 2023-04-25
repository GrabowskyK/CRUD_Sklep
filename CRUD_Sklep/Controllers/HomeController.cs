using CRUD_Sklep.Models;
using CRUD_Sklep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Sklep.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ListProducts()
        {
            List<Product> products = _productService.GetAllProducts().ToList();
            return View(products);
        }

        public IActionResult AddProdcuts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProdcuts(Product product) 
        {
            _productService.AddProduct(product);
            return RedirectToAction("ListProducts");
        }

        [HttpPost]//Dodawanie do koszyka
        public IActionResult AddToKoszyk(Product product)
        {

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}