namespace CrazyQuiz.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAnswerRepository AnswerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IQuizRepository QuizRepository { get; }
        IQuizResultRepository QuizResultRepository { get; }
        IUserRepository UserRepository { get; }

        void Save();
    }
}