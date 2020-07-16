using System;

namespace _11_Operatoren
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
            readonly double[] werte;
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

            //Vergleich zweier Vektoren(Operator) :
            //Vergleichen Sie die jeweiligen Komponenten der beiden Vektoren und liefern Sie true, wenn
            //alle gleich sind, false sonst.

            public static bool operator ==(Vector v1, Vector v2)
            {
                if (v1.Dimension != v2.Dimension)
                    return false;
                for (int i = 0; i < v1.Dimension; i++)
                {
                    if (v1[i] != v2[i])
                        return false;
                }
                return true;
            }

            public static bool operator !=(Vector v1, Vector v2)
            {
                if (v1.Dimension != v2.Dimension)
                    return true;
                for (int i = 0; i < v1.Dimension; i++)
                {
                    if (v1[i] != v2[i])
                        return true;
                }
                return false;
            }

            //Betrag eines Vektors
            //Im dreidimensionalen euklidischen Raum kann der Betrag des Vektors, auch als Länge
            //bezeichnet, nach dem Satz des Pythagoras berechnet werden
            public double Betrag()
            {
                double sum = 0;
                for (int i = 0; i<werte.Length; i++)
                {
                    sum += Math.Pow(werte[i], 2);
                }
                return Math.Sqrt(sum);
            }

            //Addition zweier Vektoren der gleichen Größe(Operator)
            //liefert als Ergebnis einen Vektor, dessen Komponenten die Summe der entsprechenden
            //Komponenten der Summanden ist.
            public static Vector operator +(Vector v1, Vector v2)
            {
                if (v1.Dimension != v2.Dimension)
                    return null;
                Vector v3 = new Vector(v1.Dimension);
                for(int i = 0; i<v1.Dimension; i++)
                {
                    v3[i] = v1[i] + v2[i];
                }
                return v3;
            }

            //Skalares Produkt zweier Vektoren der gleichen Größe(Operator)
            //liefert als Ergebnis die Summe der Produkte der jeweiligen Komponenten der beiden
            //Vektoren zurück.
            public static double operator *(Vector v1, Vector v2)
            {
                if (v1.Dimension != v2.Dimension)
                    return 0;
                double sum = 0;
                for(int i = 0; i<v1.Dimension; i++)
                {
                    sum += v1[i] * v2[i];
                }
                return sum;
            } 

            public void Print()
            {
                for(int i = 0; i<werte.Length; i++)
                {
                    Console.Write(werte[i] + " ");
                }
                Console.WriteLine();
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
            Vector v2 = new Vector(3);
            v2[0] = 3;
            v2[1] = 4;
            v2[2] = 5;
            v2.Print();
            Console.WriteLine(v2.Betrag());
            Console.WriteLine(v==v2);
            Console.WriteLine(v != v2);
            (v + v2).Print();
            Console.WriteLine(v*v2);
        }
    }
}
