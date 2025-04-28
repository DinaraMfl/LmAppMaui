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

                 new Question
                 {
                    Id = 11,

                    TextDe = "Was passiert beim Berechnungstyp „nicht bestellen, ohne Bestand-Sim“?",
                    Answer1De = "Es werden keine Bestellvorschläge, aber eine Bestandssimulation generiert",
                    Answer2De = " Es werden keine Bestellvorschläge generiert, wenn es keine Bestandsimulation gibt",
                    Answer3De = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",
                    CorrectAnswersDe = "Es werden keine Bestellvorschläge & Bestandssimulation generiert",

                    TextEn = "What happens with the “No replenishment, no simulation” calculation type?",
                    Answer1En = "No order proposals are generated, but a stock simulation is generated",
                    Answer2En = " No order proposals are generated if there is no stock simulation",
                    Answer3En = "No order proposals & stock simulation are generated",
                    CorrectAnswersEn = "No order proposals & stock simulation are generated",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Id = 12,

                    TextDe = "Was passiert beim Berechnungstyp „Bestellmenge nullen vor Abfüllen“?",
                    Answer1De = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0",
                    Answer2De = "Es werden Bestellungen mit einer Bestellmenge von 0 entfernt",
                    Answer3De = "Bestellungen werden nachträglich mit einer Bestellmenge von 0 ersetzt",
                    CorrectAnswersDe = "Es wird ein Bedarf gerechnet und Bestellvorschläge erhalten eine Bestellmenge von 0",

                    TextEn = "What happens with the calculation type “Set order to zero quantity before reducing down”?",
                    Answer1En = "A requirement is calculated and order proposals receive an order quantity of 0",
                    Answer2En = "Orders with an order quantity of 0 are removed",
                    Answer3En = "Orders are subsequently replaced with an order quantity of 0",
                    CorrectAnswersEn = "A requirement is calculated and order proposals receive an order quantity of 0",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Id = 13,

                    TextDe = "Was macht die Optimierungs-Einheit?",
                    Answer1De = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll",
                    Answer2De = "Die Optimierungs-Einheit zeigt an welche Einheit manuell angepasst werden soll",
                    Answer3De = "Bestellungen werden mit dieser Einheit getätigt",
                    CorrectAnswersDe = "Die Optimierungs-Einheit gibt an mit welcher Einheit gerechnet werden soll| Bestellungen werden mit dieser Einheit getätigt",

                    TextEn = "What does the optimization unit do?",
                    Answer1En = "The optimization unit specifies the unit to be used for the calculation",
                    Answer2En = "The optimization unit indicates which unit is to be adjusted manually",
                    Answer3En = "Orders are placed with this unit",
                    CorrectAnswersEn = "The optimization unit specifies the unit to be used for the calculation| Orders are placed with this unit",

                    QuizCategory = new List<string> { "Bestellung", "Kondition" }
                 },

                 new Question
                 {
                    Id = 14,

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
                 },

                 new Question
                 {
                    Id = 15,

                    TextDe = "Welche Parameter sollten eingestellt werden, wenn neue SKUs übergeben werden ohne bekannter Abgangshistorie?",
                    Answer1De = "Mittelwert",
                    Answer2De = "Feld “Wenn Prognose, möglich“",
                    Answer3De = "Inaktiv setzen bis Historie vorhanden",
                    CorrectAnswersDe = "Mittelwert| Feld “Wenn Prognose, möglich“",

                    TextEn = "Which parameters should be set if new SKUs are transferred without a known retirement history?",
                    Answer1En = "Mean value",
                    Answer2En = "Field “If forecast is possible”",
                    Answer3En = "Set inactive until history available",
                    CorrectAnswersEn = "Mean value| Field “If forecast is possible”",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 16,

                    TextDe = "Was unterscheidet eine Filterklasse von einer Zuordnungsklasse?",
                    Answer1De = "Einer Filterklasse können mehr SKUs zugeordnet werden",
                    Answer2De = "Eine Filterklasse ist nur temporär & wird nach erneuten Starten von LOGOMATE entfernt",
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
                    Id = 17,

                    TextDe = "Was unterscheidet eine Zuordnungsklasse zu einer Filterklasse?",
                    Answer1De = "Eine Zuordnungsklasse muss manuell befüllt werden",
                    Answer2De = "Eine Zuordnungsklasse können maximal 10 SKUs zugeordnet werden",
                    Answer3De = "Eine Zuordnungsklasse ist nur temporär & wird nach erneuten Starten von LOGOMATE entfernt",
                    CorrectAnswersDe = "Eine Zuordnungsklasse muss manuell befüllt werden",

                    TextEn = "What is the difference between an assignment class and a filter class?",
                    Answer1En = "An assignment class must be filled manually",
                    Answer2En = "A maximum of 10 SKUs can be assigned to an assignment class",
                    Answer3En = "An assignment class is only temporary & is removed after LOGOMATE is restarted",
                    CorrectAnswersEn = "An assignment class must be filled manually",

                    QuizCategory = new List<string> { "Filter" }
                 },

                 new Question
                 {
                    Id = 18,

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
                    Id = 19,

                    TextDe = "Was wird inaktiviert, wenn der Parameter „Inaktiv“ gesetzt wird?",
                    Answer1De = "Die Prognose-Rechnung",
                    Answer2De = "Die Dispo-Rechnung",
                    Answer3De = "Der Zugeordnete Lieferant",
                    CorrectAnswersDe = "Die Prognose-Rechnung| Die Dispo-Rechnung",

                    TextEn = "Was wird inaktiviert, wenn der Parameter „Inaktiv“ gesetzt wird?",
                    Answer1En = "The forecast calculation",
                    Answer2En = "The Replenishment calculation",
                    Answer3En = "The allocated suppliert",
                    CorrectAnswersEn = "The forecast calculation | The Replenishment calculation",

                    QuizCategory = new List<string> { "Bestellung", "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 20,

                    TextDe = "Was macht der Read-Only Modus?",
                    Answer1De = "Man kann darüber Bestellungen exportieren",
                    Answer2De = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden",
                    Answer3De = "Man kann sich nur SKUs anzeigen lassen",
                    CorrectAnswersDe = "Damit können, zu Testzwecken, temporäre Änderungen vorgenommen werden",

                    TextEn = "What does the read-only mode do?",
                    Answer1En = "You can use it to export orders",
                    Answer2En = "This allows temporary changes to be made for test purposes",
                    Answer3En = "You can only display SKUs",
                    CorrectAnswersEn = "This allows temporary changes to be made for test purposes",

                    QuizCategory = new List<string> { "Filter", "Allgemein" }
                 },

                 new Question
                 {
                    Id = 21,

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
                 },

                 new Question
                 {
                    Id = 22,

                    TextDe = "Darf ich eine SKU löschen?",
                    Answer1De = "Nein, SKUs darf man nur auf inaktiv setzen",
                    Answer2De = "Ja, um Rechenleistung zu sparen",
                    Answer3De = "Ja, wenn diese entsprechend gefiltert werden",
                    CorrectAnswersDe = "Nein, SKUs darf man nur auf inaktiv setzen",

                    TextEn = "Can I delete an SKU?",
                    Answer1En = "No, SKUs may only be set to inactive",
                    Answer2En = "Yes, to save computing power",
                    Answer3En = "Yes, if they are filtered accordingly",
                    CorrectAnswersEn = "No, SKUs may only be set to inactive",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 23,

                    TextDe = "Was sind Ausreißer?",
                    Answer1De = "Ausreißer erkennen SKUs die doppelt vorhanden sind",
                    Answer2De = "Ausreißer löschen Abgänge die dazu führen das Bestände unter den SiB fallen",
                    Answer3De = "Ausreißer sind Extrem-Werte in der Historie",
                    CorrectAnswersDe = "Ausreißer sind Extrem-Werte in der Historie",

                    TextEn = "What are outliers?",
                    Answer1En = "Recognize outliers SKUs that exist twice",
                    Answer2En = "Delete outliers Disposals that result in stocks falling below the SiB",
                    Answer3En = "Outliers are extreme values in the history",
                    CorrectAnswersEn = "Outliers are extreme values in the history",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 24,

                    TextDe = "Woran erkenne ich wie lang eine Saison ist?",
                    Answer1De = "Die Anzahl der Perioden vor und nach dem Stichtag definiert die Länge der Saison",
                    Answer2De = "Die Anzahl der Perioden bezieht sich ausschließlich auf die letzten zwei Jahre",
                    Answer3De = "Perioden sind Zeiträume in  denen kein Ereignisse stattfinden",
                    CorrectAnswersDe = "Die Anzahl der Perioden vor und nach dem Stichtag definiert die Länge der Saison",

                    TextEn = "How can I tell how long a season is?",
                    Answer1En = "The number of periods before and after the reporting date defines the length of the season",
                    Answer2En = "The number of periods relates exclusively to the last two years",
                    Answer3En = "Periods are time periods in which no events take place",
                    CorrectAnswersEn = "The number of periods before and after the reporting date defines the length of the season",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Id = 25,

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
                    Id = 26,

                    TextDe = "Was korrigiert die Behandlungsgrenze?",
                    Answer1De = "Ausreißer",
                    Answer2De = "Ungültige Planwerte",
                    Answer3De = "Zu wenig Liefertermine",
                    CorrectAnswersDe = "Ausreißer",

                    TextEn = "What corrects the treatment limit?",
                    Answer1En = "Outliers",
                    Answer2En = "Invalid plan values",
                    Answer3En = "Too few delivery dates",
                    CorrectAnswersEn = "Outliers",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 27,

                    TextDe = "Welche Grenze sollte höher sein bei den Ausreißern, damit diese korrigiert wird?",
                    Answer1De = "Behandlungsgrenze",
                    Answer2De = "Warnungsgrenze",
                    Answer3De = "Max.-Grenze",
                    CorrectAnswersDe = "Behandlungsgrenze",

                    TextEn = "Which limit should be higher for the outliers so that this is corrected?",
                    Answer1En = "Treatment limit",
                    Answer2En = "Warning limit ",
                    Answer3En = "Max. limit",
                    CorrectAnswersEn = "Treatment limit",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 28,

                    TextDe = "Wann kommen Vorläufer (normalerweise) zum Einsatz?",
                    Answer1De = "Neue SKUs ohne Historie",
                    Answer2De = "Neu Artikel-Variation-SKUs ohne Historie",
                    Answer3De = "Ablöse-Artikel-SKUs ohne Historie",
                    CorrectAnswersDe = "Neu Artikel-Variation-SKUs ohne Historie| Ablöse-Artikel-SKUs ohne Historie",

                    TextEn = "When are precursors (normally) used?",
                    Answer1En = "New SKUs without history",
                    Answer2En = "New Article variation SKUs without history",
                    Answer3En = "Replacement article SKUs without history",
                    CorrectAnswersEn = "New Article variation SKUs without history| Replacement article SKUs without history",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 29,

                    TextDe = "Was bewirkt ein eingetragener Vorläufer?",
                    Answer1De = "Die Vorläufer-SKU wird ab dem eingetragenen Datum inaktiv gelöscht & wird dann ersetzt mit der SKU, die diese SKU als Vorläufer eingetragen hat.",
                    Answer2De = "Die Historie vom Vorläufer wird übertragen auf die SKU",
                    Answer3De = "Die SKU wird inaktiviert und erhält eine „Info“-Warnung, die „Vorläufer-SKU“ heißt",
                    CorrectAnswersDe = "",

                    TextEn = "What does a registered forerunner do?",
                    Answer1En = "The predecessor SKU is deleted from the date entered as inactive & is then replaced with the SKU that entered this SKU as the predecessor.",
                    Answer2En = "The history of the predecessor is transferred to the SKU",
                    Answer3En = "The SKU is deactivated and receives an “Info” warning called “Predecessor SKU”",
                    CorrectAnswersEn = "The history of the predecessor is transferred to the SKU",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 30,

                    TextDe = "Wie kann man LOGOMATE dazu bringen nur einen bestimmten Zeitraum der Historie für die Berechnung zu nutzen?",
                    Answer1De = "Bei den Parametern unter dem Reiter „Prognose“ den Kasten „Zu verwendende Historie“ befüllen",
                    Answer2De = "Bei den Parametern unter dem Reiter „Vorgabe“ das Feld „Plan verwenden“ befüllen",
                    Answer3De = "Bei den Konditionen unter dem Reiter „Zeiten“ das Feld „Rhythmus“ befüllen",
                    CorrectAnswersDe = "Bei den Parametern unter dem Reiter „Prognose“ den Kasten „Zu verwendende Historie“ befüllen",

                    TextEn = "How can LOGOMATE be made to use only a certain period of the history for the calculation?",
                    Answer1En = "In the parameters under the “Forecast” tab, fill in the “History to use” box",
                    Answer2En = "In the parameters under the “ Preset” tab, fill in the “Use plan” field",
                    Answer3En = "In the conditions under the “Order schedule” tab, fill in the “Rhythm” field",
                    CorrectAnswersEn = "In the parameters under the “Forecast” tab, fill in the “History to use” box",

                    QuizCategory = new List<string> { "Parameter", "Prognose", "Filter" }
                 },
                 
                 new Question
                 {
                    Id = 31,

                    TextDe = "Was bewirkt das Gütekriterium „Bestand minimieren“?",
                    Answer1De = "Der Bestand wird so niedrig wie möglich gehalten, indem die kleinstmöglich Bestellmenge vorgeschlagen wird",
                    Answer2De = "Der Bestand, der nach einer bestimmten Anzahl an Tagen noch nicht verkauft wurde, wird aus LOGOMATE entfernt",
                    Answer3De = "Es wird standardmäßig davon ausgegangen das eine bestimmte Anzahl Artikel in einer bestimmten Periode verkauft werden & werden daraufhin von LOGOMATE abgezogen",
                    CorrectAnswersDe = "Der Bestand wird so niedrig wie möglich gehalten, indem die kleinstmöglich Bestellmenge vorgeschlagen wird",

                    TextEn = "What does the “minimize stock” quality criterion do?",
                    Answer1En = "Stock is kept as low as possible by proposing the smallest possible order quantity",
                    Answer2En = "The stock that has not been sold after a certain number of days is removed from LOGOMATE",
                    Answer3En = "By default, it is assumed that a certain number of items are sold in a certain period & are then deducted from LOGOMATE",
                    CorrectAnswersEn = "Stock is kept as low as possible by proposing the smallest possible order quantity",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Id = 32,

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
                    Id = 33,

                    TextDe = "Wann tritt die Warnung  “Max. Prognose erreicht” auf?",
                    Answer1De = "Tritt auf, wenn die Prognose einem starken Trend oder quadratischen Trend nach oben unterliegt",
                    Answer2De = "Erscheint, wenn LM eine überhöhte Prognose einschließlich der Standardabweichung „abgeschnitten“ hat",
                    Answer3De = "Tritt auf, wenn die Einträge im Abschnitt Vorgaben ungültig sind",
                    CorrectAnswersDe = "Erscheint, wenn LM eine überhöhte Prognose einschließlich der Standardabweichung „abgeschnitten“ hat",

                    TextEn = "When does the warning “Max. forecast reached” appear?",
                    Answer1En = "Occurs when the forecast is subject to a strong upward trend or quadratic trend",
                    Answer2En = "Appears when LM has “truncated” an inflated forecast including the standard deviation",
                    Answer3En = "Occurs if the entries in the Preset section are invalid",
                    CorrectAnswersEn = "Appears when LM has “truncated” an inflated forecast including the standard deviation",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Id = 34,

                    TextDe = "Wann wird ein Strukturbruch erkannt?",
                    Answer1De = "Dies ist ausschließlich nur in der Prognosegrafik zu erkennen",
                    Answer2De = "Wenn es mehrere Historienwerte gibt",
                    Answer3De = "Wenn die Volatilität (Schwankungsbreite) den zulässigen Wert nicht übersteigt",
                    CorrectAnswersDe = "Wenn es mehrere Historienwerte gibt| Wenn die Volatilität (Schwankungsbreite) den zulässigen Wert nicht übersteigt",

                    TextEn = "When is a structural break recognized?",
                    Answer1En = "This can only be seen in the forecast chart",
                    Answer2En = "If there are several history values",
                    Answer3En = "If the volatility (fluctuation range) does not exceed the permissible value",
                    CorrectAnswersEn = "If there are several history values| If the volatility (fluctuation range) does not exceed the permissible value",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 35,

                    TextDe = "Wann tritt die Warnung  “Max. Prognose erreicht” auf?",
                    Answer1De = "Tritt auf, wenn zu viel bestellt wird",
                    Answer2De = "Tritt auf, falls ein Prognosefehler entdeckt wurde",
                    Answer3De = "Wenn die maximale Reichweite der SKU bei der Bestandssimulation überschritten wurde",
                    CorrectAnswersDe = "Tritt auf, wenn zu viel bestellt wird",

                    TextEn = "When does the warning “Max. forecast reached” appear?",
                    Answer1En = "Occurs when too much is ordered",
                    Answer2En = "Occurs if a forecast error has been detected",
                    Answer3En = "If the maximum range of the SKU was exceeded during the stock simulation",
                    CorrectAnswersEn = "Occurs when too much is ordered",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Id = 36,

                    TextDe = "Die Wiederbeschaffungszeit setzt sich zusammen aus:?",
                    Answer1De = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ) Transporttagen (TT) Einlagerungszeit (ELZ)",
                    Answer2De = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ) ABC-Analyse (ABC) Einlagerungszeit (ELZ)",
                    Answer3De = "Auftragsvorbereitungszeit (AVZ) Just-in-Time (JiT) ABC-Analyse (ABC) Einlagerungszeit (ELZ)",
                    CorrectAnswersDe = "Auftragsvorbereitungszeit (AVZ) Lieferzeit (LFZ) Transporttagen (TT) Einlagerungszeit (ELZ)",

                    TextEn = "The replacement time is made up of:?",
                    Answer1En = "Order Preparation Time (OPT) Delivery Time (DT Transport Time (TT) Storage Time (ST)",
                    Answer2En = "Order Preparation Time (OPT) Delivery Time (DT) ABC Analysis (ABC) Storage Time (ST)",
                    Answer3En = "Order Preparation Time (OPT) Just-in-Time (JiT) ABC Analysis (ABC) Storage Time (ST)",
                    CorrectAnswersEn = "Order Preparation Time (OPT) Delivery Time (DT) Transport Time (TT) Storage Time (ST)",

                    QuizCategory = new List<string> { "Filter" }
                 },

                 new Question
                 {
                    Id = 37,

                    TextDe = "Was macht der Trend?",
                    Answer1De = "Er lässt den Mittelwert linear steigen",
                    Answer2De = "Er lässt den Mittelwert exponentiell steigen",
                    Answer3De = "Er zeigt Stellen an mit unerwartet hohen Abgängen in der Historie an",
                    CorrectAnswersDe = "Er lässt den Mittelwert linear steigen",

                    TextEn = "What is the trend doing?",
                    Answer1En = "It allows the mean value to increase linearly",
                    Answer2En = "It causes the mean value to rise exponentially",
                    Answer3En = "It indicates places with unexpectedly high departures in the history",
                    CorrectAnswersEn = "It allows the mean value to increase linearly",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 38,

                    TextDe = "Was ist die Voraussetzung für einen Trend?",
                    Answer1De = "Ein Mittelwert",
                    Answer2De = "Eine Historie von mindestens 10 Perioden",
                    Answer3De = "Ein Startdatum, ab dem der Trend benutzt werden soll",
                    CorrectAnswersDe = "Ein Mittelwert",

                    TextEn = "What is the prerequisite for a trend?",
                    Answer1En = "An average value",
                    Answer2En = "A history of at least 10 periods",
                    Answer3En = "A start date from which the trend is to be used",
                    CorrectAnswersEn = "An average value",

                    QuizCategory = new List<string> { "Paramter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 39,

                    TextDe = "Was macht der „Quadrat. Trend“?",
                    Answer1De = "Er lässt den Mittelwert linear steigen",
                    Answer2De = "Er lässt den Mittelwert exponentiell steigen",
                    Answer3De = "Er zeigt Stellen an mit unerwartet hohen Abgängen in der Historie an",
                    CorrectAnswersDe = "Er lässt den Mittelwert exponentiell steigen",

                    TextEn = "What does the “square trend” do?",
                    Answer1En = "It allows the average value to increase linearly",
                    Answer2En = "It causes the average value to increase exponentially",
                    Answer3En = "It indicates places with unexpectedly high departures in the history",
                    CorrectAnswersEn = "It causes the average value to increase exponentially",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },

                 new Question
                 {
                    Id = 40,

                    TextDe = "Ist es möglich sowohl Trend als auch Quadrat. Trend einzustellen? ",
                    Answer1De = "Ja, weil der Quadratische Trend ohne linearen Trend nicht funktioniert",
                    Answer2De = "Ja, beide schließen sich nicht aus",
                    Answer3De = "Nein, man kann pro SKU nur einen Trend einstellen",
                    CorrectAnswersDe = "Ja, weil der Quadratische Trend ohne linearen Trend nicht funktioniert",

                    TextEn = "Is it possible to set both trend and square trend? ",
                    Answer1En = "Yes, because the quadratic trend does not work without a linear trend",
                    Answer2En = "Yes, the two are not mutually exclusive",
                    Answer3En = "No, you can only set one trend per SKU",
                    CorrectAnswersEn = "Yes, because the quadratic trend does not work without a linear trend",

                    QuizCategory = new List<string> { "Parameter", "Prognose" }
                 },
                 
                 new Question
                 {
                    Id = 41,

                    TextDe = "Was sagt die ABC-Klasse über eine SKU aus?",
                    Answer1De = "Die ABC-Klasse zeigt welche SKU am genausten prognostiziert werden kann",
                    Answer2De = "Die ABC-Klasse zeigt welche SKU meisten bestellt wird",
                    Answer3De = "Die ABC-Klasse zeigt welche SKUs am umsatzstärksten sind",
                    CorrectAnswersDe = "Die ABC-Klasse zeigt welche SKUs am umsatzstärksten sind",

                    TextEn = "What does the ABC class say about an SKU?",
                    Answer1En = "The ABC class shows which SKU can be predicted most accurately",
                    Answer2En = "The ABC class shows which SKU is ordered most often",
                    Answer3En = "The ABC class shows which SKUs have the highest turnover",
                    CorrectAnswersEn = "The ABC class shows which SKUs have the highest turnover",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Id = 42,

                    TextDe = "Was sagt eine XYZ-Klasse über eine SKU aus?",
                    Answer1De = "Die ABC-Klasse zeigt welche SKU am genausten prognostiziert werden kann",
                    Answer2De = "Die ABC-Klasse zeigt welche SKU meisten bestellt wird",
                    Answer3De = "Die ABC-Klasse zeigt welche SKUs am umsatzstärksten sind",
                    CorrectAnswersDe = "Die ABC-Klasse zeigt welche SKU am genausten prognostiziert werden kann",

                    TextEn = "What does an XYZ class say about an SKU?",
                    Answer1En = "The ABC class shows which SKU can be predicted most accurately ",
                    Answer2En = "The ABC class shows which SKU is ordered most often",
                    Answer3En = "The ABC class shows which SKUs have the highest turnover",
                    CorrectAnswersEn = "The ABC class shows which SKU can be predicted most accurately",

                    QuizCategory = new List<string> { "Prognose" }
                 },

                 new Question
                 {
                    Id = 43,

                    TextDe = "Was bewirkt der “Rhythmusanfang” in einem Bestellrhythmus?",
                    Answer1De = "Er gibt an ab welcher Periodenzahl der Bestellrhythmus anfangen soll",
                    Answer2De = "Der Rhythmusanfang gibt ab welchem Datum der Bestellrhythmus starten soll",
                    Answer3De = "Das ist eine Sondereinstellung, die ermöglicht mit einem langsameren Bestellrhythmus anzufangen",
                    CorrectAnswersDe = "Er gibt an ab welcher Periodenzahl der Bestellrhythmus anfangen soll",

                    TextEn = "What is the effect of the “start of rhythm” in an order rhythm?",
                    Answer1En = "It specifies the number of periods from which the ordering cycle should start",
                    Answer2En = "The start of rhythm specifies the date from which the order rhythm should start",
                    Answer3En = "This is a special setting that allows you to start with a slower ordering rhythm",
                    CorrectAnswersEn = "It specifies the number of periods from which the ordering cycle should start",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 44,

                    TextDe = "Was muss erfüllt sein damit man im Kalender, die Wochentage & Feiertage bearbeiten kann?",
                    Answer1De = "„Eigener Kalender“ muss angehakt sein",
                    Answer2De = "Es gibt keine Voraussetzungen, man kann ständig den Kalender bearbeiten",
                    Answer3De = "Der REMIRA Support muss einstellen, dass der Kalender bearbeitet werden darf",
                    CorrectAnswersDe = "„Eigener Kalender“ muss angehakt sein",

                    TextEn = "What must be fulfilled so that you can edit the weekdays and public holidays in the calendar?",
                    Answer1En = "“Separate calendar” must be checked",
                    Answer2En = "There are no prerequisites, you can always edit the calendar",
                    Answer3En = "Der REMIRA Support muss einstellen, dass der Kalender bearbeitet werden darf",
                    CorrectAnswersEn = "“Separate calendar” must be checked",

                    QuizCategory = new List<string> { "Allgemein" }
                 },

                 new Question
                 {
                    Id = 45,

                    TextDe = "Was kann auch ohne „Eigener Kalender“-Haken eingestellt werden?",
                    Answer1De = "Wochentage",
                    Answer2De = "Feiertage",
                    Answer3De = "Dynamischer Kalenderteil (Bertriebsferien, Sonderschichten, …)",
                    CorrectAnswersDe = "Dynamischer Kalenderteil (Bertriebsferien, Sonderschichten, …)",

                    TextEn = "What can be set without the “Separate calendar” tick?",
                    Answer1En = "Weekdays",
                    Answer2En = "Holidays",
                    Answer3En = "Dynamic calendar section (company vacations, special shifts, ...)",
                    CorrectAnswersEn = "Dynamic calendar section (company vacations, special shifts, ...)",

                    QuizCategory = new List<string> { "Algemein" }
                 },

                 new Question
                 {
                    Id = 46,

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
                    Id = 47,

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
                    Id = 48,

                    TextDe = "Welche Kalender gibt es in LOGOMATE?",
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
                    Id = 49,

                    TextDe = "Bei was unterstützt Sie die Vererbung in LOGOMATE?",
                    Answer1De = "Sie verweist auf die letzten Bestellungen vor ca. ein Jahr",
                    Answer2De = "Es hilft, die Parameter und Konditionen schnell zu erfassen und zu verwalten",
                    Answer3De = "Ist für die Abgänge zuständig",
                    CorrectAnswersDe = "Es hilft, die Parameter und Konditionen schnell zu erfassen und zu verwalten",

                    TextEn = "What does inheritance in LOGOMATE help you with?",
                    Answer1En = "She refers to the last orders about a year ago",
                    Answer2En = "It helps to quickly record and manage parameters and conditions",
                    Answer3En = "Is responsible for departures",
                    CorrectAnswersEn = "It helps to quickly record and manage parameters and conditions",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 50,

                    TextDe = "Was sorgt dafür, dass eine Bestellung überfällig ist?",
                    Answer1De = "Warenüberschuss",
                    Answer2De = "MHD ist abgelaufen",
                    Answer3De = "Wenn keine Bestellung rechtzeitig ankommt",
                    CorrectAnswersDe = "Wenn keine Bestellung rechtzeitig ankommt",

                    TextEn = "What makes an order overdue?",
                    Answer1En = "Surplus of goods ",
                    Answer2En = "BBD has expiredn",
                    Answer3En = "If no order arrives on time",
                    CorrectAnswersEn = "If no order arrives on time",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 51,

                    TextDe = "Welchen Vorteil hat die 2D-Ansicht?",
                    Answer1De = "Nur damit ist die Prognosegrafik richtig dargestellt",
                    Answer2De = "Hat keinen Vorteil",
                    Answer3De = "Bessere Ansicht der Prognosegrafik",
                    CorrectAnswersDe = "Bessere Ansicht der Prognosegrafik",

                    TextEn = "What is the advantage of the 2D view?",
                    Answer1En = "This is the only way to show the forecast chart correctly",
                    Answer2En = "Has no advantage",
                    Answer3En = "Better view of the forecast graphic",
                    CorrectAnswersEn = "Better view of the forecast graphic",

                    QuizCategory = new List<string> { "Prognose", "Allgemein" }
                 },

                 new Question
                 {
                    Id = 52,

                    TextDe = "Wie viele Rhythmen kann ich in den Konditionen (Zeiten)auswählen?",
                    Answer1De = "5",
                    Answer2De = "4",
                    Answer3De = "2",
                    CorrectAnswersDe = "4",

                    TextEn = "How many rhythms can I select in the conditions (order schedule)?",
                    Answer1En = "5",
                    Answer2En = "4",
                    Answer3En = "2",
                    CorrectAnswersEn = "4",

                    QuizCategory = new List<string> { "Kondition" }
                 },

                 new Question
                 {
                    Id = 53,

                    TextDe = "Was ist ein Dispofehler?",
                    Answer1De = "Überfällige Bestellungen",
                    Answer2De = "Zu wenig Liefertermine",
                    Answer3De = "Ungültige Aktion",
                    CorrectAnswersDe = "Zu wenig Liefertermine",

                    TextEn = "What is a Replenishment error?",
                    Answer1En = "Overdue orders",
                    Answer2En = "Too few delivery dates",
                    Answer3En = "Invalid action",
                    CorrectAnswersEn = "Too few delivery dates",

                    QuizCategory = new List<string> { "Bestellung", "Filter" }
                 },

                 new Question
                 {
                    Id = 54,

                    TextDe = "Was ist die primäre Aufgabe der Verbund-Bestellung?",
                    Answer1De = "Alle SKUs die bestellt wurden, sollen gleichzeitig ihren SiB erreichen, um die SKUs wieder gleichzeitig bestellen zu können",
                    Answer2De = "Eine Bestellung zu generieren aus allen vorhandenen SKUs der Verbund-Gruppe",
                    Answer3De = "Die Bestellkosten pro Bestellung so niedrig wie möglich zu halten",
                    CorrectAnswersDe = "Alle SKUs die bestellt wurden, sollen gleichzeitig ihren SiB erreichen, um die SKUs wieder gleichzeitig bestellen zu können",

                    TextEn = "What is the primary task of the compound order?",
                    Answer1En = "All SKUs that have been ordered should reach their safety stock at the same time so that the SKUs can be ordered again at the same time",
                    Answer2En = "Generate an order from all existing SKUs of the compound group",
                    Answer3En = "To keep the order costs per order as low as possible ",
                    CorrectAnswersEn = "All SKUs that have been ordered should reach their safety stock at the same time so that the SKUs can be ordered again at the same time",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 55,

                    TextDe = "Was bewirkt der Parameter „Kein Auslöseartikel“?",
                    Answer1De = "Die SKU darf nur bei einer Verbund-Bestellung mitbestellt werden",
                    Answer2De = "Dies SKU löst keine OoS-Korrektur aus",
                    Answer3De = "Die SKU auf die dieser Parameter angewandt wurde darf keine Bestellung auslösen",
                    CorrectAnswersDe = "Die SKU auf die dieser Parameter angewandt wurde darf keine Bestellung auslösen| Die SKU darf nur bei einer Verbund-Bestellung mitbestellt werden",

                    TextEn = "What does the “No order trigger” parameter do?",
                    Answer1En = "The SKU may only be ordered with a compound order",
                    Answer2En = "This SKU does not trigger an OoS correction",
                    Answer3En = "The SKU to which this parameter was applied must not trigger an order",
                    CorrectAnswersEn = "The SKU to which this parameter was applied must not trigger an order| The SKU may only be ordered with a compound order",

                    QuizCategory = new List<string> { "Bestellung", "Parameter" }
                 },

                 new Question
                 {
                    Id = 56,

                    TextDe = "Was unterscheidet eine Verbund- Bestellung zu einer „normalen“ Bestellung?",
                    Answer1De = "Mit Verbund-Bestellungen kriegt man einen Mengen-Rabatt, da mehrere Artikel auf einmal bestellt werden",
                    Answer2De = "Eine Verbund-Bestellung besteht aus mehreren Artikeln, die bestellt werden",
                    Answer3De = "Bei einer Verbund-Bestellung wird nur eine Bestellung generiert, für alle SKUs in der Verbund-Gruppe",
                    CorrectAnswersDe = "Eine Verbund-Bestellung besteht aus mehreren Artikeln, die bestellt werden",

                    TextEn = "What is the difference between a compound order and a “normal” order?",
                    Answer1En = "With compound orders you get a quantity discount, as several items are ordered at once",
                    Answer2En = "A compound order consists of several items that are ordered",
                    Answer3En = "Only one order is generated for a compound order, for all SKUs in the compound group",
                    CorrectAnswersEn = "A compound order consists of several items that are ordered",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 57,

                    TextDe = "Was kann man machen bei SKUs in einer Verbund-Gruppe, mit jeweils unterschiedlichen Konditionen?",
                    Answer1De = "Verbund-Untergruppen bilden, bei SKUs die die gleichen Konditionen besitzen",
                    Answer2De = "SKUs, die einzigartige Konditionen besitzen, aus der Verbund-Gruppe entfernen",
                    Answer3De = "Die SKUs, die die Verbund-Bestellung aufhalten, inaktiv setzen",
                    CorrectAnswersDe = "Verbund-Untergruppen bilden, bei SKUs die die gleichen Konditionen besitzen| SKUs, die einzigartige Konditionen besitzen, aus der Verbund-Gruppe entfernen",

                    TextEn = "What can be done with SKUs in a compound group, each with different conditions?",
                    Answer1En = "Form compound subgroups with SKUs that have the same conditions",
                    Answer2En = "Remove SKUs that have unique conditions from the compound group",
                    Answer3En = "Set the SKUs that hold up the compound order to inactive ",
                    CorrectAnswersEn = "Form compound subgroups with SKUs that have the same conditions| Remove SKUs that have unique conditions from the compound group",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 58,

                    TextDe = "Woran erkennt man eine Verbund-Gruppe?",
                    Answer1De = "An der hellgrünen Schriftfarbe der Gruppe",
                    Answer2De = "An der hellblauen Variante des Ursprungsymbols",
                    Answer3De = "An der Dispo-Warnung „Verbundkondition auf Lagerplatz vorhanden“",
                    CorrectAnswersDe = "An der hellblauen Variante des Ursprungsymbols",

                    TextEn = "How can you recognize a compound group?",
                    Answer1En = "The light green font color of the group",
                    Answer2En = "On the light blue version of the original symbol",
                    Answer3En = "An der Dispo-Warnung „Verbundkondition auf Lagerplatz vorhanden“",
                    CorrectAnswersEn = "On the light blue version of the original symbol",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 59,

                    TextDe = "Wie können Verbund-Gruppen erstellt werden?",
                    Answer1De = "“Gewünschte Gruppe”->Rechtsklick->Gruppe/Benutzer ändern->“Verbund“ anhaken",
                    Answer2De = "“Gewünschte Gruppe”->Rechtsklick->Neue Gruppe->“Verbund“ anhaken",
                    Answer3De = "Parameter->Status->”Verbund” anhaken",
                    CorrectAnswersDe = "“Gewünschte Gruppe”->Rechtsklick->Neue Gruppe->“Verbund“ anhaken| “Gewünschte Gruppe”->Rechtsklick->Gruppe/Benutzer ändern->“Verbund“ anhaken",

                    TextEn = "How can compound groups be created?",
                    Answer1En = "“Desired group”->right-click->Edit group/user->check “Compound”",
                    Answer2En = "“Desired group“->right-click->New group->”Compound group” checkbox",
                    Answer3En = "Parameter->Status->“Network” checkbox",
                    CorrectAnswersEn = "“Desired group“->right-click->New group->”Compound group” checkbox| “Desired group”->right-click->Edit group/user->check “Compound”",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 60,

                    TextDe = "Was zeigt eine rote Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",
                    Answer2De = "Die Bestellung wurde, bevor sie exportiert wurde, als Report ausgegeben",
                    Answer3De = "Die Bestellung wurde nach dem Exportieren geändert",
                    CorrectAnswersDe = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",

                    TextEn = "What does a red font in the orders indicate (by default)?",
                    Answer1En = "The order has missed its availability date and is now considered overdue",
                    Answer2En = "The order was output as a report before it was exported",
                    Answer3En = "The order was changed after exporting",
                    CorrectAnswersEn = "The order has missed its availability date and is now considered overdue",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 61,

                    TextDe = "Was zeigt eine hellrote Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung hat ihren Verfügbarkeitstermin verpasst und gilt jetzt als überfällig",
                    Answer2De = "Die Bestellung ist geändert worden & hat Ihren Verfügbarkeitstermin überschritten",
                    Answer3De = "Die Bestellung wurde, bevor sie exportiert wurde, als Report ausgegeben",
                    CorrectAnswersDe = "Die Bestellung ist geändert worden & hat Ihren Verfügbarkeitstermin überschritten",

                    TextEn = "What does a light red font in the orders indicate (by default)?",
                    Answer1En = "The order has missed its availability date and is now considered overdue",
                    Answer2En = "The order has been changed & has exceeded your availability date",
                    Answer3En = "The order was output as a report before it was exported",
                    CorrectAnswersEn = "The order has been changed & has exceeded your availability date",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 62,

                    TextDe = "Was zeigt eine grüne Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Der Bestellvorschlag wurde exportiert",
                    Answer2De = "Die Bestellung wurde als Report ausgegeben und exportiert",
                    Answer3De = "Die Bestellung wurde importiert",
                    CorrectAnswersDe = "Der Bestellvorschlag wurde exportiert| Die Bestellung wurde importiert| Die Bestellung wurde als Report ausgegeben und exportiert",

                    TextEn = "What does a green font in the orders indicate (by default)?",
                    Answer1En = "The order proposal has been exported",
                    Answer2En = "The order was output as a report and exported",
                    Answer3En = "The order has been imported",
                    CorrectAnswersEn = "The order proposal has been exported| The order was output as a report and exported| The order has been imported",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 63,

                    TextDe = "Was zeigt eine hellgrüne Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung wurde importiert",
                    Answer2De = "Die Bestellung wurde als Report ausgegeben, bevor sie exportiert wurde",
                    Answer3De = "Die Bestellung wurde geändert, nachdem sie bereits exportiert wurde",
                    CorrectAnswersDe = "Die Bestellung wurde geändert, nachdem sie bereits exportiert wurde",

                    TextEn = "What does a light green font in the orders indicate (by default)?",
                    Answer1En = "The order has been imported",
                    Answer2En = "The order was output as a report before it was exported",
                    Answer3En = "The order has been changed after it has already been exported",
                    CorrectAnswersEn = "The order has been changed after it has already been exported",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 64,
                 
                    TextDe = "Was zeigt eine schwarze Schrift in den Bestellungen an (standardmäßig)?",
                    Answer1De = "Die Bestellung hat Ihren Bestellzeitpunkt noch nicht erreicht und wurde noch nicht exportiert",
                    Answer2De = "Der Verfügbarkeitstermin der Bestellung ist heute",
                    Answer3De = "Die Bestellung wurde storniert/ gelöscht",
                    CorrectAnswersDe = "Die Bestellung hat Ihren Bestellzeitpunkt noch nicht erreicht und wurde noch nicht exportiert",

                    TextEn = "What does a black font in the orders indicate (by default)?",
                    Answer1En = "The order has not yet reached your order date and has not yet been exported",
                    Answer2En = "The availability date of the order is today",
                    Answer3En = "The order has been canceled/deleted",
                    CorrectAnswersEn = "The order has not yet reached your order date and has not yet been exported",

                    QuizCategory = new List<string> { "Bestellung" }
                 },

                 new Question
                 {
                    Id = 65,

                    TextDe = "Was bewirkt das Gütekriterium „Auf Max. auffüllen“?",
                    Answer1De = "Es wird die maximale Menge bestellt, die pro Bestellung getätigt werden darf",
                    Answer2De = "Es werden Bestellvorschläge generiert, bis der maximale Bestand erreicht wird",
                    Answer3De = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der Max. Bestand erreicht wurde",
                    CorrectAnswersDe = "Es werden Bestellvorschläge generiert, bis der maximale Bestand erreicht wird",

                    TextEn = "What is the effect of the “Fill up to max.“quality criterion?”",
                    Answer1En = "The maximum quantity that may be ordered per order is ordered",
                    Answer2En = "Order proposals are generated until the maximum stock level is reached",
                    Answer3En = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached.",
                    CorrectAnswersEn = "Order proposals are generated until the maximum stock level is reached",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 66,

                    TextDe = "Was bewirkt das Gütekriterium „Auf Max. + Reserv. auffüllen“?",
                    Answer1De = "Es werden Bestellvorschläge generiert, bis der maximale Bestand erreicht wird",
                    Answer2De = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der Max. Bestand erreicht wurde",
                    Answer3De = "Es werden Bestellvorschläge generiert, um alle Reservierungen zu befriedigen",
                    CorrectAnswersDe = "Es werden Bestellvorschläge generiert, bis alle Reservierungen befriedigt wurden und der Max. Bestand erreicht wurde",

                    TextEn = "What is the effect of the quality criterion “Fill up to max. + reserv.”?",
                    Answer1En = "Order proposals are generated until the maximum stock level is reached",
                    Answer2En = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached.",
                    Answer3En = "Order proposals are generated to satisfy all reservations",
                    CorrectAnswersEn = "Order proposals are generated until all reservations have been satisfied and the max. stock level has been reached.",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 67,

                    TextDe = "Welche Funktion hat das Auto-Store-Verfahren?",
                    Answer1De = "Es werden Bestellvorschläge, aus mehreren Optimierungseinheiten, generiert",
                    Answer2De = "LOGOMATE entscheidet selbst bei welchem Lager die Bestellung eingelagert wird",
                    Answer3De = "Der Einheiten-Faktor wird so niedrig wie möglich gehalten",
                    CorrectAnswersDe = "Der Einheiten-Faktor wird so niedrig wie möglich gehalten| Es werden Bestellvorschläge, aus mehreren Optimierungseinheiten, generiert",

                    TextEn = "What is the function of the auto-store procedure?",
                    Answer1En = "Order proposals are generated from several optimization units",
                    Answer2En = "LOGOMATE itself decides which warehouse to store the order at",
                    Answer3En = "The unit factor is kept as low as possible",
                    CorrectAnswersEn = "The unit factor is kept as low as possible| Order proposals are generated from several optimization units",

                    QuizCategory = new List<string> { "Paramter" }
                 },

                 new Question
                 {
                    Id = 68,

                    TextDe = "Wie und wo wird das Auto-Store-Verfahren aktiviert?",
                    Answer1De = "Parameter->Dispo->Gütekriterium->“Auto-Store-Verfahren“ auswählen",
                    Answer2De = "Konditionen->Einheiten->“Auto-Store-Verfahren“ anhaken",
                    Answer3De = "Konditionen->Menge, Preise, Kosten->“Auto-Store-Verfahren“ auswählen",
                    CorrectAnswersDe = "Parameter->Dispo->Gütekriterium->“Auto-Store-Verfahren“ auswählen",

                    TextEn = "How and where is the auto-store method activated?",
                    Answer1En = "Parameters->Dispo->Quality criterion->“Auto-store method” select",
                    Answer2En = "Conditions->Units->“Auto-store method” checkbox",
                    Answer3En = "Conditions->Quantity, Prices, Costs->Select “Auto-store method",
                    CorrectAnswersEn = "Parameters->Dispo->Quality criterion->“Auto-store method” select",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 69,

                    TextDe = "Was bewirkt das Gütekriterium „Container-Optimierung“?",
                    Answer1De = "Es werden Bestellvorschläge generiert mit den kleinstmöglichen Bestellkosten",
                    Answer2De = "Es werden Bestellvorschläge generiert mit der kleinstmöglichen Anzahl an Einheiten",
                    Answer3De = "Es werden Bestellvorschläge generiert mit dem höchsten Warenwert pro Container-Einheit",
                    CorrectAnswersDe = "Es werden Bestellvorschläge generiert mit den kleinstmöglichen Bestellkosten",

                    TextEn = "What does the “container optimization” quality criterion do?",
                    Answer1En = "Order proposals are generated with the lowest possible order costs",
                    Answer2En = "Order proposals are generated with the smallest possible number of units",
                    Answer3En = "Order proposals are generated with the highest value of goods per container unit",
                    CorrectAnswersEn = "Order proposals are generated with the lowest possible order costs",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 70,

                    TextDe = "Was bewirkt das Gütekriterium „Mit Partitionierung“?",
                    Answer1De = "Es wird eine zusätzliche Bestellung generiert für alle Aufträge, die in der aktuellen Periode stattfinden",
                    Answer2De = "Es werden Bestellvorschläge für Aufträge generiert",
                    Answer3De = "Es werden Bestellvorschläge für Restmengen von Aufträgen generiert (OE wird beachtet!)",
                    CorrectAnswersDe = "Es werden Bestellvorschläge für Restmengen von Aufträgen generiert (OE wird beachtet!)",

                    TextEn = "What is the effect of the “Partitioning” quality criterion?",
                    Answer1En = "An additional order is generated for all orders that take place in the current period",
                    Answer2En = "Order proposals for orders are generated",
                    Answer3En = "Order proposals are generated for remaining quantities of orders (optimization unit is taken into account!)",
                    CorrectAnswersEn = "Order proposals are generated for remaining quantities of orders (optimization unit is taken into account!)",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 71,

                    TextDe = "Was bewirkt das Gütekriterium „Partitionen verwenden Anfangsbestand nicht“?",
                    Answer1De = "Aufträge werden, unabhängig vom Bestand und offenen Bestellungen, 1:1 zu Bestellungen umgewandelt",
                    Answer2De = "Es werden Bestellvorschläge für Restmengen von Aufträgen generiert (OE wird beachtet!)",
                    Answer3De = "Es wird eine zusätzliche Bestellung generiert mit der Restmenge für alle Aufträge, die in der aktuellen Periode stattfinden",
                    CorrectAnswersDe = "Aufträge werden, unabhängig vom Bestand und offenen Bestellungen, 1:1 zu Bestellungen umgewandelt",

                    TextEn = "What is the effect of the quality criterion “Partitioning stock only for default partition”?",
                    Answer1En = "Orders are converted 1:1 into purchase orders, regardless of stock and open purchase orders",
                    Answer2En = "Order proposals are generated for remaining quantities of orders (optimization unit is taken into account!)",
                    Answer3En = "An additional order is generated with the remaining quantity for all orders that take place in the current period",
                    CorrectAnswersEn = "Orders are converted 1:1 into purchase orders, regardless of stock and open purchase orders",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 72,

                    TextDe = "Was muss erfüllt werden damit das Auto-Store-Verfahren ordnungsgemäß ausgeführt werden kann?",
                    Answer1De = "Die Differenz zwischen den zu verwendenden Optimierungs-Einheiten muss nach oben hin größer werden",
                    Answer2De = "Die zu verwendenden Optimierungs-Einheiten müssen einen Mix-Haken besitzen",
                    Answer3De = "Die zu verwendenden Optimierungs-Einheiten dürfen kein Mix-Haken besitzen",
                    CorrectAnswersDe = "Die zu verwendenden Optimierungs-Einheiten dürfen kein Mix-Haken besitzen| Die Differenz zwischen den zu verwendenden Optimierungs-Einheiten muss nach oben hin größer werden",

                    TextEn = "What must be fulfilled for the auto-store method to be carried out properly?",
                    Answer1En = "The difference between the optimization units to be used must increase towards the top",
                    Answer2En = "The optimization units to be used must have a mix hook",
                    Answer3En = "The optimization units to be used must not have a mix hook",
                    CorrectAnswersEn = "The optimization units to be used must not have a mix hook| The difference between the optimization units to be used must increase towards the top",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 73,

                    TextDe = "Was ist der Unterschied zwischen Auto-Store-Verfahren und Container-Optimierung?",
                    Answer1De = "Beim Auto-Store-Verfahren wird die Bestellmenge optimiert",
                    Answer2De = "Beim Auto-Store-Verfahren wird der Einheiten-Faktor optimiert",
                    Answer3De = "Bei der Container-Optimierung werden die Bestellkosten optimiert",
                    CorrectAnswersDe = "Beim Auto-Store-Verfahren wird der Einheiten-Faktor optimiert| Bei der Container-Optimierung werden die Bestellkosten optimiert",

                    TextEn = "What is the difference between the auto-store method and container optimization?",
                    Answer1En = "The auto-store method optimizes the order quantity",
                    Answer2En = "The auto-store method optimizes the unit factor",
                    Answer3En = "Container optimization optimizes the ordering costs",
                    CorrectAnswersEn = "The auto-store method optimizes the unit factor| Container optimization optimizes the ordering costs",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 74,
                    
                    TextDe = "Welche Kombinationen sind bei einer Container-Optimierung möglich, nach der optimiert werden soll?",
                    Answer1De = "Volumen / Gewicht",
                    Answer2De = "Faktor / Volumen",
                    Answer3De = "Gewicht / Faktor",
                    CorrectAnswersDe = "Volumen / Gewicht| Gewicht / Faktor",

                    TextEn = "What combinations are possible for a container optimization that is to be optimized?",
                    Answer1En = "Volume / weight",
                    Answer2En = "Factor / Volume",
                    Answer3En = "Weight / factor",
                    CorrectAnswersEn = "Volume / weight| Weight / factor",

                    QuizCategory = new List<string> { "Parameter" }
                 },

                 new Question
                 {
                    Id = 75,

                    TextDe = "Was ändert sich im Bestellfenster wenn Reservierungen eine Partition besitzen?",
                    Answer1De = "Eine Reservierung mit Partition kriegt eine eigene Bestellung und kann direkt einem Auftrag zugeordnet werden",
                    Answer2De = "Eine Reservierung mit Partition wird zusammengefasst mit anderen Bestellungen im Bestellungs-Fenster",
                    Answer3De = "Eine Reservierung mit Partition wird in mehrere kleinere Bestellungen aufgeteilt",
                    CorrectAnswersDe = "Eine Reservierung mit Partition kriegt eine eigene Bestellung und kann direkt einem Auftrag zugeordnet werden",

                    TextEn = "How does the order window change when reservations have a partition?",
                    Answer1En = "A reservation with a partition gets its own order and can be assigned directly to an item",
                    Answer2En = "A reservation with partition is summarized with other orders in the order window",
                    Answer3En = "A reservation with a partition is divided into several smaller orders",
                    CorrectAnswersEn = "A reservation with a partition gets its own order and can be assigned directly to an item",

                    QuizCategory = new List<string> { "Parameter" }
                 },
                 /*
                 new Question
                 {
                    Id = 76,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 77,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 78,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 79,
                    
                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 80,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 81,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 82,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 83,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 84,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 85,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 86,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 87,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 },

                 new Question
                 {
                    Id = 88,

                    TextDe = "",
                    Answer1De = "",
                    Answer2De = "",
                    Answer3De = "",
                    CorrectAnswersDe = "",

                    TextEn = "",
                    Answer1En = "",
                    Answer2En = "",
                    Answer3En = "",
                    CorrectAnswersEn = "",

                    QuizCategory = new List<string> { "", "" }
                 }, */
            
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

