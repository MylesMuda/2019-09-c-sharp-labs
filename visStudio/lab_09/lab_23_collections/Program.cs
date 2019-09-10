using System;
using System.Collections.Generic;
using System.Collections;

namespace lab_23_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //dictionary
            //pairs: 0,"hi" 1,"there"
            var dictionary = new Dictionary<int, string>();
            dictionary.Add(0, "hi");
            dictionary.Add(1, "there");
            dictionary.TryAdd(0, "hi"); //silently fail

            // Get values
            foreach(KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"{item.Key,-10}{item.Value}");
            }

            //Queue : enqueue, dequeue, peek, contains
            var qwu = new Queue();
            qwu.Enqueue(1);
            qwu.Enqueue("Jalapeno");
            foreach (object item in qwu) { Console.WriteLine(item); }
            //Stack : push, pop, 


            //List
            var leest = new List<int>();
            leest.Add(400);
            
            //ArrayList
            var arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("hola");
            foreach (object item in arrayList) { Console.WriteLine(item.ToString()); }

            //LinkedList
            var linkList = new LinkedList<int>();
            //HashSet


        }
    }
}
