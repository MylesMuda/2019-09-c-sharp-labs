using System;

namespace lab_29_interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Child();
            c.DoThat();
            c.DoThis();
            c.ParentThings();
            c.AlsoDoThis();        }
    }

    class Parent
    {
        //public string LastName;
        //public int age;
        public void ParentThings() { Console.WriteLine("I am doing parent things"); }
    }

    class Child : Parent, IDoThis, IDoThat, external.IAlsoDoThis
    {
        //Child(string lastName, int age)
        //{
        //    this.age = age;
        //    this.LastName = lastName;
        //}

        public void DoThis() { Console.WriteLine("I do this"); }
        public void DoThat() { Console.WriteLine("I do that"); }
        public void AlsoDoThis() { Console.WriteLine("I also do this"); }
    }

    interface IDoThis{ void DoThis(); }

    interface IDoThat { void DoThat(); }
}
namespace external
{
    interface IAlsoDoThis { void AlsoDoThis(); }
}
