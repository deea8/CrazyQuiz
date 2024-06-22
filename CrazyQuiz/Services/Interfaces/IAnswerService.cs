using CrazyQuiz.Models;

namespace CrazyQuiz.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAllAnswers();
        Answer? GetAnswerById(int answerId);
        void CreateAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void DeleteAnswer(int AnswerId);
        IEnumerable<Answer> GetAnswersByQuestion(int questionId);
        IEnumerable<Answer> GetAllAnswersWithQuestion();
    }
}
