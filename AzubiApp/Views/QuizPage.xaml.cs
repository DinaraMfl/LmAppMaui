using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;
using AzubiApp.Models;

namespace AzubiApp.Views
{
    public partial class QuizPage : ContentPage
    {
        private readonly List<Question> _questions;
        private int _currentIndex = 0;
        private readonly List<List<string>> _selectedAnswers = new();
        private List<string> _currentSelectedAnswers;
        private Dictionary<CheckBox, Label> _answerMap;
        private List<string> _shuffledAnswers;

        public QuizPage(List<Question> questions)
        {
            InitializeComponent();

            if (questions == null || questions.Count == 0)
            {
                DisplayAlert("Ошибка", "Список вопросов пуст. Проверьте базу данных!", "ОК");
                return;
            }

            _questions = questions.OrderBy(q => Guid.NewGuid()).ToList(); // Перемешивание вопросов
            _currentSelectedAnswers = new List<string>();
            _selectedAnswers.Clear();
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_currentIndex >= _questions.Count)
            {
                Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions));
                return;
            }

            var question = _questions[_currentIndex];

            // Устанавливаем текст вопроса
            QuestionLabel.Text = question.Text;

            // Перемешивание ответов
            _shuffledAnswers = new List<string> { question.Answer1, question.Answer2, question.Answer3 }
                .OrderBy(a => Guid.NewGuid()).ToList();

            Answer1Text.Text = _shuffledAnswers[0];
            Answer2Text.Text = _shuffledAnswers[1];
            Answer3Text.Text = _shuffledAnswers[2];

            // Сбрасываем чекбоксы
            Answer1.IsChecked = false;
            Answer2.IsChecked = false;
            Answer3.IsChecked = false;

            _answerMap = new Dictionary<CheckBox, Label>
            {
                { Answer1, Answer1Text },
                { Answer2, Answer2Text },
                { Answer3, Answer3Text }
            };

            _currentSelectedAnswers.Clear();
        }

        private void OnAnswerChecked(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox == null || !_answerMap.ContainsKey(checkBox)) return;

            string selectedText = _answerMap[checkBox].Text;

            if (e.Value)
            {
                if (!_currentSelectedAnswers.Contains(selectedText))
                {
                    _currentSelectedAnswers.Add(selectedText);
                }
            }
            else
            {
                _currentSelectedAnswers.Remove(selectedText);
            }
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (_currentSelectedAnswers.Count == 0)
            {
                await DisplayAlert("Ошибка", "Выберите хотя бы один ответ!", "ОК");
                return;
            }

            _selectedAnswers.Add(new List<string>(_currentSelectedAnswers));

            _currentIndex++;

            if (_currentIndex <= _questions.Count)
            {
                ShowQuestion();
            }
            else
            {
                await Navigation.PushAsync(new ResultsPage(_selectedAnswers, _questions));
            }
        }
    }
}
