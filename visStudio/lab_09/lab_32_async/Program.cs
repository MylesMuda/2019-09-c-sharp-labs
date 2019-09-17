using System;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace lab_32_async
{
    class Program
    {
        static List<string> lines = new List<string>();
        static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        { 
            //for (int i = 0; i < 100000; i++)
            //{
            //    File.AppendAllText("data.txt", $"\n Adding line {i} at {DateTime.Now}");
            //}

            //DoThisLongThing();


            s.Start();
            DoThisLongThingAsync();

            Console.WriteLine($"main thread completed after {s.ElapsedMilliseconds} milliseconds\n");
            //Console.WriteLine(s.Elapsed);
            Console.ReadLine();
        }

        static void DoThisLongThing()
        {
            Thread.Sleep(3000);
        }

        async static void DoThisLongThingAsync()
        {
            //Thread.Sleep(3000);
            //STREAM INLINES USING STREAM READER (NORMAL IF WE DON'T KNOW THE LENGTH OF THE DATA THAT WE'RE PULLING IN)
            using(var reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null)
                    {
                        break;
                    }
                    lines.Add(line);
                }
            };
            s.Stop();
            Console.WriteLine($"Finished reading {lines.Count} lines which took {s.ElapsedMilliseconds} milliseconds");
        }
    }
}
