using System;

namespace lab_17_security
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "Hello World";
            if (x.StartsWith("hello"))
            {
                Console.WriteLine("world");
            }

            Console.WriteLine(x.AmazingExtraStringMethod());
        }
    }

    public static class AddingToString
    {
        public static string AmazingExtraStringMethod(this string s)
        {
            Console.WriteLine("changing string");
            s = s + "--->add your comment ";
            return s; 
        }
    }
}
