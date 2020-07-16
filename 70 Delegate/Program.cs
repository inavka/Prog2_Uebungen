using System;

namespace _70_Delegate
{
    delegate void Operation(ref double x1, double x2);
    delegate double Operation2(double x3, double x4);
    class Program
    {
        
        //public event Operation Operat; 

        public static bool MeFunkt (double x, Operation2 op)
        {

            if (x >= op(x, x / 2))
            {
                return true;
            }
            return false;

        }
        public static void Add(ref double y1, double y2)
        {
            y1 = y1 + y2;
            Console.WriteLine("Add " + y1);
        }

        public static void Sub(ref double y1, double y2)
        {
            y1 = y1 - y2;
            Console.WriteLine("Sub " + y1);
        }
        public static double Sub2( double y1, double y2)
        {
            return y1 - y2;
           
        }

        public static void Mult(ref double y1, double y2)
        {
            y1 = y1 * y2;
            Console.WriteLine("Mult " + y1);
        }

        public static void Div(ref double y1, double y2)
        {
            if (y2 == 0)
            {
                Console.WriteLine("Falsch");
            }
            y1 = y1 / y2;
            Console.WriteLine("Div " + y1);
        }
        static void Main(string[] args)
        {
            Operation op2 = Mult;
            Operation op = Add;
            op += op2;
            op += Sub;
            op += Mult;
            op += Div;
            double a = 5;
            op(ref a, 3);
            Console.WriteLine("__________________________");
            op -= Mult;
            op -= Mult;
            op(ref a, 3);
            Console.WriteLine(MeFunkt(15, Sub2));
            Operation2 op33=null;
            op33?.Invoke(3, 4);
            op33 = Sub2;
            Console.WriteLine(op33?.Invoke(3, 4));
            Operation2 op4 = delegate (double x, double y)
            { 
                return x* y+x; 
            };
            Console.WriteLine(op4?.Invoke(4,7));
        }
    }
}
