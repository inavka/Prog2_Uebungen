using System;

namespace _21_Verkettete_Liste
{
    class Seminarbuchung
    {
        class SeminarListe
        {
            private class Teilnehmer
            {
                public string name { get; private set; }
                public int mtr { get; private set; }
                public Teilnehmer next;
                public Teilnehmer(string Name, int Mtr)
                {
                    name = Name;
                    mtr = Mtr;
                }

                public override string ToString()
                {
                    return $"{name}, {mtr}";
                }
            }
            Teilnehmer anf, ende;

            int anz;
            public SeminarListe(int anz)
            {
                this.anz = anz;
            }

            public bool Anmelden(string Name, int Mtr)
            {
                if (anz <= 0)
                    return false;

                Teilnehmer neu = new Teilnehmer(Name, Mtr);
                anz--;
                if (anf == null)
                    anf = ende = neu;
                else
                    ende = ende.next = neu;
                return true;
            }

            public bool Abmelden(int Mtr)
            {
                if (anf == null)
                    return false;
                if (anf.mtr.CompareTo(Mtr) == 0)
                {
                    anz++;
                    if (anf == ende)
                        anf = ende = null;
                    // mind. zwei Elemente
                    else
                        // erstes Element entfernen
                        anf = anf.next;
                    return true;
                }
                // Wir wissen jetzt:
                // Liste hat mind. ein Element UND das erste Element ist nicht das gesuchte Element
                else
                {
                    Teilnehmer item = anf;
                    // Durchlaufen der Liste
                    // solange Elemente in Liste vorhanden und gesuchtes Element noch nicht gefunden
                    while (item.next != null && item.next.mtr.CompareTo(Mtr) != 0)
                        item = item.next;
                    // Wenn gesuchtes Element in Liste vorhanden
                    if (item.next != null)
                    {
                        // Nächstes Element überspringen = löschen
                        item.next = item.next.next;
                        // Wenn letztes Element = gesuchtes Element
                        if (item.next == null)
                            ende = item;
                        anz++;
                        return true;
                    }
                    else
                        return false;
                }
            }

            public bool Suche(int Mtr)
            {
                if (anf.mtr == Mtr)
                    return true;
                Teilnehmer item = anf;
                // Durchlaufen der Liste
                // solange Elemente in Liste vorhanden und gesuchtes Element noch nicht gefunden
                while (item.next != null && item.next.mtr.CompareTo(Mtr) != 0)
                    item = item.next;
                // Wenn gesuchtes Element in Liste vorhanden
                if (item.next != null)
                    return true;
                else
                    return false;
            }
            public int Anzahl
            {
                get
                {
                    return anz;
                }
            }

            public override string ToString()
            {
                string erg = "";
                Teilnehmer item = anf;
               
                // Durchlaufen der Liste
                // solange Elemente in Liste vorhanden und gesuchtes Element noch nicht gefunden
                while (item.next != null)
                {
                    erg += item + "\n";
                    item = item.next;
                }
                return erg;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

