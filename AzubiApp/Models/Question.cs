using SQLite;

namespace AzubiApp.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string CorrectAnswers { get; set; } // Храним правильный ответ в виде текста
    }
}
