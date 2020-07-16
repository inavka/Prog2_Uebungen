using System;

namespace Test
{
    class Program
    {
        class Test
        {
            int[] birthYearDigits;
            public Test Execute()
            {
                Console.Write("A");
                try
                {
                    Initialize();
                    Console.Write(birthYearDigits[4]);
                    Console.Write("B");
                }
                catch (DivideByZeroException) { Console.Write(birthYearDigits[2]); }
                catch (IndexOutOfRangeException) { Console.Write("C"); }
                catch (Exception) { Console.Write("D"); }
                Console.Write(birthYearDigits[3]);
                birthYearDigits = null;
                return this;
            }
            void Initialize()
            {
                try
                {
                    if (birthYearDigits != null) birthYearDigits = null;
                    Console.Write("E");
                    birthYearDigits = new int[4] { 1, 9, 9, 4 }; // Hier die 4 Ziffern!
                    Console.Write(birthYearDigits[0] / (birthYearDigits[3] - birthYearDigits[3]));
                }
                catch (NullReferenceException) { Console.Write("F"); }
                catch (IndexOutOfRangeException e) { Console.Write(birthYearDigits[4] / 0); throw e; }
                finally { Console.Write(birthYearDigits[1]); }
                Console.Write("G");
            }
            public void Finish() { Console.Write("H"); }
        }
        static void Main()
        {
            try
            {
                new Test().Execute().Finish();
            }
            catch (Exception) { Console.Write("I"); }
        }
    }
}
