using System.ComponentModel.DataAnnotations;

namespace CrazyQuiz.Models
{
    public class Question
    {
        // Cheia primară pentru întrebare
        [Key]
        public int QuestionId { get; set; }

        // Textul întrebării
        [Required]
        [StringLength(200)]
        public string Text { get; set; }

        // Cheia externă pentru quiz-ul căruia îi aparține întrebarea
        [Required]
        public int QuizId { get; set; }

        public Quiz? Quiz { get; set; }

        // Relație de tip "one-to-many": o întrebare poate avea mai multe răspunsuri
        public ICollection<Answer>? Answers { get; set; }
    }
}
