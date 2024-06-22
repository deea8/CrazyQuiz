using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;

namespace CrazyQuiz.Services
{
    public class QuizResultService : IQuizResultService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public QuizResultService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<QuizResult> GetAllQuizResults()
        {
            return _repositoryWrapper.QuizResultRepository.FindAll().ToList();
        }

        public QuizResult? GetQuizResultById(int quizResultId)
        {
            return _repositoryWrapper.QuizResultRepository.FindByCondition(qr => qr.QuizResultId == quizResultId).FirstOrDefault();
        }

        public IEnumerable<QuizResult> GetQuizResultsByUser(string? userId)
        {
            return _repositoryWrapper.QuizResultRepository.FindByCondition(qr => qr.UserId == userId).ToList();
        }

        public IEnumerable<QuizResult> GetQuizResultsByQuiz(int quizId)
        {
            return _repositoryWrapper.QuizResultRepository.FindByCondition(qr => qr.QuizId == quizId).ToList();
        }
        public IEnumerable<QuizResult> GetTopQuizResults(int count)
        {
            return _repositoryWrapper.QuizResultRepository.FindAll()
                .OrderByDescending(qr => qr.Score)
                .Take(count)
                .ToList();
        }
        public void CreateQuizResult(QuizResult quizResult)
        {
            _repositoryWrapper.QuizResultRepository.Create(quizResult);
            _repositoryWrapper.Save();
        }

        public void UpdateQuizResult(QuizResult quizResult)
        {
            _repositoryWrapper.QuizResultRepository.Update(quizResult);
            _repositoryWrapper.Save();
        }

        public void DeleteQuizResult(int quizResultId)
        {
            var quizResult = _repositoryWrapper.QuizResultRepository.FindByCondition(qr => qr.QuizResultId == quizResultId).FirstOrDefault();
            if (quizResult != null)
            {
                _repositoryWrapper.QuizResultRepository.Delete(quizResult);
                _repositoryWrapper.Save();
            }
        }
    }
}
