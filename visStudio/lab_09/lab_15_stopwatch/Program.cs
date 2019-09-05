using System;
using System.Diagnostics;
namespace lab_15_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();

            var counter = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                counter++;
            }

            var b = 0b_1010_1010_1010;
            var c = 0x_ff_ee_dd_cc_bb;

            s.Stop();
            Console.WriteLine(s.Elapsed);
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine(s.ElapsedTicks);

        }
    }
}
