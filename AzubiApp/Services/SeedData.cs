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
                new Question
                {
                    Id = 6,
                    Text = "Welche Funktion hat die „Max. Reichweite“ in den Parametern?",
                    Answer1 = "Die Max. Reichweite gibt an wie lange die Lieferroute von Lager bis Filiale sein darf",
                    Answer2 = "Das dort die Out-of-Stock Bereinigung stattfindet",
                    Answer3 = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten im diesen Zeitraum",
                    CorrectAnswers = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten im diesen Zeitraum"
                },
                new Question
                {
                    Id = 7,
                    Text = "Warum kriegt man eine OoS-Warnmeldung?",
                    Answer1 = "Weil eine SKU keine Bestandsdaten hat",
                    Answer2 = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist",
                    Answer3 = "Weil ein Standort seinen Bestand aufgebraucht hat",
                    CorrectAnswers = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist"
                },
                new Question
                {
                    Id = 8,
                    Text = "Wie kann ich das Gütekriterium ändern?",
                    Answer1 = "Parameter>Dispo>Bestellmenge",
                    Answer2 = "Konditionen>Lieferant>Lieferantenpriorität",
                    Answer3 = "Parameter>Vorgabe>Saison verwenden von",
                    CorrectAnswers = "Parameter>Dispo>Bestellmenge"
                },
                new Question
                {
                    Id = 9,
                    Text = "Was passiert beim Berechnungstyp „standard, Prognose + Dispo“?",
                    Answer1 = "Es wird nur eine Prognose ohne Dispo gerechnet",
                    Answer2 = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt",
                    Answer3 = "Es wird keine Prognose und keine Dispo gerechnet",
                    CorrectAnswers = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt"
                },
                new Question
                {
                    Id = 10,
                    Text = "Was passiert beim Berechnungstyp „nicht bestellen, mit Bestand-Sim“?",
                    Answer1 = "Es werden keine Bestellvorschläge generiert, wenn es eine Bestandsimulation gibt",
                    Answer2 = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",
                    Answer3 = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    CorrectAnswers = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert"
                },
                new Question
                {
                    Id = 11,
                    Text = "Was passiert beim Berechnungstyp „nicht bestellen, ohne Bestand-Sim“?",
                    Answer1 = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    Answer2 = "Es werden keine Bestellvorschläge generiert, wenn es keine Bestandsimulation gibt",
                    Answer3 = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    CorrectAnswers = "Es werden keine Bestellvorschläge & Bestandssimulation generiert"
                },
                new Question
                {
                    Id = 12,
                    Text = "Was passiert beim Berechnungstyp „Bestellmenge nullen vor Abfüllen“?",
                    Answer1 = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0",
                    Answer2 = "Es werden Bestellungen mit einer Bestellmenge von 0 entfernt",
                    Answer3 = "Bestellungen werden nachträglich mit einer Bestellmenge von 0 ersetzt",
                    CorrectAnswers = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0"
                },
                new Question
                {
                    Id = 13,
                    Text = "Was macht die Optimierungs-Einheit?",
                    Answer1 = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll",
                    Answer2 = "Die Optimierungs-Einheit zeigt an welche Einheit manuell angepasst werden soll",
                    Answer3 = "Bestellungen werden mit dieser Einheit getätigt",
                    CorrectAnswers = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll| Bestellungen werden mit dieser Einheit getätigt"
                },
                new Question
                {
                    Id = 14,
                    Text = "Wie kann eine Mindestgrenze von 100 Stück (BE0) auf 100€ geändert werden? [Bis Version 8.8-01]",
                    Answer1 = "Den Zweck auf „Mindestgrenze (€)“ setzten",
                    Answer2 = "Den Bezug auf “Wert Brutto/Netto“ setzen",
                    Answer3 = "Die Wert-Spalte füllen mit gewünschtem Wert",
                    CorrectAnswers = "Den Bezug auf “Wert Brutto/Netto“ setzen"
                },
                new Question
                {
                    Id = 15,
                    Text = "Welche Parameter sollten eingestellt werden, wenn neue SKUs übergeben werden ohne bekannter Abgangshistorie?",
                    Answer1 = "Mittelwert",
                    Answer2 = "Feld “Wenn Prognose, möglich“",
                    Answer3 = "Inaktiv setzen bis Historie vorhanden",
                    CorrectAnswers = "Mittelwert| Feld “Wenn Prognose, möglich“"
                },
                new Question
                {
                    Id = 16,
                    Text = "Was unterscheidet eine Filterklasse von einer Zuordnungsklasse?",
                    Answer1 = "Einer Filterklasse können mehr SKUs zugeordnet werden",
                    Answer2 = "Eine Filterklasse ist nur temporär & wird nach erneuten Starten von LOGOMATE entfernt",
                    Answer3 = "Eine Filterklasse hat klar definierte Bedingungen, die eine SKU erfüllen muss",
                    CorrectAnswers = "Eine Filterklasse hat klar definierte Bedingungen, die eine SKU erfüllen muss"
                },
                new Question
                {
                    Id = 17,
                    Text = "Was unterscheidet eine Zuordnungsklasse zu einer Filterklasse?",
                    Answer1 = "Eine Zuordnungsklasse muss manuell befüllt werden",
                    Answer2 = "Eine Zuordnungsklasse können maximal 10 SKUs zugeordnet werden",
                    Answer3 = "Eine Zuordnungsklasse ist nur temporär & wird nach erneuten Starten von LOGOMATE entfernt",
                    CorrectAnswers = "Eine Zuordnungsklasse muss manuell befüllt werden"
                },
                new Question
                {
                    Id = 18,
                    Text = "Was wird inaktiviert, wenn die Kondition „Inaktiv“ gesetzt wird?",
                    Answer1 = "Der Zugeordnete Lieferant",
                    Answer2 = "Die Prognose-Rechnung",
                    Answer3 = "Die Dispo-Rechnung",
                    CorrectAnswers = "Der Zugeordnete Lieferant"
                },
                new Question
                {
                    Id = 19,
                    Text = "Was wird inaktiviert, wenn der Parameter „Inaktiv“ gesetzt wird?",
                    Answer1 = "Die Prognose-Rechnung",
                    Answer2 = "Die Dispo-Rechnung",
                    Answer3 = "Der Zugeordnete Lieferant",
                    CorrectAnswers = "Die Prognose-Rechnung| Die Dispo-Rechnung"
                },
                new Question
                {
                    Id = 20,
                    Text = "Was macht der Read-Only Modus?",
                    Answer1 = "Man kann darüber Bestellungen exportieren",
                    Answer2 = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden",
                    Answer3 = "Man kann sich nur SKUs anzeigen lassen",
                    CorrectAnswers = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden"
                },
                new Question
                {
                    Id = 21,
                    Text = "Was bedeuten grüne  Zeilen in der Export-Tabelle?",
                    Answer1 = "Muss nichts bedeuten da die Farbe angepasst werden kann",
                    Answer2 = "Das Lieferdatum ist fällig",
                    Answer3 = "Die gezeigte Bestellung wurde nach Erstellung/Berechnung geändert",
                    CorrectAnswers = "Muss nichts bedeuten da die Farbe angepasst werden kann| Die gezeigte Bestellung wurde nach Erstellung/Berechnung geändert"
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

