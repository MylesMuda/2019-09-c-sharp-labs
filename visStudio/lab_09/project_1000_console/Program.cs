using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace project_1000_console
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRabbits = 1000;
            Random rand = new Random();
            Stopwatch sw = new Stopwatch();
            //stopwatch

            //one read

            //Console.WriteLine($"Time taken for one read {sw.Elapsed}");
            //sw.Stop();
            //sw.Reset();
            //1000 seperate reads

            //Console.WriteLine($"Time taken for 1000 reads {sw.Elapsed}");
            //sw.Stop();

            using (var db = new RabbitDbEntities())
            {
                sw.Start();
                foreach(Rabbit rabbit in db.Rabbits.ToList())
                {
                    Console.WriteLine(rabbit.RabbitID);
                }
            }
            
            var OneTime = sw.Elapsed.ToString();
            sw.Stop();
            sw.Reset();

            for(int i = 1; i <= numberOfRabbits; i++)
            {
                sw.Start();
                using (var db = new RabbitDbEntities())
                {
                    Console.WriteLine(db.Rabbits.Find(i).RabbitID);
                }
            }

            var ThousandTimes = sw.Elapsed.ToString();
            sw.Stop();

            Console.WriteLine($"Time taken for 1 read {OneTime}");
            Console.WriteLine($"Time taken for 1000 reads {ThousandTimes}");
            
            Console.ReadLine();
            //report times to console DONE
            //report times to CSV
            File.WriteAllText("RabbitOutput.CSV", "//log of new rabbit");
            File.AppendAllText("RabbitOutput.CSV", $"\n1,Billy,12");
            File.AppendAllText("RabbitOutput.CSV", $"\n2,Fluffy,13");
            Process.Start("RabbitOutput.CSV");
            //report times to Word
            //do that in wpf
        }

        public void PopRabbitDb1000(int numberOfRabbits)
        {
            Random rand = new Random();

            for (int i = 0; i < numberOfRabbits; i++)
            {
                //sw.Start();
                using (var db = new RabbitDbEntities())
                {
                    Rabbit rb = new Rabbit();
                    rb.Age = rand.Next(21);
                    rb.Name = $"Jeff{i}";
                    db.Rabbits.Add(rb);
                    db.SaveChanges();
                }
            }
        }

        public void PopRabbitDb1(int numberOfRabbits)
        {
            Random rand = new Random();

            using (var db = new RabbitDbEntities())
            {
                for (int i = 0; i < numberOfRabbits; i++)
                {
                    Rabbit rb = new Rabbit();
                    rb.Age = rand.Next(21);
                    rb.Name = $"Jeff{i}";
                    db.Rabbits.Add(rb);
                    db.SaveChanges();
                }
            }
        }
    }
}
