using System;
using System.Reflection;

namespace lab_46_assemblies
{
    class Program
    {
        static void Main(string[] args)
        {
            //use integer type as an example
            var mytype = typeof(int);
            //lets find the DLL where INT lives in windows
            //IE Assembly
            var myAssembly = Assembly.GetAssembly(mytype);
            Console.WriteLine($"Assembly is called {myAssembly.GetName()}\n\n");
            // Check out all other types in the same assembly and print them out
            foreach(var type in myAssembly.GetTypes())
            {
                Console.WriteLine(type);
            }
        }
    }
}
