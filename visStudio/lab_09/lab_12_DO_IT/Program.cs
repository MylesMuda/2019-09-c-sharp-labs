using System;
using System.Threading;
using System.Collections.Generic;

namespace lab_12_DO_IT
{
    class Program
    {
        static void Main(string[] args)
        {
            int PopLimit = 50;
            Rabbit rabbi = new Rabbit();
            int count = 0;
            List<Rabbit> rabbit = new List<Rabbit>();
            rabbit.Add(rabbi);

            while(rabbit.Count <= PopLimit)
            {
                Console.WriteLine($"{rabbit.Count} rabbits");


                Thread.Sleep(200);
                
                count++;
            }
            
        }

        
    }

    class Rabbit
    {
        string Name { get; set; }
        int Age { get; set; }

        List<Rabbit> rabbit = new List<Rabbit>();

        public Rabbit() { }

        public Rabbit(string name, int age)
        {
            this.Name = name;
            this.Age = 0;
        }

        public void Timer() { Thread.Sleep(200); }

    }
}   

