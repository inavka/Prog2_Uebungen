using System;

namespace _02_Indexer
{
    class Klasse_Temperatur
    {
//        Erstellen Sie eine Klasse Temperatur zur Verwaltung von Temperaturwerten.Als Datenfeld
//enthält die Klasse ein Array aus double-Werten.Die Klasse Temperatur bekommt folgende
//Methoden:
//- Konstruktor, der ein leeres Array einer bestimmter Größe(Parameter) erzeugt.
//- Konstruktor, der eine variable Anzahl von Temperaturwerten als Parameter hat, das Array in
//dieser Größe anlegt und die Werte in das Array übernimmt.
//- property Anzahl(read-only), die die Anzahl der Elemente im Array zurückliefert
//- Indexer für den Zugriff auf die Feldelemente
//- Methode zur Bestimmung der Maximaltemperatur.
//In einem testenden Hauptprogramm legen Sie ein Objekt der Klasse an, geben mit Hilfe des
//Indexers alle Werte aus und rufen Sie anschließend noch die Methode zur Bestimmung der
//Maximaltemperatur auf und geben diese aus.
       class Temperatur
        {
            double[] werte;

            public Temperatur(int n=1)
            {
                werte = new double[n];
            }
            public Temperatur(params double[] Werte)
            {
                werte = new double[Werte.Length];
                for (int i = 0; i<Werte.Length;i++)
                {
                    werte[i] = Werte[i];
                }
            }

            public int Anzahl
            {
                get
                {
                    return werte.Length;
                }
            }

            public double this[int n]
            {
                get
                {
                    return werte[n];
                }
                set
                {
                    werte[n] = value;
                }
            }

            public double MaxTemp ()
            {
                double max = werte[0];
                for (int i = 1; i< werte.Length; i++)
                {
                    if (werte[i] > max)
                        max = werte[i];
                }
                return max;
            }
        }
        static void Main(string[] args)
        {
            Temperatur t = new Temperatur(3);
            t[0] = 1.5;
            t[1] = 2.2;
            t[2] = 3.2;
            for(int i = 0; i<t.Anzahl; i++)
            {
                Console.WriteLine(t[i]);
            }
            Console.WriteLine(t.MaxTemp());
        }
    }
}
