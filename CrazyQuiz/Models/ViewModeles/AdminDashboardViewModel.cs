using System.Collections.Generic;
using CrazyQuiz.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrazyQuiz.ViewModels
{
    public class AdminDashboardViewModel
    {
        public Quiz Quiz { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }
        public SelectList QuizList { get; set; }
        public SelectList QuestionList { get; set; }
    }
}
