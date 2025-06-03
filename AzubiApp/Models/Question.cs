using SQLite;

namespace AzubiApp.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Number { get; set; }

        // Deutsch
        public string TextDe { get; set; }
        public string Answer1De { get; set; }
        public string Answer2De { get; set; }
        public string Answer3De { get; set; }
        public string CorrectAnswersDe { get; set; } // Store the correct answer as text

        // English
        public string TextEn { get; set; }
        public string Answer1En { get; set; }
        public string Answer2En { get; set; }
        public string Answer3En { get; set; }
        public string CorrectAnswersEn { get; set; }

        public int Level { get; set; } = 0; // 1 false -> Level + 1
        public int Points { get; set; } = 0; // 1 true -> Level - 1 AND Point + 1   -->    if Points == 3 AND Level == 0 -> "hide" questions. Points for progress

        public string CategoriesSerialized
        {
            get => string.Join(";", QuizCategory);
            set => QuizCategory = string.IsNullOrWhiteSpace(value) ? new List<string>() : value.Split(';').ToList();
        }

        [Ignore]
        public List<string> QuizCategory { get; set; } = new List<string>(); // Category of the question

        public const int MaxLevel = 3;
        public const int MaxPoints = 3;

        public bool IsMaxPoints() => Points >= MaxPoints;
        public bool IsMaxLevel() => Level >= MaxLevel;
    }
}