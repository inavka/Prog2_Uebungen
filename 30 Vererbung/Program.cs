using System;

namespace _30_Vererbung
{
    interface IBewertung
    {
        string Daten { get; set; }
    }

    abstract class Spiel
    {
      public abstract void Play();
    }
    class Fussballspiel : Spiel
    {
        int nummer;
        public Fussballspiel(int Nummer)
        {
            nummer = Nummer;
        }
        public override void Play()
        {
            Console.WriteLine("Rennen");
        }
    }

    class FussballUebertargung : Fussballspiel
    {
        public FussballUebertargung(int Nummer) : base (Nummer) { }
        public new void Play()
        {
            Console.WriteLine("schauen");
        }
    }

    class Brettspiel : Spiel, IBewertung
    {
        string name;
        public Brettspiel(string Name)
        {
            name = Name;
        }
        virtual public string Daten
        {
            get; set;
        }

        public override void Play()
        {
            Console.WriteLine("spielen");
        }
    }
    class Schach : Brettspiel
    {
        public Schach() : base("Schach") { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
