using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace lab_33_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var task1 = new Task(() => 
            {
                Console.WriteLine("Running Task01");
            }); //anonymous (lambda) delagate

            //Delagate is a PLACEHOLDER for one or more methods
            //Simplest delagate is called ACTION
            //ACTION == void DoThis() - has no parameters, void output
            var taskOld = new Task(DoThis);
            taskOld.Start();

            var task02 = Task.Run(() => 
            {
                Console.WriteLine("Running Task02");
            });
            //Console.ReadLine();

            var taskArray = new Task[10];
            var counter = 0;
            taskArray[0] = Task.Run(() => 
            {
                Console.WriteLine("Task Array 00");
            });
            taskArray[1] = Task.Run(() => 
            {
                Console.WriteLine("Task Array 01");
            });
            taskArray[2] = Task.Run(() => 
            {
                Console.WriteLine("Task Array 02");
            });

            for(int i = 2; i < 9; i++)
            {
                taskArray[counter] = Task.Run(() => { Console.WriteLine($"Task Array {counter}"); });
                System.Threading.Thread.Sleep(10);
                counter++;
            }

            //Task.WaitAll(taskArray);
            Console.ReadLine();

            //parallel ForEach
            var myList = new List<String> { "a", "b", "c" };
            Stopwatch st = new Stopwatch();
            Stopwatch t = new Stopwatch();

            st.Start();
            myList.ForEach((s) => 
            {
                Console.WriteLine($"Item is {s}");
                System.Threading.Thread.Sleep(50);
            });
            Console.WriteLine(st.Elapsed);
            st.Stop();
            //Execute in parallel
            t.Start();
            Parallel.ForEach(myList, (s) => { Console.WriteLine($"Parallel item is {s}"); });
            Console.WriteLine(t.Elapsed);
            t.Stop();
            //parallel LINQ Queries
            var output = (
                from item in myList
                select item).ToList();
            var outputAsParallel = (
                from item in myList
                select item).AsParallel().ToList();

            // Getting data back from a task
            // var t = Task.Run(()=>{});
            // var t = Task<T>.Run... returns data of type T
            // can access the data with t.Result;
            var taskWithResult = Task<int>.Run(() => {
                return 100;
            });
            taskWithResult.Wait();
            Console.WriteLine($"Result of our task is {taskWithResult.Result}");
            Console.ReadLine();
        }

        static void DoThis()
        {
            Console.WriteLine("I am doing something");
            
        }
    }
}
