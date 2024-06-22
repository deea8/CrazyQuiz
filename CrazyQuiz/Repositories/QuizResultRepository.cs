using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class QuizResultRepository : RepositoryBase<QuizResult>, IQuizResultRepository
    {
        public QuizResultRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}
