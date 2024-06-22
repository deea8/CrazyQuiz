using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {
        public AnswerRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}
