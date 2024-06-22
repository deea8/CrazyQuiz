using CrazyQuiz.Models;
using CrazyQuiz.Repositories.Interfaces;
using CrazyQuiz.Services.Interfaces;

namespace CrazyQuiz.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _repositoryWrapper.CategoryRepository.FindAll().ToList();
        }

        public Category? GetCategoryById(int categoryId)
        {
            return _repositoryWrapper.CategoryRepository.FindByCondition(c => c.CategoryId == categoryId).FirstOrDefault();
        }

        public void CreateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Create(category);
            _repositoryWrapper.Save();
        }

        public void UpdateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Update(category);
            _repositoryWrapper.Save();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _repositoryWrapper.CategoryRepository.FindByCondition(qr => qr.CategoryId == categoryId).FirstOrDefault();
            if (category != null)
            {
                _repositoryWrapper.CategoryRepository.Delete(category);
                _repositoryWrapper.Save();
            }
        }
    }
}
