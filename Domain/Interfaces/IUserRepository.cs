using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<CustomUser>
    {
        public Task<CustomUser?> GetByEmailAndPassword(string email, string password);
    }
}
