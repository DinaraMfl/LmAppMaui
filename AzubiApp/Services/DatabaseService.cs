using SQLite;
using AzubiApp.Models;

namespace AzubiApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = Path.Combine(appDataDirectory, "quiz.db");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Question>().Wait();

            // Open the file (for example, to read its contents)
            try
            {
                using (StreamReader reader = new StreamReader(dbPath))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        // Method to clear the database (need to be called in SeedData)
        public async Task ClearQuestionsAsync()
        {
            await _database.DeleteAllAsync<Question>();
        }

        public async Task<List<Question>> GetShuffledQuestionsAsync()
        {
            var questions = await _database.Table<Question>().ToListAsync();
            return questions.OrderBy(q => Guid.NewGuid()).ToList(); //  Randomize the list of questions
        }

        public Task<int> AddQuestionAsync(Question question)
        {
            return _database.InsertAsync(question);
        }
    }
}
