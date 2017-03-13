using System.Web.Mvc;

namespace ProStoSystem.Controllers
{
    using Database.Entities;
    using Logic.Repositories.Abstract;

    public class StorageController : Controller
    {
        private readonly IProductRepository _productRepository;

        public StorageController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Index()
        {
            var products = _productRepository.GetAll();
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