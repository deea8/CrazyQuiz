using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        public QuestionRepository(CrazyQuizContext quizContext)
            : base(quizContext)
        {
        }
    }
}
