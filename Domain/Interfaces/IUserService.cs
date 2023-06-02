using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<CustomUser>> GetAll();
        Task<CustomUser> GetById(int id);
        Task Create(CustomUser model);
        Task Update(CustomUser model);
        Task Delete(int id);
        Task<CustomUser> Login(string email,string password);
    }
}
