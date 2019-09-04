using System;

namespace lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            object o = 10;

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = "A String";

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            o = new int[1, 2, 3];

            Console.WriteLine(o);
            Console.WriteLine(o.GetType());

            dynamic obj2 = 10;
            obj2 = "a String";
            obj2 = new int[1, 2, 3];
        }
    }
}
