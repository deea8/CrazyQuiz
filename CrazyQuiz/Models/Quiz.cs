using System.ComponentModel.DataAnnotations;

namespace CrazyQuiz.Models
{
    public enum QuizDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    public class Quiz
    {
        // Cheia primară pentru quiz
        [Key]
        public int QuizId { get; set; }

        // Titlul quiz-ului
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        // Descrierea quiz-ului
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        // Durata quiz-ului
        [Required]
        public int Duration { get; set; }

        // Cheia externă pentru categoria din care face parte quiz-ul
        [Required]
        public int CategoryId { get; set; }

        // Relație de tip "many-to-one": un quiz aparține unei singure categorii
        public Category? Category { get; set; }

        [Required]
        public QuizDifficulty Difficulty { get; set; }

        // Relație de tip "one-to-many": un quiz poate conține mai multe întrebări
        public ICollection<Question>? Questions { get; set; }

    }
}
