using System;

namespace _12_Operatoren
{
    class Program
    {
        class CPoint
        {
            double x, y;
            public CPoint(double x, double y)
            {
                this.x = x; this.y = y;
            }

            public static CPoint operator *(CPoint p, int n)
            {
                return new CPoint(p.x*n, p.y*n);
            }

            public static CPoint operator -(CPoint p1, CPoint p2)
            {
                return new CPoint(p1.x - p2.x, p1.y - p2.y);
            }
            
            public static explicit operator double(CPoint p)
            {
                return Math.Sqrt(p.x*p.x+p.y*p.y);
            }
            
            public static bool operator ==(CPoint p1, CPoint p2)
            {
                if (p1.x != p2.x || p1.y != p2.y)
                    return false;
                return true;
            }

            public static bool operator !=(CPoint p1, CPoint p2)
            {
                if (p1.x != p2.x || p1.y != p2.y)
                    return true;
                return false;
            }

            public override string ToString()
            {
                return $"({x}, {y})";
            }
        }
        static void Main(string[] args)
        {
            CPoint p1 = new CPoint(10, 10);
            CPoint p2 = p1 * 2; // Skalarprodukt (alle Komponenten werden mit dem Faktor multipliziert)
            CPoint p3 = p2 - p1; // Differenz zweier Vektoren
            double d = (double)p3; // Vektorlänge (mittels Konvertierung nach double)
            if (p2 - p1 == p1) Console.WriteLine("Punkte sind gleich!");
            Console.WriteLine(p2 * 3 - p1);
            Console.WriteLine(d);
        }
    }
}
