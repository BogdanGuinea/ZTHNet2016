using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.EnumerableMethods
{
   public class ContainsMethod
    {
        public static IEnumerable<Band> GetBandsThatContainsEnglandCountryClassic(IEnumerable<Band> bands)
        {
            List<Band> bandList = new List<Band>();
            foreach(var band in bands)
            {
                if(band.Country.Contains("England"))
                {
                    bandList.Add(band);
                }
            }
            return bandList;
        }

        public static IEnumerable<Band> GetBandsThatContainsEnglandCountryLambda(IEnumerable<Band> bands)
        {

            // Ask?
            return bands.Where(item => item.Country.Contains("Engl"));
        }

        public static IEnumerable<Band> GetBandsThatContainsEnglandCountryLinq(IEnumerable<Band> bands)
        {
            var bandList = from b in bands
                           where b.Country.Contains("England")
                           select b;

            return bandList.ToList();
            
        }
    }
}
