using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CrazyQuiz.Models;
using CrazyQuiz.Services.Interfaces;
using CrazyQuiz.ViewModels;
using CrazyQuiz.Services;
using Microsoft.AspNetCore.Authorization;

namespace CrazyQuiz.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class AdminController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IQuizService _quizService;

        public AdminController(IQuestionService questionService, IAnswerService answerService, IQuizService quizService)
        {
            _questionService = questionService;
            _answerService = answerService;
            _quizService = quizService;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult AdminDashboard()
        {
            var viewModel = new AdminDashboardViewModel
            {
                Quiz = new Quiz(),
                Question = new Question(),
                Answer = new Answer(),
                QuizList = new SelectList(_quizService.GetAllQuizzes(), "QuizId", "Title"),
                QuestionList = new SelectList(_questionService.GetAllQuestions(), "QuestionId", "Text")
            };

            return View(viewModel);
        }

        public IActionResult ManageQuestions()
        {
            var questions = _questionService.GetAllQuestionsWithQuiz();
            return View(questions);
        }

        public IActionResult DetailsQuestion(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
                return NotFound();

            return View(question);
        }

        public IActionResult CreateQuestion()
        {
            ViewBag.QuizList = new SelectList(_quizService.GetAllQuizzes(), "QuizId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                _questionService.CreateQuestion(question);
                return RedirectToAction(nameof(ManageQuestions));
            }

            ViewBag.QuizList = new SelectList(_quizService.GetAllQuizzes(), "QuizId", "Title");
            return View(question);
        }

        public IActionResult EditQuestion(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
                return NotFound();

            ViewBag.QuizList = new SelectList(_quizService.GetAllQuizzes(), "QuizId", "Title", question.QuizId);
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditQuestion(int id, Question question)
        {
            if (ModelState.IsValid)
            {
                _questionService.UpdateQuestion(question);
                return RedirectToAction(nameof(ManageQuestions));
            }

            ViewBag.QuizList = new SelectList(_quizService.GetAllQuizzes(), "QuizId", "Title", question.QuizId);
            return View(question);
        }

        public IActionResult DeleteQuestion(int id)
        {
            var question = _questionService.GetQuestionById(id);
            if (question == null)
                return NotFound();

            return View(question);
        }

        [HttpPost, ActionName("DeleteQuestion")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteQuestionConfirmed(int id)
        {
            _questionService.DeleteQuestion(id);
            return RedirectToAction(nameof(ManageQuestions));
        }

        public IActionResult ManageAnswers()
        {
            var answers = _answerService.GetAllAnswersWithQuestion();
            return View(answers);
        }

        public IActionResult DetailsAnswer(int id)
        {
            var answer = _answerService.GetAnswerById(id);
            if (answer == null)
                return NotFound();

            return View(answer);
        }

        public IActionResult CreateAnswer()
        {
            ViewBag.QuestionList = new SelectList(_questionService.GetAllQuestions(), "QuestionId", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnswer(Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerService.CreateAnswer(answer);
                return RedirectToAction(nameof(ManageAnswers));
            }

            ViewBag.QuestionList = new SelectList(_questionService.GetAllQuestions(), "QuestionId", "Text");
            return View(answer);
        }

        public IActionResult EditAnswer(int id)
        {
            var answer = _answerService.GetAnswerById(id);
            if (answer == null)
                return NotFound();

            ViewBag.QuestionList = new SelectList(_questionService.GetAllQuestions(), "QuestionId", "Text", answer.QuestionId);
            return View(answer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAnswer(int id, Answer answer)
        {
            if (ModelState.IsValid)
            {
                _answerService.UpdateAnswer(answer);
                return RedirectToAction(nameof(ManageAnswers));
            }

            ViewBag.QuestionList = new SelectList(_questionService.GetAllQuestions(), "QuestionId", "Text", answer.QuestionId);
            return View(answer);
        }

        public IActionResult DeleteAnswer(int id)
        {
            var answer = _answerService.GetAnswerById(id);
            if (answer == null)
                return NotFound();

            return View(answer);
        }

        [HttpPost, ActionName("DeleteAnswer")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAnswerConfirmed(int id)
        {
            _answerService.DeleteAnswer(id);
            return RedirectToAction(nameof(ManageAnswers));
        }
    }
}
