using Domain.Interfaces;
using DataAccess.Repositories;
using DataAccess;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class UserRepository : RepositoryBase<CustomUser>, IUserRepository
    {
        public UserRepository(eshop_dbContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<CustomUser?> GetByEmailAndPassword(string email, string password)
        {
            var result = await base.FindByCondition(x => x.UserEmail == email && x.UserPassword == password);
            if (result == null || result.Count == 0)
            {
                return null;
            }

            return result[0];

        }
    }
}
