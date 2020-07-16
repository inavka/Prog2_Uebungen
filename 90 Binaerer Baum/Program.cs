using System;

namespace _05BinTree
{
    public class BinTree
    {
        public class BItem
        {
            // Zahlen enthalten, kleinere und größere Elemente
            public int zahl;
            public BItem kleinereElemente = null, groessereElemente = null;

        }
        BItem anfang = null;

        public void InsertItem(int Zahl)
        {
            BItem neu = new BItem() { zahl = Zahl };

            // Erstes Element in Liste
            if (anfang == null)
                anfang = neu;

            // Bereits Elemente vorhanden
            else
            {
                bool gefunden = false;
                BItem lfd = anfang;

                // Solange bis bool gefunden == true
                do
                {
                    // links oder rechts?
                    if (Zahl < lfd.zahl)
                    {   // Linker Teilbaum
                        // ist "links" frei?
                        if (lfd.kleinereElemente == null)
                        {
                            lfd.kleinereElemente = neu;
                            gefunden = true;
                        }
                        // nein --> links weitersuchen
                        else
                            lfd = lfd.kleinereElemente;
                    }

                    else
                    {
                        // Rechter Teilbaum
                        // ist "rechts" frei?
                        if (lfd.groessereElemente == null)
                        {
                            lfd.groessereElemente = neu;
                            gefunden = true;
                        }
                        // nein --> rechts weitersuchen
                        else
                            lfd = lfd.groessereElemente;
                    }
                } while (!gefunden);
            }
        }

        public bool FindItem(int zahl)
        {
            BItem item = anfang;
            while (item != null)
            {
                if (zahl == item.zahl)
                {
                    return true;
                }
                item = (zahl < item.zahl) ? item.kleinereElemente : item.groessereElemente;
            }
            return false;
        }

        private void Ausgeben(BItem ausgabe)
        {
            // Solange BItem nicht leer
            if (ausgabe != null)
            {
                // Zuerst Ausgabe der kleinen Elemente
                Ausgeben(ausgabe.kleinereElemente);
                Console.Write(ausgabe.zahl + " ");
                // Dann Ausgabe der großen Elemente
                Ausgeben(ausgabe.groessereElemente);
            }
        }
        public void Ausgeben()
        {
            Ausgeben(anfang);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Zahlen werden in Binärbaum eingefügt
            BinTree bt = new BinTree();
            bt.InsertItem(50);
            bt.InsertItem(25);
            bt.InsertItem(75);
            bt.InsertItem(60);
            bt.InsertItem(80);
            bt.InsertItem(77);
            bt.InsertItem(70);

            bt.ToString();
            Console.WriteLine();

            // Baum wird ausgegeben
            bt.Ausgeben();
        }
    }
}