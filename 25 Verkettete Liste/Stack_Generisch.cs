using System;
using System.Collections.Generic; 

namespace _25_Verkettete_Liste
{
    class Program
    {
        

        class Stack<T>
        {
            public class Node
            {
                public T value { get; private set; }
                public Node next;
                public Node(T i)
                {
                    value = i;
                }
                public override string ToString() { return $"{value}"; }
            }
            Node top;
            public void Push(T i) // Insert
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
               else
                    throw new ArgumentNullException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                for (Node item = top; item != null; item = item.next)
                {
                    yield return item.value; 
                }
            }

            public void Revert()
            {
                if (top == null)
                    return;
                    Node end = top;
                while (end.next != null)
                {
                    end = end.next;

                }
                if (top == end) //1.Fall: die Liste ist Leer
                    return;

                //2. Fall: Liste hat mehr als 1 Element
                Node current = top;
                Node neuAnfang = null;
                while (current != null)
                {
                    Node tmpNext = current.next;
                    current.next = neuAnfang;
                    neuAnfang = current;
                    current = tmpNext;
                }
                end = top; //Neues Ende ist der alte Anfang
                top = neuAnfang;
            }
        }
        static void Main(string[] args)
        {
            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            stack1.Push(5);
            foreach(var item in stack1)
                Console.WriteLine(item);
            Console.WriteLine("____________________");
            stack1.Pop();
            foreach (var item in stack1)
                Console.WriteLine(item);
            Console.WriteLine("____________________");
            stack1.Revert();
            foreach (var item in stack1)
                Console.WriteLine(item);
            Console.WriteLine("____________________");
        }
    }
}
