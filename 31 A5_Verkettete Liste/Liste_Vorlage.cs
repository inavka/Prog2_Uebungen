using System;
using System.Collections.Generic;

namespace _31_A5_Verkettete_Liste
{
    class Program
    {       // Normale einfach verkettete Liste
            // Liste nur für strings
        class Liste_Vorlage
        {
            // Klasse für die Elemente
            private class Element
            {
                public string name;
                public Element next;
                public Element(string Name) { name = Name; }
            }

            Element anfang, ende;
            int anz = 0;
            // Gibt Anzahl der Elemente in Liste zurück
            public int Anz { get { return anz; } }

            // Am Anfang anhängen
            public void AddFirst(string daten)
            {
                Element neu = new Element(daten);
                anz++;
                neu.next = anfang;
                anfang = neu;
                // Wenn Liste bislang leer war
                if (ende == null)
                    ende = neu;
            }

            // Am Ende anhängen
            public void AddLast(string daten)
            {
                Element neu = new Element(daten);
                anz++;
                // Leere Liste
                if (anfang == null)
                    anfang = ende = neu;
                // Bereits Elemente in Liste vorhanden
                else
                    ende = ende.next = neu;
            }

            public void AddBeforeNth(int index, string daten)
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
                    Element neu = new Element(daten);
                    anz++;
                    Element tmp = anfang;
                    // Durchlaufen der Liste
                    // -1 da VOR Element eingefügt wird
                    for (int i = 0; i < index - 1; i++)
                        tmp = tmp.next;
                    // Einfügen des Elements
                    neu.next = tmp.next;
                    tmp.next = neu;
                }
            }
            public void AddSorted(string daten)
            {
                // 1.Fall:
                // Leere Liste 
                // oder neues Element > letztes Element
                if (anfang == null || daten.CompareTo(ende.name) > 0)
                    AddLast(daten);
                // Es existiert mind. ein Element in Liste
                // Neues Element wird nicht letztes Element
                else
                {
                    // 2.Fall:
                    // Neues Element <= erstes Element
                    if (daten.CompareTo(anfang.name) <= 0)
                        AddFirst(daten);
                    // 3.Fall:
                    // In Mitte einfügen
                    else
                    {
                        Element neu = new Element(daten);
                        anz++;
                        Element tmp = anfang;
                        // Durchlaufen der Liste
                        // Wenn Name des nächsten Elements kleiner ist => weitergehen
                        // tmp verweist auf das Element VOR der Einfügestelle
                        while (tmp.next.name.CompareTo(daten) < 0)
                            tmp = tmp.next;
                        // Einfügen des Elements
                        neu.next = tmp.next;
                        tmp.next = neu;
                    }
                }
            }

            // Index wird übergeben
            private Element NthElem(int index)
            {
                if (index < 0 || index >= anz)
                    throw new IndexOutOfRangeException("Listenindex außerhalb des gültigen Bereichs");
                Element item = anfang;
                while (index > 0)
                {
                    item = item.next;
                    index--;
                }
                return item;
            }

            public string this[int index]
            {
                get => NthElem(index).name;
                set { NthElem(index).name = value; }
            }

            // Anfangselement entfernen
            public void DeleteFirst()
            {
                // leere Liste
                if (anfang == null)
                    return;
                // nur ein Element in Liste 
                anz--;
                if (anfang == ende)
                    anfang = ende = null;
                // mind. zwei Elemente
                else
                    // erstes Element entfernen
                    anfang = anfang.next;
            }

            public void DeleteLast()
            {
                // 1.Fall: Liste ist leer
                // 2.Fall: Liste besteht nur aus einem Element
                // 3.Fall: Liste hat mehr als ein Element
                if (anfang == null)  // 1. Fall
                    throw new NullReferenceException("Die Liste ist leer");
                anz--;
                if (anfang == ende)  // 2. Fall
                    anfang = ende = null;
                else              // 3. Fall
                {  // Wir wissen: Die Liste hat mehr als ein Element, d.h. es gibt ein
                   // vorletztes Element mit vorletzter.next == ende
                    Element vorletzter = anfang;
                    while (vorletzter.next != ende)
                        vorletzter = vorletzter.next;
                    vorletzter.next = null;
                    ende = vorletzter;   // neues Ende!
                }
            }

            public void DeleteNth(int index)
            {
                // 1.Fall: Liste ist leer ODER Ind>=anz --> Fehler
                // 2.Fall: Ind == 0  --> DeleteFirst
                // 3.Fall: Ind == anz-1 --> DeleteLast
                // 4. Bis hierher: Liste hat mind. ein Element und das zu löschende Element
                //                 ist nicht das Erste oder Letzte
                if (anz == 0 || index >= anz)  // 1. Fall
                    throw new ArgumentOutOfRangeException("Außerhalb der Anzahl der Listenelemente");
                if (index == 0)  // 2. Fall
                    DeleteFirst();
                else if (index == anz - 1)             // 3. Fall
                    DeleteLast();
                else
                {
                    Element vorletzter = anfang;
                    for (int i = 1; i < index; i++)
                        vorletzter = vorletzter.next;
                    vorletzter.next = vorletzter.next.next;
                    anz--;
                }
            }

            public void DeleteByName(string name)
            {
                // leere Liste ohne Elemente
                if (anfang == null)
                    return;
                // erstes Element = gesuchtes Element
                if (anfang.name.CompareTo(name) == 0)
                    DeleteFirst();
                // Wir wissen jetzt:
                // Liste hat mind. ein Element UND das erste Element ist nicht das gesuchte Element
                else
                {
                    Element item = anfang;
                    // Durchlaufen der Liste
                    // solange Elemente in Liste vorhanden und gesuchtes Element noch nicht gefunden
                    while (item.next != null && item.next.name.CompareTo(name) != 0)
                        item = item.next;
                    // Wenn gesuchtes Element in Liste vorhanden
                    if (item.next != null)
                    {
                        // Nächstes Element überspringen = löschen
                        item.next = item.next.next;
                        // Wenn letztes Element = gesuchtes Element
                        if (item.next == null)
                            ende = item;
                    }
                }
            }

            public void Print()
            {
                // Durchlaufen der Liste 
                // Ausgabe für jedes Element
                for (Element tmp = anfang; tmp != null; tmp = tmp.next)
                    Console.WriteLine(tmp.name);
            }

            public IEnumerator<string> GetEnumerator()
            {
                for (Element tmp = anfang; tmp != null; tmp = tmp.next)
                {
                    yield return tmp.name;
                }
            }

            public void Reverse()
            {
                if (anfang == ende) //1.Fall: die Liste ist Leer
                    return;

                //2. Fall: Liste hat mehr als 1 Element
                Element current = anfang;
                Element neuAnfang = null;
                while (current != null)
                {
                    Element tmpNext = current.next;
                    current.next = neuAnfang;
                    neuAnfang = current;
                    current = tmpNext;
                }
                ende = anfang; //Neues Ende ist der alte Anfang
                anfang = neuAnfang;
            }

        }
        
    }
}
