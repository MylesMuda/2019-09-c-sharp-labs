# 2019-09-c-sharp-labs

Labs built and run while learning C#

# Intro To C# and .NET

## History of coding

Operating System ==> makes a bit of hardware (motherboard, processor, RAM, network card) 'work'.

	Common operating systems we know have been written originally in 'C'

		UNIX (original) 				PAID, CLOSED-SOURCE
		APPLE IOS and OSX 				UNIX DERIVATIVE, CLOSED SOURCE
		WINDOWS 						CLOSED 
		LINUX (UNIX-like) 				OPEN SOURCE

			OPEN SOURCE WINS!!!

				WINDOWS ==> .NET is now OPEN SOURCE !!!

				LINUX ==> World's top 500 supercomputers

						TFLOP TERA (10^12) FLOATING POINT OPERATIONS/SEC
							1,000,000,000,000

	Programming Language

		'C'

		then

		C++  ==> in use today.

			'raw' coding ==> C++

	However!!!

		Java
			run in 'JVM' Virtual Machine (install Java)
		C#
			Microsoft ==> main 'push' using this language
				F# Functional Programming Language
		Python
			Engineering
			Data Science

Cloud
	
	Traditional computing ran on local hardware

	Today - everything has changed

		Traditional : local
		Newer       : services to cloud

				1) AWS Amazon 			No 1 provider  70%???
				2) Azure                25% market      *** Microsoft : MOST REVENUE IN THIS SPACE ***
				3) Google Cloud         5% ???

	Container : Mini Virtual Machine : run individual 'apps' 
	
		Group of containers : manage with 'Kubernetes' from Google (now open source)

	Function as a service ==> individual methods : call in cloud !!!!	



Structure Of An Application

	.NET  old, huge, cumulative libraries for ALL WINDOWS !!!

	.NET Core   new, streamlined version : valid LINUX, MAC


	.sln  XML file with all NAMES OF ALL OF THE PROJECTS INSIDE

		'CONTAINER' which has no function of itself ==> just to hold multiple projects

	.csproj

		METADATA for individual project

	Program.cs

		class Program{

			public static void Main(){

					// CODE RUN HERE
			}
		}


.NET structure

	In order to build a program with C# / .NET we need the following

	CLI Common Language Infrastructure : RULES FOR THE LANGUAGE 

	CLR                 Runtime         : Run inside this environment

		Garbage Collector               : Reclaim memory when we are finished with an object

	CSC C Sharp Compiler 			    : Turn .cs text into .exe BINARY RUNTIME EXECUTABLE FILE 

	CIL Common Intermediate Language    : Half-compiled code  'assembly language' 


			CS  ==>  CIL (half-way-house)   ==> CLR runtime
			raw 
			code

					Tool 'ILDASM'  ==> inspect .exe and view this 'CIL' compiled code




# OOP Object Oriented Programming

Traditional computing has been LINEAR PROGRAMMING where code starts at line 1 and runs to the end.

	OK but when GUI was invented, screen objects appeared

		Button ==> Click (event)  ==> Method (function)   (event 'handler')

		OBJECT          EVENT                METHOD (CODE)


	Object looks like

	{
		id:1,                               field:value  (key/value pairs)
		name:"bob",
		dob:"10/10/2001"		
		likes:["strawberries","pizza"]
	}

	Array [1,2,3]

	String "some text"

	Number  

		Whole number   integer 
		Decimal        float 32 bits long / double 64 bits long / decimal type 128 bits

	Char 
		'f'


# Creating Basic Objects

Class = Template = Blueprint for creating object

```cs

using System;

namespace lab_02_class
{
    class Program
    {
        static void Main(string[] args)
        {
            // use the class : create new Dog object
            var dog01 = new Dog();  // create new empty blank Dog object
            dog01.Name = "Fido";
            dog01.Age = 1;
            dog01.Height = 400;
        }
    }


    // INSTRUCTIONS (BLUEPRINT) FOR CREATING NEW DOG OBJECT
    class Dog
    {
        public string Name;
        public int Age;
        public int Height;
    }


}

```


# Method

Method = Function

	Call a Method to get something done

		Let's GROW OUR DOG

			Grow(){
				Age = Age+1;
				Height = Height + 10;
			}


```cs

using System;

namespace lab_02_class
{
    class Program
    {
        static void Main()
        {
            // use the class : create new Dog object ==> call this an INSTANCE (of a class)
            var dog01 = new Dog();  // create new empty blank Dog object
            dog01.Name = "Fido";
            dog01.Age = 1;
            dog01.Height = 400;
            // GROW OUR DOG
            dog01.Grow();
            // PRINT NEW AGE AND HEIGHT
            Console.WriteLine("Age is " + dog01.Age + " and height is " + dog01.Height);
            dog01.Grow();
            // $ literal syntax : just print what's inside
            // EXCEPT {} CURLY BRACES : PUT VARIABLES IN THEM
            Console.WriteLine($"Age is {dog01.Age} and height is {dog01.Height}");

        }
    }


    // INSTRUCTIONS (BLUEPRINT) FOR CREATING NEW DOG OBJECT
    class Dog
    {
        public string Name;
        public int Age;
        public int Height;

        public void Grow()          // have the method but return nothing
        {
            // LET COMPUTER KNOW : IS IT RETURNING ANY VALUE???
            // NO ==> VOID
            // YES ==> SPECIFY TYPE EG INT, STRING
            this.Age++;
            this.Height += 10;
        }
    }


}

```


