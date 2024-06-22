using System.ComponentModel.DataAnnotations;

namespace CrazyQuiz.Models
{
    public class Answer
    {
        // Cheia primară pentru răspuns
        [Key]
        public int AnswerId { get; set; }

        // Textul răspunsului
        [Required]
        [StringLength(100)]
        public string Text { get; set; }

        // Indică dacă răspunsul este corect sau nu
        [Required]
        public bool IsCorrect { get; set; }

        // Cheia externă pentru întrebarea la care se referă răspunsul
        [Required]
        public int QuestionId { get; set; }

        // Relație de tip "many-to-one": un răspuns aparține unei singure întrebări
        public Question? Question { get; set; }
    }
}

