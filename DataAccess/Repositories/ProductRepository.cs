using Domain.Interfaces;
using DataAccess.Repositories;
using DataAccess;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(eshop_dbContext repositoryContext)
            : base(repositoryContext) { }
    }
}
