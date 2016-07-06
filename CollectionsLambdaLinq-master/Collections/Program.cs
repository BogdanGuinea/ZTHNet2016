using System;
using System.Collections.Generic;
using Collections.Collection;
using Collections.Enumerable;
using Collections.List;

namespace Collections
{
    class Program
    {
        private static readonly Band[] BandsArray =
        {
            new Band("Led Zeppelin", 9, "Hard Rock", "England"),
            new Band("Judas Priest", 17, "Heavy Metal", "England"),
            new Band("Phoenix", 10, "Rock", "Romania"),
            new Band("Black Sabbath", 19, "Heavy Metal", "England"),
            new Band("Rammstein", 6, "Industrial Metal", "Germany"),
            new Band("Black Keys", 8, "Indie Rock", "United States"),
            new Band("Muse", 6, "Alternative Rock", "England")
        };

        static void Main(string[] args)
        {
            //EnumerableExample();
            //YieldExample();
            //CollectionExample();
            //ListExample();
            DictionaryExample();

            Console.Read();
        }

        private static void EnumerableExample()
        {
            Console.WriteLine();
            Console.WriteLine("=====Example 1 (Enumerable example)=====");

            //Enumerating example
            var bands = new BandsEnumerable(BandsArray);
            var enumerator = bands.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var band = enumerator.Current;
                Console.WriteLine("{0} ({1}, {2}): {3} albums.",band.Name,band.Country,band.Genre,band.StudioAlbums);
            }

            //TODO 1: Change "BandsEnumerator" to enumerate from last element to first. 
            //DONE
        }

        private static void YieldExample()
        {
            Console.WriteLine();
            Console.WriteLine("=====Example 2 (Yield example)=====");

            //Enumerating an yield list
            foreach (var frontman in FrontmenList)
            {
                Console.WriteLine(frontman);
            }

            Console.WriteLine();

            //Projecting objects in a different form using yield
            var bandNames = BandNames(new List<Band>(BandsArray));
            foreach (var bandName in bandNames)
            {
                Console.WriteLine(bandName);
            }

            Console.WriteLine();

            //TODO 2: Implement "BritishBands" to return only bands that have Country == "England". 
            //DONE.
            var britishBands = BritishBands(new List<Band>(BandsArray));
            foreach (var britishBand in britishBands)
            {
                if (britishBand.Country == "England")
                {
                    Console.WriteLine(britishBand.Name);
                }
            }
        }

        private static void CollectionExample()
        {
            Console.WriteLine();
            Console.WriteLine("=====Example 3 (Collection example)=====");

            var bandsCollection = new BandsCollection(BandsArray);

            //Custom insert example
            bandsCollection.Insert(0, new Band("Band X", 0, "", ""));
            bandsCollection.Insert(3, new Band("Band Y", 0, "", ""));
            bandsCollection.Insert(9, new Band("Band Z", 0, "", ""));

            //Custom item set example
            bandsCollection[3] = new Band("Band W", 0, "", "");

            //Custom remove example
            bandsCollection.RemoveAt(8);

            Console.WriteLine();

            foreach (var bandName in BandNames(bandsCollection))
            {
                Console.WriteLine(bandName);
            }

            //TODO 3: Update bandsCollection.Clear() so it prints the removed items.
            // DONE Modificare method Clear sa permina un for care sa adauge index pentru fiecare element si sa il afiseze plus elementul acestuia;
            bandsCollection.Clear();


        }

        private static void ListExample()
        {
            Console.WriteLine();
            Console.WriteLine("=====Example 4 (List example)=====");

            var bandsList = new List<Band>(BandsArray);

            //Custom comparer example
            //  bandsList.Sort(new BasicBandsComparer());
            // bandsList.Sort(new CustomBandsComparer(BandsCompareBy.Country));
            bandsList.Sort(new CustomBandsComparer(BandsCompareBy.NameLength));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.Name));
            //bandsList.Sort(new CustomBandsComparer(BandsCompareBy.AlbumCount));

            var index = 0;
            foreach (var band in bandsList)
            {
                Console.WriteLine("{0} {1} {2} {3}",index,band.Name,band.Name.Length,band.StudioAlbums,band.Country);
                index++;
            }

            Console.WriteLine();

            //Add/Get range example
            var bandsToAdd = new[]
            {
                new Band("Band X", 0, "", ""),
                new Band("Band Y", 0, "", "")
            };
            bandsList.AddRange(bandsToAdd);
            var lastTwoBands = bandsList.GetRange(bandsList.Count - 2, 2);

            foreach (var bandName in BandNames(bandsList))
            {
                Console.WriteLine(bandName);
            }

            Console.WriteLine();

            //IndexOf uses Object.GetHashCode, which is a reference comparer by default
            var newBand = new Band("Band X", 0, "", "");
            var indexNewBand = bandsList.IndexOf(newBand);
            Console.WriteLine("Index of new Band X is {indexNewBand}");

            var refBand = bandsToAdd[0];
            var indexRefBand = bandsList.IndexOf(bandsToAdd[0]);
            Console.WriteLine("Index of reference Band X is {indexRefBand}");

            //TODO 4: Extend CustomBandsComparer to allow comparing by name length.
            //DONE.

        }

        private static void DictionaryExample()
        {
            Console.WriteLine();
            Console.WriteLine("=====Example 5 (Dictionary example)=====");

            //Adding items example
            var bandsDictionary = new Dictionary<string, Band>();
            foreach (var band in BandsArray)
            {
                bandsDictionary.Add(band.Name, band);
            }

            //Enumerating the KeyValue pairs
            foreach (var keyValuePair in bandsDictionary)
            {
                //TODO 5: Change to display key and albums count
                Console.WriteLine("Key: {0}, Value: {1}", keyValuePair.Key, keyValuePair.Value.StudioAlbums);
            }

            Console.WriteLine();

            //Retrieving value based on key example
            var bandToGet = bandsDictionary["Muse"];
            Console.WriteLine("Name:{0}  Genre:{1} Country: {2}",bandToGet.Name,bandToGet.Genre,bandToGet.Country);

            Console.WriteLine();

            //TODO 7: Check if key is present before adding/retrieving a new entry.
            //bandsDictionary.Add("Muse", new Band("Muse", 6, "Alternative Rock", "England"));
            //Console.WriteLine(bandsDictionary["Band X"].Name);
        }

        private static IEnumerable<string> FrontmenList
        {
            get
            {
                yield return "Robert Plant";
                yield return "Rob Halford";
                yield return "Ozzy Osbourne";
                yield return "Till Lindemann";
                yield return "Dan Auerbach";
                yield return "Matt Bellamy";
            }
        }

        private static IEnumerable<string> BandNames(IEnumerable<Band> bandsList)
        {
            int index = 0;
            foreach (var band in bandsList)
            {
                yield return String.Format("{0} {1}",index,band.Name);
                index++;
            }
        }

        private static IEnumerable<Band> BritishBands(IEnumerable<Band> bandsList)
        {
            foreach (var britishBand in bandsList)
            {
                yield return new Band(britishBand.Name, britishBand.StudioAlbums, britishBand.Genre, britishBand.Country);
            }
        }

    }
}
