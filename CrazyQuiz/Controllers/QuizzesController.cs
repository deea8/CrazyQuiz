using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrazyQuiz.Models;
using CrazyQuiz.Services.Interfaces;
using System.Linq;
using CrazyQuiz.Services;

namespace CrazyQuiz.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly IQuizService _quizService;
        private readonly ICategoryService _categoryService;
        private readonly IQuestionService _questionService;

        public QuizzesController(IQuizService quizService, ICategoryService categoryService, IQuestionService questionService)
        {
            _quizService = quizService;
            _categoryService = categoryService;
            _questionService = questionService;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;
            var quizzes = _quizService.GetAllQuizzes()
                            .OrderBy(q => q.QuizId)
                            .Skip((page - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

            return View(quizzes);
        }

        public IActionResult Details(int id)
        {
            var quiz = _quizService.GetQuizById(id);
            if (quiz == null)
                return NotFound();

            return View(quiz);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
            ViewBag.Difficulties = new SelectList(Enum.GetValues(typeof(QuizDifficulty)));
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _quizService.CreateQuiz(quiz);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name");
            ViewBag.Difficulties = new SelectList(Enum.GetValues(typeof(QuizDifficulty)));
            return View(quiz);
        }

        public IActionResult Edit(int id)
        {
            var quiz = _quizService.GetQuizById(id);
            if (quiz == null)
                return NotFound();

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", quiz.CategoryId);
            ViewBag.Difficulties = new SelectList(Enum.GetValues(typeof(QuizDifficulty)), quiz.Difficulty.ToString());
            return View(quiz);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                _quizService.UpdateQuiz(quiz);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = new SelectList(_categoryService.GetAllCategories(), "CategoryId", "Name", quiz.CategoryId);
            ViewBag.Difficulties = new SelectList(Enum.GetValues(typeof(QuizDifficulty)), quiz.Difficulty.ToString());
            return View(quiz);
        }

        public IActionResult Delete(int id)
        {
            var quiz = _quizService.GetQuizById(id);
            if (quiz == null)
                return NotFound();

            return View(quiz);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _quizService.DeleteQuiz(id);
            return RedirectToAction(nameof(Index));
        }
        /*
        public IActionResult StartQuiz(int id)
        {
            var quiz = _quizService.GetQuizById(id);
            if (quiz == null)
                return NotFound();

            // Încarcă întrebările pentru quiz
            quiz.Questions = _questionService.GetQuestionsByQuiz(id).ToList();

            return View(quiz);
        }
        */
        public IActionResult SearchQuizzes(string searchTerm)
        {
            var quizzes = _quizService.GetAllQuizzes()
                            .Where(q => q.Description.Contains(searchTerm))
                            .ToList();

            if (!quizzes.Any())
            {
                ViewBag.Message = "No quizzes found with the given description.";
            }

            ViewBag.SearchMode = true;
            return View("QuizList", quizzes);
        }
    }
}
