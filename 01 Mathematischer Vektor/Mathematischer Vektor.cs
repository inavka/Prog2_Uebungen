using System;

namespace _01_Mathematischer_Vektor
{
//    Mathematischer Vektor(eindimensionales Array)
//Erstellen Sie eine Klasse Vector für Richtungskomponenten vom Typ double. Die Klasse
//Vector enthält zur Speicherung der Werte ein Array(Datentyp double, geschützt) und
//folgende Methoden:
//- Konstruktor ohne Parameter zur Erzeugung eines Nullvektors – Ein Nullvektor ist ein
//Vektor, bei dem Anfangs- und Endpunkt zusammenfallen: Array der Größe 1
//- Konstruktor zur Erzeugung eines n-dimensionalen, gerichteten Vektors: Array der Größe n
//- Dimension des Vektors ermitteln(Property)
//- Lesender und schreibender Zugriff auf die Richtungskomponenten(Indexer)
//Erzeugen Sie ein Objekt der Klasse Vektor, ermitteln Sie die Dimension und belegen Sie
//die Komponenten mit Hilfe des Indexers mit Werten und geben Sie die Werte(Zugriff
//ebenfalls über Indexer) auf Konsole aus
    class Program
    {
        class Vector
        {
            double[] werte;
            public Vector()
            {
                werte = new double[1];
            }

            public Vector(int n)
            {
                werte = new double[n];
            }

            public int Dimension
            {
                get
                {
                    return werte.Length;
                }
            }

            public double this[int n]
            {
                get { return werte[n]; }
                set { werte[n] = value; }
            }
        }
        static void Main(string[] args)
        {
            Vector v = new Vector(3);
            int d = v.Dimension;
            v[0] = 0;
            v[1] = 1;
            v[2] = 2;
            for (int i = 0; i < d; i++)
            {
                Console.WriteLine(v[i]);
            }
        }
    }
}
