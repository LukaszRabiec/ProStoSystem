﻿using System.Linq;

namespace ProStoSystem.Logic.Repositories.Concrete
{
    using Abstract;
    using Database;
    using Database.Entities;
    using System.Data.Entity;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
