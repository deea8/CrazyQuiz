using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class QuizRepository : RepositoryBase<Quiz>, IQuizRepository
    {
        public QuizRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}
