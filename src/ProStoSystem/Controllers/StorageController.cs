using System.Web.Mvc;

namespace ProStoSystem.Controllers
{
    using Database.Entities;
    using Logic.Repositories.Abstract;
    using Logic.UoW;

    public class StorageController : Controller
    {
        private readonly IUnitOfWork _uow;

        public StorageController(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public ActionResult Index()
        {
            var products = _uow.Repository<Product>().GetAll();
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