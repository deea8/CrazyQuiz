using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrazyQuiz.Services
{
    public class QuizService : IQuizService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public QuizService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Quiz> GetAllQuizzes()
        {
            return _repositoryWrapper.QuizRepository.FindAll().Include(q => q.Category).ToList();

        }

        public Quiz? GetQuizById(int quizId)
        {
            return _repositoryWrapper.QuizRepository.FindByCondition(q => q.QuizId == quizId).Include(q => q.Category).FirstOrDefault();
        }

        public IEnumerable<Quiz> GetQuizzesByCategory(int categoryId)
        {
            return _repositoryWrapper.QuizRepository.FindByCondition(q => q.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Quiz> GetQuizzesByDifficulty(QuizDifficulty difficulty)
        {
            return _repositoryWrapper.QuizRepository.FindByCondition(q => q.Difficulty == difficulty).ToList();
        }

        public void CreateQuiz(Quiz quiz)
        {
            _repositoryWrapper.QuizRepository.Create(quiz);
            _repositoryWrapper.Save();
        }

        public void UpdateQuiz(Quiz quiz)
        {
            _repositoryWrapper.QuizRepository.Update(quiz);
            _repositoryWrapper.Save();
        }

        public void DeleteQuiz(int quizId)
        {
            var quiz = _repositoryWrapper.QuizRepository.FindByCondition(q => q.QuizId == quizId).FirstOrDefault();
            if (quiz != null)
            {
                _repositoryWrapper.QuizRepository.Delete(quiz);
                _repositoryWrapper.Save();
            }
        }
    }
}
