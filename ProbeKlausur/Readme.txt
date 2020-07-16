DIGITALE PRÜFUNG IM BEREICH PROGRAMMIERUNG MIT C#

Technische Hochschule Nürnberg - Fakultät Informatik


Projektstruktur
---------------

Dieses C#-Projekt stellt Ihre individuelle Prüfung in digitaler Form dar. Das Projekt ist folgendermaßen strukturiert:

- "Readme.txt": Diese Datei...

- "Program.cs": Programmklasse mit (leerem) Anwendungseinstiegspunkt "Main()"

- Jeweils in den Ordnern "Aufgabe *" befinden sich die eigentlichen Aufgaben in der folgenden Struktur:

  * "Aufgabe*.cs": Übergeordnete Aufgabenbeschreibung, mit eventuellen vorgegebenen ("vorimplementierten") Quellcode(-ausschnitten)

  * "Loesung*.cs": Spezifische (Teil-)Aufgabenstellungen mit Bereichen im Quellcode, wo Sie Ihre eigene Lösung der
                   entsprechenden (Teil-)Aufgabe implementieren sollen.


Aufgabenlösung
--------------

Zur Aufgabenlösung gehen Sie in den Lösungsdateien (Loesung*.cs) bitte folgendermaßen vor:

(a) Wenn Sie eine Aufgabe NICHT lösen können, dann lassen Sie die entsprechende Lösungsdatei unverändert!

(b) (Nur) Wenn Sie eine Aufgabe lösen können, dann gehen Sie bitte folgendermaßen vor:

    1. Löschen Sie (komplett) all die Zeilen in dem Quellcode, die den Kommentar "Hier löschen" enthalten (falls zutreffend)
    2. Zur Lösung einer (Teil-)Aufgabe implementieren Sie Quellcode basierend auf der Aufgabenbeschreibung und dem vorgebenenen Quellcode
    3. Bei Zeilen mit dem Kommentar "Hier ergänzen" dürfen Sie Quellcode (nur) HINZUFÜGEN, und in all den anderen Fällen...
    4. ...verändern Sie NIEMALS den vorgegebenen Quellcode (also auch nicht (Zugriffs-)Modifizierer, Bezeichner, etc.)!
    5. Eine Ausnahme zum Punkt 4. bildet das Einbinden von Namensräumen, d. h. eigene "using"-Anweisungen dürfen Sie immer hinzufügen
    6. Bei vorgegebenen Bezeichnern (Klassen-, Methodennamen etc.) und Strings achten Sie auf die EXAKTE Schreibweise (inkl. Groß-/Klein-)!
    7. Fügen Sie Ihre Lösungen nur in den vorbereiteten Namensräumen (siehe "Aufgabe*.cs") und - falls zutreffend - Klassen ein!

(c) Wenn Sie EIGENE Hilfsklassen, Hilfs(eigenschafts)methoden oder Hilfsdatenfelder hinzufügen möchten (d. h. solche die nicht in 
    der Aufgabenstellung explizit vorgegeben sind), dann MÜSSEN die entsprechenden Bezeichner mit einem Unterstrich ("_") beginnen, 
    z. B. "public void _MyMethod()"!   

 
Wichtige Hinweise
-----------------

1. Richten Sie sich bei Ihrer Aufgabenlösung immer EXAKT nach den vorgegebenen Quellcodes und beachten Sie die enthaltenen Kommentare!

2. Die Projekdatei ("*.csproj") und all darin vorgegebenen (Quellcode-)Dateien dürfen NICHT UMBENANNT werden,
   ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!

3. Ihr gesamtes Projekt, inkl. aller enthaltener Quellcodes (d. h. "Program.cs"., "Aufgabe*.cs" und "Loesung*.cs" MUSS KOMPILIEREN,
   ansonsten bekommen Sie für die GESAMTE Prüfung keine Punkte (= Durchgefallen)!

-> Bitte überprüfen Sie unbedingt vor der Abgabe Ihrer Lösungen, ob das gesamte Projekt kompiliert.
   Wenn Sie eine (Teil-)Aufgabe nicht lösen können, dann lassen Sie bitte die entsprechende Quellcode-Datei unverändert.