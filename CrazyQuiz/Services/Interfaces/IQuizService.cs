using CrazyQuiz.Models;

namespace CrazyQuiz.Services.Interfaces
{
    public interface IQuizService
    {
        IEnumerable<Quiz> GetAllQuizzes();
        Quiz? GetQuizById(int quizId);
        void CreateQuiz(Quiz quiz);
        void UpdateQuiz(Quiz quiz);
        void DeleteQuiz(int quizId);
        IEnumerable<Quiz> GetQuizzesByCategory(int categoryId);
        IEnumerable<Quiz> GetQuizzesByDifficulty(QuizDifficulty difficulty);
    }
}
