using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace suanfa
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 8, 1, 45, 7, 34, 8, 3, 9 };
            for (int a = 0; a < array.Length; a++)
            {
                for (int b = a + 1; b < array.Length; b++)
                {
                    if (array[b] < array[a])
                    {
                        int temp = array[a];
                        array[a] = array[b];
                        array[b] = temp;
                    }
                }
            }
            foreach(var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
