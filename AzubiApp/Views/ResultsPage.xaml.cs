using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class ResultsPage : ContentPage
    {
        public ResultsPage(List<List<string>> userAnswers, List<Question> questions)
        {
            InitializeComponent();
            ShowResults(userAnswers, questions);
        }

        private void ShowResults(List<List<string>> userAnswers, List<Question> questions)
        {
            ResultsLayout.Children.Clear(); // Теперь `ResultsLayout` существует!

            for (int i = 0; i < questions.Count; i++)
            {
                var question = questions[i];
                var correctAnswers = question.CorrectAnswers.Split("| ").ToList();
                var userSelected = userAnswers[i];

                bool isCorrect = correctAnswers.All(userSelected.Contains) && correctAnswers.Count == userSelected.Count;

                var resultText = new Label
                {
                    Text = isCorrect ? "✅ Верно" : "❌ Ошибка",
                    TextColor = isCorrect ? Colors.Green : Colors.Red,
                    FontSize = 18
                };

                var questionText = new Label
                {
                    Text = $"Вопрос {i + 1}: {question.Text}",
                    FontAttributes = FontAttributes.Bold
                };

                var userAnswerText = new Label
                {
                    Text = $"Ваш ответ: {string.Join(", ", userSelected)}",
                    TextColor = Colors.Blue
                };

                var correctAnswerText = new Label
                {
                    Text = $"Правильный ответ: {string.Join(", ", correctAnswers)}",
                    TextColor = Colors.Green
                };

                ResultsLayout.Children.Add(questionText);
                ResultsLayout.Children.Add(userAnswerText);
                ResultsLayout.Children.Add(correctAnswerText);
                ResultsLayout.Children.Add(resultText);
            }
        }
    }
}
