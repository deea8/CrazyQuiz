using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CrazyQuiz.Models;
using System.Reflection.Emit;

namespace CrazyQuiz.Models
{
    public class CrazyQuizContext : IdentityDbContext<User>
    {
        public CrazyQuizContext(DbContextOptions<CrazyQuizContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(180);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Answer>? Answers { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Quiz>? Quizzes { get; set; }
        public DbSet<QuizResult>? QuizResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder); 
        }
    }
}