# Private and Public fields

class Person{
	private string NINO;
	public string Name;
}

```cs
using System;

namespace lab_03_private_public_fields
{
    class Program
    {
        static void Main(string[] args)
        {
            var person01 = new Person();
            person01.Name = "Fantasia";
            // person01.NINO = "ABC123";
            person01.SetNINO("ABC123");
            // print NINO
            string output = person01.GetNINO();
            Console.WriteLine(output);
        }
    }

    class Person
    {
        private string NINO;
        public string Name;

        // Getter / Setter Methods to read/write private data
        public string GetNINO() {
            return this.NINO;
        }

        // PARAMETER IS DATA PASSED INTO METHOD
        public void SetNINO(string nino) {
            this.NINO = nino;
        }

    }
}

```



# Fields and Properties

In a class we can have

	fields - tend to be private     private string NINO;

		   - convention camelCase   private string privateData;

		   - convention _camelCase  private string _privateData;

	properties - tend to be PUBLIC  public string Name {get;set;}

			   - convention PascalCase  public string ThisIsAPublicProperty

			   - {get;set;}  // abbreviations for GET/SET methods which we
			   					already coded


```using System;

namespace lab_04_properties
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabbit = new Rabbit();
            rabbit.Name = "Cute01";
            // rabbit._bloodType.. INVALID
            rabbit.Age = -10;
            Console.WriteLine(rabbit.Age);

            int x = default; // 0
        }
    }

    class Rabbit
    {
        private int _bloodType;            // FIELD
        private int _age;
        public string Name { get; set; }   // AUTO-IMPLEMENTED PROPERTY

        public int Age { 
            get {
                return this._age;
            } 
            set {
                if (value > 0)
                {
                    this._age = value; // value is c# code word
                }
            } 
        }
    }
}



```



# Creating Multiple Objects

Array written [1,2,3] has FIXED SIZE

List written  List<int>() has VARIABLE SIZE and we can use this to ADD items
		to a list


	// create a lab

	// count 1 to 10

	// create Rabbits

	// name = "Rabbit" + 0 + i    Rabbit01, Rabbit02,  
	// age = i
	// add to list of rabbits
	// print out list at end 


```cs
using System;
using System.Collections.Generic; // list

namespace lab_05_rabbits
{
    class Program
    {
        static List<Rabbit> rabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            for(int i = 1; i<=20; i++)
            {
                var r = new Rabbit();
                r.Age = i;
                if (i < 10)
                {
                    r.Name = $"Rabbit0{i}";
                }
                else
                {
                    r.Name = $"Rabbit{i}";
                }
                //r.Name = String.Format("Rabbit{0:G2}", i);
                rabbits.Add(r);
            }
            foreach(var rabbit in rabbits)
            {
                Console.WriteLine($"Name is {rabbit.Name} and age is {rabbit.Age}");
            }
        }
    }

    class Rabbit
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}

```


# Inheritance

Natural world we think Species eg Mammal class ==> Cats ==> Lions ==> African Lion


```cs
using System;

namespace lab_06_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Dog();
            d.Name = "Fido";
            var labrador01 = new Labrador();
            labrador01.Name = "MansBestFriend";
            labrador01.Age = 2; // child only
        }
    }

    class Dog {
        public string Name { get; set; }
    }

    class Labrador : Dog { 
        public int Age { get; set; }
    }
}



```


# Methods In More Detail

	convention   name is PascalCase       void DoThis(){}
	parameters   passed IN                void DoThis(int x, string y){}
	return       passed OUT               string DoThis(){ return "hi"; }
	optional     passed IN                void DoThis(int x = 1000){}
	                          pass in x but if missing set value to 1000

	out parameters pass OUT               void DoThis(int x, int y, out int z)

	Tuple is a fancy new variable from C#

		(int x, string y, bool z)  IS NOW A CUSTOM DATA TYPE!!!  


```cs
using System;

namespace lab_07_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            DoThis();
            DoThisAswell();
            var m = new Mammal();       // m is an INSTANCE (REAL EXAMPLE) of class mammal
            m.GetOlder(); // INCREASE AGE TO 1

            // method INSIDE method
            void DoThis(){
                Console.WriteLine("I am doing something");
            }

            CountNumbers(5000);       // y only
            CountNumbers(5000, 300);  // y and x

            OutParameters(10, 10, out int a);
            Console.WriteLine($"out parameter was {a}");

            TupleMethod();         // Not gathering output; output is wasted

            var tupleOutput = TupleMethod();   // OUTPUT Sent to custom object
            Console.WriteLine($"{tupleOutput.x}, {tupleOutput.y},{tupleOutput.z}");

        }

        // ATTACH METHOD TO CLASS : ADD 'STATIC' KEYWORD
        static void DoThisAswell() {
            Console.WriteLine("I am doing something aswell");
        }


        static void CountNumbers(int y, int x = 100)
        {
            Console.WriteLine(x*y);
        }

        static void OutParameters(int x, int y, out int z)
        {
            z = x * y;   // WILL RETURN THIS AS z
        }

        static (int x, string y, bool z) TupleMethod()
        {
            return (10, "hi", false);
        }


    }


    class Mammal
    {
        public int Age { get; set; }
        // INSTANCE METHOD
        public void GetOlder() { Age++; }
    }
}


```







# Random
Comment = Control K C
Uncomment = Control K U


UH OH THIS IVE MADE A JUMBO MESS