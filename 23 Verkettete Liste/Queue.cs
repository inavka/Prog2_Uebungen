using System;

namespace _23_Verkettete_Liste
{
    class Program
    {
        class Queue
        {
            class Node
            {
                public int data;
                public Node next;
                public Node(int i)
                {
                    data = i;
                }
            }
            Node header;
            public void Enqueue(int i) // Daten hinzufuegen
            {
                if (IsEmpty())
                {
                    header = new Node(i);
                }
                else
                {
                    Node temp = header;
                    while(temp.next !=null)
                    {
                        temp = temp.next;
                    }
                    temp.next = new Node(i);
                }
            }
            public int Dequeue()
            {
                if (IsEmpty())
                {
                    Console.WriteLine("Queue ist leer");
                    return 0;
                }
                else
                {
                    int i = header.data;
                    if (header.next == null)
                    {
                        header = null;
                    }
                    else
                    {
                        header = header.next;
                    }
                    return i;
                }

            }
            private bool IsEmpty() //Hilfsmethode
            {
                if (header == null)
                    return true;
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
