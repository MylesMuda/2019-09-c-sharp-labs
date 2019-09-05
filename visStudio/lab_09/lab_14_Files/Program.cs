using System;
using System.IO;

namespace lab_14_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("myFile.txt"))
            {
                var string1 = File.ReadAllText("myFile.txt");
                Console.WriteLine(string1);
            }

            File.WriteAllText("output.txt", "llammo jegg");

            Console.WriteLine("\nSave multiple lines\n\n");

            File.WriteAllText("multiple lines.txt", "some\ndata\non\nmultiple\nlines\n");

            File.WriteAllText("multiplelines.txt", "some" + Environment.NewLine + "new" + Environment.NewLine + "lines");
            Console.WriteLine(File.ReadAllText("multiplelines.txt"));

            string[] myArray = new string[] { "some", "data", "in", "many", "lines"};
            File.WriteAllLines("multiLines2.txt", myArray);
            var outputArray = File.ReadAllLines("multiple lines.txt");
            //print array using fancy Lambda syntax
            Array.ForEach(outputArray, item => Console.WriteLine(item));

            Console.WriteLine("\n=== Logging ===\n");

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("myLogFile.log", $"Event occured at time: {DateTime.Now}");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine(File.ReadAllText("myLogFile.log"));
        }
            
    }
}
