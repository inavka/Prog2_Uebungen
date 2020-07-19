using System;

namespace _71_Delegates
{
    class Program
    {
        delegate bool Auswahl(int anzahl);
        // Teilweise vorgegebene Listenimplementierung:
        class Liste
        {
            class LElement
            {
                public string name;
                public int anzahl;
                public LElement next;
                public LElement(string name, int anzahl)
                {
                    this.name = name;
                    this.anzahl = anzahl;
                }
            }
            LElement root;
            public void Hinzufügen(string name, int anzahl)
            {
                // Hier Ihre ergänzende Implementierung der Methode Hinzufügen():
                LElement tmp = SucheArtikel(name);
                if (tmp!=null)
                {
                    tmp.anzahl++;
                }
                else
                {
                    // Vorne einfügen:
                    LElement neu = new LElement(name, anzahl);
                    neu.next = root;
                    root = neu;
                }
            }
            // Hier Ihre Implementierung der privaten Methode SucheArtikel():
            private LElement SucheArtikel(string name)
            {
                if (root == null)
                    return null;
                LElement item = root;
                while (item.next != null)
                {
                    if (item.name == name)
                    {
                        return item;
                    }
                    item = item.next;
                }
                return null;
            }
            // Hier Ihre Implementierung der öffentlichen Methode Bestellung():
            public Liste Bestellung(Auswahl funktion)
            {
                Liste l1 = new Liste();
                if (root == null)
                    return null;
                LElement item = root;
                while(item.next!=null)
                {
                    if (funktion(item.anzahl))
                    {
                        l1.Hinzufügen(item.name, item.anzahl);
                        Console.WriteLine(item.name + item.anzahl);
                    }
                    item = item.next;
                }
                return l1;
            }
        } // Ende der Klasse Liste
        public static void Main()
        {
            Liste sortiment = new Liste();
            sortiment.Hinzufügen("Kaffee", 2);
            sortiment.Hinzufügen("Zucker", 4);
            sortiment.Hinzufügen("Mehl", 10);
            sortiment.Hinzufügen("Kaffee", 3);
            Liste bestellListe = sortiment.Bestellung
            (
            // Hier Ihre Implementierung mittels anonymer Funktion (oder alternativ Lambda‐Ausdruck):
            delegate (int x)
            {
                if (x <= 5)
                    return true;
                else
                    return false;
            }
            );
            // bestellListe enthält nun (nur) die Einträge mit den Artikelnamen „Kaffee“ und „Zucker“
        }
    }
}
