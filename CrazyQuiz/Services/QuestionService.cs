using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrazyQuiz.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public QuestionService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _repositoryWrapper.QuestionRepository.FindAll().ToList();
        }

        public Question? GetQuestionById(int questionId)
        {
            return _repositoryWrapper.QuestionRepository.FindByCondition(q => q.QuestionId == questionId).FirstOrDefault();
        }
        public IEnumerable<Question> GetAllQuestionsWithQuiz()
        {
            return _repositoryWrapper.QuestionRepository.FindAll()
                        .Include(q => q.Quiz)
                        .ToList();
        }

        public IEnumerable<Question> GetQuestionsByQuiz(int quizId)
        {
            return _repositoryWrapper.QuestionRepository.FindByCondition(q => q.QuizId == quizId).Include(q => q.Quiz).ToList();
        }

        public void CreateQuestion(Question question)
        {
            _repositoryWrapper.QuestionRepository.Create(question);
            _repositoryWrapper.Save();
        }

        public void UpdateQuestion(Question question)
        {
            _repositoryWrapper.QuestionRepository.Update(question);
            _repositoryWrapper.Save();
        }

        public void DeleteQuestion(int questionId)
        {
            var question = _repositoryWrapper.QuestionRepository.FindByCondition(q => q.QuestionId == questionId).FirstOrDefault();
            if (question != null)
            {
                _repositoryWrapper.QuestionRepository.Delete(question);
                _repositoryWrapper.Save();
            }
        }
    }
}