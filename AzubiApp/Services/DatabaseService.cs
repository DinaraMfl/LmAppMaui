using SQLite;
using AzubiApp.Models;

namespace AzubiApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;
        private int _currentDifficultyLevel = 1;

        public DatabaseService()
        {
            string appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dbPath = Path.Combine(appDataDirectory, "quiz.db");

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Question>().Wait();

            // Check if the NEW_COLUMN column exists, and add it if it doesn't
            /* var tableInfo = _database.GetTableInfoAsync("Question").Result;
            if (!tableInfo.Any(x => x.Name == "NEW_COLUMN"))
            {
                _database.ExecuteAsync("ALTER TABLE Question ADD COLUMN NEW_COLUMN INTEGER NOT NULL DEFAULT 0").Wait();
            } */

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

        public async Task<List<Question>> GetQuestionsForLanguageAsync(string languageCode, int numberOfQuestions = 15)
        {
            var questions = await GetShuffledQuestionsAsync(numberOfQuestions);
            return questions.Where(q =>
                (languageCode == "de" && !string.IsNullOrWhiteSpace(q.TextDe)) ||
                (languageCode == "en" && !string.IsNullOrWhiteSpace(q.TextEn))
            ).ToList();
        }

        public async Task<List<Question>> GetShuffledQuestionsAsync(int numberOfQuestions = 15)
        {
            while (true)
            {
                var questions = await _database.QueryAsync<Question>($@"
                SELECT * FROM Question
                WHERE DifficultyLevel = {_currentDifficultyLevel}
                AND NOT (Points = {Question.MaxPoints} AND Level = 0)
                ORDER BY Level DESC, RANDOM()
                LIMIT {numberOfQuestions}");

                if (questions.Count > 0)
                {
                    return questions;
                }
                else
                {
                    _currentDifficultyLevel++;

                    var countNextLevel = await _database.ExecuteScalarAsync<int>($@"
                    SELECT COUNT(*) FROM Question
                    WHERE DifficultyLevel = {_currentDifficultyLevel}");

                    if (countNextLevel == 0)
                    {
                        return new List<Question>();
                    }
                }
            }
        }

        public Task<int> AddQuestionAsync(Question question)
        {
            return _database.InsertAsync(question);
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _database.Table<Question>().ToListAsync();
        }

        public async Task UpdateQuestionAsync(Question question)
        {
            await _database.UpdateAsync(question);
        }

        public async Task UpdateQuestionStatsAsync(List<(int QuestionId, bool IsCorrect)> results)
        {
            foreach (var result in results)
            {
                var question = await _database.Table<Question>().Where(q => q.Id == result.QuestionId).FirstOrDefaultAsync();
                if (question != null)
                {
                    if (result.IsCorrect)
                    {
                        if (question.Points == Question.MaxPoints && question.Level != 0)
                        {
                            question.Level = Math.Max(0, question.Level - 1);
                        } 
                        else 
                        {
                            question.Points = Math.Max(0, question.Points + 1);
                            question.Level = Math.Max(0, question.Level - 1);
                        }
                    }
                    else // if result.IsFalse
                    {
                        question.Level = Math.Min(Question.MaxLevel, question.Level + 1);
                    }
                    await UpdateQuestionAsync(question);
                }
            }
        }

        public async Task ClearUserProgressAsync()
        {
            var questions = await _database.Table<Question>().ToListAsync();
            foreach (var question in questions)
            {
                question.Points = 0;
                await _database.UpdateAsync(question);
            }
        }

        public void ResetCurrentDifficultyLevel()
        {
            _currentDifficultyLevel = 1;
        }
    }
}