// Anmerkung: Diese Datei wird später bei der Bewertung komplett ignoriert!
using System;
using System.IO;

//namespace Aufgabe1
//{
//    class Program
//    {
//        static void Main()
//        {
//            // Wenn Sie möchten, können Sie hier Ihren eigenen Testcode zur Überprüfung Ihrer Implementierungen einfügen (-> Ihre "Spielwiese")...
//            IntegerWrapper myIntegerWrapper = new IntegerWrapper();

//            myIntegerWrapper.Value = 23;

//            int myInteger = myIntegerWrapper.Double();
//            Console.WriteLine(myInteger);

//            IntegerWrapper myIntegerWrapper2 = new IntegerWrapper();

//            myIntegerWrapper2.Value = 2;

//            string myString = myIntegerWrapper2.WithPrefix("Programmieren");
//            Console.WriteLine(myString);
//        }
//    }
//}
namespace Aufgabe2
{
    class Program
    {
        static void Main()
        {
            // Wenn Sie möchten, können Sie hier Ihren eigenen Testcode zur Überprüfung Ihrer Implementierungen einfügen (-> Ihre "Spielwiese")...
           foreach (int n in MyClass.GetIntegerArray())
            {
                Console.WriteLine(n);
            }
            string[] text = MyOtherClass.GetWords("Viel Erfolg bei der Prüfung!");
            foreach (string t in text)
            {
                Console.WriteLine(t);
            }

            //StreamReader sr = new StreamReader(@"..\..\..\Zusatzinformationen2.pdf");
            //while (!sr.EndOfStream)
            //{

            //    string zeile = sr.ReadLine();

            //    string[] text = MyOtherClass.GetWords(zeile);
            //    foreach (string t in text)
            //    {
            //        Console.WriteLine(t);
            //    }
            //}
            //sr.Close();
        }
    }
}
