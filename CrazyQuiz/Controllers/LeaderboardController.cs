using CrazyQuiz.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrazyQuiz.Controllers
{
    public class LeaderboardController : Controller
    {
        private readonly IQuizResultService _quizResultService;
        private readonly IUserService _userService;

        public LeaderboardController(IQuizResultService quizResultService, IUserService userService)
        {
            _quizResultService = quizResultService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            // Obține toate rezultatele quiz-urilor
            var allQuizResults = _quizResultService.GetAllQuizResults();

            // Calculează scorul total pentru fiecare utilizator
            var leaderboardResults = allQuizResults
                .GroupBy(r => r.UserId)
                .Select(group => new
                {
                    UserId = group.Key,
                    Score = group.Sum(r => r.Score)
                })
                .OrderByDescending(result => result.Score)
                .Take(10) // Ia primele 10 rezultate pentru leaderboard
                .ToList();

            // Trimite rezultatele către view
            return View(leaderboardResults);
        }

        public IActionResult UserResults(string userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            var userResults = _quizResultService.GetQuizResultsByUser(userId);

            return View(userResults);
        }
    }
}
