using System;

namespace lab_21_struct
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MyStruct();
            var s2 = new MyStruct(10, 10, "yeah");
            Console.WriteLine(s2.GetX());
        }
    }

    class MyClass
    {

    }

    struct MyStruct
    {
        private int x;
        public int y;
        public string z { get; set; }
        public MyStruct(int X, int Y, string Z)
        {
            this.x = X;
            this.y = Y;
            this.z = Z;
        }

        public int GetX()
        {
            return this.x;
        }
    }
}
