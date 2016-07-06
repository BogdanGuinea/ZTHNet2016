using System.Collections.Generic;
using System.Linq;

namespace Linq.EnumerableMethods
{
    public class WhereMethod
    {
        public static IEnumerable<int> GetEvenNumbersClassic(IEnumerable<int> numbersList)
        {
            foreach (var number in numbersList)
            {
                if (number % 2 == 0)
                    yield return number;
            }
        }

        public static IEnumerable<int> GetEvenNumbersLinqSql(IEnumerable<int> numbersList)
        {
            return from number in numbersList
                   where number % 2 == 0
                   select number;
        }

        public static IEnumerable<int> GetEvenNumbersLinqLambda(IEnumerable<int> numbersList)
        {
            return numbersList.Where(number => number % 2 == 0);
        }
        
        //Implement the method, so it returns only bands that start with "black". 
        //Hint: For string comparison, use string.StartsWith with StringComparison.InvariantCultureIgnoreCase
        public static IEnumerable<Band> GetBandsThatStartWithBlack(IEnumerable<Band> bandsList)
        {
                         
                var startWithBlack = from b in bandsList
                                     where b.Name.StartsWith("Black", System.StringComparison.InvariantCultureIgnoreCase)
                                     select b;
                var startwithBlackLambda = bandsList.Where(x => x.Name.StartsWith("Black", System.StringComparison.InvariantCultureIgnoreCase));

                return startWithBlack;
          
            
        }
    }
}
