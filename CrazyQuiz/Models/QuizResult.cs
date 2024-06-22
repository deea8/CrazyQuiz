using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CrazyQuiz.Models
{
    public class QuizResult
    {
        // Cheia primară pentru rezultatul quiz-ului pentru utilizator
        [Key]
        public int QuizResultId { get; set; }
        public string UserId { get; set; }
        // Utilizatorul căruia îi aparține rezultatul quiz-ului
        public User User { get; set; }

        // Cheia externă pentru quiz-ul la care se referă rezultatul
        [Required]
        public int QuizId { get; set; }

        // Quiz-ul la care se referă rezultatul
        public Quiz? Quiz { get; set; }

        // Numărul de întrebări corect răspunse
        [Required]
        public int CorrectAnswers { get; set; }

        // Numărul de întrebări incorect răspunse
        [Required]
        public int IncorrectAnswers { get; set; }
        
        [Required]
        public int TotalQuestions { get; set; }

        // Scorul obținut în quiz
        [Required]
        public int Score { get; set; }

        // Data și ora la care a fost completat quiz-ul
        public DateTime CompletionTime { get; set; }
    }
}
