using System.Collections.Generic;
using Xunit;

public class QuizEngineTests
{
    [Fact]
    public void CheckAnswer_CorrectAnswer_IncreasesStreak()
    {
        var questions = new List<Question>
        {
            new Question
            {
                Id = 1,
                Text = "Capital of France?",
                CorrectAnswers = new List<string> { "Paris" },
                AllAnswers = new List<string> { "Paris", "London", "Berlin" }
            }
        };

        var engine = new QuizEngine(questions, removeAfterCorrectStreak: 3);

        Assert.True(engine.CheckAnswer(1, new List<string> { "Paris" }));
        Assert.True(engine.CheckAnswer(1, new List<string> { "Paris" }));
        Assert.True(engine.CheckAnswer(1, new List<string> { "Paris" }));

        Assert.Equal(0, engine.QuestionsCount);
    }


    [Fact]
    public void QuestionRemovedAfterCorrectStreak()
    {
        var questions = new List<Question>
        {
            new Question { Id = 3, Text = "Test", CorrectAnswers = new List<string> { "C" }, AllAnswers = new List<string> { "A", "B", "C" } }
        };
        var engine = new QuizEngine(questions, removeAfterCorrectStreak: 2);

        Assert.True(engine.CheckAnswer(3, new List<string> { "C" }));
        Assert.True(engine.CheckAnswer(3, new List<string> { "C" }));

        Assert.Equal(0, engine.QuestionsCount);
    }


    [Fact]
    public void CheckAnswer_WrongAnswer_ResetsStreak()
    {
        var questions = new List<Question>
        {
            new Question
            {
                Id = 2,
                Text = "Capital of Germany?",
                CorrectAnswers = new List<string> { "Berlin" },
                AllAnswers = new List<string> { "Paris", "London", "Berlin" }
            }
        };

        var engine = new QuizEngine(questions, removeAfterCorrectStreak: 2);

        Assert.False(engine.CheckAnswer(2, new List<string> { "Paris" }));
        Assert.True(engine.CheckAnswer(2, new List<string> { "Berlin" }));
        Assert.True(engine.CheckAnswer(2, new List<string> { "Berlin" }));


        Assert.Equal(0, engine.QuestionsCount);
    }
}
