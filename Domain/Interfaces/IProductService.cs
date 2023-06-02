using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task Create(Product model);
        Task Update(Product model);
        Task Delete(int id);
    }
}
