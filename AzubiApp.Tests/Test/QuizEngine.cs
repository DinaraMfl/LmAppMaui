public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<string> CorrectAnswers { get; set; }
    public List<string> AllAnswers { get; set; }
}

public class QuizEngine
{
    private readonly List<Question> _questions;
    private readonly Dictionary<int, int> _correctStreaks = new();
    private readonly int _removeAfterCorrectStreak;

    public QuizEngine(List<Question> questions, int removeAfterCorrectStreak = 3)
    {
        _questions = questions;
        _removeAfterCorrectStreak = removeAfterCorrectStreak;
        foreach (var q in _questions)
        {
            _correctStreaks[q.Id] = 0;
        }
    }

    public bool CheckAnswer(int questionId, List<string> givenAnswers)
    {
        var question = _questions.Find(q => q.Id == questionId);
        if (question == null) throw new ArgumentException("Question not found");

        bool isCorrect = question.CorrectAnswers.Count == givenAnswers.Count &&
                         !question.CorrectAnswers.Except(givenAnswers).Any();

        if (isCorrect)
        {
            _correctStreaks[questionId]++;
            if (_correctStreaks[questionId] >= _removeAfterCorrectStreak)
            {
                RemoveQuestion(questionId);
            }
        }
        else
        {
            _correctStreaks[questionId] = 0; 
        }

        return isCorrect;
    }



    private void RemoveQuestion(int questionId)
    {
        var question = _questions.Find(q => q.Id == questionId);
        if (question != null)
            _questions.Remove(question);
        _correctStreaks.Remove(questionId);
    }

    public int QuestionsCount => _questions.Count;
}
