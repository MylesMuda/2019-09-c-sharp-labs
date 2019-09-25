using System;

namespace lab_35_oop_events
{
    class Program
    {
        static void Main(string[] args)
        {
            var Jame = new Child();
            Jame.Name = "Jame";
            Jame.Grow("NO");

            for(int i = 0; i < 10; i++)
            {
                Jame.Grow($"SPACE {i}");
            }
        }

        class Child
        {
            public delegate int BirthdayDelegate(string TypeOfParty);
            public event BirthdayDelegate HaveBirthday;

            public string Name { get; set; }
            public int Age { get; set; }

            public Child()
            {
                this.Age = 0;
                Console.WriteLine("Congratulations, BEAUTIFUL baby :)");
                HaveBirthday += Celebrate;
            }

            int Celebrate(string TypeOfParty)
            {
                Age++; //one year older
                Console.WriteLine($"Celebrating yet another birthday! Age: {Age} Type of Party: {TypeOfParty}");
                return Age;
            }

            public void Grow(string TypeOfParty)
            {
                int ageNow = HaveBirthday(TypeOfParty);
            }
        }
    }
}
