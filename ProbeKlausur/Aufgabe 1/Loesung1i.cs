/*  
 * WICHTIGER HINWEIS: IHR GESAMTES PROJEKT (INKL. DIESER DATEI) MUSS KOMPILIEREN!
 * 
 * Ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!
 * Bitte überprüfen Sie unbedingt vor der Abgabe Ihrer Lösungen, ob das gesamte Projekt kompiliert.
 * Wenn Sie eine (Teil-)Aufgabe nicht lösen können, dann lassen Sie bitte die entsprechende Quellcode-Datei unverändert.
 */

/*
 * Aufgabe 1 - Methoden-Rückgabewerte - Integer-Rückgabewert
 * 
 * Implementieren Sie die u.s. Methode "Double()" so, dass als Rückgabewert das Dopplete von dem in der Klasse "IntegerWrapper" 
 * gekapselten Integer-Wert "Value" (Siehe Aufgabe1.cs) zurückgegeben wird. Beispiel:
 * 
 *   IntegerWrapper myIntegerWrapper = new IntegerWrapper();
 * 
 *   myIntegerWrapper.Value = 23;
 * 
 *   int myInteger = myIntegerWrapper.Double();
 * 
 * Die Variable "myInteger" soll nun den Wert 46 haben.
 */

namespace Aufgabe1
{
  partial class IntegerWrapper
  {
    public int Double()
    {
            return this.Value * 2;
     // throw new System.NotImplementedException("Keine Lösung der Aufgabe!");  // Hier löschen und ergänzen, (nur) wenn Sie die Aufgabe lösen können...
    }
  }
}