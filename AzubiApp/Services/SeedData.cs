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

                    TextDe = "Welche Grenze sollte höher sein bei den Ausreißern, damit diese korrigiert wird?                                              ",
                    Answer1De = "Behandlungsgrenze",
                    Answer2De = "Warnungsgrenze",
                    Answer3De = "Max.-Grenze",
                    CorrectAnswersDe = "Behandlungsgrenze",

                    TextEn = "Which limit should be higher for the outliers so that this is corrected?                                              ",
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
                    CorrectAnswersEn = "New Article variation SKUs without history | Replacement article SKUs without history",

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
                 /*
                 new Question
                 {
                    Id = 31,

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
                    Id = 32,

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
                    Id = 33,

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
                    Id = 34,

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
                    Id = 35,

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
                    Id = 36,

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
                    Id = 37,

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
                    Id = 38,

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
                    Id = 39,

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
                    Id = 40,

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
                 */
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

