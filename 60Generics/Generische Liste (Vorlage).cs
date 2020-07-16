using System;
using System.Collections.Generic;

namespace _60Generics
{
    class Program
    {
        // Normale einfach verkettete Liste,
        // aber für verschiedene Datentypen
        class Liste<TYP> where TYP : IComparable
        {
            // Klasse Element
            private class LElem
            {
                public TYP daten;
                public LElem next;
                public LElem(TYP Name) { daten = Name; }
            }

            LElem anfang, ende;
            int anz = 0;
            // Gibt Anzahl der Elemente in Liste zurück
            public int Anz { get { return anz; } }

            // Am Anfang anhängen
            public void AddFirst(TYP Daten)
            {
                // 1. Leere Liste
                // 2. Es existiert mind. ein Element
                LElem neuesElement = new LElem(Daten);   // Neues Element anlegen
                anz++;
                if (anfang == null)                            // 1.Fall: Leere Liste?
                    anfang = ende = neuesElement;
                else
                {
                    neuesElement.next = anfang;                // 2. Fall
                    anfang = neuesElement;
                }
            }

            // Am Ende anhängen
            public void AddLast(TYP Daten)
            {
                LElem neuesElement = new LElem(Daten);   // 1. Neues Element anlegen
                anz++;
                if (anfang == null)                            // 2. Leere Liste?
                    anfang = ende = neuesElement;
                else
                {
                    ende.next = neuesElement;               // 3. Neues Element am Ende anfügen
                    ende = ende.next;
                }
            }

            public void EinfuegenVor(int index, TYP daten)
            {

                // Index ungültig 
                if (index < 0 || index > anz)
                    throw new ArgumentOutOfRangeException("Index außerhalb der Listengröße");
                // Vor erstes Element = AddFirst()
                if (index == 0)
                    AddFirst(daten);
                // Hinter letztes Element = AddLast()
                else if (index == anz)
                    AddLast(daten);

                // Mindestens 2 Elemente vorhanden
                else
                {
                    LElem neu = new LElem(daten);
                    anz++;

                    LElem tmp = anfang;
                    // Durchlaufen der Liste
                    // -1 da VOR Element eingefügt wird
                    for (int i = 0; i < index - 1; i++)
                        tmp = tmp.next;

                    // Einfügen des Elements
                    neu.next = tmp.next;
                    tmp.next = neu;
                }

            }

            public void SortedInsert(TYP Daten)
            {
                // 1. Fall: Leere Liste oder Anfügen am Listenende
                if (anfang == null || ende.daten.CompareTo(Daten) <= 0)
                    AddLast(Daten);
                else
                {
                    if (Daten.CompareTo(anfang.daten) <= 0)
                        AddFirst(Daten);
                    else
                    {
                        // Wir wissen: Das neue Element ist nicht das erste und nicht das letzte Element
                        LElem neu = new LElem(Daten);
                        anz++;

                        LElem item = anfang;
                        while (item.next.daten.CompareTo(Daten) < 0)
                            item = item.next;
                        neu.next = item.next;
                        item.next = neu;
                    }
                }
            }
            // Element mitten in Liste entfernen
            public void Delete(TYP Daten)
            {
                if (anfang == null)
                    return;
                if (anfang.daten.CompareTo(Daten) == 0)
                {
                    anfang = anfang.next;
                    // Falls Liste jetzt leer ist
                    if (anfang == null)
                        ende = null;
                }
                else
                {
                    LElem tmp = anfang;
                    while (tmp.next != null && tmp.next.daten.CompareTo(Daten) != 0)
                        tmp = tmp.next;
                    if (tmp.next != null)
                    {
                        tmp.next = tmp.next.next;
                        if (tmp.next == null)
                            ende = tmp;
                    }
                }
            }

            public IEnumerator<TYP> GetEnumerator()
            {
                for (LElem item = anfang; item != null; item = item.next)
                {
                    yield return item.daten; // Merken dieser Ausführungsposition
                                             // UND Zurückliefern von item.name
                                             // Beim nächsten Aufruf von GetEnumerator() wird
                                             // an der gespeicherten Pos. weitergemacht.
                }

            }
           
            public void Print()
            {
                for (LElem item = anfang; item != null; item = item.next)
                {
                    Console.WriteLine(item);
                }
            }
            public bool Suche(TYP daten)
            {
                for (LElem item = anfang; item != null; item = item.next)
                {
                    if (item.daten.CompareTo(daten) == 0)
                        return true;
                }
                return false;
            }

            public delegate bool MyFilter1(TYP daten);   // Typpar. T wird vom äußeren Class<T> genommen
       
            public IEnumerable<TYP> Filter(MyFilter1 myTest)   // string => bool,  x => x.Contains("er")
            {
                for (LElem item = anfang; item != null; item = item.next)
                {
                    if (myTest(item.daten))   // if (item.daten.Contains(pattern))
                        yield return item.daten;
                }
            }
            private LElem NthElem(int index)
            {
                if (index < 0 || index >= anz)
                    throw new IndexOutOfRangeException("Listenindex außerhalb des gültigen Bereichs");
                LElem item = anfang;
                while (index > 0)
                {
                    item = item.next;
                    index--;
                }
                return item;
            }
            public TYP this[int index]
            {
                get => NthElem(index).daten;
                set { NthElem(index).daten = value; }
            }
            public Liste<TYP> Reverse() // Erstellt neue Liste
            {
                Liste<TYP> neueListe = new Liste<TYP>();
                for (LElem item = anfang; item != null; item = item.next)
                    neueListe.AddFirst(item.daten);
                return neueListe;
            }

            public int CompareTo(Liste<TYP> other) => anz - other.anz;
        }   
    }
}
