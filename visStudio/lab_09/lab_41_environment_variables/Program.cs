using System;
using System.Collections;
using System.Collections.Generic;

namespace lab_41_environment_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{item.Key} === {item.Value}");
            }

            Console.WriteLine(Environment.GetEnvironmentVariable("WinDir"));

            Environment.SetEnvironmentVariable("SecretPassword", "munnkey");
            Console.WriteLine(Environment.GetEnvironmentVariable("SecretPassword"));
        }
    }
}
