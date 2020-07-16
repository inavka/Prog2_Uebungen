/*  
 * WICHTIGER HINWEIS: IHR GESAMTES PROJEKT (INKL. DIESER DATEI) MUSS KOMPILIEREN!
 * 
 * Ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!
 * Bitte überprüfen Sie unbedingt vor der Abgabe Ihrer Lösungen, ob das gesamte Projekt kompiliert.
 * Wenn Sie eine (Teil-)Aufgabe nicht lösen können, dann lassen Sie bitte die entsprechende Quellcode-Datei unverändert.
 */

/*
 * Aufgabe 1 - Methoden-Rückgabewerte - String-Rückgabewert
 * 
 * Implementieren Sie in der u. s. Klasse "IntegerWrapper" eine öffentliche Methode "WithPrefix()" mit den folgenden Eigenschaften:
 * 
 * - Die Methode soll einen String-Parameter haben
 * - Der Rückgabewert der Methode soll wieder ein String sein
 * - Der zurückgegebene String soll eine Konkatenation aus dem als Parameter übergebenen String mit dem 
 *   Integer-Wert "Value" aus der o.g. Klasse sein (Siehe Aufgabe1.cs)
 *   
 * Beispiel:
 * 
 *   IntegerWrapper myIntegerWrapper = new IntegerWrapper();
 * 
 *   myIntegerWrapper.Value = 2;
 * 
 *   string myString = myIntegerWrapper.WithPrefix("Programmieren");
 * 
 * Die Variable "myString" soll nun den Wert "Programmieren2" haben.
 */

namespace Aufgabe1
{
  partial class IntegerWrapper
  {
    // Hier Ihre Lösung...
    public string WithPrefix(string praefix)
        {
            return $"{praefix}{this.Value}";
        }
  }
}