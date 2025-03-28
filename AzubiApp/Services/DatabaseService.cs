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

        public async Task<List<Question>> GetShuffledQuestionsAsync(int numberOfQuestions = 15)
        { 
            var query = $"SELECT * FROM Question ORDER BY RANDOM() LIMIT {numberOfQuestions}";
            return await _database.QueryAsync<Question>(query);
        }

        public Task<int> AddQuestionAsync(Question question)
        {
            return _database.InsertAsync(question);
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _database.Table<Question>().ToListAsync();
        }

    }
}