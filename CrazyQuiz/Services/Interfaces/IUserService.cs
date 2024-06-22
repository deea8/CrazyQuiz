using CrazyQuiz.Models;
using Microsoft.AspNetCore.Identity;

namespace CrazyQuiz.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(string userId);
        
    }
}
