using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CrazyQuiz.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}