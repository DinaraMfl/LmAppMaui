using System.Reflection.Metadata;
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
                    Number = 1,

                    TextDe = "Was passiert, wenn die Option „Heute bestellen“ ausgewählt wurde?",
                    Answer1De = "Bestellungen werden auf den heutigen Tag vorgezogen",
                    Answer2De = "Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf",
                    Answer3De = "Es werden zusätzliche Bestellvorschläge für heute generiert",
                    CorrectAnswersDe = "Bestellungen werden auf den heutigen Tag vorgezogen| Bestellmengen werden, wenn möglich, reduziert abhängig vom Bedarf| Es werden zusätzliche Bestellvorschläge für heute generiert",

                    TextEn = "What happens if the “Order Now” option is selected?",
                    Answer1En = "Orders will be brought forward to today",
                    Answer2En = "Order quantities are reduced where possible, depending on demand",
                    Answer3En = "Additional order proposals are generated for today",
                    CorrectAnswersEn = "Orders will be brought forward to today| Order quantities are reduced where possible, depending on demand",

                    QuizCategory = new List<string> { "Bestellung", "Filter", "Allgemein" },
                    DifficultyLevel = 3
                },
                
                new Question
                {
                    Number = 2,

                    TextDe = "Welche Funktion hat der Planungshorizont?",
                    Answer1De = "Er zeigt den letzten Bestellvorschlag an",
                    Answer2De = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",
                    Answer3De = "Er zeigt den Zeitraum an in die Planwerte eingestellt wurden",
                    CorrectAnswersDe = "Er zeigt den Zeitraum an in dem Bestellvorschläge generiert werden können",

                    TextEn = "What is the purpose of the planning horizon?",
                    Answer1En = "It displays the last order proposal",
                    Answer2En = "It shows the period in which order proposals can be generated",
                    Answer3En = "It shows the period in which the planned values were set",
                    CorrectAnswersEn = "It shows the period in which order proposals can be generated",

                    QuizCategory = new List<string> { "Parameter" }
                },
                
                new Question
                {
                    Number = 3,

                    TextDe = "Bis zu welchem Datum wird der festgelegte Planungshorizont in der Bestandssimulation angezeigt?",
                    Answer1De = "HEUTE + Eingetragener Planungshorizont in Werktagen",
                    Answer2De = "Nächster Bestelltag + Eingetragener Planungshorizont in Werktagen",
                    Answer3De = "HEUTE + Eingetragener Planungshorizont in Kalendertagen?",
                    CorrectAnswersDe = "HEUTE + Eingetragener Planungshorizont in Kalendertagen",

                    TextEn = "Until what date is the defined planning horizon displayed in the Stock Chart?",
                    Answer1En = "TODAY + Entered planning horizon in working days",
                    Answer2En = "Next order date + entered planning horizon",
                    Answer3En = "TODAY + Entered planning horizon in calendar days",
                    CorrectAnswersEn = "TODAY + Entered planning horizon in calendar days",

                    QuizCategory = new List<string> { "Parameter" }
                },

                new Question
                {
                    Number = 4,

                    TextDe = "Mit welcher Periodenlänge hat man eine weniger schwankende Standardabweichung bei der Prognose?",
                    Answer1De = "Tagesperiode",
                    Answer2De = "Wochenperiode",
                    Answer3De = "Monatsperiode",
                    CorrectAnswersDe = "Monatsperiode",

                    TextEn = "With which period length do you have a less fluctuating standard deviation in the forecast??",
                    Answer1En = "Day period",
                    Answer2En = "Weekly period",
                    Answer3En = "Monthly period",
                    CorrectAnswersEn = "Monthly period",

                    QuizCategory = new List<string> { "Prognose" }
                },

                new Question
                {
                    Number = 5,

                    TextDe = "Was passiert beim Typ „nur Prognose, nicht disponieren“ aus dem Tab \"Status\" der Parameter?",
                    Answer1De = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo",
                    Answer2De = "Es wird eine Prognose gerechnet & Bestellvorschläge generiert",
                    Answer3De = "Es wird nur eine Prognose und Reichweite berechnet",
                    CorrectAnswersDe = "Es wird nur nur eine Prognose gerechnet, aber keine Dispo",

                    TextEn = "What happens with the type \"only forecast, no replanish\" from the \"Status\" tab of the parameters?",
                    Answer1En = "Only a forecast is calculated, but no dispo",
                    Answer2En = "A forecast is calculated & order proposals are generated",
                    Answer3En = "Only a forecast is calculated, but no dispo",
                    CorrectAnswersEn = "Only a forecast is calculated, but no dispo",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                },

                new Question
                {
                    Number = 6,

                    TextDe = "Welche Funktion hat die „Max. Reichweite“ in den Parametern ?",
                    Answer1De = "Die Max. Reichweite gibt an wie lange die Lieferroute von Lager bis Filiale sein darf",
                    Answer2De = "Wird eine Max. Reichweite übergeben ist es möglich das eine OoS- Bereinigung stattfinden kann",
                    Answer3De = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten in diesen Zeitraum",
                    CorrectAnswersDe = "Die Max. Reichweite (Menge) limitiert den Bestand einer SKU auf x Tage, ohne eine weitere Bestellung zu erwarten in diesen Zeitraum",

                    TextEn = "What is the function of the “Max. coverage” in the parameters?",
                    Answer1En = "The max. coverage indicates how long the delivery route from the warehouse to the store may be",
                    Answer2En = "If a maximum range is passed, it is possible that an OoS cleanup can take place",
                    Answer3En = "The max. coverage (quantity) limits the stock of a SKU to x days without expecting another order in this period",
                    CorrectAnswersEn = "The max. coverage (quantity) limits the stock of a SKU to x days without expecting another order in this period",

                    QuizCategory = new List<string> { "Parameter" }
                },

                new Question
                {
                    Number = 7,

                    TextDe = "Wann kriegt man eine OoS-Warnmeldung?",
                    Answer1De = "Wenn der Bestand einer SKU zum Teil aus abgelaufener Ware besteht",
                    Answer2De = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist",
                    Answer3De = "Wenn prognostiert wird das eine SKU in 7 Tagen Ihren ganzen Bestand aufgebraucht hat",
                    CorrectAnswersDe = "Wenn ich einen Bestand von 0 habe jedoch der Bedarf > 0 ist",

                    TextEn = "When do you get an OoS warning?",
                    Answer1En = "When a SKU's inventory is partly expired",
                    Answer2En = "If I have a stock of 0 but the demand is > 0",
                    Answer3En = "If a SKU is forecast to have used up all your inventory in 7 days",
                    CorrectAnswersEn = "If I have a stock of 0 but the demand is > 0",

                    QuizCategory = new List<string> { "Prognose" }
                },

                new Question
                {
                    Number = 8,

                    TextDe = "Wo kann ich das Gütekriterium ändern?",
                    Answer1De = "Parameter>Dispo>Bestellmenge",
                    Answer2De = "Konditionen>Lieferant>Lieferantenpriorität",
                    Answer3De = "Parameter>Vorgabe>Saison verwenden von",
                    CorrectAnswersDe = "Parameter>Dispo>Bestellmenge",

                    TextEn = "Where can I change the quality criterion?",
                    Answer1En = "Parameter>Dispo>Order quantity",
                    Answer2En = "Conditions>Supplier>Supplier priority",
                    Answer3En = "Parameter>Default>Use season from",
                    CorrectAnswersEn = "Parameter>Dispo>Order quantity",

                    QuizCategory = new List<string> { "Parameter" }
                },

                new Question
                {
                    Number = 9,

                    TextDe = "Was passiert beim Typ „standard, Prognose + Dispo“ aus dem Tab \"Status\" der Parameter??",
                    Answer1De = "Es wird nur eine Prognose ohne Dispo gerechnet",
                    Answer2De = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt",
                    Answer3De = "Es wird keine Prognose und keine Dispo gerechnet",
                    CorrectAnswersDe = "Es wird sowohl eine Prognose als auch eine Dispo-Rechnung durchgeführt",

                    TextEn = "What happens with the type \"standard, forecast + replenishment\" from the \"Status\" tab of the parameters?",
                    Answer1En = "Only a forecast without replenishment is calculated",
                    Answer2En = "Both a forecast and an replenishment calculation is carried out",
                    Answer3En = "No forecast and no replenishment is calculated",
                    CorrectAnswersEn = "Both a forecast and an replenishment calculation is carried out",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                },

                new Question
                {
                    Number = 10,

                    TextDe = "Was passiert beim Typ „nicht bestellen, mit Bestand-Sim“ aus dem \"Status\" Tab der Parameter?",
                    Answer1De = "Es werden keine Bestellvorschläge generiert, wenn es eine Bestandsimulation gibt",
                    Answer2De = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",
                    Answer3De = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    CorrectAnswersDe = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",

                    TextEn = "What happens with the type \"No replenishment, do simulation\" from the \"Status\" tab of the parameters?",
                    Answer1En = "No order proposals are generated if there is a stock simulation",
                    Answer2En = "No order proposals & stock simulation are generated",
                    Answer3En = "No order proposals are generated, but a stock simulation is generated",
                    CorrectAnswersEn = "No order proposals are generated, but a stock simulation is generated",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                },

                 new Question
                 {
                    Number = 11,

                    TextDe = "Was passiert beim Typ „nicht bestellen, ohne Bestand-Sim“ aus dem \"Status\" Tab der Parameter?",
                    Answer1De = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    Answer2De = "Es werden keine Bestellvorschläge generiert, wenn es keine Bestandsimulation gibt",
                    Answer3De = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",
                    CorrectAnswersDe = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",

                    TextEn = "What happens with the type \"No replenishment, no simulation\" from the \"Status\" tab of the parameters?",
                    Answer1En = "No order proposals are generated, but a stock simulation is generated",
                    Answer2En = "No order proposals will be generated if there are no stock simulation",
                    Answer3En = "No order proposals & stock simulation are generated",
                    CorrectAnswersEn = "No order proposals & stock simulation are generated",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Number = 12,

                    TextDe = "Was passiert beim Typ „Bestellmenge nullen vor Abfüllen“ aus dem \"Status\" Tab der Parameter?",
                    Answer1De = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0",
                    Answer2De = "Es werden Bestellungen mit einer Bestellmenge von 0 entfernt",
                    Answer3De = "Bestellungen werden nachträglich mit einer Bestellmenge von 0 ersetzt",
                    CorrectAnswersDe = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0",

                    TextEn = "What happens with the type \"Set order to zero quantity before reducing down\" from the \"Status\" tab of the parameters?",
                    Answer1En = "A demand is calculated and order proposals receive an order quantity of 0",
                    Answer2En = "Orders with an order quantity of 0 are removed",
                    Answer3En = "Orders are subsequently replaced with an order quantity of 0",
                    CorrectAnswersEn = "A requirement is calculated and order proposals receive an order quantity of 0",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Number = 13,

                    TextDe = "Wofür wird die Optimierungs-Einheit benutzt?",
                    Answer1De = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll",
                    Answer2De = "Die Optimierungs-Einheit zeigt an welche Einheit manuell angepasst werden soll",
                    Answer3De = "Bestellvorschläge werden mit dieser Einheit berechnet",
                    CorrectAnswersDe = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll| Bestellvorschläge werden mit dieser Einheit berechnet",

                    TextEn = "What is the optimization unit used for?",
                    Answer1En = "The optimization unit specifies the unit to be used for the calculation",
                    Answer2En = "The optimization unit indicates which unit is to be adjusted manually",
                    Answer3En = "Order proposals are calculated with this unit",
                    CorrectAnswersEn = "The optimization unit specifies the unit to be used for the calculation| Order proposals are calculated with this unit",

                    QuizCategory = new List<string> { "Bestellung", "Kondition" }
                 },

                 /*new Question
                 {
                    Number = 14,

                    TextDe = "Wie kann eine Mindestgrenze von 100 Stück (BE0) auf 100€ geändert werden? [Bis Version 8.8-01]",
                    Answer1De = "Den Zweck auf „Mindestgrenze (€)“ setzten",
                    Answer2De = "Den Bezug auf “Wert Brutto/Netto“ setzen",
                    Answer3De = "Die Wert-Spalte füllen mit gewünschtem Wert",
                    CorrectAnswersDe = "Den Bezug auf “Wert Brutto/Netto“ setzen",

                    TextEn = "How can a minimum limit of 100 units (BE0) be changed to 100€? [Up to version 8.8-01]",
                    Answer1En = "Set the purpose to “Minimum limit (€)”",
                    Answer2En = "Set the reference to “Value gross/net”",
                    Answer3En = "Fill the value column with the desired value",
                    CorrectAnswersEn = "Set the reference to “Value gross/net”",

                    QuizCategory = new List<string> { "Bestellung", "Kondition" }
                 },*/

                 new Question
                 {
                    Number = 15,

                    TextDe = "Parameter sollten eingestellt werden, wenn neue SKUs übergeben werden ohne bekannte Abgangshistorie?",
                    Answer1De = "Mittelwert",
                    Answer2De = "Feld “Wenn Prognose, möglich“",
                    Answer3De = "Inaktiv setzen bis Historie vorhanden",
                    CorrectAnswersDe = "Mittelwert| Feld “Wenn Prognose, möglich“",

                    TextEn = "Which parameters should be set if new SKUs are transferred without a known retirement history?",
                    Answer1En = "Mean value",
                    Answer2En = "Field “If forecast is possible”",
                    Answer3En = "Set inactive until history is available",
                    CorrectAnswersEn = "Mean value| Field “If forecast is possible”",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 16,

                    TextDe = "Was unterscheidet eine Filterklasse von einer Zuordnungsklasse?",
                    Answer1De = "Einer Filterklasse können mehr SKUs zugeordnet werden",
                    Answer2De = "Eine Filterklasse ist nur temporär & wird nach erneuten Starten von F&R entfernt",
                    Answer3De = "Eine Filterklasse hat klar definierte Bedingungen, die eine SKU erfüllen muss",
                    CorrectAnswersDe = "Eine Filterklasse hat klar definierte Bedingungen, die eine SKU erfüllen muss",

                    TextEn = "What is the difference between a filter class and an assignment class?",
                    Answer1En = "More SKUs can be assigned to one filter class",
                    Answer2En = "A filter class is only temporary & is removed after LOGOMATE is restarted",
                    Answer3En = "A filter class has clearly defined conditions that an SKU must fulfill",
                    CorrectAnswersEn = "A filter class has clearly defined conditions that an SKU must fulfill",

                    QuizCategory = new List<string> { "Filter" }
                 },

                 new Question
                 {
                    Number = 17,

                    TextDe = "Was unterscheidet eine Zuordnungsklasse zu einer Filterklasse?",
                    Answer1De = "Eine Zuordnungsklasse muss manuell befüllt werden",
                    Answer2De = "Einer Zuordnungsklasse können maximal 10 SKUs zugeordnet werden",
                    Answer3De = "Eine Zuordnungsklasse ist nur temporär & wird nach erneuten Starten von F&R entfernt",
                    CorrectAnswersDe = "Eine Zuordnungsklasse muss manuell befüllt werden",

                    TextEn = "What is the difference between an assignment class and a filter class?",
                    Answer1En = "An assignment class must be filled manually",
                    Answer2En = "A maximum of 10 SKUs can be assigned to an assignment class",
                    Answer3En = "An assignment class is only temporary & is removed after F&R is restarted",
                    CorrectAnswersEn = "An assignment class must be filled manually",

                    QuizCategory = new List<string> { "Filter" },
                    DifficultyLevel = 1
                },

                new Question
                {
                    Number = 18,

                    TextDe = "Was wird inaktiviert, wenn die Kondition „Inaktiv“ gesetzt wird?",
                    Answer1De = "Der Zugeordnete Lieferant",
                    Answer2De = "Die Prognose-Rechnung",
                    Answer3De = "Die Dispo-Rechnung",
                    CorrectAnswersDe = "Der Zugeordnete Lieferant",

                    TextEn = "What is deactivated when the “Inactive” condition is set?",
                    Answer1En = "The allocated supplier",
                    Answer2En = "The forecast calculation",
                    Answer3En = "The Replenishment calculation",
                    CorrectAnswersEn = "The allocated supplier",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 19,

                    TextDe = "Was wird inaktiviert, wenn der Parameter „Inaktiv“ gesetzt wird?",
                    Answer1De = "Die Prognose-Rechnung",
                    Answer2De = "Die Dispo-Rechnung",
                    Answer3De = "Der Zugeordnete Lieferant",
                    CorrectAnswersDe = "Die Prognose-Rechnung| Die Dispo-Rechnung",

                    TextEn = "What is deactivated when the “Inactive” parameter is set??",
                    Answer1En = "The forecast calculation",
                    Answer2En = "The Replenishment calculation",
                    Answer3En = "The allocated suppliert",
                    CorrectAnswersEn = "The forecast calculation | The Replenishment calculation",

                    QuizCategory = new List<string> { "Bestellung", "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 20,

                    TextDe = "Was macht der Read-Only Modus?",
                    Answer1De = "Man kann darüber Bestellungen exportieren",
                    Answer2De = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden",
                    Answer3De = "Man kann sich nur SKUs anzeigen lassen",
                    CorrectAnswersDe = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden",

                    TextEn = "What does the read-only mode do?",
                    Answer1En = "You can use it to export orders",
                    Answer2En = "This allows temporary changes to be made for test purposes",
                    Answer3En = "You can only see SKUs",
                    CorrectAnswersEn = "This allows temporary changes to be made for test purposes",

                    QuizCategory = new List<string> { "Filter", "Allgemein" }
                 },

                 /*new Question
                 {
                    Number = 21,

                    TextDe = "Was bedeuten grüne  Zeilen in der Export-Tabelle?",
                    Answer1De = "Muss nichts bedeuten da die Farbe angepasst werden kann",
                    Answer2De = "Das Lieferdatum ist fällig",
                    Answer3De = "Die gezeigte Bestellung wurde nach Erstellung/Berechnung geändert",
                    CorrectAnswersDe = "Muss nichts bedeuten da die Farbe angepasst werden kann| Die gezeigte Bestellung wurde nach Erstellung/Berechnung geändert",

                    TextEn = "What do green rows in the export table mean?",
                    Answer1En = "Does not necessarily mean anything as the color can be customized",
                    Answer2En = "The delivery date is due",
                    Answer3En = "The order shown was changed after creation/calculation",
                    CorrectAnswersEn = "Does not necessarily mean anything as the color can be customized| The order shown was changed after creation/calculation",

                    QuizCategory = new List<string> { "Bestellung" }
                 },*/

                 new Question
                 {
                    Number = 22,

                    TextDe = "Ist es sinnvoll eine SKU, die in Benutzung war oder ist, zu löschen??",
                    Answer1De = "Nein, SKUs sollte man nur auf inaktiv setzen",
                    Answer2De = "Ja, um Rechenleistung zu sparen",
                    Answer3De = "Ja, wenn Sie mindestens 1 Monat inaktiv war.",
                    CorrectAnswersDe = "Nein, SKUs sollte man nur auf inaktiv setzen",

                    TextEn = "Does it make sense to delete a SKU that was or is in use?",
                    Answer1En = "No, SKUs should only be set to inactive",
                    Answer2En = "Yes, to save computing power",
                    Answer3En = "Yes, if it has been inactive for at least 1 month",
                    CorrectAnswersEn = "No, SKUs should only be set to inactive",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 23,

                    TextDe = "Was sind Ausreißer?",
                    Answer1De = "Ausreißer erkennen SKUs die doppelt vorhanden sind",
                    Answer2De = "Ausreißer löschen Abgänge die dazu führen das Bestände unter den SiB fallen",
                    Answer3De = "Ausreißer sind Extrem-Werte in der Historie",
                    CorrectAnswersDe = "Ausreißer sind Extrem-Werte in der Historie",

                    TextEn = "What are outliers?",
                    Answer1En = "Outliers recognize SKUs that exist twice",
                    Answer2En = "Outliers delete Issues that result in stocks falling below the SFT",
                    Answer3En = "Outliers are extreme values in the history",
                    CorrectAnswersEn = "Outliers are extreme values in the history",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 24,

                    TextDe = "Wie kann ich die Länge einer variablen Saison steuern?",
                    Answer1De = "Indem ich ein \"Vorher\" & \"Nachher\"-Wert bei den Stichtagen hinterlege",
                    Answer2De = "Die Länge kann nicht manuell gesteuert werden, da die Länge von F&R berechnet wird",
                    Answer3De = "Indem man zwei Stichtage miteinander verknüpft",
                    CorrectAnswersDe = "Indem ich ein \"Vorher\" & \"Nachher\"-Wert bei den Stichtagen hinterlege",

                    TextEn = "How can I control the length of a variable season?",
                    Answer1En = "By storing a \"before\" & \"after\" value in the key dates",
                    Answer2En = "The length cannot be controlled manually, as the length is calculated by F&R",
                    Answer3En = "By linking two key dates",
                    CorrectAnswersEn = "By storing a \"before\" & \"after\" value in the key dates",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 25,

                    TextDe = "Wie viele Historienwerte sind erforderlich um einen Strukturbruch zu erkennen?",
                    Answer1De = "Mindestens 2 Historienwerte",
                    Answer2De = "Mindestens 8 Historienwerte",
                    Answer3De = "Mindestens 5 Historienwerte",
                    CorrectAnswersDe = "Mindestens 8 Historienwerte",

                    TextEn = "How many history values are required to recognize a structural break?",
                    Answer1En = "At least 2 history values",
                    Answer2En = "At least 8 history values",
                    Answer3En = "At least 5 history values",
                    CorrectAnswersEn = "At least 8 history values",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 26,

                    TextDe = "Was passiert wenn die definierte Behandlungsgrenze überschritten wird?",
                    Answer1De = "Die Ausreißer werden korrigiert",
                    Answer2De = "Ungültige Planwerte werden korrigiert",
                    Answer3De = "Es werden mehr Liefertermine generiert weil zu wenige Vorhanden sind um den Bedarf zu decken.",
                    CorrectAnswersDe = "Die Ausreißer werden korrigiert",

                    TextEn = "What happens if the defined treatment limit is exceeded?",
                    Answer1En = "The outliers will be corrected",
                    Answer2En = "Invalid plan values will be corrected",
                    Answer3En = "More delivery dates are generated because there are too few to meet the demand.",
                    CorrectAnswersEn = "The outliers will be corrected",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 27,

                    TextDe = "Welche Grenze muss gepflegt sein bei den Ausreißern, damit der Ausreißer korrigiert werden kann?                                              ?",
                    Answer1De = "Behandlungsgrenze",
                    Answer2De = "Warnungsgrenze",
                    Answer3De = "Max.-Grenze",
                    CorrectAnswersDe = "Behandlungsgrenze",

                    TextEn = "What threshold must be maintained for the outliers so that the outlier can be corrected?                                  ",
                    Answer1En = "Correction threshold",
                    Answer2En = "Warning threshold",
                    Answer3En = "Max. Stock threshold",
                    CorrectAnswersEn = "Treatment threshold",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 28,

                    TextDe = "Wann kommen Vorläufer (normalerweise) zum Einsatz?",
                    Answer1De = "Neue SKUs ohne Historie",
                    Answer2De = "Neue SKUs ohne Historie für Artikel-Variationen",
                    Answer3De = "Nachfolger-SKUs ohne Historie",
                    CorrectAnswersDe = "Neue SKUs ohne Historie für Artikel-Variationen| Nachfolger-SKUs ohne Historie",

                    TextEn = "When are predecessors (normally) used?",
                    Answer1En = "New SKUs without history",
                    Answer2En = "New Article variation SKUs without history",
                    Answer3En = "Successor SKUs without history",
                    CorrectAnswersEn = "New SKUs without history for an article variation| Successor SKUs without history",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 29,

                    TextDe = "Was bewirkt ein eingetragener Vorläufer?",
                    Answer1De = "Die Vorläufer-SKU wird ab dem eingetragenen Datum gelöscht & wird dann ersetzt mit der SKU, die diese SKU als Vorläufer eingetragen hat.",
                    Answer2De = "Die Historie vom Vorläufer wird übertragen auf die SKU",
                    Answer3De = "Die SKU wird inaktiviert und erhält eine „Info“-Warnung, die „Vorläufer-SKU“ heißt",
                    CorrectAnswersDe = "Die Historie vom Vorläufer wird übertragen auf die SKU",

                    TextEn = "What does a registered predecessor do?",
                    Answer1En = "The predecessor SKU will be deleted from the passed date and will then be replaced with the SKU that passed that SKU as a predecessor",
                    Answer2En = "The history of the predecessor is transferred to the SKU",
                    Answer3En = "The SKU is deactivated and receives an “Info” warning called “Predecessor SKU”",
                    CorrectAnswersEn = "The history of the predecessor is transferred to the SKU",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 30,

                    TextDe = "Wie kann man F&R dazu bringen nur einen bestimmten Zeitraum der Historie für die Berechnung zu nutzen?",
                    Answer1De = "Bei den Parametern unter dem Reiter „Prognose“ den Kasten „Zu verwendende Historie“ befüllen",
                    Answer2De = "Bei den Parametern unter dem Reiter „Vorgabe“ das Feld „Plan verwenden“ befüllen",
                    Answer3De = "Bei den Konditionen unter dem Reiter „Zeiten“ das Feld „Rhythmus“ befüllen",
                    CorrectAnswersDe = "Bei den Parametern unter dem Reiter „Prognose“ den Kasten „Zu verwendende Historie“ befüllen",

                    TextEn = "How can F&R be set up to use only a certain period of the history for the calculation?",
                    Answer1En = "In the parameters under the “Forecast” tab, fill in the “History to use” box",
                    Answer2En = "In the parameters under the “Preset” tab, fill in the “Use plan” field",
                    Answer3En = "In the conditions under the “Order schedule” tab, fill in the “Rhythm” field",
                    CorrectAnswersEn = "In the parameters under the “Forecast” tab, fill in the “History to use” box",

                    QuizCategory = new List<string> { "Parameter", "Prognose", "Filter" }
                 },
                 
                 new Question
                 {
                    Number = 31,

                    TextDe = "Was bewirkt das Gütekriterium „Bestand minimieren“?",
                    Answer1De = "Der Bestand wird so niedrig wie möglich gehalten, indem die kleinstmögliche Bestellmenge vorgeschlagen wird",
                    Answer2De = "Der Bestand, der nach einer bestimmten Anzahl an Tagen noch nicht verkauft wurde, wird aus F&R entfernt",
                    Answer3De = "Es wird standardmäßig davon ausgegangen das eine bestimmte Anzahl Artikel in einer bestimmten Periode verkauft werden & werden daraufhin von F&R abgezogen",
                    CorrectAnswersDe = "Der Bestand wird so niedrig wie möglich gehalten, indem die kleinstmögliche Bestellmenge vorgeschlagen wird",

                    TextEn = "What does the “minimize stock” quality criterion do?",
                    Answer1En = "Stock is kept as low as possible by proposing the smallest possible order quantity",
                    Answer2En = "The stock that has not been sold after a certain number of days is removed from F&R",
                    Answer3En = "By default, it is assumed that a certain number of items are sold in a certain period & are then deducted from F&R",
                    CorrectAnswersEn = "Stock is kept as low as possible by proposing the smallest possible order quantity",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Number = 32,

                    TextDe = "Was bewirkt das Gütekriterium „Kosten/ Warenwert minimieren“?",
                    Answer1De = "Bestellmengen werden reduziert jedoch wird öfter bestellt, um die Lagerhaltungskosten zu minimieren",
                    Answer2De = "Bestellmengen werden erhöht jedoch wird seltener bestellt, um die Bestellkosten niedrig zu halten",
                    Answer3De = "Bestellungen werden so optimiert, dass möglichst der höchste Mengenrabatt erreicht wird, um die Einkaufskosten pro Stück niedrig zu halten",
                    CorrectAnswersDe = "Bestellmengen werden reduziert jedoch wird öfter bestellt, um die Lagerhaltungskosten zu minimieren| Bestellmengen werden erhöht jedoch wird seltener bestellt, um die Bestellkosten niedrig zu halten",

                    TextEn = "What is the effect of the quality criterion “minimize costs/stock value”?",
                    Answer1En = "Order quantities are reduced, but orders are placed more frequently in order to minimize warehousing costs",
                    Answer2En = "Order quantities are increased, but orders are placed less frequently to keep order costs low",
                    Answer3En = "Orders are optimized to achieve the highest possible volume discount in order to keep the purchasing costs per unit low",
                    CorrectAnswersEn = "Order quantities are reduced, but orders are placed more frequently in order to minimize warehousing costs| Order quantities are increased, but orders are placed less frequently to keep order costs low",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Number = 33,

                    TextDe = "Wann tritt die Warnung  \"Max. Prognose erreicht\" auf?",
                    Answer1De = "Tritt auf, wenn die Prognose einem starken Trend oder quadratischen Trend nach oben unterliegt",
                    Answer2De = "Sobald der Wert, der im Feld \"Max.Prognose\" definiert ist, überschritten werden würde",
                    Answer3De = "Tritt auf, wenn die Einträge im Abschnitt Vorgaben ungültig sind",
                    CorrectAnswersDe = "Sobald der Wert, der im Feld \"Max.Prognose\" definiert ist, überschritten werden würde",

                    TextEn = "When does the warning “Max. forecast reached” appear?",
                    Answer1En = "Occurs when the forecast is subject to a strong upward trend or quadratic trend",
                    Answer2En = "Once the value defined in the Max Forecast field would be exceeded",
                    Answer3En = "Occurs if the entries in the Preset section are invalid",
                    CorrectAnswersEn = "Once the value defined in the Max Forecast field would be exceeded",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                new Question
                {
                    Number = 34,

                    TextDe = "Wodurch wird ein Strukturbruch erkannt?",
                    Answer1De = "Dies ist ausschließlich nur in der Prognosegrafik zu erkennen",
                    Answer2De = "Wenn mindestens 4 Historienwerte vorliegen die die definerte Niveau-Änderung erreichen",
                    Answer3De = "Wenn die Volatilität (Schwankungsbreite) den zulässigen Wert nicht übersteigt",
                    CorrectAnswersDe = "Wenn mindestens 4 Historienwerte vorliegen die die definerte Niveau-Änderung erreichen| Wenn die Volatilität (Schwankungsbreite) den zulässigen Wert nicht übersteigt",

                    TextEn = "When is a structural break recognized?",
                    Answer1En = "This can only be seen in the forecast chart",
                    Answer2En = "If there are at least 4 history values that reach the defined level change",
                    Answer3En = "If the volatility (fluctuation range) does not exceed the permissible value",
                    CorrectAnswersEn = "If there are at least 4 history values that reach the defined level change| If the volatility (fluctuation range) does not exceed the permissible value",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 35,

                    TextDe = "Wann tritt die Warnung  \"Max. Bestand wir überschritten\" auf?",
                    Answer1De = "Tritt auf, wenn zu viel bestellt wird",
                    Answer2De = "Tritt auf, falls ein Prognosefehler entdeckt wurde",
                    Answer3De = "Wenn die maximale Reichweite der SKU bei der Bestandssimulation überschritten wurde",
                    CorrectAnswersDe = "Tritt auf, wenn zu viel bestellt wird",

                    TextEn = "When does the warning “Max. Stock reached” appear?",
                    Answer1En = "Occurs when too much is ordered",
                    Answer2En = "Occurs if a forecast error has been detected",
                    Answer3En = "If the maximum coverage of the SKU was exceeded during the stock simulation",
                    CorrectAnswersEn = "Occurs when too much is ordered",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 36,

                    TextDe = "Die Wiederbeschaffungszeit setzt sich zusammen aus:?",
                    Answer1De = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ)\r\nTransporttagen (TT)\r\nEinlagerungszeit (ELZ)",
                    Answer2De = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ)\r\nABC-Analyse (ABC)\r\nEinlagerungszeit (ELZ)",
                    Answer3De = "Auftragsvorbereitungszeit (AVZ)\r\n Just-in-Time (JiT)\r\nABC-Analyse (ABC)\r\nEinlagerungszeit (ELZ)",
                    CorrectAnswersDe = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ)\r\nTransporttagen (TT)\r\nEinlagerungszeit (ELZ)",

                    TextEn = "The replenishment time consists of: ?",
                    Answer1En = "Order Preparation Time (OPT)\r\nDelivery Time (DT)\r\nABC Analysis (ABC)\r\nStorage Time (ST)",
                    Answer2En = "Order Preparation Time (OPT)\r\nDelivery Time (DT)\r\nTransport Time (TT)\r\nStorage Time (ST)",
                    Answer3En = "Order Preparation Time (OPT)\r\nJust-in-Time (JiT)\r\nABC Analysis (ABC)\r\nStorage Time (ST)",
                    CorrectAnswersEn = "Order Preparation Time (OPT)\r\nDelivery Time (DT)\r\nTransport Time (TT)\r\nStorage Time (ST)",

                    QuizCategory = new List<string> { "Filter" }
                 },

                 new Question
                 {
                    Number = 37,

                    TextDe = "Was passiert wenn ein Wert bei dem Parameter \"Trend\" definiert wird??",
                    Answer1De = "Der Mittelwert steigt linear",
                    Answer2De = "Der Mittelwert steigt exponentiell",
                    Answer3De = "Stellen mit unerwartet hohen Abgängen in der Historie werden angezeigt",
                    CorrectAnswersDe = "Der Mittelwert steigt linear",

                    TextEn = "What happens when a value is defined in the \"Trend\" parameter?",
                    Answer1En = "It causes the mean value to rise linearly",
                    Answer2En = "It causes the mean value to rise exponentially",
                    Answer3En = "It highlights places with unexpectedly high issues in the history",
                    CorrectAnswersEn = "It allows the mean value to increase linearly",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 38,

                    TextDe = "Was ist die Voraussetzung für einen Trend?",
                    Answer1De = "Ein Mittelwert",
                    Answer2De = "Eine Historie von mindestens 10 Perioden",
                    Answer3De = "Ein Startdatum, ab dem der Trend benutzt werden soll",
                    CorrectAnswersDe = "Ein Mittelwert",

                    TextEn = "What is the requirement for a trend?",
                    Answer1En = "A mean value",
                    Answer2En = "A history of at least 10 periods",
                    Answer3En = "A start date from which the trend is to be used",
                    CorrectAnswersEn = "An mean value",

                    QuizCategory = new List<string> { "Paramter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 39,

                    TextDe = "Was macht der „Quadrat. Trend“?",
                    Answer1De = "Er lässt den Mittelwert linear steigen",
                    Answer2De = "Er lässt den Mittelwert exponentiell steigen",
                    Answer3De = "Er zeigt Stellen an mit unerwartet hohen Abgängen in der Historie an",
                    CorrectAnswersDe = "Er lässt den Mittelwert exponentiell steigen",

                    TextEn = "What happens if a \"square trend\" is defined?",
                    Answer1En = "It causes the mean value to rise linearly",
                    Answer2En = "It causes the mean value to rise exponentially",
                    Answer3En = "It highlights places with unexpectedly high issues in the history",
                    CorrectAnswersEn = "It causes the mean value to increase exponentially",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 40,

                    TextDe = "Ist es möglich sowohl Trend als auch Quadrat. Trend einzustellen? ",
                    Answer1De = "Ja, weil der Quadratische Trend ohne linearen Trend nicht funktionieren würde",
                    Answer2De = "Nein, weil verschiedene Prognose-Verfahren verwendet werden für die Berechnung des Trends",
                    Answer3De = "Nein, man kann pro SKU nur einen der beiden Trend-Parameter benutzen",
                    CorrectAnswersDe = "Ja, weil der Quadratische Trend ohne linearen Trend nicht funktionieren würde",

                    TextEn = "Is it possible to set both trend and square trend?  ",
                    Answer1En = "Yes, because the square trend does not work without a linear trend",
                    Answer2En = "No, because different forecasting methods are used to calculate the trend",
                    Answer3En = "No, you can only set one trend per SKU",
                    CorrectAnswersEn = "Yes, because the square trend does not work without a linear trend",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },
                 
                 new Question
                 {
                    Number = 41,

                    TextDe = "Was sagt die ABC-Klasse über eine SKU aus?",
                    Answer1De = "Die ABC-Klasse zeigt an welche SKUs am genausten prognostiziert werden können",
                    Answer2De = "Die ABC-Klasse zeigt an welche SKUs am meisten bestellt werden",
                    Answer3De = "Die ABC-Klasse zeigt an welche SKUs am umsatzstärksten sind",
                    CorrectAnswersDe = "Die ABC-Klasse zeigt an welche SKUs am umsatzstärksten sind",

                    TextEn = "What does the ABC class say about an SKU?",
                    Answer1En = "The ABC class shows which SKU can be predicted most accurately",
                    Answer2En = "The ABC class shows which SKU is ordered most often",
                    Answer3En = "The ABC class shows which SKUs have the highest turnover",
                    CorrectAnswersEn = "The ABC class shows which SKUs have the highest turnover",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 42,

                    TextDe = "Was sagt eine XYZ-Klasse über eine SKU aus?",
                    Answer1De = "Die XYZ-Klasse zeigt an welche SKU am genausten prognostiziert werden kann",
                    Answer2De = "Die XYZ-Klasse zeigt an welche SKU meisten bestellt wird",
                    Answer3De = "Die XYZ-Klasse zeigt an welche SKUs am umsatzstärksten sind",
                    CorrectAnswersDe = "Die XYZ-Klasse zeigt welche SKU am genausten prognostiziert werden kann",

                    TextEn = "What does an XYZ class say about an SKU?",
                    Answer1En = "The ABC class shows which SKU can be predicted most accurately",
                    Answer2En = "The ABC class shows which SKU is ordered most often",
                    Answer3En = "The ABC class shows which SKUs have the highest turnover",
                    CorrectAnswersEn = "The ABC class shows which SKU can be predicted most accurately",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 43,

                    TextDe = "Welche Funktion hat der \"Rhythmusanfang\" bei einem Bestellrhytmus?",
                    Answer1De = "Der Bestellrhythmus fängt ab dem definierten Datum an",
                    Answer2De = "Bei der ersten Bestellung innerhalb des Bestellrhythmus wird ein Vielfaches der definierten Bestellmenge bestellt",
                    Answer3De = "Der Bestellrhythmus wird gestartet sobald die definierte Starbedingung erfüllt ist",
                    CorrectAnswersDe = "Der Bestellrhythmus fängt ab dem definierten Datum an",

                    TextEn = "What is the function of the field \"Rhythm starts at\" in an Order rhythm?",
                    Answer1En = "It specifies when the order cycle should start",
                    Answer2En = "For the first order within the order rhythm, a multiple of the defined order quantity is ordered",
                    Answer3En = "This is a special setting that allows you to start with a slower ordering rhythm",
                    CorrectAnswersEn = "It specifies when the order cycle should start",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 44,

                    TextDe = "Was muss erfüllt sein damit man im Kalender, die Wochentage & Feiertage bearbeiten kann?",
                    Answer1De = "Im \"Kalender\" Fenster muss das Feld „Eigener Kalender“ angehakt sein",
                    Answer2De = "Es gibt keine Voraussetzungen, man kann den Kalender ständig bearbeiten",
                    Answer3De = "Der REMIRA Support muss einstellen, dass diese Felder bearbeitet werden dürfen",
                    CorrectAnswersDe = "Im \"Kalender\" Fenster muss das Feld „Eigener Kalender“ angehakt sein",

                    TextEn = "What must be fulfilled so that you can edit the weekdays and public holidays in the calendar?",
                    Answer1En = "“Separate calendar” must be ticked",
                    Answer2En = "There are no requirements, you can always edit the calendar",
                    Answer3En = "REMIRA Support has to set up the system to be able to edit the calendar",
                    CorrectAnswersEn = "“Separate calendar” must be checked",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 45,

                    TextDe = "Welche Besonderheit hat der Werkskalender?",
                    Answer1De = "Der Werkskalender kann gleichzeitig im Gruppenbaum als auch im Lagerbaum abgerufen werden",
                    Answer2De = "Der Werkskalender kann entweder über den Gruppenbaum oder über den Lagerbaum abgerufen werden",
                    Answer3De = "Der Werkskalender hat einen 4.Abschnitt in dem eigene Feiertage oder Betriebsferien übergeben werden können",
                    CorrectAnswersDe = "Der Werkskalender kann entweder über den Gruppenbaum oder über den Lagerbaum abgerufen werden",

                    TextEn = "What can be set without the “Separate calendar\" tick?",
                    Answer1En = "Weekdays",
                    Answer2En = "Holidays",
                    Answer3En = "Dynamic calendar section (company vacations, special shifts, ...)",
                    CorrectAnswersEn = "Dynamic calendar section (company vacations, special shifts, ...)",

                    QuizCategory = new List<string> { "Algemein" }
                 },

                 new Question
                 {
                    Number = 46,

                    TextDe = "Wo kann man den Werkskalender finden?",
                    Answer1De = "Gruppenbaum",
                    Answer2De = "Lagerbaum",
                    Answer3De = "Artikelbaum",
                    CorrectAnswersDe = "Gruppenbaum| Lagerbaum",

                    TextEn = "Where can I find the site calendar?",
                    Answer1En = "Group tree",
                    Answer2En = "Store tree",
                    Answer3En = "Article tree",
                    CorrectAnswersEn = "Group tree| Store tree",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 47,

                    TextDe = "Wo kann man den Lieferanten-Kalender finden?",
                    Answer1De = "Lieferantenbaum",
                    Answer2De = "Gruppenbaum",
                    Answer3De = "Artikelbaum",
                    CorrectAnswersDe = "Lieferantenbaum",

                    TextEn = "Where can I find the supplier calendar?",
                    Answer1En = "Supplier tree",
                    Answer2En = "Group tree",
                    Answer3En = "Article tree",
                    CorrectAnswersEn = "Supplier tree",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 48,

                    TextDe = "Welche Kalender gibt es in F&R?",
                    Answer1De = "Lieferanten-Kalender",
                    Answer2De = "Werkskalender",
                    Answer3De = "Bestell-Kalender",
                    CorrectAnswersDe = "Lieferanten-Kalender| Werkskalender",

                    TextEn = "Which calendars are available in LOGOMATE?",
                    Answer1En = "Supplier calendar",
                    Answer2En = "Site calendar",
                    Answer3En = "Order calendar",
                    CorrectAnswersEn = "Supplier tree| Site calendar",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 49,

                    TextDe = "Bei was unterstützt Sie die Vererbung in F&R?",
                    Answer1De = "Sie verweist auf die letzten Bestellungen vor ca. einem Jahr",
                    Answer2De = "Es hilft, die Parameter und Konditionen schneller zu erfassen und zu verwalten",
                    Answer3De = "Sie vererbt die Abverkaufhistorie auf die unteren Ebenen",
                    CorrectAnswersDe = "Es hilft, die Parameter und Konditionen schnell zu erfassen und zu verwalten",

                    TextEn = "What does inheritance in F&R help you with?",
                    Answer1En = "It refers to the last orders about a year ago",
                    Answer2En = "It helps to register and manage the parameters and conditions faster",
                    Answer3En = "It inherits the sales history to the lower levels",
                    CorrectAnswersEn = "It helps to register and manage the parameters and conditions faster",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 50,

                    TextDe = "Was sorgt dafür, dass eine Bestellung überfällig ist?",
                    Answer1De = "Warenüberschuss",
                    Answer2De = "MHD ist abgelaufen",
                    Answer3De = "Wenn das Lieferdatum überschritten wird",
                    CorrectAnswersDe = "Wenn das Lieferdatum überschritten wird",

                    TextEn = "What makes an order overdue?",
                    Answer1En = "Excessive goods",
                    Answer2En = "BBD has been expired",
                    Answer3En = "If the delivery date is exceeded",
                    CorrectAnswersEn = "If the delivery date is exceeded",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 51,

                    TextDe = "Welchen Vorteil hat die 2D-Ansicht?",
                    Answer1De = "Die dargestellte Farbe ist intensiver",
                    Answer2De = "Hat keinen Vorteil",
                    Answer3De = "Genauere Ansicht der Prognosegrafik",
                    CorrectAnswersDe = "Genauere Ansicht der Prognosegrafik",

                    TextEn = "What is the advantage of the 2D view?",
                    Answer1En = "The color shown is more intense",
                    Answer2En = "Has no advantage",
                    Answer3En = "Better view of the forecast graphic",
                    CorrectAnswersEn = "Better view of the forecast graphic",

                    QuizCategory = new List<string> { "Prognose", "Allgemein" }
                 },

                 new Question
                 {
                    Number = 52,

                    TextDe = "Wie viele verschiedene Rhythmen kann man in den Konditionen auswählen?",
                    Answer1De = "5",
                    Answer2De = "4",
                    Answer3De = "2",
                    CorrectAnswersDe = "4",

                    TextEn = "How many different rhythm option do I have in the conditions (Order schedule)?",
                    Answer1En = "5",
                    Answer2En = "4",
                    Answer3En = "2",
                    CorrectAnswersEn = "4",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 53,

                    TextDe = "Welcher der genannten ist ein Dispofehler?",
                    Answer1De = "Überfällige Bestellungen",
                    Answer2De = "Zu wenig Liefertermine",
                    Answer3De = "Ungültige Aktion",
                    CorrectAnswersDe = "Zu wenig Liefertermine",

                    TextEn = "What is a Replenishment error?",
                    Answer1En = "Overdue orders",
                    Answer2En = "Too few delivery dates",
                    Answer3En = "Invalid promotion",
                    CorrectAnswersEn = "Too few delivery dates",

                    QuizCategory = new List<string> { "Bestellung", "Filter" }
                 },

                 new Question
                 {
                    Number = 54,

                    TextDe = "Was ist die primäre Aufgabe der Verbund-Bestellung?",
                    Answer1De = "Alle SKUs die bestellt wurden, sollen gleichzeitig ihren SiB erreichen, um die SKUs wieder gleichzeitig bestellen zu können",
                    Answer2De = "Eine Bestellung zu generieren aus allen vorhandenen SKUs der Verbund-Gruppe",
                    Answer3De = "Die Bestellkosten pro Bestellung so niedrig wie möglich zu halten",
                    CorrectAnswersDe = "Alle SKUs die bestellt wurden, sollen gleichzeitig ihren SiB erreichen, um die SKUs wieder gleichzeitig bestellen zu können",

                    TextEn = "What is the primary task of the compound order?",
                    Answer1En = "All SKUs that have been ordered should reach their SFT at the same time so that the SKUs can be ordered again at the same time",
                    Answer2En = "Generate an order from all existing SKUs of the compound group",
                    Answer3En = "To keep the order costs per order as low as possible ",
                    CorrectAnswersEn = "All SKUs that have been ordered should reach their SFT at the same time so that the SKUs can be ordered again at the same time",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 55,

                    TextDe = "Was bewirkt der Parameter „Kein Auslöseartikel“?",
                    Answer1De = "Die SKU darf nur bei einer Verbund-Bestellung mitbestellt werden ",
                    Answer2De = "Diese SKU löst keine OoS-Korrektur aus",
                    Answer3De = "Die SKU auf die dieser Parameter angewandt wurde darf keine Bestellung auslösen",
                    CorrectAnswersDe = "Die SKU auf die dieser Parameter angewandt wurde darf keine Bestellung auslösen| Die SKU darf nur bei einer Verbund-Bestellung mitbestellt werden ",

                    TextEn = "What does the “No order trigger” parameter do?",
                    Answer1En = "The SKU can only be ordered with a compound order ",
                    Answer2En = "This SKU does not trigger an OoS correction",
                    Answer3En = "The SKU to which this parameter was applied can't trigger an order",
                    CorrectAnswersEn = "The SKU to which this parameter was applied can't trigger an order| The SKU can only be ordered with a compound order ",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Number = 56,

                    TextDe = "Was unterscheidet eine Verbund- Bestellung zu einer „normalen“ Bestellung?",
                    Answer1De = "Mit Verbund-Bestellungen kriegt man einen Mengen-Rabatt, da mehrere Artikel auf einmal bestellt werden",
                    Answer2De = "Eine Verbund-Bestellung besteht aus mehreren Artikeln, die bestellt werden",
                    Answer3De = "Nur bei Verbund-Bestellungen werden Vielfachen der Optimierungseinheit verwendet",
                    CorrectAnswersDe = "Eine Verbund-Bestellung besteht aus mehreren Artikeln, die bestellt werden",

                    TextEn = "What is the difference between a compound order and a “normal” order?",
                    Answer1En = "With compound orders you get a quantity discount, as several items are ordered at once",
                    Answer2En = "A compound order consists of several items that are ordered",
                    Answer3En = "Only for compound orders are multiples of the optimization unit used",
                    CorrectAnswersEn = "A compound order consists of several items that are ordered",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 57,

                    TextDe = "Was kann man machen bei SKUs die in der gleichen Verbund-Gruppe liegen, aber verschiedene Konditionen besitzen?",
                    Answer1De = "SKUs mit gleichen Konditionen einer Verbund-Untergruppe zuordnen",
                    Answer2De = "SKUs mit einzigartigen Konditionen aus der Verbund-Gruppe entfernen",
                    Answer3De = "Alle SKUs, die eine Verbund-Bestellung aufhalten, inaktiv setzen in den Parametern",
                    CorrectAnswersDe = "SKUs mit gleichen Konditionen einer Verbund-Untergruppe zuordnen| SKUs mit einzigartigen Konditionen aus der Verbund-Gruppe entfernen",

                    TextEn = "What can be done with SKUs in a compound group, each with different conditions?",
                    Answer1En = "Form compound subgroups with SKUs that have the same conditions",
                    Answer2En = "Remove SKUs that have unique conditions from the compound group",
                    Answer3En = "Set the SKUs that hold up the compound order to inactive ",
                    CorrectAnswersEn = "Form compound subgroups with SKUs that have the same conditions| Remove SKUs that have unique conditions from the compound group",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 58,

                    TextDe = "Woran erkennt man eine Verbund-Gruppe?",
                    Answer1De = "An der hellgrünen Schriftfarbe der Gruppe",
                    Answer2De = "An der hellblauen Variante des Ursprungsymbols",
                    Answer3De = "An der Dispo-Warnung „Verbund-SKU“",
                    CorrectAnswersDe = "An der hellblauen Variante des Ursprungsymbols",

                    TextEn = "How can you recognize a compound group?",
                    Answer1En = "The light green font color of the group",
                    Answer2En = "By the light blue version of the original symbol",
                    Answer3En = "At the replenishment warning \"Compound condition available at storage location\"“",
                    CorrectAnswersEn = "By the light blue version of the original symbol",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 59,

                    TextDe = "Wie können \"Verbund\"-Gruppen erstellt werden",
                    Answer1De = "“Gewünschte Gruppe”->Rechtsklick->Gruppe/Benutzer ändern->“Verbund“ anhaken",
                    Answer2De = "“Gewünschte Gruppe”->Rechtsklick->Neue Gruppe->“Verbund“ anhaken",
                    Answer3De = "Parameter->Status->”Verbund” anhaken",
                    CorrectAnswersDe = "“Gewünschte Gruppe”->Rechtsklick->Neue Gruppe->“Verbund“ anhaken| “Gewünschte Gruppe”->Rechtsklick->Gruppe/Benutzer ändern->“Verbund“ anhaken",

                    TextEn = "How can compound groups be created?",
                    Answer1En = "“Desired group”->right-click->Edit group/user->check “Compound”",
                    Answer2En = "“Desired group“->right-click->New group->”Compound” checkbox",
                    Answer3En = "Parameter->Status->“Compound” checkbox",
                    CorrectAnswersEn = "“Desired group“->right-click->New group->”Compound” checkbox| “Desired group”->right-click->Edit group/user->check “Compound”",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 60,

                    TextDe = "Was zeigt eine rote Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",
                    Answer2De = "Die Bestellung wurde, bevor sie exportiert wurde, als Report ausgegeben",
                    Answer3De = "Die Bestellung wurde nach dem exportieren geändert",
                    CorrectAnswersDe = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",

                    TextEn = "What does a red font show in the orders (by default)?",
                    Answer1En = "The order has missed its availability date and is now considered overdue",
                    Answer2En = "The order was output as a report before it was exported",
                    Answer3En = "The order was changed after exporting",
                    CorrectAnswersEn = "The order has missed its availability date and is now considered overdue",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 61,

                    TextDe = "Was zeigt eine hellrote Schrift in den Bestellungen an (standardmäßig)??",
                    Answer1De = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",
                    Answer2De = "Die Bestellung ist geändert worden & hat Ihren Verfügbarkeitstermin überschritten",
                    Answer3De = "Die Bestellung wurde, bevor sie exportiert wurde, als Report ausgegeben",
                    CorrectAnswersDe = "Die Bestellung ist geändert worden & hat Ihren Verfügbarkeitstermin überschritten",

                    TextEn = "What does a light red font show in the orders (by default)?",
                    Answer1En = "The order has missed its availability date and is now considered overdue",
                    Answer2En = "The order has been changed & has exceeded its availability date",
                    Answer3En = "The order was output as a report before it was exported",
                    CorrectAnswersEn = "The order has been changed & has exceeded its availability date",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 62,

                    TextDe = "Was zeigt eine grüne Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Der Bestellvorschlag wurde exportiert",
                    Answer2De = "Die Bestellung wurde als Report ausgegeben und exportiert",
                    Answer3De = "Die Bestellung wurde importiert",
                    CorrectAnswersDe = "Der Bestellvorschlag wurde exportiert| Die Bestellung wurde importiert| Die Bestellung wurde als Report ausgegeben und exportiert",

                    TextEn = "What does a green font show in the orders (by default)?",
                    Answer1En = "The order proposal has been exported",
                    Answer2En = "The order was output as a report and exported",
                    Answer3En = "The order has been imported",
                    CorrectAnswersEn = "The order proposal has been exported | The order has been imported | The order was output as a report and exported",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 63,

                    TextDe = "Was zeigt eine hellgrüne Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung wurde importiert",
                    Answer2De = "Die Bestellung wurde als Report ausgegeben, bevor sie exportiert wurde",
                    Answer3De = "Die Bestellung wurde geändert, nachdem sie bereits exportiert wurde",
                    CorrectAnswersDe = "Die Bestellung wurde geändert, nachdem sie bereits exportiert wurde",

                    TextEn = "What does a light green font show in the orders (by default)?",
                    Answer1En = "The order has been imported",
                    Answer2En = "The order was output as a report before it was exported",
                    Answer3En = "The order has been changed after it has already been exported",
                    CorrectAnswersEn = "The order has been changed after it has already been exported",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 64,
                 
                    TextDe = "Was zeigt eine schwarze Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung hat Ihren Bestellzeitpunkt noch nicht erreicht und wurde noch nicht exportiert",
                    Answer2De = "Der Verfügbarkeitstermin der Bestellung ist heute",
                    Answer3De = "Die Bestellung wurde storniert/ gelöscht",
                    CorrectAnswersDe = "Die Bestellung hat Ihren Bestellzeitpunkt noch nicht erreicht und wurde noch nicht exportiert",

                    TextEn = "What does a black font show in the orders (by default)?",
                    Answer1En = "The order has not reached its order date and has not been exported yet",
                    Answer2En = "The availability date of the order is today",
                    Answer3En = "The order has been canceled/deleted",
                    CorrectAnswersEn = "The order has not reached its order date and has not been exported yet",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 65,

                    TextDe = "Was bewirkt das Gütekriterium „Auf Max. auffüllen“?",
                    Answer1De = "Es wird die maximale Menge bestellt, die pro Bestellung getätigt werden darf",
                    Answer2De = "Es werden so lange neue Bestellvorschläge generiert bis der Bestand seine maximale Menge erreicht hat",
                    Answer3De = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der definierte Max. Bestand erreicht wurde",
                    CorrectAnswersDe = "Es werden so lange neue Bestellvorschläge generiert bis der Bestand seine maximale Menge erreicht hat",

                    TextEn = "What is the effect of the “Fill up to max.\" quality criterion?",
                    Answer1En = "The maximum quantity that may be ordered per order is ordered",
                    Answer2En = "Order proposals are generated until the maximum stock level is reached",
                    Answer3En = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached.",
                    CorrectAnswersEn = "Order proposals are generated until the maximum stock level is reached",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 66,

                    TextDe = "Was bewirkt das Gütekriterium „Auf Max. + Reserv. auffüllen“?",
                    Answer1De = "Es werden so lange neue Bestellvorschläge generiert bis der Bestand seine maximale Menge erreicht hat",
                    Answer2De = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der definierte Max. Bestand erreicht wurde",
                    Answer3De = "Es wird die maximale Menge bestellt, die pro Bestellung getätigt werden darf",
                    CorrectAnswersDe = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der definierte Max. Bestand erreicht wurde",

                    TextEn = "What is the effect of the quality criterion “Fill up to max. + reserv.”?",
                    Answer1En = "Order proposals are generated until the maximum stock level is reached",
                    Answer2En = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached. ",
                    Answer3En = "Order proposals are generated to satisfy all reservations",
                    CorrectAnswersEn = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached. ",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 67,

                    TextDe = "Was passiert beim Auto-Store-Verfahren?",
                    Answer1De = "Es werden Bestellvorschläge, aus mehreren Optimierungseinheiten, generiert",
                    Answer2De = "F&R entscheidet selbst bei welchem Lager die Bestellung eingelagert wird",
                    Answer3De = "Für die Bestellvorschläge wird die Einheit bzw. Einheit-Kombination verwendet die am nächsten an der Nötigen Menge liegt",
                    CorrectAnswersDe = "Für die Bestellvorschläge wird die Einheit bzw. Einheit-Kombination verwendet die am nächsten an der Nötigen Menge liegt| Es werden Bestellvorschläge, aus mehreren Optimierungseinheiten, generiert",

                    TextEn = "What is the function of the auto-store method?",
                    Answer1En = "Order proposals are generated from several optimization units",
                    Answer2En = "F&R itself decides which warehouse to store the order at",
                    Answer3En = "The unit factor is kept as low as possible",
                    CorrectAnswersEn = "The unit factor is kept as low as possible| Order proposals are generated from several optimization units",

                    QuizCategory = new List<string> { "Paramter" }
                 },

                 new Question
                 {
                    Number = 68,

                    TextDe = "Wie und wo wird das Auto-Store-Verfahren aktiviert?",
                    Answer1De = "Parameter->Dispo->Gütekriterium->“Auto-Store-Verfahren“ auswählen",
                    Answer2De = "Konditionen->Einheiten->“Auto-Store-Verfahren“ anhaken",
                    Answer3De = "Konditionen->Menge, Preise, Kosten->“Auto-Store-Verfahren“ auswählen",
                    CorrectAnswersDe = "Parameter->Dispo->Gütekriterium->“Auto-Store-Verfahren“ auswählen",

                    TextEn = "How and where is the auto-store method activated?",
                    Answer1En = "Parameters->Dispo->Quality criterion->Select “Auto-store method”",
                    Answer2En = "Conditions->Units->“Auto-store method” checkbox",
                    Answer3En = "Conditions->Quantity, Prices, Costs->Select “Auto-store method\"",
                    CorrectAnswersEn = "Parameters->Dispo->Quality criterion->Select “Auto-store method”",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 69,

                    TextDe = "Was bewirkt das Gütekriterium „Container-Optimierung“?",
                    Answer1De = "Es werden Bestellvorschläge generiert mit den geringsten Bestellkosten",
                    Answer2De = "Es werden Bestellvorschläge generiert mit der geringsten Anzahl an Einheiten",
                    Answer3De = "Es werden Bestellvorschläge generiert mit dem höchsten Warenwert pro Container-Einheit",
                    CorrectAnswersDe = "Es werden Bestellvorschläge generiert mit den geringsten Bestellkosten",

                    TextEn = "What does the “container optimization” quality criterion do?",
                    Answer1En = "Order proposals are generated with the lowest possible order costs",
                    Answer2En = "Order proposals are generated with the smallest possible number of units",
                    Answer3En = "Order proposals are generated with the highest value of goods per container unit",
                    CorrectAnswersEn = "Order proposals are generated with the lowest possible order costs",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 70,

                    TextDe = "Was bewirkt das Gütekriterium „Mit Partitionierung“?",
                    Answer1De = "Es wird eine zusätzliche Bestellung generiert für alle Aufträge, die in der aktuellen Periode stattfinden",
                    Answer2De = "Es werden 1:1 Bestellvorschläge für Aufträge generiert",
                    Answer3De = "Reservierungen mit Partionsnummer werden einzeln disponiert unter Beachtung des aktuellen Bestands und der noch offenen Bestellungen",
                    CorrectAnswersDe = "Reservierungen mit Partionsnummer werden einzeln disponiert unter Beachtung des aktuellen Bestands und der noch offenen Bestellungen",

                    TextEn = "What is the effect of the “Partitioning” quality criterion?",
                    Answer1En = "An additional order is generated for all reservations that take place in the current period",
                    Answer2En = "Order suggestions for reservations are generated 1:1",
                    Answer3En = "Reservations with partion number are planned individually, taking into account the current stock and the open orders",
                    CorrectAnswersEn = "Reservations with partion number are planned individually, taking into account the current stock and the open orders",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 71,

                    TextDe = "Was bewirkt das Gütekriterium „Partitionen verwenden Anfangsbestand nicht“?",
                    Answer1De = "Aufträge werden, unabhängig vom Bestand und offenen Bestellungen, 1:1 zu Bestellungen umgewandelt",
                    Answer2De = "Reservierungen mit Partionsnummer werden einzeln disponiert unter Beachtung des aktuellen Bestands und der noch offenen Bestellungen",
                    Answer3De = "Es wird eine zusätzliche Bestellung generiert mit der Restmenge für alle Aufträge, die in der aktuellen Periode stattfinden",
                    CorrectAnswersDe = "Aufträge werden, unabhängig vom Bestand und offenen Bestellungen, 1:1 zu Bestellungen umgewandelt",

                    TextEn = "What is the effect of the quality criterion “Partitioning stock only for default partition”?",
                    Answer1En = "Resevations are converted 1:1 into orders, regardless of stock and open orders",
                    Answer2En = "Reservations with partion number are planned individually, taking into account the current stock and the open orders",
                    Answer3En = "An additional order is generated with the remaining quantity for all reservations that take place in the current period",
                    CorrectAnswersEn = "Resevations are converted 1:1 into orders, regardless of stock and open orders",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 72,

                    TextDe = "Was muss erfüllt werden damit das Auto-Store-Verfahren ordnungsgemäß ausgeführt werden kann?",
                    Answer1De = "Die Differenz zwischen den zu verwendenden Optimierungs-Einheiten muss nach oben hin größer werden",
                    Answer2De = "Die zu verwendenden Optimierungs-Einheiten müssen einen Mix-Haken besitzen",
                    Answer3De = "Die zu verwendenden Optimierungs-Einheiten dürfen kein Mix-Haken besitzen",
                    CorrectAnswersDe = "Die zu verwendenden Optimierungs-Einheiten dürfen kein Mix-Haken besitzen| Die Differenz zwischen den zu verwendenden Optimierungs-Einheiten muss nach oben hin größer werden",

                    TextEn = "What must be fulfilled for the auto-store method to be carried out properly?",
                    Answer1En = "The difference between the optimization units has increase towards the top",
                    Answer2En = "The optimization units must have a mix hook",
                    Answer3En = "The optimization units doesn't have a mix hook",
                    CorrectAnswersEn = "The optimization units doesn't have a mix hook| The difference between the optimization units has increase towards the top",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 73,

                    TextDe = "Was ist der Unterschied zwischen Auto-Store-Verfahren und Container-Optimierung?",
                    Answer1De = "Beim Auto-Store-Verfahren wird die Bestellmenge optimiert",
                    Answer2De = "Beim Auto-Store-Verfahren wird der Einheiten-Faktor optimiert",
                    Answer3De = "Bei der Container-Optimierung werden die Bestellkosten minimiert",
                    CorrectAnswersDe = "Beim Auto-Store-Verfahren wird der Einheiten-Faktor optimiert| Bei der Container-Optimierung werden die Bestellkosten minimiert",

                    TextEn = "What is the difference between the auto-store method and container optimization?",
                    Answer1En = "The auto-store method optimizes the order quantity",
                    Answer2En = "The auto-store method optimizes the unit factor",
                    Answer3En = "The container optimization optimizes the ordering costs",
                    CorrectAnswersEn = "The auto-store method optimizes the unit factor | The container optimization optimizes the ordering costs",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 74,
                    
                    TextDe = "Welche Kombinationen sind bei einer Container-Optimierung möglich, nach der optimiert werden soll?",
                    Answer1De = "Volumen / Gewicht",
                    Answer2De = "Faktor / Volumen",
                    Answer3De = "Gewicht / Faktor",
                    CorrectAnswersDe = "Volumen / Gewicht| Gewicht / Faktor",

                    TextEn = "What combinations are possible for the container optimization after which optimization is to be carried out?",
                    Answer1En = "Volume / Weight",
                    Answer2En = "Factor / Volume",
                    Answer3En = "Weight / Factor",
                    CorrectAnswersEn = "Volume / Weight | Weight / Factor",

                    QuizCategory = new List<string> { "Parameter" }
                 },
                 
                 new Question
                 {
                    Number = 75,

                    TextDe = "Was ist der Unterschied von einer Reservierung mit Partition & einer Reservierung ohne Partition?",
                    Answer1De = "Eine Reservierung mit Partition kriegt eine eigene Bestellung und kann direkt einem Auftrag zugeordnet werden",
                    Answer2De = "Eine Reservierung mit Partition wird zusammengefasst mit anderen Bestellungen im Bestellungs-Fenster",
                    Answer3De = "Eine Reservierung ohne Partition wird zusammengefasst mit anderen Bestellungen im Bestellungs-Fenster",
                    CorrectAnswersDe = "Eine Reservierung mit Partition kriegt eine eigene Bestellung und kann direkt einem Auftrag zugeordnet werden3| Eine Reservierung ohne Partition wird zusammengefasst mit anderen Bestellungen im Bestellungs-Fenster",

                    TextEn = "How does a reservation with a partition differ from a reservation without a partition?",
                    Answer1En = "A reservation with partition gets its own order and can be assigned directly to an order.",
                    Answer2En = "A reservation with a partition is summarised with other orders in the order window",
                    Answer3En = "A reservation without a partition is summarised with other orders in the order window",
                    CorrectAnswersEn = "A reservation with partition gets its own order and can be assigned directly to an order.| A reservation without a partition is summarised with other orders in the order window",

                    QuizCategory = new List<string> { "Parameter" }
                 },
                 
                 new Question
                 {
                    Number = 76,

                    TextDe = "Wofür werden Pseudo-Kontrakte verwendet?",
                    Answer1De = "Das sind Kontrakte auf die nur bestimmte Benutzer zugreifen können",
                    Answer2De = "Damit kann ein zusätzlicher SiB vorgegeben werden",
                    Answer3De = "Diese Kontrakte werden für Kommentare verwendet",
                    CorrectAnswersDe = "Damit kann ein zusätzlicher SiB vorgegeben werden",

                    TextEn = "What are pseudo-contracts used for?",
                    Answer1En = "These are contracts that only certain users can access",
                    Answer2En = "This can be used to define an additional SFT..",
                    Answer3En = "These contracts can be used for comments",
                    CorrectAnswersEn = "define an additional Sft",

                    QuizCategory = new List<string> { "Paramter", "Kondition" }
                 },

                 new Question
                 {
                    Number = 77,

                    TextDe = "Wie viele Kontrakte kann ein Artikel haben?",
                    Answer1De = "Ein Artikel kann mehrere Kontrakte haben",
                    Answer2De = "Keine, weil Kontrakte nicht auf der Artikelebene vergeben werden können",
                    Answer3De = "Ein Kontrakt pro Artikel",
                    CorrectAnswersDe = "Ein Artikel kann mehrere Kontrakte haben",

                    TextEn = "How many contracts can an article have?",
                    Answer1En = "An article can have multiple contracts",
                    Answer2En = "None, as contracts do not run at article level",
                    Answer3En = "One contract per article",
                    CorrectAnswersEn = "An article can have multiple contracts",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 78,

                    TextDe = "Wie viele Lieferanten können einer SKU zugeordnet werden?",
                    Answer1De = "5",
                    Answer2De = "1",
                    Answer3De = "Es gibt keine Begrenzung",
                    CorrectAnswersDe = "Es gibt keine Begrenzung",

                    TextEn = "How many suppliers can be assigned to a SKU?",
                    Answer1En = "5",
                    Answer2En = "1",
                    Answer3En = "There is no limit",
                    CorrectAnswersEn = "There is no limit",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 79,
                    
                    TextDe = "Wo kann eingestellt werden dass Lieferantenkontrakte gesplittet werden können?",
                    Answer1De = "Parameter -> Dispo -> Kontraktart die Option \"Lieferantenauswahl\" und / oder \"Max. Menge\"",
                    Answer2De = "Parameter -> Dispo -> Kontraktauswahl die Option \"Nach Restmenge\"",
                    Answer3De = "Konditionen -> Kontrakte -> Spaltenauswahl die Option \"Ext. Kontrakt-Pos-Nr\".",
                    CorrectAnswersDe = "Parameter -> Dispo -> Kontraktart die Option \"Lieferantenauswahl\" und / oder \"Max. Menge\"",

                    TextEn = "Where can I set up that supplier contracts should be split?",
                    Answer1En = "Parameters -> Replenishment -> Contract type: \"Select Supplier\" and / or \"Max. Quantity\"",
                    Answer2En = "Parameters -> Replenishment -> Select contract:  \"By rest quantity\"",
                    Answer3En = "Conditions -> Contracts -> Columns (Right Click): \"Ext. contract pos no\"",
                    CorrectAnswersEn = "Parameters -> Replenishment -> Contract type: \"Select Supplier\" and / or \"Max. Quantity\"",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 80,

                    TextDe = "Was passiert mit dem Bestellverhalten bei der Kontraktauswahl \"Nach Vertragsende\"?",
                    Answer1De = "Es wird bei dem Lieferanten bestellt dessen Kontrakt als nächstes endet, wenn der Kontrakt noch nicht erfüllt ist",
                    Answer2De = "Bestellt wird immer beim Lieferanten mit der kürzesten Wiederbeschaffungszeit (WBZ)",
                    Answer3De = "Bestellt wird nur dann, wenn der Kontrakt vollständig erfüllt wird.",
                    CorrectAnswersDe = "Es wird bei dem Lieferanten bestellt dessen Kontrakt als nächstes endet, wenn der Kontrakt noch nicht erfüllt ist",

                    TextEn = "What does the Option \"By timeout contract\" mean at the field \"Select contract\"",
                    Answer1En = "It is ordered from the supplier whose contract ends next if the contract has not been fulfilled yet",
                    Answer2En = "Orders are always placed with the supplier with the shortest Total Lead Time (TLT)",
                    Answer3En = "Orders are only placed if the contract will be than fully fulfilled",
                    CorrectAnswersEn = "It is ordered from the supplier whose contract ends next if the contract has not been fulfilled yet",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 81,

                    TextDe = "Was passiert mit dem Bestellverhalten bei der Kontraktart \"Dauerauftrag/Bestellungsaufteilung\"?",
                    Answer1De = "Bestellmengen für SKUs mit mehreren Lieferanten können nicht aufgeteilt werden",
                    Answer2De = "Die Aufteilung der Bestellmengen einer einzelnen SKU auf mehrere Lieferanten ist möglich",
                    Answer3De = "Es werden Bestellungen generiert mit einer festen Bestellmenge für den angegeben Zeitraum",
                    CorrectAnswersDe = "Die Aufteilung der Bestellmengen einer einzelnen SKU auf mehrere Lieferanten ist möglich| Es werden Bestellungen generiert mit einer festen Bestellmenge für den angegebenen Zeitpunkt",

                    TextEn = "What does the contract type “Standing order/Order split” do?",
                    Answer1En = "Order quantities for SKUs with multiple suppliers cannot be split",
                    Answer2En = "It is possible to split the order quantities of a single SKU between several suppliers",
                    Answer3En = "Orders are generated with a fixed order quantity for a specified period",
                    CorrectAnswersEn = "It is possible to split the order quantities of a single SKU between several suppliers| Orders are generated with a fixed order quantity for a specified period",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 82,

                    TextDe = "Was passiert mit dem Bestellverhalten bei der Kontraktart \"Max.Menge\"?",
                    Answer1De = "Es wird immer soviel bestellt dass der Max. Bestand erreicht wird von der SKU",
                    Answer2De = "Mit diese Kontraktart kann eine maximale Abrufmenge der Kontrakt festgelegt werden",
                    Answer3De = "Es wird die maximal abrufbare Menge vom Lieferanten bestellt bis der Kontakt aufgebraucht wurde",
                    CorrectAnswersDe = "Es wird die maximal abrufbare Menge vom Lieferanten bestellt bis der Kontakt aufgebraucht wurde",

                    TextEn = "What does the contract type “Max. quantity” do?",
                    Answer1En = "Orders are always placed until the maximum stock capacity of the SKU is reached.",
                    Answer2En = "A maximum contract order quantity can be defined with this contract type",
                    Answer3En = "The maximum quantity that can be requested from a supplier is ordered until the contact has been fulfilled",
                    CorrectAnswersEn = "The maximum quantity that can be requested from a supplier is ordered until the contact has been fulfilled",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 83,

                    TextDe = "Welche Farbe haben negative Aktionen in der Prognosegrafik? (standardgemäß)",
                    Answer1De = "weiß",
                    Answer2De = "blau",
                    Answer3De = "rot",
                    CorrectAnswersDe = "weiß",

                    TextEn = "What color do negative promotions have in the forecast chart? (by default)",
                    Answer1En = "white",
                    Answer2En = "blue",
                    Answer3En = "red",
                    CorrectAnswersEn = "white",

                    QuizCategory = new List<string> { "Prognose"}
                 },

                 new Question
                 {
                    Number = 84,

                    TextDe = "Was sind Semi-Aktionen?",
                    Answer1De = "Semi-Aktionen werden angezeigt bei einer Ausreißer-Behandlung",
                    Answer2De = "Semi-Aktionen sind Aktionen, bei denen der Zeitraum bekannt ist aber die Menge unbekannt ist",
                    Answer3De = "Semi-Aktionen sind Aktionen aus der Vergangenheit",
                    CorrectAnswersDe = "Semi-Aktionen sind Aktionen, bei denen sowohl der Zeitraum als auch die Menge unbekannt sind.| Semi-Aktionen sind Aktionen aus der Vergangenheit",

                    TextEn = "What are semi-promotions?",
                    Answer1En = "Semi-promotions are displayed for outlier corrections",
                    Answer2En = "\"Semi-promotions\" are promotions where the time period is known but the quantity is unknown",
                    Answer3En = "Semi-promotions are Promotions from the past",
                    CorrectAnswersEn = "\"Semi-promotions\" are promotions where the time period is known but the quantity is unknown | Semi-promotions are Promotions from the past",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 85,

                    TextDe = "Was symbolisiert ein Parameter/Konditions-Feld, wenn dieses blau & unterstrichen angezeigt wird?",
                    Answer1De = "Der Wert wurde auf der aktuellen Ebene erfasst.",
                    Answer2De = "Der Wert gehört zu einer Verbundgruppe.",
                    Answer3De = "Der Wert wurde von einer höheren Ebene geerbt.",
                    CorrectAnswersDe = "Der Wert wurde von einer höheren Ebene geerbt",

                    TextEn = "What does a parameter/condition field indicate when it is displayed in blue & underlined?",
                    Answer1En = "The value was entered at the current level",
                    Answer2En = "The value belongs to a compound group",
                    Answer3En = "The value was passed on from a higher level",
                    CorrectAnswersEn = "The value was passed on from a higher level",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 86,

                    TextDe = "Was symbolisiert ein Parameter/Konditions-Feld, wenn dieses grün & unterstrichen angezeigt wird?",
                    Answer1De = "Der Wert wurde von einer Klasse geerbt.",
                    Answer2De = "Der Wert wurde auf der aktuellen Ebene erfasst.",
                    Answer3De = "Der Wert wurde von einer anderen SKU übernommen. ",
                    CorrectAnswersDe = "Der Wert wurde von einer Klasse geerbt",

                    TextEn = "What does a parameter/condition field indicate when it is displayed in green & underlined?",
                    Answer1En = "The value was passed on from a class",
                    Answer2En = "The value was entered at the current level",
                    Answer3En = "The value was adopted from another SKU",
                    CorrectAnswersEn = "The value was passed on from a class",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 87,

                    TextDe = "Automatische Aktionen, die Vergangenheitswerte korrigieren, können entstehen…",
                    Answer1De = "durch die Prognose",
                    Answer2De = "durch die OoS-Bereinigung",
                    Answer3De = "durch eine Strukturbruch-Erkennung",
                    CorrectAnswersDe = "durch die OoS-Bereinigung| durch die Behandlung von Ausreißern",

                    TextEn = "Automatic promotions that correct historical values can occur...",
                    Answer1En = "by the forecast",
                    Answer2En = "by the OoS correction",
                    Answer3En = "by treating outliers",
                    CorrectAnswersEn = "by the OoS correction | by treating outliers",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 88,

                    TextDe = "Welche Funktion haben Info-Aktionen?",
                    Answer1De = "Semi-Aktionen die auf Info-Aktionen geändert werden, können für die Prognose mit berücksichtigt werden",
                    Answer2De = "Zeiträume mit diesen Aktionen werden nicht für die Prognoserechnung verwendet",
                    Answer3De = "Eine Info-Aktion hat keinen Einfluss auf die Prognose, aber besitzt Kommentare um auf besondere Umstände hinzuweisen",
                    CorrectAnswersDe = "Semi-Aktionen die auf Info-Aktionen geändert, werden können für die Prognose mit berücksichtigt werden",

                    TextEn = "What is the function of info-promotions ?",
                    Answer1En = "Semi-promotions that are changed to info actions can be included in the forecast",
                    Answer2En = "Periods with these actions are not used for forecast calculation",
                    Answer3En = "An info promotion has no influence on the forecast, but has comments to point out special circumstances",
                    CorrectAnswersEn = "Semi-promotions that are changed to info actions can be included in the forecast",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 89,

                    TextDe = "Was bewirken Stichtage?",
                    Answer1De = "Stichtage ermöglichen variable Saisons",
                    Answer2De = "Stichtage verhindern, dass saisonale Schwankungen erkannt werden können",
                    Answer3De = "Stichtage werden verwendet um vor Preisschwankungen zu warnen",
                    CorrectAnswersDe = "Stichtage ermöglichen variable Saisons",

                    TextEn = "What effect do \"Key Dates\" have?",
                    Answer1En = "Key dates allow variable seasons",
                    Answer2En = "Key dates prevent the detection of seasonal swings",
                    Answer3En = "Key dates are used to warn about price swings",
                    CorrectAnswersEn = "Key dates allow variable seasons",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 90,

                    TextDe = "Welche Aussage stimmt nicht?",
                    Answer1De = "Der SiB ist die Menge, die auf Lager sein muss, damit keine Out-of-Stock-Situation eintritt.",
                    Answer2De = "Der SiB ist der durchschnittliche Lagerbestand während eines Monats.",
                    Answer3De = "Der SiB sagt aus welche Menge bestellt werden muss um einer OoS-Situation zu entgehen",
                    CorrectAnswersDe = "Der SiB ist der durchschnittliche Lagerbestand während eines Monats| Der SiB sagt aus welche Menge bestellt werden muss um einer OoS-Situation zu entgehen",

                    TextEn = "Which statement is not true?",
                    Answer1En = "The SFT is the quantity that must be in stock in order to compensate for deviations in forecast sales",
                    Answer2En = "The SFT is the average stock level during a month",
                    Answer3En = "The SFT indicates the quantity that must be ordered to avoid an OoS situation",
                    CorrectAnswersEn = "The SFT is the average stock level during a month| The SFT indicates the quantity that must be ordered to avoid an OoS situation",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 91,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Dienstag?",
                    Answer1De = "9 Tage",
                    Answer2De = "10 Tage",
                    Answer3De = "11 Tage",
                    CorrectAnswersDe = "11 Tage",

                    TextEn = "How long would the total lead time be if an order is placed on a Tuesday with the following conditions? ",
                    Answer1En = "9 Days",
                    Answer2En = "10 Days",
                    Answer3En = "11 Days",
                    CorrectAnswersEn = "11 Days",

                    ImagePathDe = "question_091.png",
                    ImagePathEn = "question_091_en.png",

                    QuizCategory = new List<string> { "Bestellung", "Kondition" }
                 },

                 new Question
                 {
                    Number = 92,

                    TextDe = "Was symbolisiert ein Parameter/Konditions-Feld, wenn dieses blau angezeigt wird?",
                    Answer1De = "Das Feld vererbt einen Wert",
                    Answer2De = "Der Wert im Feld wird standardmäßig übergeben",
                    Answer3De = "Das Feld wird nicht verwendet",
                    CorrectAnswersDe = "Der Wert im Feld wird standardmäßig übergeben",

                    TextEn = "What does a parameter/condition field indicate when it is displayed in blue?",
                    Answer1En = "The field passes on a value",
                    Answer2En = "The value in the field is set by default",
                    Answer3En = "The field is not used",
                    CorrectAnswersEn = "The value in the field is set by default",

                    QuizCategory = new List<string> { "Parameter", "Kondition" }
                 },

                 new Question
                 {
                    Number = 93,

                    TextDe = "Was symbolisiert ein Parameter/Konditions-Feld, wenn dieses schwarz angezeigt wird?",
                    Answer1De = "Der Wert im Feld wurde manuell eingepflegt",
                    Answer2De = "Der Wert im Feld wird standardmäßig übergeben",
                    Answer3De = "Das Feld wird nicht verwendet",
                    CorrectAnswersDe = "Der Wert im Feld wurde manuell eingepflegt",

                    TextEn = "What does a parameter/condition field show when it is displayed in black?",
                    Answer1En = "The value in the field was entered manually",
                    Answer2En = "The value in the field is set by default",
                    Answer3En = "The field is not used",
                    CorrectAnswersEn = "The value in the field was entered manually",

                    QuizCategory = new List<string> { "Parameter", "Kondition" }
                 },

                 new Question
                 {
                    Number = 94,

                    TextDe = "Welchen Unterschied macht es, wenn ein Konditions- / Parameter-Feld unterstrichen wird oder nicht?",
                    Answer1De = "Ein unterstrichenes Feld wurde von einem User bearbeitet",
                    Answer2De = "Wenn ein Feld unterstrichen ist bedeutet es das dieser Wert von einer höheren Ebene vererbt wurde",
                    Answer3De = "Es gibt keine eindeutige Bedeutung",
                    CorrectAnswersDe = "Wenn ein Feld unterstrichen ist bedeutet es das dieser Wert von einer höheren Ebene vererbt wurde",

                    TextEn = "What difference does it make if a condition / parameter field is underlined or not?",
                    Answer1En = "An underlined field has been edited by a user",
                    Answer2En = "If a field is underlined, it means that this value was passed on from a higher level",
                    Answer3En = "There is no clear meaning",
                    CorrectAnswersEn = "If a field is underlined, it means that this value was passed on from a higher level",

                    QuizCategory = new List<string> { "Parameter", "Kondition" }
                 },

                 new Question
                 {
                    Number = 95,

                    TextDe = "Welche Auswirkung hat eine Kontraktart?",
                    Answer1De = "Die Kontraktart bestimmt, wie mit Kontrakten umgegangen werden soll",
                    Answer2De = "Die Kontraktart bestimmt, ob es sich um einen Lieferanten-, Artikel- oder Kundenkontrakt handelt",
                    Answer3De = "Die Kontraktart bestimmt welche Kontrakte gewählt werden sollen",
                    CorrectAnswersDe = "Die Kontraktart bestimmt, wie mit Kontrakten umgegangen werden soll",

                    TextEn = "What is the effect of a contract type?",
                    Answer1En = "The contract type defines how contracts should be handled",
                    Answer2En = "The contract type determines whether it is a supplier, article or customer contract",
                    Answer3En = "The contract type determines which contracts should be chosen",
                    CorrectAnswersEn = "The contract type defines how contracts should be handled",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 96,

                    TextDe = "Welche Auswirkung hat eine Kontraktauswahl?",
                    Answer1De = "Mit der Kontraktauswahl kann ein Kontrakt statisch übergeben werden, bis dieser erfüllt wurde",
                    Answer2De = "Die Kontraktauswahl bestimmt welche Kontrakte gewählt werden sollen",
                    Answer3De = "Die Kontraktauswahl bestimmt, wie mit Kontrakten umgegangen werden soll",
                    CorrectAnswersDe = "Die Kontraktauswahl bestimmt welche Kontrakte gewählt werden sollen",

                    TextEn = "What is the effect of the \"Select contract\" field?",
                    Answer1En = "With the select contract function, a contract can be assigned statically until it has been fulfilled",
                    Answer2En = "The select contract function determines which contracts are to be chosen",
                    Answer3En = "The select contract function defines how contracts are to be handled",
                    CorrectAnswersEn = "The select contract function determines which contracts are to be chosen",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 97,

                    TextDe = "Was bewirkt die Kontraktauswahl „Nach Restmenge“?",
                    Answer1De = "Der Kontrakt mit der niedrigsten Restlaufzeit wird verwendet",
                    Answer2De = "Der Kontrakt mit der größten Restmenge wird verwendet",
                    Answer3De = "Der Kontrakt mit der niedrigsten Restmenge wird verwendet",
                    CorrectAnswersDe = "Der Kontrakt mit der größten Restmenge wird verwendet",

                    TextEn = "What does the select contract function “By rest quantity” do?",
                    Answer1En = "The contract with the lowest remaining duration is used",
                    Answer2En = "The contract with the largest remaining quantity is used",
                    Answer3En = "The contract with the lowest remaining quantity is used",
                    CorrectAnswersEn = "The contract with the largest remaining quantity is used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 98,

                    TextDe = "Was bewirkt die Kontraktauswahl „RMge / RLfz“?",
                    Answer1De = "Der Kontrakt mit der höchsten prozentualen Restmenge wird verwendet",
                    Answer2De = "Der Kontrakt mit der höchsten durchschnittlichen Restmenge pro Tag wird verwendet",
                    Answer3De = "Der Kontrakt mit der höchsten prozentualen Restmenge pro Tag wird verwendet",
                    CorrectAnswersDe = "Der Kontrakt mit der höchsten durchschnittlichen Restmenge pro Tag wird verwendet",

                    TextEn = "What is the effect of the select contract “RQty / RTm”?",
                    Answer1En = "The contract with the highest remaining quantity in % is used",
                    Answer2En = "The contract with the highest average remaining quantity per day is used",
                    Answer3En = "The contract with the highest remaining quantity in % per day is used",
                    CorrectAnswersEn = "The contract with the highest average remaining quantity per day is used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 99,

                    TextDe = "Was bewirkt die Kontraktauswahl „RMge / GMge“?",
                    Answer1De = "Der Kontrakt mit der höchsten prozentualen Restmenge pro Tag wird verwendet",
                    Answer2De = "Der Kontrakt mit der höchsten prozentualen Restmenge wird verwendet",
                    Answer3De = "Der Kontrakt mit der höchsten durchschnittlichen Restmenge pro Tag wird verwendet",
                    CorrectAnswersDe = "Der Kontrakt mit der höchsten prozentualen Restmenge wird verwendet",

                    TextEn = "What is the effect of the select contract “RQty / GTm”?",
                    Answer1En = "The contract with the highest remaining quantity in % per day is used",
                    Answer2En = "The contract with the highest remaining quantity in % is used",
                    Answer3En = "The contract with the highest average remaining quantity per day is used",
                    CorrectAnswersEn = "The contract with the highest remaining quantity in % is used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 100,

                    TextDe = "Was bewirkt die Kontraktauswahl „(RMge / GMge) * (1 / RLfz)“?",
                    Answer1De = "Der Kontrakt mit der höchsten durchschnittlichen Restmenge pro Tag wird verwendet",
                    Answer2De = "Der Kontrakt mit der niedrigsten prozentualen Restmenge pro Tag wird verwendet",
                    Answer3De = "Der Kontrakt mit der höchsten prozentualen Restmenge pro Tag wird verwendet",
                    CorrectAnswersDe = "Der Kontrakt mit der höchsten prozentualen Restmenge pro Tag wird verwendet",

                    TextEn = "What does the contract selection \"(RMge / GMge) * (1 / RLfz)\" do?",
                    Answer1En = "The contract with the highest average remaining quantity per day is used",
                    Answer2En = "The contract with the lowest remaining quantity in % per day is used",
                    Answer3En = "The contract with the highest remaining quantity in % per day is used",
                    CorrectAnswersEn = "The contract with the lowest remaining quantity in % per day is used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 101,

                    TextDe = "Was bewirkt die Kontraktauswahl „(RMge / GMge) * (GLfz / RLfz)“?",
                    Answer1De = "Der Kontrakt mit, der am stärksten steigenden durchschnittlichen Restmenge pro Tag wird, verwendet",
                    Answer2De = "Der Kontrakt mit der höchsten durchschnittlichen Restmenge pro Tag wird verwendet",
                    Answer3De = "Der Kontrakt mit der höchsten prozentualen Restmenge pro Tag wird verwendet",
                    CorrectAnswersDe = "Der Kontrakt mit, der am stärksten steigenden durchschnittlichen Restmenge pro Tag wird, verwendet",

                    TextEn = "What is the effect of the select contract “(RMge / GMge) * (GLfz / RLfz)”?",
                    Answer1En = "The contract with the highest increasing average remaining quantity per day is used",
                    Answer2En = "The contract with the highest average remaining quantity per day is used",
                    Answer3En = "The contract with the highest remaining quantity in % per day is used",
                    CorrectAnswersEn = "The contract with the highest increasing average remaining quantity per day is used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 102,

                    TextDe = "Was bewirkt die Kontraktauswahl „Bestell-Verhältnis“?",
                    Answer1De = "Die Bestellmenge wird auf mehrere Lieferanten aufgeteilt im angegebenen Verhältnis",
                    Answer2De = "Die Kontraktmenge vom ausgewählten Kontrakt wird verbraucht und der Rest wird mit anderen Kontrakten aufgefüllt",
                    Answer3De = "Der Kontrakt vom Hauptlieferanten wird verwendet",
                    CorrectAnswersDe = "Die Bestellmenge wird auf mehrere Lieferanten aufgeteilt im angegebenen Verhältnis",

                    TextEn = "What does the select contract \"Order Ratio\" do?",
                    Answer1En = "The order quantity is divided among several suppliers in the specified ratio",
                    Answer2En = "The contract quantity from the selected contract is consumed and the rest is replenished with other contracts",
                    Answer3En = "The contract from the main supplier is used",
                    CorrectAnswersEn = "The order quantity is divided among several suppliers in the specified ratio",

                    QuizCategory = new List<string> { "Paramter" }
                 },

                 new Question
                 {
                    Number = 103,

                    TextDe = "Welche Kontraktart muss ausgewählt sein damit die Kontraktauswahl verwendet wird?",
                    Answer1De = "Lieferantenauswahl",
                    Answer2De = "Dauerauftrag/ Bestellungsaufteilung",
                    Answer3De = "\"Max. Menge & Lieferantenauswahl\"",
                    CorrectAnswersDe = "Lieferantenauswahl | \"Max. Menge & Lieferantenauswahl\"",

                    TextEn = "Which contract type must be selected for the contract selection to be used?",
                    Answer1En = "Supplier selection",
                    Answer2En = "Standing order/ order splitting",
                    Answer3En = "Max. Qty + Supplier selection",
                    CorrectAnswersEn = "Supplier selection| Max. Qty + Supplier selection",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 104,

                    TextDe = "Was bewirkt die Kontraktart „Kontrakte ignorieren“?",
                    Answer1De = "Die Kontrakte werden bis zum nächsten Bestelltermin nicht verwendet",
                    Answer2De = "Die in den Konditionen eingetragene Kontrakte werden nicht verwendet",
                    Answer3De = "Die gewählte Kontraktauswahl wird ignoriert",
                    CorrectAnswersDe = "Die in den Konditionen eingetragene Kontrakte werden nicht verwendet",

                    TextEn = "What does the contract type “Ignore contracts” do?",
                    Answer1En = "The contracts will not be used until the next order date",
                    Answer2En = "Contracts will not be used",
                    Answer3En = "The select contract is ignored",
                    CorrectAnswersEn = "Contracts will not be used",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 105,

                    TextDe = "Was bewirkt die Kontraktart „Max. Menge u. Lieferantenauswahl“?",
                    Answer1De = "Es wird immer der Kontrakt mit der höchsten Kontraktmenge gewählt",
                    Answer2De = "Es wird der Kontrakt gewählt, der zum Entscheidungskriterium von der Kontraktauswahl am ehesten passt und es wird anschließend die maximal abrufbare Menge bestellt",
                    Answer3De = "Es wird immer der Kontrakt mit der höchsten abrufbaren Menge gewählt",
                    CorrectAnswersDe = "Es wird der Kontrakt gewählt, der zum Entscheidungskriterium von der Kontraktauswahl am ehesten passt und es wird anschließend die maximal abrufbare Menge bestellt",

                    TextEn = "What does the contract type \"Max Quantity & Supplier Selection\" do?",
                    Answer1En = "The contract with the highest contract quantity is selected",
                    Answer2En = "The contract that most closely matches the decision criterion of contract selection is selected and the maximum callable quantity is then ordered",
                    Answer3En = "The contract with the highest callable quantity is always selected",
                    CorrectAnswersEn = "The contract that most closely matches the decision criterion of contract selection is selected and the maximum callable quantity is then ordered",

                    QuizCategory = new List<string> { "Paramter" }
                 },

                 new Question
                 {
                    Number = 106,

                    TextDe = "Wofür wird der Parameter \"Berechnung von Semi-Aktionen\" benutzt?",
                    Answer1De = "Mit diesen Parameter legen Sie Typen fest, wie die \r\nAktionsmengen berechnet werden sollen",
                    Answer2De = "Damit kann man sich deutliche und beständige Niveau-Änderung in der Historie anzeigen lassen",
                    Answer3De = "Mit dem Parameter werden, im Planungshorizont, Akionen mit berücksichtigt",
                    CorrectAnswersDe = "Mit diesen Parameter legen Sie Typen fest, wie die \r\nAktionsmengen berechnet werden sollen",

                    TextEn = "What is the \"Semi-Promotion Calculation\" parameter used for?",
                    Answer1En = "Use these parameters to define types, such as the promotion quantities to be calculated",
                    Answer2En = "This allows you to display clear and consistent level changes in the history",
                    Answer3En = "With this parameter, promotions are taken into account in the planning horizon",
                    CorrectAnswersEn = "Use these parameters to define types, such as the Promotion quantities to be calculated",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 107,

                    TextDe = "Wie werden die Aktionsmengen von Semi-Aktionen, bei dem Parameter-Typen \"Rel zu aktionsfreier Zeit\", berechnet?",
                    Answer1De = "Aktionsmengen werden auf die mittlere Abgangsmenge der aktionsfreien Perioden reduziert.",
                    Answer2De = "Die Aktionsmenge ergibt sich aus dem durchschnittlichen Preisunterschied vor und während der Aktion",
                    Answer3De = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht",
                    CorrectAnswersDe = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht",

                    TextEn = "What does the type ''Rel to non-promotion time'' do when calculating semi-promotions?",
                    Answer1En = "Promotion quantities are calculated exclusively from the warehouse stocks during the promotion",
                    Answer2En = "The promotional quantity is the average price difference before and during the promotion",
                    Answer3En = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods",
                    CorrectAnswersEn = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 108,

                    TextDe = "Wie wird die Berechnung von Semi-Aktionen, bei dem Parameter-Typen, \"Rel zu aktionsfreier Zeit + ggf. Info setzen\", beeinflusst? ",
                    Answer1De = "Aktionsmengen werden anhand von Info-Aktionen berechnet, falls welche vorhanden sind",
                    Answer2De = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht. Endet die Semi-Aktion, bevor der erste \r\nAbverkauf stattfindet, wird sie automatisch zu einer Info-Aktion",
                    Answer3De = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht",
                    CorrectAnswersDe = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht. Endet die Semi-Aktion, bevor der erste \r\nAbverkauf stattfindet, wird sie automatisch zu einer Info-Aktion",

                    TextEn = "How is the calculation of semi-promotions affected, with the parameter type \"'Rel to non promotion time + set info if necessary\"?",
                    Answer1En = "Promotion quantities are calculated using info actions, if any are available",
                    Answer2En = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods. If the Semi-promotion ends before the first \r\nsale takes place, it automatically becomes an info promotion",
                    Answer3En = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods",
                    CorrectAnswersEn = "No calculation is made. If the semi-promotion ends before the first sale takes place, it is automatically counted as an info promotion",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 109,

                    TextDe = "Wie werden die Aktionsmengen von Semi-Aktionen, bei dem Parameter-Typen \"Rel zu Ex-Post-Prognose\", berechnet?",
                    Answer1De = "Aktionsmengen werden auf die mittlere Abgangsmenge der aktionsfreien Perioden reduziert.",
                    Answer2De = "Aktionsmengen werden aus dem Verhältnis von Verkäufen zur Ex-Post-Prognose berechnet",
                    Answer3De = "Die Aktionsmenge wird durch den Durchschnitt der Verkäufe aus den vorherigen Aktionen berechnet",
                    CorrectAnswersDe = "Aktionsmengen werden aus dem Verhältnis von Verkäufen zur Ex-Post-Prognose berechnet",

                    TextEn = "How are the promotion quantities of semi-promotions calculated for the parameter type \"Rel to Ex-Post Forecast\"?",
                    Answer1En = "Promotion quantities are reduced to the average issue quantity of the promotion-free periods.",
                    Answer2En = "Promotions quantities are calculated from the ratio of sales to the ex-post forecast",
                    Answer3En = "The promotion quantity is calculated by the average of sales from the previous promotions",
                    CorrectAnswersEn = "Promotion quantities are calculated from the ratio of sales to the ex-post forecast.",

                    QuizCategory = new List<string> { "Paramter" }
                 },

                 new Question
                 {
                    Number = 110,

                    TextDe = "Wie werden die Berechnung von Semi-Aktionen, bei dem Parameter-Typen ''Rel. zu aktionsfreier Zeit mit OoS-Korrektur'', beeinflusst?",
                    Answer1De = "Für diesen Parameter sind nur zukünftige Verkaufsprognosen notwendig",
                    Answer2De = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht. Hat eine Aktion während einer OoS-Periode stattgefunden, werden entgangene Aktionsmengen mit berechnet",
                    Answer3De = "Entgangene Aktionsmengen werden anhand der Bestellungen im Aktionszeitraum ermittelt",
                    CorrectAnswersDe = "Die Aktionsmenge wird berechnet, indem man die Verkäufe während der Aktion mit den Verkäufen in Zeiten ohne Aktion vergleicht. Hat eine Aktion während einem OoS-Zeitpunkt stattgefunden, werden entgangene Aktionsmengen mit berechnet",

                    TextEn = "What does the type ''Rel. to non promotion time with OoS correction'' do when calculating semi-promotions?",
                    Answer1En = "Only future sales forecasts are required for this parameter.",
                    Answer2En = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods. If an promotion has taken place during an OoS period, lost promotion quantities are also calculated",
                    Answer3En = "Missed promotional quantities are determined on the basis of orders placed during the promotional period.",
                    CorrectAnswersEn = "The promotional quantity is calculated by comparing the sales during the promotion with the sales during non-promotional periods. If an promotion has taken place during an OoS period, lost promotion quantities are also calculated",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 111,

                    TextDe = "Wie werden die Berechnung von Semi-Aktionen, bei dem Parameter-Typen ''Rel. zur Ex-Post-Prognose mit OoS-Korrektur'', beeinflusst?",
                    Answer1De = "Dieser Parameter funktioniert auch ohne historische Daten.",
                    Answer2De = "Entgangene Aktionsmengen basieren ausschließlich auf den geplanten Liefermengen.",
                    Answer3De = "Aktionsmengen werden aus dem Verhältnis von Verkäufen zur Ex-Post-Prognose berechnet. Hat eine Aktion während einem OoS-Zeitpunkt stattgefunden, werden entgangene Aktionsmengen mit berechnet",
                    CorrectAnswersDe = "Aktionsmengen werden aus dem Verhältnis von Verkäufen zur Ex-Post-Prognose berechnet. Hat eine Aktion während einem OoS-Zeitpunkt stattgefunden, werden entgangene Aktionsmengen mit berechnet",

                    TextEn = "What does the type ''Rel. to ex-post forecast with OoS correction'' do when calculating semi-promotions?",
                    Answer1En = "This parameter also works without historical data.",
                    Answer2En = "Missed promotion quantities are based exclusively on the planned delivery quantities.",
                    Answer3En = "Promotion quantities are calculated from the ratio of sales to the ex-post forecast. If an promotion has taken place during an OoS time, lost action quantities are also calculated",
                    CorrectAnswersEn = "Promotion quantities are calculated from the ratio of sales to the ex-post forecast. If an promotion has taken place during an OoS time, lost action quantities are also calculated",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Number = 112,

                    TextDe = "Wo kann ich die \"Ausreißer-Erkennung\" bearbeiten?",
                    Answer1De = "Parameter -> Strukturbruch/Ausreißer -> Strukturbrucherkennung",
                    Answer2De = "Parameter -> Strukturbruch/Ausreißer -> Ausreißererkennung",
                    Answer3De = "Parameter -> Strukturbruch/Ausreißer -> OoS-Analyse",
                    CorrectAnswersDe = "Parameter -> Strukturbruch/Ausreißer -> Ausreißererkennung",

                    TextEn = "Where can I deactivate the outlier detection?",
                    Answer1En = "Parameters -> Structure break/ Outlier -> Structure break detection",
                    Answer2En = "Parameters -> Structure break/ Outlier -> Outlier detection",
                    Answer3En = "Parameter -> Structure break/outlier -> OoS-Analysis",
                    CorrectAnswersEn = "Parameters -> Structure break/ Outlier -> Outlier detection",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 /*new Question
                 {
                    Number = 113,

                    TextDe = "Wie viele SiB-Typen gibt es?",
                    Answer1De = "5",
                    Answer2De = "9",
                    Answer3De = "30",
                    CorrectAnswersDe = "9",

                    TextEn = "How many Sft types are there?",
                    Answer1En = "5",
                    Answer2En = "9",
                    Answer3En = "30",
                    CorrectAnswersEn = "9",

                    QuizCategory = new List<string> { "Parameter" }
                 },*/

                 new Question
                 {
                    Number = 114,

                    TextDe = "Was passiert wenn der Parameter \"Prognose-Einstellungen mit übernehmen\" angehakt wird?",
                    Answer1De = "Die Prognose-Einstellungen vom eingetragenen Vorläufer werden übernommen",
                    Answer2De = "Die Prognose-Einstellungen von der SKU, von der die Saison übernommen wird, werden übernommen",
                    Answer3De = "Alle SKUs einer Gruppe erhalten die gleichen Prognose-Einstellungen",
                    CorrectAnswersDe = "Die Prognose-Einstellungen von der SKU, von der die Saison übernommen wird, werden übernommen",

                    TextEn = "What happens if the parameter \"Also use forecast settings\" is checked?",
                    Answer1En = "The forecast parameter settings from the entered predecessor are used",
                    Answer2En = "The forecast parameter settings from the SKU that the season is taken from are used",
                    Answer3En = "All SKUs in a group receive the same forecast parameter settings",
                    CorrectAnswersEn = "The forecast parameter settings from the SKU that the season is taken from are used",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 115,

                    TextDe = "Was bedeuten die roten Striche am unteren Rand der Bestandssimulation?",
                    Answer1De = "Ein alternativer SiB-Typ, der an jedem Wochenende pausiert",
                    Answer2De = "Feiertage & Wochenenden an dem gar kein Verkauf stattfindet",
                    Answer3De = "Kennzeichnet immer den Anfang der Woche.",
                    CorrectAnswersDe = "Feiertage & Wochenenden an dem gar kein Verkauf stattfindet",

                    TextEn = "What does the red line at the bottom of the stock simulation mean?",
                    Answer1En = "An alternative Sft type who takes a break every weekend",
                    Answer2En = "Public holidays, usually weekends on which there are no sales at all",
                    Answer3En = "Always marks the beginning of the week",
                    CorrectAnswersEn = "Public holidays, usually weekends on which there are no sales at all",

                    ImagePathDe = "question_115.png",
                    ImagePathEn = "question_115_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 116,

                    TextDe = "Was stellen die schwarzen Striche oben bei der Prognose dar?",
                    Answer1De = "Der Prognosehorizont",
                    Answer2De = "Die Standardabweichung",
                    Answer3De = "Die relative Abgangsmenge",
                    CorrectAnswersDe = "Die Standardabweichung",

                    TextEn = "What does the black line at the top of the forecast represent? ",
                    Answer1En = "The forecast horizon",
                    Answer2En = "The standard deviation",
                    Answer3En = "The relative issue amount",
                    CorrectAnswersEn = "The standard deviation",

                    ImagePathDe = "question_116.png",
                    ImagePathEn = "question_116_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 117,

                    TextDe = "Wo kann ich die Farben der Prognosegrafik ändern?",
                    Answer1De = "Unter \"Layout\"",
                    Answer2De = "Unter \"Extras\"",
                    Answer3De = "Unter \"Parameter\"",
                    CorrectAnswersDe = "Unter \"Extras\"",

                    TextEn = "Where can I change the colors of the forecast graphic?",
                    Answer1En = "Under \"Layout\"",
                    Answer2En = "Under \"Extras\"",
                    Answer3En = "Under \"Parameters\"",
                    CorrectAnswersEn = "Under \"Extras\"",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 118,

                    TextDe = "Was passiert mit einer Prognose die einen Prognose-Faktor von 2.0 hat?",
                    Answer1De = "Die Prognose wird halbiert",
                    Answer2De = "Die Prognose wird verdoppelt",
                    Answer3De = "Die Prognose verwendet 2 Prognose-Verfahren",
                    CorrectAnswersDe = "Die Prognose wird verdoppelt",

                    TextEn = "What happens to a forecast that has a forecast factor of 2.0?",
                    Answer1En = "a reduction by half for the forecast",
                    Answer2En = "a duplication of the forecast",
                    Answer3En = "Forecasting uses 2 forecasting methods",
                    CorrectAnswersEn = "a duplication of the forecast",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 119,

                    TextDe = "Was passiert wenn ''Sofort bestellen'' in den Konditionen angehakt wird?",
                    Answer1De = "Alle offenen Bestellungen werden heute bestellt",
                    Answer2De = "Alle Reservierungen werden auf heute vorgezogen",
                    Answer3De = "Der Rhythmusanfang für alle offenen Bestellungen wird auf heute gesetzt",
                    CorrectAnswersDe = "Alle offenen Bestellungen werden heute bestellt",

                    TextEn = "What does ''order immediately'' mean in the conditions?",
                    Answer1En = "All open orders will be ordered today",
                    Answer2En = "All reservations will be brought forward to today",
                    Answer3En = "The start of the rhythm for all open orders is set to today",
                    CorrectAnswersEn = "All open orders will be ordered today",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 120,

                    TextDe = "Welche Bedingungen gibt es damit die Kontaktauswahl \"Bestell-Verhältnis\" funktioniert?",
                    Answer1De = "Man benötigt zwei Lieferanten",
                    Answer2De = "Die Kontraktart \"Lieferantenauswahl\" oder \"Max. Menge u. Lieferantenauswahl\" muss ausgewählt sein",
                    Answer3De = "Mengen-Verhältnis bei den Kontrakten eintragen über das Feld \"Menge\" in den Konditionen",
                    CorrectAnswersDe = "Die Kontraktart \"Lieferantenauswahl\" oder \"Max. Menge u. Lieferantenauswahl\" muss ausgewählt sein| Man benötigt zwei Lieferanten",

                    TextEn = "What are the requirements for the select contract: “order ratio” ?",
                    Answer1En = "You need two suppliers",
                    Answer2En = "The contract type must also be adjusted",
                    Answer3En = "It must belong to a compound order",
                    CorrectAnswersEn = "You need two suppliers | The contract type must also be adjusted",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 121,

                    TextDe = "Werden historische Aktionen bei der Prognose berücksichtigt?",
                    Answer1De = "Ja",
                    Answer2De = "Nein",
                    Answer3De = "Nein, diese sind nur in der Bestandssimulation zusehen",
                    CorrectAnswersDe = "Ja",

                    TextEn = "Are historical promotions taken into account in the forecast?",
                    Answer1En = "Yes",
                    Answer2En = "No",
                    Answer3En = "No, these are only visible in the stock simulation",
                    CorrectAnswersEn = "Yes",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 122,

                    TextDe = "Über welche Felder wird eine variable Saison eingetragen?",
                    Answer1De = "Stichtage",
                    Answer2De = "F&R bietet nur eine statische Saison",
                    Answer3De = "Saison-Vorgabe",
                    CorrectAnswersDe = "Stichtage",

                    TextEn = "Which fields are used to enter a variable season?",
                    Answer1En = "Key Dates",
                    Answer2En = "F&R offers only one static season",
                    Answer3En = "Season Specification",
                    CorrectAnswersEn = "Key Dates",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 123,

                    TextDe = "Was stellen die dunkelgrünen Balkenanteile dar?",
                    Answer1De = "Negative Aktionen",
                    Answer2De = "Positive Aktionen im Falle einer Ausreißererkennung",
                    Answer3De = "Die Behandlungsgrenze für Ausreißer",
                    CorrectAnswersDe = "Positive Aktionen im Falle einer Ausreißererkennung",

                    TextEn = "What do the dark green bars represent? (Default Settings)",
                    Answer1En = "Negative promotions",
                    Answer2En = "Positive promotions in the event of outlier detection",
                    Answer3En = "The outlier treatment limit",
                    CorrectAnswersEn = "Positive promotions in the event of outlier detection",

                    ImagePathDe = "question_123.png",
                    ImagePathEn = "question_123_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 124,

                    TextDe = "Wie wird der Sicherheitsbestand beeinflusst, wenn bei dem Parameter \"Behandlung Aktionsbestellung\" der Typ \"SiB-Erhöhung\" eingestellt wird?",
                    Answer1De = "Der SiB wird dauerhaft um die Aktionsmenge × Prozentsatz erhöht",
                    Answer2De = "Der SiB wird zwischen dem Verfügbar-ab-Datum und dem Aktionsbeginn um die Aktionsmenge × Prozentsatz erhöht und zum Aktionsstart sofort wieder gesenkt",
                    Answer3De = "Der Sicherheitsbestand wird um die Aktionsmenge erhöht",
                    CorrectAnswersDe = "Der SiB wird zwischen dem Verfügbar-ab-Datum und dem \r\nAktionsbeginn um die Aktionsmenge × Prozentsatz erhöht \r\nund zum Aktionsstart sofort wieder gesenkt",

                    TextEn = "What does the “Safety Stock increase” type do in the \"handling promotion order\" parameter?",
                    Answer1En = "The Sft is permanently increased by the promotion quantity × percentage",
                    Answer2En = "The Sft is increased by the promotion quantity × percentage between the available-from date and the start of the promotion and is immediately reduced again at the start of the promotion",
                    Answer3En = "Safety stock is increased by the promotion quantity",
                    CorrectAnswersEn = "The Sft is increased between the available-from date and the \r\nstart of the promotion by the promotion quantity × percentage \r\nand immediately reduced again at the start of the promotion",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 125,

                    TextDe = "Wie wird der Sicherheitsbestand beeinflusst, wenn bei dem Parameter \"Behandlung Aktionsbestellung\" der Typ \"SiB-Erhöhung m. langsamen Abfall\" eingestellt wird?",
                    Answer1De = "Wie \"SiB-Erhöhung\", aber die Reduktion des Sicherheitsbestands beginnt erst nach Ende der Aktion",
                    Answer2De = "Wie \"SiB-Erhöhung\", aber der Sicherheitsbestand bleibt während des gesamten Aktionszeitraums konstant auf dem erhöhten Niveau",
                    Answer3De = "Wie \"SiB-Erhöhung\", aber der SiB wird langsam und gleichmäßig über den gesamten Aktions-Zeitraum verringert",
                    CorrectAnswersDe = "Wie \"SiB-Erhöhung\", aber der SiB wird langsam und gleichmäßig über den gesamten Aktions-Zeitraum verringert",

                    TextEn = "What does the type “Sft increase w. slow decline” do in the \"handling promotion order\" parameter?",
                    Answer1En = "Same as \"SiB increase\", but the reduction of safety stock only begins after the end of the action",
                    Answer2En = "Same as \"SiB increase\", but the safety stock remains constant at the elevated level throughout the promotion period",
                    Answer3En = "Like Sft increase, but the Sft is reduced slowly and evenly over the entire promotion period",
                    CorrectAnswersEn = "Like Sft increase, but the Sft is reduced slowly and evenly over the entire promotion period",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 126,

                    TextDe = "Wie werden Reservierungen beeinflusst, wenn bei dem Parameter \"Behandlung Aktionsbestellung\" der Typ \"Reservierungsdatum vordatieren\" eingestellt wird?",
                    Answer1De = "Das Reservieungsdatum wird auf das Verfügbar-Ab-Datum der Aktion vorgezogen, wenn die Reservierung im Aktionszeitraum stattfindet",
                    Answer2De = "Die Reservierung wird reduziert wenn der Gesamtbestand nicht ausreicht um die Aktionsmenge und die Reservierung zu befriedigen",
                    Answer3De = "Das Reservierungsdatum wird erst nach Ende des Aktionszeitraums angepasst.",
                    CorrectAnswersDe = "Das Reservieungsdatum wird auf das Verfügbar-Ab-Datum der Aktion vorgezogen, wenn die Reservierung im Aktionszeitraum stattfindet",

                    TextEn = "How are reservations affected if the \"Handling promotion order\" parameter is set to \"Predate Reservation Date\"?",
                    Answer1En = "The reservation date will be brought forward to the Available-From date of the promotion if the reservation takes place during the promotion period",
                    Answer2En = "The reservation will be reduced if the total inventory is not sufficient to satisfy the promotional quantity and the reservation",
                    Answer3En = "The reservation date will only be adjusted after the end of the promotional period.",
                    CorrectAnswersEn = "The reservation date will be brought forward to the Available-From date of the promotion if the reservation takes place during the promotion period",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 127,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Montag?",
                    Answer1De = "15 Tage",
                    Answer2De = "17 Tage",
                    Answer3De = "19 Tage",
                    CorrectAnswersDe = "17 Tage",

                    TextEn = "How long would the replenishment time be if an order is placed on a Monday with the following conditions?",
                    Answer1En = "15 Days",
                    Answer2En = "17 Days",
                    Answer3En = "19 Days",
                    CorrectAnswersEn = "17 Days",

                    ImagePathDe = "question_127.png",
                    ImagePathEn = "question_127_en.png",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 128,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Montag?",
                    Answer1De = "25 Tage",
                    Answer2De = "29 Tage",
                    Answer3De = "27 Tage",
                    CorrectAnswersDe = "27 Tage",

                    TextEn = "How long would the replenishment time be if an order is placed on a Monday with the following conditions?",
                    Answer1En = "25 Days",
                    Answer2En = "29 Days",
                    Answer3En = "27 Days",
                    CorrectAnswersEn = "27 Days",

                    ImagePathDe = "question_128.png",
                    ImagePathEn = "question_128_en.png",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 129,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Montag?",
                    Answer1De = "11 Tage",
                    Answer2De = "15 Tage",
                    Answer3De = "19 Tage",
                    CorrectAnswersDe = "11 Tage",

                    TextEn = "How long would the replenishment time be if an order is placed on a Monday with the following conditions?)",
                    Answer1En = "11 Days",
                    Answer2En = "15 Days",
                    Answer3En = "13 Days",
                    CorrectAnswersEn = "11 Days",

                    ImagePathDe = "question_129.png",
                    ImagePathEn = "question_129_en.png",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 130,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Montag?",
                    Answer1De = "13 Tage",
                    Answer2De = "15 Tage",
                    Answer3De = "17 Tage",
                    CorrectAnswersDe = "13 Tage",

                    TextEn = "How long would the replenishment time be if an order is placed on a Monday with the following conditions?",
                    Answer1En = "13 Days",
                    Answer2En = "15 Days",
                    Answer3En = "17 Days",
                    CorrectAnswersEn = "13 Days",

                    ImagePathDe = "question_130.png",
                    ImagePathEn = "question_130_en.png",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 131,

                    TextDe = "Wie lange würde die Wiederbeschaffungszeit sein, wenn mit folgenden Konditionen eine Bestellung getätigt wird an einem Montag?",
                    Answer1De = "12 Tage",
                    Answer2De = "16 Tage",
                    Answer3De = "13 Tage",
                    CorrectAnswersDe = "13 Tage",

                    TextEn = "How long would the replenishment time be if an order is placed on a Monday with the following conditions?",
                    Answer1En = "12 Days",
                    Answer2En = "16 Days",
                    Answer3En = "13 Days",
                    CorrectAnswersEn = "13 Days",

                    ImagePathDe = "question_131.png",
                    ImagePathEn = "question_131_en.png",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Number = 132,

                    TextDe = "Welcher dieser Balken zeigt eine Ausreißer-Korrektur an?",
                    Answer1De = "Der linke Balken",
                    Answer2De = "Der rechte Balken",
                    Answer3De = "Beide Balken",
                    CorrectAnswersDe = "Beide Balken",

                    TextEn = "Which of these bars shows an outlier correction?",
                    Answer1En = "The left bar",
                    Answer2En = "The right bar",
                    Answer3En = "Both",
                    CorrectAnswersEn = "Both",

                    ImagePathDe = "question_132.png",
                    ImagePathEn = "question_132_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 133,

                    TextDe = "Welche Warnung wird erzeugt?",
                    Answer1De = "Max. Reichweite wird überschritten",
                    Answer2De = "Max. Bestand wird überschritten",
                    Answer3De = "Max. Planungshorizont wird überschritten",
                    CorrectAnswersDe = "Max. Bestand wird überschritten",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Max. Coverage is exceeded",
                    Answer2En = "Max. Stock is exceeded",
                    Answer3En = "Max. Planning horizon exceeded",
                    CorrectAnswersEn = "Max. Stock is exceeded",

                    ImagePathDe = "question_133.png",
                    ImagePathEn = "question_133_en.png",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 134,

                    TextDe = "Welche Warnung wird erzeugt?",
                    Answer1De = "Aktuell OoS",
                    Answer2De = "Wahrscheinlich OoS",
                    Answer3De = "Reservierungen können nicht befriedigt werden",
                    CorrectAnswersDe = "Wahrscheinlich OoS| Reservierungen können nicht befriedigt werden",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Currently OoS",
                    Answer2En = "Probably OoS",
                    Answer3En = "Reservations cannot be fulfilled",
                    CorrectAnswersEn = "Probably OoS| Reservations cannot be fulfilled",

                    ImagePathDe = "question_134.png",
                    ImagePathEn = "question_134_en.png",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 135,

                    TextDe = "Wofür wird dieser Block benutzt?",
                    Answer1De = "Um festzulegen wieviel von der Abgangs-Historie verwendet werden soll, für die Prognoserechnung",
                    Answer2De = "Um festzulegen wieviel von der Abgangs-Historie angezeigt werden soll, in der Prognosegrafik",
                    Answer3De = "Um zu begrenzen, für wie weit in der Zukunft Bestellungen generiert werden dürfen",
                    CorrectAnswersDe = "Um festzulegen wieviel von der Abgangs-Historie verwendet werden soll, für die Prognoserechnung",

                    TextEn = "What is this block used for?",
                    Answer1En = "To determine how much of the issue history should be used for the forecast calculation",
                    Answer2En = "To determine how much of the retirement history should be displayed in the forecast graphic",
                    Answer3En = "To limit for how far into the future orders may be generated",
                    CorrectAnswersEn = "To determine how much of the issue history should be used for the forecast calculation",

                    ImagePathDe = "question_135.png",
                    ImagePathEn = "question_135_en.png",

                    QuizCategory = new List<string> { "Bestellung", "Prognose" }
                 },

                 new Question
                 {
                    Number = 136,

                    TextDe = "Welche Warnungen werden erzeugt?",
                    Answer1De = "Ausreißer",
                    Answer2De = "Strukturbruch",
                    Answer3De = "Stark steigende Prognose",
                    CorrectAnswersDe = "Ausreißer| Stark steigende Prognose",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Outlier",
                    Answer2En = "Structure break",
                    Answer3En = "Strongly rising forecast",
                    CorrectAnswersEn = "Outliers| Strongly rising forecast",

                    ImagePathDe = "question_136.png",
                    ImagePathEn = "question_136_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 137,

                    TextDe = "Welche Warnungen werden erzeugt?",
                    Answer1De = "Stark fallende Prognose",
                    Answer2De = "Stark steigende Prognose",
                    Answer3De = "Aktuell keine Standardabweichung",
                    CorrectAnswersDe = "Stark fallende Prognose",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Strongly falling forecast",
                    Answer2En = "Strongly rising forecast",
                    Answer3En = "Currently no standard deviation",
                    CorrectAnswersEn = "Strongly rising forecast",

                    ImagePathDe = "question_137.png",
                    ImagePathEn = "question_137_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 138,

                    TextDe = "Welche Warnungen werden erzeugt?",
                    Answer1De = "Ausreißer",
                    Answer2De = "Strukturbruch",
                    Answer3De = "Möglicher Strukturbruch",
                    CorrectAnswersDe = "Ausreißer",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Outlier",
                    Answer2En = "Structure break",
                    Answer3En = "Possible structure break",
                    CorrectAnswersEn = "Outlier",

                    ImagePathDe = "question_138.png",
                    ImagePathEn = "question_138_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 139,

                    TextDe = "Welche Warnungen werden erzeugt?",
                    Answer1De = "Ausreißer",
                    Answer2De = "Stark fallende Prognose",
                    Answer3De = "Strukturbruch",
                    CorrectAnswersDe = "Ausreißer| Stark fallende Prognose",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Outlier",
                    Answer2En = "Strongly falling forecast",
                    Answer3En = "Structure break",
                    CorrectAnswersEn = "Outlier| Strongly rising forecast",

                    ImagePathDe = "question_139.png",
                    ImagePathEn = "question_139_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 140,

                    TextDe = "Was zeigen die gestrichelten Linien an?",  
                    Answer1De = "Die Ausreißer-Behandlungsgrenze",
                    Answer2De = "Die Ausreißer-Warnungsgrenze",
                    Answer3De = "Den Sicherheitsbestand",
                    CorrectAnswersDe = "Die Ausreißer-Behandlungsgrenze | Die Ausreißer-Warnungsgrenze",

                    TextEn = "What does the dotted lines show?",
                    Answer1En = "The outlier treatment threshold",
                    Answer2En = "The outlier warning threshold",
                    Answer3En = "The SFT",
                    CorrectAnswersEn = "The outlier treatment threshold | The outlier warning threshold",

                    ImagePathDe = "question_140.png",
                    ImagePathEn = "question_140_en.png",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Number = 141,

                    TextDe = "Welche Warnung wird erzeugt?",
                    Answer1De = "Überfällige Bestellungen",
                    Answer2De = "Max. Bestand wird überschritten",
                    Answer3De = "Nachdisponieren",
                    CorrectAnswersDe = "Überfällige Bestellungen",

                    TextEn = "Which warning is generated?",
                    Answer1En = "Overdue orders",
                    Answer2En = "Max. Stock is exceeded",
                    Answer3En = "Redispatching",
                    CorrectAnswersEn = "Overdue orders",

                    ImagePathDe = "question_141.png",
                    ImagePathEn = "question_141_en.png",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 142,

                    TextDe = "Was bedeutet der graue Kasten im Bild?",
                    Answer1De = "Eine bevorstehende Aktion",
                    Answer2De = "In dem Zeitraum soll kein Bestand vorhanden sein",
                    Answer3De = "In diesem Zeitraum sind selbst definierte Betriebsferien",
                    CorrectAnswersDe = "In dem Zeitraum soll kein Bestand vorhanden sein",

                    TextEn = "What does the gray box in the picture mean? ",
                    Answer1En = "An upcoming promotion",
                    Answer2En = "There should be no stock in the period",
                    Answer3En = "During this period are self-defined company vacations",
                    CorrectAnswersEn = "There should be no stock in the period",

                    ImagePathDe = "question_142.png",
                    ImagePathEn = "question_142_en.png",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Number = 143,

                    TextDe = "Welcher Graph zeigt den Min. SiB an?",
                    Answer1De = "Graph 1",
                    Answer2De = "Graph 2",
                    Answer3De = "Graph 1 & Graph 2",
                    CorrectAnswersDe = "Graph 2",

                    TextEn = "Which graph shows the min. SiB? ",
                    Answer1En = "Graph 1",
                    Answer2En = "Graph 2",
                    Answer3En = "Graph 1 & Graph 2",
                    CorrectAnswersEn = "Graph 2",

                    ImagePathDe = "question_143.png",
                    ImagePathEn = "question_143_en.png",

                    QuizCategory = new List<string> { "Parameter", "Allgemein" }
                 },

                 new Question
                 {
                    Number = 144,

                    TextDe = "Was zeigen die vertikalen Striche an?",
                    Answer1De = "Das sind die Termine wann eine Bestellung ausgelöst wird",
                    Answer2De = "Das sind die Termine wann eine Bestellung im WE eintrifft",
                    Answer3De = "Das sind die Standardabweichungen der Bestände",
                    CorrectAnswersDe = "Das sind die Termine wann eine Bestellung ausgelöst wird",

                    TextEn = "What do the vertical lines show? (temp/adrian.pawlak/App_Use-Case/Sim_4.png)",
                    Answer1En = "These are the dates when an order is triggered",
                    Answer2En = "These are the dates when an order will be delivered",
                    Answer3En = "These are the standard deviations of the stocks",
                    CorrectAnswersEn = "These are the dates when an order is triggered",
       
                    ImagePathDe = "question_144.png",
                    ImagePathEn = "question_144_en.png",


                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Number = 145,

                    TextDe = "Was zeigt die blaue Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage die ihr Datum überschritten hat",
                    Answer2De = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt",
                    Answer3De = "Eine Wiedervorlage die übergeben wurde mit einem Datum in der Zukunft",
                    CorrectAnswersDe = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt",

                    TextEn = "What does the blue pin show?",
                    Answer1En = "A Memo that has exceeded its date",
                    Answer2En = "A Memo that was inherited and has no date",
                    Answer3En = "A Memo that has been provided with a date in the future",
                    CorrectAnswersEn = "A Memo that was inherited and has no date",

                    ImagePathDe = "question_145.png",
                    ImagePathEn = "question_145_en.png",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 146,

                    TextDe = "Was zeigt die schwarze Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt ",
                    Answer2De = "Eine Wiedervorlage, die geerbt wurde und ihr Datum überschritten hat",
                    Answer3De = "Eine Wiedervorlage ohne Datum",
                    CorrectAnswersDe = "Eine Wiedervorlage ohne Datum",

                    TextEn = "What does the black pin show? ",
                    Answer1En = "A Memo that was inherited and has no date",
                    Answer2En = "A Memo that has been inherited and has exceeded its date",
                    Answer3En = "A Memo without a date",
                    CorrectAnswersEn = "A Memo without a date",

                    ImagePathDe = "question_146.png",
                    ImagePathEn = "question_146_en.png",

                    QuizCategory = new List<string> { "Allgemein" }
                 },


                new Question
                 {
                    Number = 147,

                    TextDe = "Was zeigt die graue Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage, die geerbt wurde und ein Datum in der Zukunft hat",
                    Answer2De = "Eine Wiedervorlage die ihr Datum überschritten hat",
                    Answer3De = "Eine Wiedervorlage mit Datum in der Zukunft",
                    CorrectAnswersDe = "Eine Wiedervorlage mit Datum in der Zukunft",

                    TextEn = "What does the gray pin show?",
                    Answer1En = "A Memo that was inherited and has a date in the future",
                    Answer2En = "A Memo that has exceeded its date",
                    Answer3En = "A Memo that has been provided with a date in the future",
                    CorrectAnswersEn = "A Memo that has been provided with a date in the future",

                    ImagePathDe = "question_147.png",
                    ImagePathEn = "question_147_en.png",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 148,

                    TextDe = "Was zeigt die rote Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage, die geerbt wurde und ihr Datum überschritten hat",
                    Answer2De = "Eine Wiedervorlage, die ihr Datum überschritten hat",
                    Answer3De = "Eine Wiedervorlage ohne Datum",
                    CorrectAnswersDe = "Eine Wiedervorlage, die ihr Datum überschritten hat",

                    TextEn = "What does the red pin show?",
                    Answer1En = "A Memo that has been inherited and has exceeded its date",
                    Answer2En = "A Memo that has exceeded its date",
                    Answer3En = "A Memo without a date",
                    CorrectAnswersEn = "A Memo that has exceeded its date",

                    ImagePathDe = "question_148.png",
                    ImagePathEn = "question_148_en.png",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Number = 149,

                    TextDe = "Was zeigen die roten Pfeile in der Bestandssimulation an?",
                    Answer1De = "Sie zeigen den Verfall von Beständen einer SKU an",
                    Answer2De = "Sie zeigen an wann Reservierungen fällig sind",
                    Answer3De = "Sie zeigen den Zeitraum einer Aktion an",
                    CorrectAnswersDe = "Sie zeigen den Verfall von Beständen einer SKU an",

                    TextEn = "What do the red arrows show in the stock simulation? App_Use-Case/Sim_5.png)",
                    Answer1En = "They show the expiration of stocks of an SKU",
                    Answer2En = "They show when reservations are due",
                    Answer3En = "They show the time period of an promotion",
                    CorrectAnswersEn = "They show the expiration of stocks of an SKU",

                    ImagePathDe = "question_149.png",
                    ImagePathEn = "question_149_en.png",

                    QuizCategory = new List<string> { "Kondition" },
                    DifficultyLevel = 3
                },

                 new Question
                 {
                    Number = 150,

                    TextDe = "Woran erkennt man, in der Bestandssimulation, wann eine Bestellung eintrifft?",
                    Answer1De = "An den gestrichelten vertikalen Linien",
                    Answer2De = "An den vertikal steigenden Stellen in der bestandssimulation",
                    Answer3De = "An der gestrichelten horizontalen Linie",
                    CorrectAnswersDe = "An den vertikal steigenden Stellen in der Bestandssimulation",

                    TextEn = "How can you tell when an order arrives in the Stock simulation? ",
                    Answer1En = "By the dotted vertical lines",
                    Answer2En = "By the rising points of the graph",
                    Answer3En = "By the dotted horizontal line",
                    CorrectAnswersEn = "By the rising points of the graph",

                    ImagePathDe = "question_150.png",
                    ImagePathEn = "question_150_en.png",

                    QuizCategory = new List<string> { "Bestellung", "Allgemein" }
             
                 }, 
            
                  new Question
                 {
                    Number = 151,

                    TextDe = "Was zeigt eine hellblaue Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt",
                    Answer2De = "Eine Wiedervorlage, die geerbt wurde und ein Datum in der Zukunft hat",
                    Answer3De = "Eine Wiedervorlage die ein Datum in der Zukunft hat",
                    CorrectAnswersDe = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt",

                    TextEn = "What does the light blue pin show?",
                    Answer1En = "A Memo that was inherited and has no date",
                    Answer2En = "A Memo that was inherited and has a date in the future",
                    Answer3En = "A Memo that has been provided with a date in the future",
                    CorrectAnswersEn = "A Memo that was inherited and has a date in the future",

                    ImagePathDe = "question_151.png",
                    ImagePathEn = "question_151_en.png",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                  new Question
                 {
                    Number = 152,

                    TextDe = "Was zeigt eine lilane Stecknadel an?",
                    Answer1De = "Eine Wiedervorlage, die geerbt wurde und kein Datum besitzt",
                    Answer2De = "Eine Wiedervorlage, die geerbt wurde und ihr Datum überschritten hat",
                    Answer3De = "Eine Wiedervorlage die ein Datum in der Zukunft hat",
                    CorrectAnswersDe = "Eine Wiedervorlage, die geerbt wurde und ihr Datum überschritten hat",

                    TextEn = "What does the purple pin show?",
                    Answer1En = "A Memo that was inherited and has no date",
                    Answer2En = "A Memo that has been inherited and has exceeded its date",
                    Answer3En = "A Memo that has been provided with a date in the future",
                    CorrectAnswersEn = "A Memo that has been inherited and has exceeded its date",

                    ImagePathDe = "question_152.png",
                    ImagePathEn = "question_152_en.png",


                    QuizCategory = new List<string> { "Allgemein" }
                 },

                  new Question
                 {
                    Number = 153,

                    TextDe = "Was zeigt die türkise Farbe an?",
                    Answer1De = "Es hat keine Bedeutung, da man jeder Gruppe eine beliebige Farbe geben kann für eine individuelle Farbkodierung",
                    Answer2De = "Eine Verbund-Gruppe",
                    Answer3De = "Eine Gruppe auf den nur bestimmte User zugreifen können",
                    CorrectAnswersDe = "Eine Verbund-Gruppe",

                    TextEn = "What does the turquoise color show?",
                    Answer1En = "It has no meaning, as you can give each group any color for individual color coding",
                    Answer2En = "A compound group",
                    Answer3En = "A group that only certain users can access",
                    CorrectAnswersEn = "A compound group",

                    ImagePathDe = "question_153.png",
                    ImagePathEn = "question_153_en.png",
                    QuizCategory = new List<string> { "Bestellung", "Allgemein" }
                 },
            };


            foreach (var question in newQuestions)
            {
                var existingQuestion = existingQuestions.FirstOrDefault(q => q.Number == question.Number);

                if (existingQuestion == null)
                {
                    await database.AddQuestionAsync(question);
                }
                // logik for adding new columns to existing questions
                /* else
                {
                    if (existingQuestion.NEW_COLUMN != question.NEW_COLUMN)
                    {
                        existingQuestion.NEW_COLUMN = question.NEW_COLUMN;
                        await database.UpdateQuestionAsync(existingQuestion);
                    }
                } */
            }
        }
    }
}

