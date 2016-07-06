using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class AggregateMethod
    {
        public static int GetSumClassic(IEnumerable<int> numbersList)
        {
            int sum = 0;

            foreach (var number in numbersList)
            {
                sum = sum + number;
            }

            return sum;
        }

        public static int GetSumLinq(IEnumerable<int> numbersList)
        {
            return numbersList.Aggregate(0, (sum, element) => sum = sum + element);
        }

        //Implement the method, so it returns the sum of even numbers in the list.
        public static int GetSumOfEvenNumbers(IEnumerable<int> numbersList)
        {
           var evenNo = numbersList.Where(x => (int)x % 2 == 0).Sum();
           
            return (int)evenNo;
        }
    }
}
