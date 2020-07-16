/*  
 * WICHTIGER HINWEIS: IHR GESAMTES PROJEKT (INKL. DIESER DATEI) MUSS KOMPILIEREN!
 * 
 * Ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!
 * Bitte überprüfen Sie unbedingt vor der Abgabe Ihrer Lösungen, ob das gesamte Projekt kompiliert.
 * Wenn Sie eine (Teil-)Aufgabe nicht lösen können, dann lassen Sie bitte die entsprechende Quellcode-Datei unverändert.
 */

/*
 * Aufgabe 2 - Statiche Methoden und Arrays - Integer-Arrays
 * 
 * Implementieren Sie eine Klasse "MyClass" mit einer öffentlichen statischen Methode "GetIntegerArray()", die keinen
 * Parameter hat und als Rückgabe einen Integer-Array mit den Werten (in exakt der Reihenfolge) zurückliefert: 1, 2, 3, 5, 8.
 */

namespace Aufgabe2
{
  // Hier ergänzen...
  class MyClass
    {
        public static int[] GetIntegerArray()
        {
            return new int[] { 1, 2, 3, 5, 8 };
        }
    }
}