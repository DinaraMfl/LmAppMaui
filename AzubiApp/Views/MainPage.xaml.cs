using AzubiApp.Services;
using AzubiApp.Models;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace AzubiApp.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseService _database;

        public MainPage()
        {
            InitializeComponent();
            _database = new DatabaseService();  // Инициализация базы данных

            // Заполняем базу данных при старте приложения
            Task.Run(async () => await SeedData.Initialize(_database)).Wait();
        }

        private async void OnStartQuizClicked(object sender, EventArgs e)
        {
            List<Question> questions = await _database.GetShuffledQuestionsAsync(); // Загружаем вопросы
            if (questions.Count == 0)
            {
                await DisplayAlert("Ошибка", "Нет доступных вопросов!", "OK");
                return;
            }

            await Navigation.PushAsync(new QuizPage(questions)); // Передаем вопросы в QuizPage
        }
    }
}
