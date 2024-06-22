using Microsoft.AspNetCore.Identity;


namespace CrazyQuiz.Models
{
    public class User : IdentityUser
    {

        // Relație de tip "one-to-many": un utilizator poate avea mai multe rezultate de quiz
        public ICollection<QuizResult>? QuizResults { get; set; }
    }
}