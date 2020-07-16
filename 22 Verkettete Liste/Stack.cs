using System;

namespace _22_Verkettete_Liste
{
    class Programm
    {
        class Node
        {
            public int value;
            public Node next;
            public Node(int i)
            {
                value = i;
            }
        }

        class Stack
        {
            Node top;
            public void Push(int i) // Insert
            {
                Node insert = new Node(i);
                if (top != null) // wenn Stack nicht leer ist
                {
                    insert.next = top;
                    top = insert;
                }
                else
                {
                    top = insert;
                }
            }

            public Node Pop() //Zurueckliefern und loeschen
            {
                if (top != null) // wenn Stack nicht leer ist
                {
                    Node temp;
                    if (top.next != null)// wenn Stack min. 2 Elemente hat
                    {
                        temp = top;
                        top = top.next;
                    }
                    else
                    {
                        temp = top; //wenn Stack nur 1 Element hat
                        top = null;
                    }
                    return temp;
                }
                return null;
            }
        }
        static void Main(string[] args)
        {
            Stack s1 = new Stack();
            s1.Push(3);
            s1.Push(4);
            s1.Push(7);
            Console.WriteLine(s1.Pop().value);
            Console.WriteLine(s1.Pop().value);
            Console.WriteLine(s1.Pop().value);

        }
    }
}
