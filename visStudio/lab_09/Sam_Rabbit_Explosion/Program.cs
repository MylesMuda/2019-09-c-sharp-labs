using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Sam_Rabbit_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            var results = JustDoItRabbitExplosion.RabbitExponentialGrowth(1000).ToTuple();
            Console.WriteLine($"Took {results.Item1} years to exceed the population limit. Finished with {results.Item2} rabbits");
        }
    }

    public class JustDoItRabbitExplosion
    {
        public static (int years, int popCount) RabbitExponentialGrowth(int populationLimit)
        {
            var s = new Stopwatch();
            s.Start();
            var rabbits = new List<Rabbit>();

            var popLimit = 1000;
            var years = 0;
            var adultAge = 3;

            var fileName = $"output-{DateTime.Now.ToLongDateString()}.log";
            File.WriteAllText(fileName, "Rabbit Log");

            Console.WriteLine($"Current population is {rabbits.Count}.");

            while (rabbits.Count < popLimit)
            {
                if (rabbits.Count < 1)
                {
                    var initialRabbit = new Rabbit(0);
                    rabbits.Add(initialRabbit);
                    File.AppendAllText(fileName, $"Rabbit born at {DateTime.Now}");
                }

                var currentPop = rabbits.Count;

                for (var i = 0; i < (currentPop); i++)
                {
                    rabbits[i].Age++;
                    if (rabbits[i].Age >= adultAge)
                    {
                        var newRabbit = new Rabbit(0);
                        rabbits.Add(newRabbit);
                        File.AppendAllText(fileName, $"Rabbit born at {DateTime.Now}");
                    }
                }
                years++;

                Console.WriteLine($"Current population is {rabbits.Count}.");
            }
            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds + " milliseconds elapsed");
            File.AppendAllText(fileName, $"Took {years} years to exceed the population limit. Finished with {rabbits.Count} rabbits.");


            return (years, rabbits.Count);
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Rabbit(int age)
        {
            Age = age;
        }
    }
}
