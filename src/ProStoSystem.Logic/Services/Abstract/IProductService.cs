using System.Collections.Generic;

namespace ProStoSystem.Logic.Services.Abstract
{
    using Database.Entities;

    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
