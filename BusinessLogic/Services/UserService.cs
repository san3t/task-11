using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<CustomUser>> GetAll()
        {
            return await _repositoryWrapper.User.FindAll();
        }

        public async Task<CustomUser> GetById(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.Id == id);

            return user.First();
        }

        public async Task Create(CustomUser model)
        {
            await _repositoryWrapper.User.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(CustomUser model)
        {
            await _repositoryWrapper.User.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _repositoryWrapper.User.FindByCondition(x => x.Id == id);
            _repositoryWrapper.User.Delete(user.First());
            _repositoryWrapper.Save();
        }

        public async Task<CustomUser> Login(string email, string password)
        {
            var user = await _repositoryWrapper.User.GetByEmailAndPassword(email, password);
            return user;
        }
    }
}
