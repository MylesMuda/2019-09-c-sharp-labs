using System;

namespace lab_11_polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var dad = new Parent(40, "Greg");
            Console.WriteLine(dad.Age);
            dad.AgeChange();
            Console.WriteLine(dad.Age);

            var son = new Child(9, "Greeg");
            Console.WriteLine(son.Age);
            son.AgeChange();
            Console.WriteLine(son.Age);
            

        }
    }

    class Parent
    {
        public int Age {get;set;}
        public string fName { get; set; }

        public Parent() { }

        public Parent(int age, string fName)
        {
            this.Age = age;
            this.fName = fName;
        }

        public virtual void AgeChange()
        {
            Age++;
        }
    }

    class Child : Parent 
    {
       public Child(int age, string fName) : base (age, fName) { }
       public override void AgeChange()
        {
            Age += 2;
            base.AgeChange();
        }
    }

}
