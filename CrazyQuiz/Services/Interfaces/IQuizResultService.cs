using CrazyQuiz.Models;
using System.Collections.Generic;

namespace CrazyQuiz.Services.Interfaces
{
    public interface IQuizResultService
    {
        IEnumerable<QuizResult> GetAllQuizResults();
        QuizResult? GetQuizResultById(int quizResultId);
        IEnumerable<QuizResult> GetQuizResultsByUser(string? userId);
        IEnumerable<QuizResult> GetQuizResultsByQuiz(int quizId);
        IEnumerable<QuizResult> GetTopQuizResults(int count);
        void CreateQuizResult(QuizResult quizResult);
        void UpdateQuizResult(QuizResult quizResult);
        void DeleteQuizResult(int quizResultId);
    }
}
