using System;

namespace _30_Zyklische_Liste
{
    class Program
    {
        class Ringpuffer<T>
        {
            private class Element
            {
                public T daten;
                public Element next;
                public Element(T Daten) { daten = Daten; }
            }
            Element anf, root;
            int anz = 0;

            public Ringpuffer(int n)
            {
                anz = n;
                root = new Element(default(T));
                Element anf = root;
                for (int i = 2; i < n; i++)
                {
                    root = root.next = new Element(default(T));        // 3. Neues Element am Ende anfügen
                }
                root.next = anf;
            }

            public void EnQueue(T Daten, int takt)
            {
                bool gefunden = false;
                int durchlauf = 0;
                while (takt != 0) //Sucht den richtigen Platz
                {
                    takt--;
                    root = root.next;
                }

                if (root.daten == null) //Prueft ob man da schreiben kann
                {
                    root.daten = Daten;
                    return;
                }
                else //wenn nicht
                {
                    while (root.daten != null || durchlauf != anz) //Sucht den leeren Platz
                    {                                           //bricht ab wenn der Ring durchgelaufen wird
                        root = root.next;                         //geht auf den Platz n+1
                        if (root.daten == null)                  //Prueft ob Platz leer ist
                            gefunden = true;
                    }
                    if (gefunden)
                    {
                        root.daten = Daten;
                    }
                    else                                        //wenn kein Platz leer war und der komplette Ring durchgelaufen wurde
                        throw new InsufficientMemoryException();
                }

            }

            public T DeQueue()
            {
                T erg = root.daten;
                root.daten = default(T);
                root = root.next;
                return erg;
            }

            public void Print()
            {
                for (Element item = root; item.next != root; item = item.next) 
                { 
                    if(item.daten!=null)
                        Console.WriteLine(item.daten); 
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
