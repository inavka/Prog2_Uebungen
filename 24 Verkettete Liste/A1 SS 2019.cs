using System;
using System.Collections;

namespace _24_Verkettete_Liste
{
    class Program
    {
        //In einer verketteten Liste sollen Beiträge(„Posts“) von Personen zu einem Thema verwaltet werden.
        //Mit Hilfe des + Operators soll ein neuer Beitrag am Anfang der Liste eingefügt werden.
        //Der – Operator soll alle Beiträge einer bestimmten Person entfernen.
        //Der [] Operator („Indexer“) soll dazu dienen den letzten Beitrag einer bestimmten Person zu bekommen.
        //Verwenden Sie für die Iterator-Implementierung(siehe IEnumerable) die einfachere Version mit „yield return“.
        
        //Geforderte Ausgabe des Programms:
        //Last Post: Max ‐ Ferienbilder
        //Moritz ‐ Ferien sind cool

        class Post
        {
            public string Name { get; }
            string post;
            public Post(string name, string post)
            {
                this.Name = name;
                this.post = post;
            }
            public override string ToString()
            {
                return Name + " ‐ " + post;
            }
        }
        class Liste : IEnumerable
        {
            class Element
            {
                public Post MyPost { get; }
                public Element Next;
                public Element(Post post)
                {
                    this.MyPost = post;
                }
            }
            Element root;
            // TODO...
            public static Liste operator +(Liste l, Post post)
            {
                l.Add(post);
                return l;
            } 
            public void Add(Post post)
            { 
                Element neu = new Element(post);
                if (root == null)
                    root = neu;
                else { 
                neu.Next = root;
                root = neu;
                    }
            }

            public static Liste operator -(Liste l, string name)
            {
                Liste l2 = new Liste();
                
                for(Element item = l.root; item.Next!=null; item = item.Next)
                {
                    if (name != item.MyPost.Name)
                    {
                        l2.Add(item.MyPost);
                    }
                }
             
                return l2;
            }

            //public void Delete(string name)
            //{
            //    foreach (Element item in this)
            //    {
            //        if(name == item.MyPost.Name)
            //        {
            //            if(item==root )
            //            {
            //                root = root.Next;
            //            }
            //            else
            //            {
            //                for(Element tmp = root; tmp.Next==item || tmp.Next==null; tmp=tmp.Next)
            //                {
            //                    tmp.Next = item.Next;
            //                }
            //            }
                        
            //        }
            //    }
            //}
            public IEnumerator GetEnumerator()
            {
                for(Element item = root; item.Next != null; item = item.Next)
                {
                    yield return item.MyPost;
                }

            }
            public Post this[string Name]
            {
                get
                {
                    Post wert = null;
                    Element tmp = root;
                    while (tmp.Next != null)
                    {
                        if (tmp.MyPost.Name == Name)
                            break;
                        tmp = tmp.Next;
                    }
                    wert= tmp.MyPost;
                    return wert;
                }
            }

        }
        static void Main(string[] args)
        {
            Liste postList = new Liste();
            postList += new Post("Max", "Klausuren sind anstrengend");
            postList += new Post("Max", "Aufgaben online");
            postList += new Post("Moritz", "Ferien sind cool");
            postList += new Post("Max", "Ferienbilder");
            Post lastPost = postList["Max"];
            if (lastPost != null)
            {
                Console.WriteLine("Last Post: " + lastPost);
            }
            postList -= "Max";
            foreach (Post post in postList)
            {
                Console.WriteLine(post);
            }
        }
       
    }
}

