using Microsoft.EntityFrameworkCore;
using AzubiApp.Models;

namespace AzubiApp.Services
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Question> QuestionsCatalog { get; set; }

        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string dbPath = Path.Combine(FileSystem.AppDataDirectory, "QuestionsCatalog.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
            }
        }
    }
}
