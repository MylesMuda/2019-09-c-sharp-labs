using System;

namespace lab_09_constructor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constructors save lots of lines of code, no need to do getters and setters for each field
            var merc01 = new Mercedes("CHASSIS1234ABC", "Silver", 2500); // calling the default constructor  
            var merc02 = new Mercedes();

            var aClass = new AClass("Chassis123", "Blue", 3000);
            var a104 = new A104("Chassis342", "Green");
        }

        class Mercedes
        {
            protected string engineChassisID;
            public string Colour { get; set; }
            public int Length { get; set; }

            public Mercedes() { } //Default constructor : EXPLICITLY CODE IT

            public Mercedes(string engineChassisID, string colour, int length)
            {
                this.engineChassisID = engineChassisID;
                this.Colour = colour;
                this.Length = length;
            }
        }

        class AClass : Mercedes
        { 
            public AClass() { }
            public AClass(string engineChassisID, string colour, int length)
            {
                this.engineChassisID = engineChassisID;
                this.Length = length;
                this.Colour = colour;
            }
        }

        class A104 : AClass
        {
            //different constructor : calling the base/parent constructor
            public A104(string engineChassisID, string colour, int length = 2300) : base(engineChassisID, colour, length) { }
        }
    }
}
