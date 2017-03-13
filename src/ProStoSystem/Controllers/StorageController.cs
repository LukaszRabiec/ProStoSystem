using System.Web.Mvc;

namespace ProStoSystem.Controllers
{
    using System.Linq;
    using Database.Entities;
    using Logic.Services.Abstract;

    public class StorageController : Controller
    {
        private readonly IProductService _productService;

        public StorageController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            return View();
        }
    }
}