using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}