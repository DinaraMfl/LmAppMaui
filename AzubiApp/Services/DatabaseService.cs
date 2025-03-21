using AzubiApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AzubiApp.Services
{
    public class DatabaseService
    {
        private readonly QuizDbContext _context;

        public DatabaseService(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetShuffledQuestionsAsync(int numberOfQuestions = 15)
        {
            return await _context.QuestionsCatalog 
                .OrderBy(q => EF.Functions.Random()) // Database level shufflingxc
                .Take(numberOfQuestions)
                .ToListAsync();
        }
    }
}
