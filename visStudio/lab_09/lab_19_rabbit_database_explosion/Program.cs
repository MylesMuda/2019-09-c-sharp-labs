using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_19_rabbit_database_explosion
{
    class Program
    {
        static List<Rabbit> rabbits;
        static void Main(string[] args)
        {

            using (var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
            }

            //////////////////HERE
            PrintRabbits();

            //foreach(var rabbit in rabbits)
            //{
            //    Console.WriteLine($"{rabbit.RabbitId,-5}" + $"{rabbit.Name,-12}{rabbit.Age}");
            //}

            //Console.ReadLine();

            //new rabbit : WPF TextBox01.text ==> use for age, name (2 boxes) 
            //buttonAdd : run this code

            var newRabbit = new Rabbit()
            {
                Age = 0,
                Name = $"Jeff{rabbits.Count+2}"
            };

            using (var db = new RabbitDbEntities())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }

            //rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" + $"{rabbit.Name,-12}{rabbit.Age}"));
            System.Threading.Thread.Sleep(200);
            using ( var db = new RabbitDbEntities())
            {
                rabbits = db.Rabbits.ToList();
                //rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" + $"{rabbit.Name,-12}{rabbit.Age}"));
                PrintRabbits();
            }
            Console.ReadLine();   
        }
        static void PrintRabbits()
        {
            rabbits.ForEach(rabbit => Console.WriteLine($"{rabbit.RabbitId,-5}" + $"{rabbit.Name,-12}{rabbit.Age}"));
        }
    }
}
