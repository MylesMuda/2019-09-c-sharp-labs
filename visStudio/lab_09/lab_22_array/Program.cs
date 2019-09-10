using System;

namespace lab_22_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1D = new int[10];

            int[,] array2D = new int[10, 10];

            int[,,] array3D = new int[10, 10, 10];

            int[] arrayLiteral = new int[] { 1, 2, 3 };

            string[] stringLiteral = new string[] { "one", "two", "three" };

            //put data in
            //pull data out
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    for(int k = 0; k < 10; k++)
                    {
                        array3D[i, j, k] = (i * i) * (j * j) * (k * k);
                    }
                }
            }

            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        sum += array3D[i, j, k];
                    }
                }
            }

            Console.WriteLine(sum);

            //A Jagged array is an array of arrays which have indistinct lengths
            int[][] myJAggedArray = new int[10][];

        }
    }
}
