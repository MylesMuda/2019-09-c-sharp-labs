using System;
using System.Collections.Generic;

namespace lab_38_reference_value_types
{
    class Program
    {
        static void Main(string[] args)
        {
            //PRIMITIVE TYPE: int, bool, char, struct
            // STORED IN FAST STACK MEM
            // values stored with declaration in live, fast code
            // destroyed immediately as well
            // == VALUE TYPES as VALUE stored in STACK MEMORY with declaration
            // var x = 10; x and 10 stored in stack.
            //COPY of a value type is INDEPENDENT
            long x = 10;
            long y = x;
            x = 1000;
            y = 3333;
            Console.WriteLine($"X is {x} and Y is {y}");

            //PASS X and Y into a method
            DoThis(x, y);

            //pass x,y by REFERENCE into DoThisPermanent
            DoThisPermanent(ref x, ref y);
            Console.WriteLine($"X is {x} and Y is {y}");



            // REFERENCE TYPES
            // Value types are primitive value types, held on the FAST STACK
            // Reference types are large objects
            // Shortcut = Pointer held on fast stack
            // actual object stored on the HEAP
            // int x = 10;
            // list<string> myList--------------> {"one", "two"}

            // COPY A REF TYPE : BY DEFAULT YOU ONLY COPY THE POINTER
            int[] myArray = new int[3] { 100, 200, 300 };
            var myArray2 = myArray;
            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));
            myArray[2] = 5000;
            myArray2[1] = 14000;
            Console.WriteLine(string.Join(",", myArray));
            Console.WriteLine(string.Join(",", myArray2));
            //var myArray3 = string.Concat("one", "two", "three");


            //REFERENCE TYPES ARE ACTUALLY TREATED AS GLOBAL WHRN PASSED INTO A METHOD
            var myList = new List<string>() { "first", "second" };
            DoThisMyList(myList);
            Console.WriteLine(string.Join(",",myList));
        }

        //method to change x and y
        static void DoThis(long x , long y)
        {
            x = x * x;
            y = y * y * y;
            Console.WriteLine($"X is {x} and Y is {y}");
        }

        static void DoThisPermanent(ref long x , ref long y)
        {
            x = x * x;
            y = y * y * y;
            Console.WriteLine($"X is {x} and Y is {y}");
        }

        static void DoThisMyList(List<string> list)
        {
            list.Add("JEFF");
            list.Add("JEFF");
        }
    }
}
