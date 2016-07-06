using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambda.Delegate
{
    public delegate double PerformCalculation(double x, double y);
    public delegate bool NumberCheck(int x);
    public delegate int SortNumber(int x, int y);
    /*
    Modified: Done
    */
    /**
     * TODO 1:
     * Create a delegate called NumberCheck which returns a boolean and has a single parameter of type int
     */

    public class SpecialFunctions //: IComparable<int>
    {
        public static double Sum(double val1, double val2)
        {
            return val1 + val2;
        }

        public static double Product(double val1, double val2)
        {
            return val1 * val2;
        }

        public static double Diff(double val1, double val2)
        {
            return val1 - val2;
        }

        public static void ExecuteFunction(PerformCalculation function, double param1, double param2)
        {
            double result = function(param1, param2);
            Console.WriteLine(result);
        }

        public static void ExecuteFunctionUsingFunc(Func<double, double, double> function, double param1, double param2)
        {
            double result = function(param1, param2);
            Console.WriteLine(result);
        }

        public static bool IsEvenNo(int x)
        {
            if (x % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static List<int> GetEvenNumbers(NumberCheck funct, List<int> intArray)
        {
            List<int> items = new List<int>();

            foreach(var item in intArray)
            {
                if (funct(item))
                {
                    items.Add(item);
                }
            }

            return items;
           
        }
       
        public static List<int> GetEvenNumbersWithFunc(Func<int,bool> function, List<int> intArray)
        {
            List<int> items = new List<int>();

            foreach (var item in intArray)
            {
                if (!function(item))
                {
                    items.Add(item);
                }
            }

            return items;

        }
        
        public static int GetBiggestNumberfromList(SortNumber function, List<int> intArray)
        {
            intArray.Sort((x, y) => function(x, y));
            return intArray[intArray.Count-1];
        }

                 


        public static List<int> GetSortedNumberFromList(SortNumber function, List<int> intArray)
        {
            intArray.Sort((x,y) => function(x,y));
            return intArray;
        }

        //int IComparable<int>.CompareTo(int other)
        //{
        //    int result = new int();

        //    return result.CompareTo(other);
            
        //}



        /*
        Modified: Done
        */

        /**
         * TODO 2: 
         * Create a function which checks if an integer is even. The function will return True for even numbers and False for odd numbers.
         */

        /**
         * TODO 3:
         * Create a function called GetEvenNumbers which uses an instance of a NumberCheck delegate and an aray list of integers.
         * The function will return a list with the even numbers.
         */
    }
}
