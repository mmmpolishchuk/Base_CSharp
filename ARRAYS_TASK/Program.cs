using System;

namespace ARRAYS_TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, temp;
            int[] arr1 = { 0, 0, 0, 0 };
            int[] arr2 = { 1, 1, 1, 1, 1, 1, 1, 1 };
            int slide = (arr2.Length - arr1.Length) / 2;

            Console.Write("Small array: ");
            for (i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + "  ");
            }
            Console.WriteLine();
            Console.Write("\nBig array:   ");
            for (j = 0; j < arr2.Length; j++)
            {
                Console.Write(arr2[j] + "  ");
            }
            Console.WriteLine();

            Array.Copy(arr1, arr2, arr1.Length);

            Console.Write("\nSmall + Big: ");
            for (i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + "  ");
            }

            for (i = 0; i <= arr1.Length; i++)
            {
                temp = arr2[arr1.Length - i];
                arr2[arr1.Length - i] = arr2[arr1.Length - i + slide];
                arr2[arr1.Length - i + slide] = temp;
            }
            Console.WriteLine();
            Console.Write("\nChanged array: ");
            for (i = 0; i < arr2.Length; i++)
            {
                Console.Write(arr2[i] + "  ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
