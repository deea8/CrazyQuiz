using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CrazyQuiz.Models;
using CrazyQuiz.Services.Interfaces;

namespace CrazyQuiz.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IQuizService _quizService;

        public CategoriesController(ICategoryService categoryService, IQuizService quizService)
        {
            _categoryService = categoryService;
            _quizService = quizService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        public IActionResult QuizzesByCategory(int categoryId)
        {
            var quizzes = _quizService.GetQuizzesByCategory(categoryId);
            if (!quizzes.Any())
            {
                ViewBag.Message = "No quizzes found from this category.";
            }
            ViewBag.SearchMode = false; 
            return View("QuizList", quizzes); 
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
