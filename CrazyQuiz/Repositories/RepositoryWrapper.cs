using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;

namespace CrazyQuiz.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CrazyQuizContext _quizContext;
        private IAnswerRepository? _answerRepository;
        private ICategoryRepository? _categoryRepository;
        private IQuestionRepository? _questionRepository;
        private IQuizRepository? _quizRepository;
        private IQuizResultRepository? _quizResultRepository;
        private IUserRepository? _userRepository;

        public IAnswerRepository AnswerRepository
        {
            get
            {
                if (_answerRepository == null)
                {
                    _answerRepository = new AnswerRepository(_quizContext);
                }

                return _answerRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_quizContext);
                }

                return _categoryRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository == null)
                {
                    _questionRepository = new QuestionRepository(_quizContext);
                }

                return _questionRepository;
            }
        }

        public IQuizRepository QuizRepository
        {
            get
            {
                if (_quizRepository == null)
                {
                    _quizRepository = new QuizRepository(_quizContext);
                }

                return _quizRepository;
            }
        }

        public IQuizResultRepository QuizResultRepository
        {
            get
            {
                if (_quizResultRepository == null)
                {
                    _quizResultRepository = new QuizResultRepository(_quizContext);
                }

                return _quizResultRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_quizContext);
                }

                return _userRepository;
            }
        }

        public RepositoryWrapper(CrazyQuizContext quizContext)
        {
            _quizContext = quizContext;
        }

        public void Save()
        {
            _quizContext.SaveChanges();
        }
    }
}
