using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrazyQuiz.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CrazyQuizContext QuizContext { get; set; }
        protected DbSet<T> _dbSet;

        public RepositoryBase(CrazyQuizContext quizContext)
        {
            this.QuizContext = quizContext;
            _dbSet = quizContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
