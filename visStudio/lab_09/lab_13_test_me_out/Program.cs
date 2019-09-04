using System;

namespace lab_13_test_me_out
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TestMeSomething.RunThisTest(10)) ;
        }


    }

    public class TestMeSomething
    {
        public static int RunThisTest(int input)
        {
            return input * input;
        }
    }
}
