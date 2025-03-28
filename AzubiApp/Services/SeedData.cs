using AzubiApp.Models;

namespace AzubiApp.Services
{
    public static class SeedData
    {
        public static async Task Initialize(DatabaseService database)
        {
            var existingQuestions = await database.GetAllQuestionsAsync();

            var newQuestions = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    Text = "Was passiert, wenn die Option „Heute bestellen“ ausgewählt wurde?",
                    Answer1 = "Bestellungen werden auf den heutigen Tag vorgezogen",
                    Answer2 = "Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf",
                    Answer3 = "Es werden zusätzliche Bestellvorschläge für heute generiert",
                    CorrectAnswers = "Bestellungen werden auf den heutigen Tag vorgezogen| Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf"
                },
                new Question
                {
                    Id = 2,
                    Text = "Welche Funktion hat der Planungshorizont?",
                    Answer1 = "Er zeigt den letzten Bestellvorschlag an",
                    Answer2 = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",
                    Answer3 = "Er zeigt den Zeitraum an in die Planwerte eingestellt wurden",
                    CorrectAnswers = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können"
                },
                new Question
                {
                    Id = 3,
                    Text = "Wie wird der Planungshorizont berechnet?",
                    Answer1 = "HEUTE + Eingetragener Planungshorizont in Werktagen",
                    Answer2 = "Nächster Bestelltag + Eingetragener Planungshorizont",
                    Answer3 = "HEUTE + Eingetragener Planungshorizont in Kalendertagen",
                    CorrectAnswers = "HEUTE + Eingetragener Planungshorizont in Kalendertagen"
                },
                new Question
                {
                    Id = 4,
                    Text = "Mit welcher Periodenlänge hat man die niedrigste Standardabweichung bei der Prognose?",
                    Answer1 = "Tagesperiode",
                    Answer2 = "Wochenperiode",
                    Answer3 = "Monatsperiode",
                    CorrectAnswers = "Monatsperiode"
                },
                new Question
                {
                    Id = 5,
                    Text = "Was passiert beim Berechnungstyp „nur Prognose, nicht disponieren“?",
                    Answer1 = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo",
                    Answer2 = "Es wird eine Prognose gerechnet & Bestellvorschläge generiert",
                    Answer3 = "Es wird nur eine Prognose und Reichweite berechnet",
                    CorrectAnswers = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo"
                },
            };

            foreach (var question in newQuestions)
            {
                if (!existingQuestions.Any(q => q.Text == question.Text))
                {
                    await database.AddQuestionAsync(question);
                }
            }
        }
    }
}

