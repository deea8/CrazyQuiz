using CrazyQuiz.Models;

namespace CrazyQuiz.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAllQuestions();
        Question? GetQuestionById(int questionId);
        IEnumerable<Question> GetAllQuestionsWithQuiz();
        IEnumerable<Question> GetQuestionsByQuiz(int quizId);
        void CreateQuestion(Question question);
        void UpdateQuestion(Question question);
        void DeleteQuestion(int questionId);

    }
}
