using System;

namespace lab_39_overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short s = 12345;
            int i = 1234567890;
            long l = 1234567890123456789;
            float f = 123456789012345000000000000000.01234567890123456789f;
            double d = 100000000000000000000000000000000000000000000000000000000000000.0d;
            decimal dd = 100000000000000000;

            unchecked
            {
                Console.WriteLine(int.MaxValue);
                int bigInt = int.MaxValue;
                bigInt+=1;
                Console.WriteLine(bigInt);
                bigInt+=1;
                Console.WriteLine(bigInt);
                bigInt+=1;
                Console.WriteLine(bigInt);
                bigInt+=1;
                Console.WriteLine(bigInt);
            }

            DoThis();

            //int maxnums MAX = 4, 0,1,2,3  

            Console.WriteLine(double.MaxValue);
            Console.WriteLine();
        }

        static int counter = 0;
        static void DoThis()
        {
            counter++;
            Console.WriteLine($"L number {counter}");
            DoThis();
        }

    }
}
