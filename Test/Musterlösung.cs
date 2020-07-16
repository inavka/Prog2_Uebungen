using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.ExceptionServices;

namespace Praktikumsaufgabe2Liste
{
    class WordCount
    {
        class LItem
        {
            public string text;
            public int count;
            public LItem next;
            public LItem(string text, int count = 1)
            {
                this.text = text;
                this.count = count;
                next = null;
            }
            public override string ToString() => $"{text}  --  {count}";
        }

        LItem first = null, last = null;
        public WordCount()
        { }
        public WordCount(params string[] textlist)
        {
            SortedUpdate(textlist);
        }
        private void AddLast(string text, int count = 1)
        {
            LItem neu = new LItem(text, count);
            if (last == null)
                first = last = neu;
            else
                last = last.next = neu;
        }
        private void AddFirst(string text, int count = 1)
        {
            LItem neu = new LItem(text, count);
            if (last == null)
                first = last = neu;
            else
            {
                neu.next = first;
                first = neu;
            }
        }
        public void SortedUpdate(params string[] text)
        {
            foreach (var item in text)
            {
                SortedUpdate(item);
            }
        }
        public void SortedUpdate(string text)
        {
            if (first == null || text.CompareTo(last.text) > 0)
                AddLast(text);
            else
            {
                int cmp = text.CompareTo(first.text);
                if (cmp < 0)
                    AddFirst(text);
                else
                {
                    if (cmp == 0)
                        first.count++;
                    else
                    {
                        LItem neu = new LItem(text);
                        LItem tmp = first;

                        while ((cmp = tmp.next.text.CompareTo(text)) < 0)
                            tmp = tmp.next;

                        if (cmp == 0)
                            tmp.next.count++;
                        else
                        {
                            neu.next = tmp.next;
                            tmp.next = neu;
                        }
                    }
                }
            }
        }
        public void Print(int min = 1)
        {
            for (LItem item = first; item != null; item = item.next)
            {
                if (item.count >= min)
                    Console.WriteLine(item);
            }
        }
        public void Reverse()
        {
            LItem newStart = null;
            LItem item = first;
            while (item != null)
            {
                LItem next = item.next;
                item.next = newStart;
                newStart = item;
                item = next;
            }
            last = first;
            first = newStart;
        }
        public WordCount Filter(string pattern)
        {
            WordCount wcNew = new WordCount();
            for (LItem item = first; item != null; item = item.next)
            {
                if (item.text.Contains(pattern))
                    wcNew.AddLast(item.text, item.count);
            }
            return wcNew;
        }
        public void Delete(string text)
        {
            if (first == null)
                return;
            if (first.text.CompareTo(text) == 0)
            {
                first = first.next;
                // Falls Liste jetzt leer ist
                if (first == null)
                    last = null;
            }
            else
            {
                LItem tmp = first;
                while (tmp.next != null && tmp.next.text.CompareTo(text) != 0)
                    tmp = tmp.next;
                if (tmp.next != null)
                {
                    tmp.next = tmp.next.next;
                    if (tmp.next == null)
                        last = tmp;
                }
            }
        }
        public int this[string text]
        {
            get
            {
                for (LItem item = first; item != null; item = item.next)
                {
                    if (item.text == text)
                        return item.count;
                }
                return -1;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] text =
            {
            "Zu Dionys, dem Tyrannen, schlich ",
            "Damon, den Dolch im Gewande: ",
            "Ihn schlugen die Häscher in Bande, ",
            "'Was wolltest du mit dem Dolche? sprich!'",
            "Entgegnet ihm finster der Wüterich.",
            "'Die Stadt vom Tyrannen befreien!'",
            "'Das sollst du am Kreuze bereuen.'",

            "Ich bin, spricht jener, zu sterben bereit ",
            "Und bitte nicht um mein Leben: ",
            "Doch willst du Gnade mir geben,",
            "Ich flehe dich um drei Tage Zeit,",
            "Bis ich die Schwester dem Gatten gefreit; ",
            "Ich lasse den Freund dir als Bürgen, ",
            "Ihn magst du, entrinn' ich, erwürgen.'",

            "Da lächelt der König mit arger List",
            "Und spricht nach kurzem Bedenken: ",
            "'Drei Tage will ich dir schenken; ",
            "Doch wisse, wenn sie verstrichen, die Frist, ",
            "Eh' du zurück mir gegeben bist, ",
            "So muß er statt deiner erblassen,",
            "Doch dir ist die Strafe erlassen.'"
        };

            WordCount count1 = new WordCount("Alf", "Bart", "Charlie", "Dora", "Emil", "Bart", "Charlie", "Dora", "Emil", "Charlie", "Dora", "Emil", "Dora", "Emil", "Emil");
            WordCount count2 = new WordCount();
            char[] seperatoren = { '\'', ',', '.', '?', '!', ' ', ';' };
            foreach (var zeile in text)
            {
                count2.SortedUpdate(zeile.Split(seperatoren, StringSplitOptions.RemoveEmptyEntries));
            }
            count1.Print();
            Console.WriteLine("---------");
            count1.Reverse();
            count1.Delete("Alf");
            count1.Delete("Emil");
            count1.Delete("Charlie");
            count1.Print();
            Console.WriteLine(count1["Dora"]);
            Console.WriteLine("---------");
            count2.Print(3);
            Console.WriteLine("---------");
            WordCount count3 = count2.Filter("ich");
            count3.Print();
        }
    }
}
