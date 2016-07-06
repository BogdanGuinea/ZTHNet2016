using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq.EnumerableMethods
{
    public class OrderByMethod 
    {
        public static List<Band> GetBandsSortedByCountryClassic(IEnumerable<Band> bands)
        {
          List<Band> sortedBands = bands.ToList();
          return sortedBands;

        }

        public static IEnumerable<Band> GetBandsSortedByCountryLambda(IEnumerable<Band> bands)
        {
            return bands.OrderBy(item => item.Country);
        }

        public static IEnumerable<Band> GetBandsSortedByCountryLinq (IEnumerable<Band> bands)
        {
            var bandList = from b in bands
                           orderby b.Country
                           select b;
            return bandList.ToList();
        }
        
        public static IEnumerable<Band> GetBandsSortedByNumberOfAlbums(IEnumerable<Band> bands)
        {
            return bands.OrderBy(item => item.Albums.Count());
        }
        

        

    }
}
