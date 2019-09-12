using System;

namespace lab_27_data_types
{
    class Program
    {
        static void Main(string[] args)
        {
            byte b = 0;
            byte max = 255;
            byte b_binary = 0b_00000000;
            byte b_binary_max = 0b_11111111;

            byte b_min_hex = 0x_00;
            byte b_max_hex = 0x_ff;

            //byte b_negative = -1; //doesn't like that

            //letters are stores in char
            char letterA = 'a';
            Console.WriteLine(letterA);
            Console.WriteLine((int)letterA);

            // a string is an array of chars

            string s = "hello";

            Console.WriteLine($"First letter has index 0 {s[0]}");

            var numberOfAnyType = 27;

            int is32Bits = 32;

            //a+b=c 	Expression
            //a, b 		operands
            //+			operator

            //Unary (one input)
            //increment
            int x = 10;
            x++;
            ++x;
            //Both of the above add one
            //in general use ++, on a seperate line if possible

            //# NOT
            Console.WriteLine(!true); //false
            Console.WriteLine(!!true); //true

            //Binary (two inputs)
            //modulus
            //integer division : take care because int/int = int
            Console.WriteLine(9/4); //Result is 2

            //Proper division : one of the two values needs to be non-int

            //Ternary operator
            //if(condition) ? return this if true : return this if false

            Console.WriteLine((10>4)? "high" : "low" );

            //# Nullable
            int number = 100;
            int? number2 = 1000;

            //number2 is useful if we read from a database and it's possible that the box is blank. This would return NULL.

            number2 = null;

            Console.WriteLine("Somevalue"??"returnthisifnull");
            Console.WriteLine(null??"returnthisifnull");

            //defualt value

            int somenumber = default; //assigns it to 0;
            int? somenumber2 = default;

            Console.WriteLine($"{somenumber} {somenumber2}");
            Console.WriteLine((somenumber2 == null) ? "yeah" : "nah");

            Console.WriteLine(0b_1010>>1); //5 shift right
            Console.WriteLine(0b_1010<<1); //20 shift left


        }
    }
}
