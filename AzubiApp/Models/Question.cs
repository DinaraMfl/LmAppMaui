using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzubiApp.Models
{
    [Table("QuestionsCatalog")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Text { get; set; }
        public required string Answer1 { get; set; }
        public required string Answer2 { get; set; }
        public required string Answer3 { get; set; }
        public required string CorrectAnswers { get; set; } // Store the correct answer(s) separated by a separator, for example, "|"
    }
}
