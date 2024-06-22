using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CrazyQuiz.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public UserService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repositoryWrapper.UserRepository.FindAll().ToList();
        }

        public User? GetUserById(string Id)
        {
            return _repositoryWrapper.UserRepository.FindByCondition(u => u.Id == Id).FirstOrDefault();
        }

    }
}

