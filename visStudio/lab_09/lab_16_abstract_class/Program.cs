using System;

namespace lab_16_abstract_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = new Holiday();
        }

        abstract public class Holiday
        {
            public abstract void Travel();

            public void Places() { Console.WriteLine("Visit Vienna, Salzburg"); }

            public void Activites() { Console.WriteLine("Skiing, Walking, Fishing"); }
        }

        public class HolidayWithTravel : Holiday
        {
            public void Travel() { Console.WriteLine("By train, eurostar, hire a car"); }
        }
    }
}
