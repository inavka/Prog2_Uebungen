/*  
 * WICHTIGER HINWEIS: IHR GESAMTES PROJEKT (INKL. DIESER DATEI) MUSS KOMPILIEREN!
 * 
 * Ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!
 * Bitte überprüfen Sie unbedingt vor der Abgabe Ihrer Lösungen, ob das gesamte Projekt kompiliert.
 * Wenn Sie eine (Teil-)Aufgabe nicht lösen können, dann lassen Sie bitte die entsprechende Quellcode-Datei unverändert.
 */

/*
 * Aufgabe 2 - Statiche Methoden und Arrays - String-Arrays
 * 
 * Implementieren Sie eine Klasse "MyOtherClass" mit einer öffentlichen statischen Methode "GetWords()", die einen String-
 * Parameter hat und als Rückgabe ein String-Array zurückgibt, das eine Zerlegung des übergebenen Strings in  einzelne Wörter
 * (ohne Leerzeihen) darstellt. Als Trennzeichen sollen (nur) Leerzeichen betrachtet werden. Beispiel: Für den übergebenen 
 * String-Parameter "This is   my text! " soll das zurückgegebene String-Array genau die folgenden Einträge (exakt in der 
 * Reihenfolge) enthalten: "This", "is", "my", "text!". Sie können davon ausgehen, dass der übergebene String-Parameter nie
 * "null" ist. Wird ein leerer String ("") übergeben, dann soll ein leeres String-Array (d.h. instanziiert, aber ohne Elemente) 
 * zurückgegebnen werden (Für die Implementierung dürfen Sie auch .NET-Funktionalität nutzen).
 * 
 * Bitte beachten Sie auch die beiligenen Zusatzinformationen zu dieser Aufgabe in der Datei "Zusatzinformaionen2b.pdf"!
 */

namespace Aufgabe2
{
    // Hier ergänzen...
    class MyOtherClass
    {
        public static string[] GetWords(string text)
        {
            string[] words = text.Split(' ');
            return words;
        }
    }
}