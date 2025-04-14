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

                    TextDe = "Was passiert, wenn die Option „Heute bestellen“ ausgewählt wurde?",
                    Answer1De = "Bestellungen werden auf den heutigen Tag vorgezogen",
                    Answer2De = "Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf",
                    Answer3De = "Es werden zusätzliche Bestellvorschläge für heute generiert",
                    CorrectAnswersDe = "Bestellungen werden auf den heutigen Tag vorgezogen| Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf",

                    TextEn = "What happens if the “Order Now” option is selected?",
                    Answer1En = "Orders will be brought forward to today",
                    Answer2En = "Order quantities are reduced where possible, depending on demand",
                    Answer3En = "Additional order proposals are generated for today",
                    CorrectAnswersEn = "Orders will be brought forward to today| Order quantities are reduced where possible, depending on demand",

                    QuizCategory = new List<string> { "Bestellung", "Filter", "Allgemein" }
                },

                new Question
                {
                    Id = 2,

                    TextDe = "Welche Funktion hat der Planungshorizont?",
                    Answer1De = "Er zeigt den letzten Bestellvorschlag an",
                    Answer2De = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",
                    Answer3De = "Er zeigt den Zeitraum an in die Planwerte eingestellt wurden",
                    CorrectAnswersDe = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",

                    TextEn = "What is the function of the planning horizon?",
                    Answer1En = "It displays the last order proposal",
                    Answer2En = "It shows the period in which order proposals can be generated",
                    Answer3En = "It shows the period in which the planned values were set",
                    CorrectAnswersEn = "It shows the period in which order proposals can be generated",

                    QuizCategory = new List<string> { "Parameter" }

                },

                new Question
                {
                    Id = 3,

                    TextDe = "Wie wird der Planungshorizont berechnet?",
                    Answer1De = "HEUTE + Eingetragener Planungshorizont in Werktagen",
                    Answer2De = "Nächster Bestelltag + Eingetragener Planungshorizont",
                    Answer3De = "HEUTE + Eingetragener Planungshorizont in Kalendertagen",
                    CorrectAnswersDe = "HEUTE + Eingetragener Planungshorizont in Kalendertagen",

                    TextEn = "How is the planning horizon calculated?",
                    Answer1En = "TODAY + Entered planning horizon in working days",
                    Answer2En = "Next order date + entered planning horizon",
                    Answer3En = "TODAY + Entered planning horizon in calendar days",
                    CorrectAnswersEn = "TODAY + Entered planning horizon in calendar days",

                    QuizCategory = new List<string> { "Parameter" }

                },

                new Question
                {
                    Id = 4,

                    TextDe = "Mit welcher Periodenlänge hat man die niedrigste Standardabweichung bei der Prognose?",
                    Answer1De = "Tagesperiode",
                    Answer2De = "Wochenperiode",
                    Answer3De = "Monatsperiode",
                    CorrectAnswersDe = "Monatsperiode",

                    TextEn = "Which period length has the lowest standard deviation in the forecast?",
                    Answer1En = "Day period",
                    Answer2En = "Weekly period",
                    Answer3En = "Monthly period",
                    CorrectAnswersEn = "Monthly period",

                    QuizCategory = new List<string> { "Prognose" }

                },

                new Question
                {
                    Id = 5,

                    TextDe = "Was passiert beim Berechnungstyp „nur Prognose, nicht disponieren“?",
                    Answer1De = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo",
                    Answer2De = "Es wird eine Prognose gerechnet & Bestellvorschläge generiert",
                    Answer3De = "Es wird nur eine Prognose und Reichweite berechnet",
                    CorrectAnswersDe = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo",

                    TextEn = "What happens with the “forecast only, not planning” calculation type?",
                    Answer1En = "Only a forecast is calculated, but no dispo",
                    Answer2En = "A forecast is calculated & order proposals are generated",
                    Answer3En = "Only one forecast and range is calculated",
                    CorrectAnswersEn = "Only a forecast is calculated, but no dispo",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                },

                new Question
                {
                    Id = 6,

                    TextDe = "Welche Funktion hat die „Max. Reichweite“ in den Parametern?",
                    Answer1De = "Die Max. Reichweite gibt an wie lange die Lieferroute von Lager bis Filiale sein darf",
                    Answer2De = "Das dort die Out-of-Stock Bereinigung stattfindet",
                    Answer3De = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten im diesen Zeitraum",
                    CorrectAnswersDe = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten im diesen Zeitraum",

                    TextEn = "What is the function of the “Max. coverage” in the parameters?",
                    Answer1En = "The max. coverage indicates how long the delivery route from the warehouse to the store may be",
                    Answer2En = "That the out-of-stock cleanup takes place there",
                    Answer3En = "The max. coverage (quantity) limits the stock of a SKU to x days without expecting another order in this period",
                    CorrectAnswersEn = "The max. coverage (quantity) limits the stock of a SKU to x days without expecting another order in this period",

                    QuizCategory = new List<string> { "Parameter" }
                },

                new Question
                {
                    Id = 7,

                    TextDe = "Warum kriegt man eine OoS-Warnmeldung?",
                    Answer1De = "Weil eine SKU keine Bestandsdaten hat",
                    Answer2De = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist",
                    Answer3De = "Weil ein Standort seinen Bestand aufgebraucht hat",
                    CorrectAnswersDe = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist",

                    TextEn = "Why do I get an OoS warning message?",
                    Answer1En = "Because an SKU has no inventory data",
                    Answer2En = "If I have a stock of 0 but the demand is > 0",
                    Answer3En = "Because a location has used up its stock",
                    CorrectAnswersEn = "If I have a stock of 0 but the demand is > 0",

                    QuizCategory = new List<string> { "Prognose" }
                },

                new Question
                {
                    Id = 8,

                    TextDe = "Wie kann ich das Gütekriterium ändern?",
                    Answer1De = "Parameter>Dispo>Bestellmenge",
                    Answer2De = "Konditionen>Lieferant>Lieferantenpriorität",
                    Answer3De = "Parameter>Vorgabe>Saison verwenden von",
                    CorrectAnswersDe = "Parameter>Dispo>Bestellmenge",

                    TextEn = "How can I change the quality criterion?",
                    Answer1En = "Parameter>Dispo>Order quantity",
                    Answer2En = "Conditions>Supplier>Supplier priority",
                    Answer3En = "Parameter>Default>Use season from",
                    CorrectAnswersEn = "Parameter>Dispo>Order quantity",

                    QuizCategory = new List<string> { "Parameter" }
                },

                new Question
                {
                    Id = 9,

                    TextDe = "Was passiert beim Berechnungstyp „standard, Prognose + Dispo“?",
                    Answer1De = "Es wird nur eine Prognose ohne Dispo gerechnet",
                    Answer2De = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt",
                    Answer3De = "Es wird keine Prognose und keine Dispo gerechnet",
                    CorrectAnswersDe = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt",

                    TextEn = "What happens with the “standard, forecast + replenishment” calculation type?",
                    Answer1En = "Only a forecast without overdraft is calculated",
                    Answer2En = "Both a forecast and an overdraft calculation are carried out",
                    Answer3En = "No forecast and no dispo is calculated",
                    CorrectAnswersEn = "Both a forecast and an overdraft calculation are carried out",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                },

                new Question
                {
                    Id = 10,

                    TextDe = "Was passiert beim Berechnungstyp „nicht bestellen, mit Bestand-Sim“?",
                    Answer1De = "Es werden keine Bestellvorschläge generiert, wenn es eine Bestandsimulation gibt",
                    Answer2De = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",
                    Answer3De = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    CorrectAnswersDe = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",

                    TextEn = "What happens with the “No replenishment, do simulation” calculation type?",
                    Answer1En = "No order proposals are generated if there is a stock simulation",
                    Answer2En = "No order proposals & stock simulation are generated",
                    Answer3En = "No order proposals are generated, but a stock simulation is generated",
                    CorrectAnswersEn = "No order proposals are generated, but a stock simulation is generated",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                },            
            };

            foreach (var question in newQuestions)
            {
                if (!existingQuestions.Any(q => q.Id == question.Id))
                {
                    await database.AddQuestionAsync(question);
                }
            }
        }
    }
}

