using System.ComponentModel.DataAnnotations;

namespace CrazyQuiz.Models
{
    public class Category
    {
        // Cheia primară pentru categorie
        [Key]
        public int CategoryId { get; set; }

        // Numele categoriei
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        // Relație de tip "one-to-many": o categorie poate avea mai multe quiz-uri
        public ICollection<Quiz>? Quizzes { get; set; }
    }
}

