using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateStudy
{

    class Program
    {
        //public delegate bool IsExites(int item);
        static void Main(string[] args)
        {
            var arry = new List<int>() { 1, 2, 3, 4, 5, 6 };
            //var d1 = new IsExites(Exit);
          var s=  new Action(doba);
            Print(arry, new Predicate<int>(Exit));
            Console.ReadKey();
            
        }
        static void doba( )
        {

        }
        static bool Exit(int item)
        {
            return item > 3;
        }

        static void Print(List<int> arr, Predicate<int> dl)
        {
            foreach (var item in arr)
            {
                if (dl(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
