using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CrazyQuiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AnswerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Answer> GetAllAnswers()
        {
            return _repositoryWrapper.AnswerRepository.FindAll().ToList();
        }

        public Answer? GetAnswerById(int answerId)
        {
            return _repositoryWrapper.AnswerRepository.FindByCondition(a => a.AnswerId == answerId).FirstOrDefault();
        }
        public IEnumerable<Answer> GetAllAnswersWithQuestion()
        {
            return _repositoryWrapper.AnswerRepository.FindAll()
                        .Include(q => q.Question)
                        .ToList();
        }
        public IEnumerable<Answer> GetAnswersByQuestion(int questionId)
        {
            return _repositoryWrapper.AnswerRepository.FindByCondition(a => a.QuestionId == questionId).Include(a => a.Question).ToList();
        }

        public void CreateAnswer(Answer answer)
        {
            _repositoryWrapper.AnswerRepository.Create(answer);
            _repositoryWrapper.Save();
        }

        public void UpdateAnswer(Answer answer)
        {
            _repositoryWrapper.AnswerRepository.Update(answer);
            _repositoryWrapper.Save();
        }

        public void DeleteAnswer(int answerId)
        {
            var answer = _repositoryWrapper.AnswerRepository.FindByCondition(a => a.AnswerId == answerId).FirstOrDefault();
            if (answer != null)
            {
                _repositoryWrapper.AnswerRepository.Delete(answer);
                _repositoryWrapper.Save();
            }
        }
    }
}
