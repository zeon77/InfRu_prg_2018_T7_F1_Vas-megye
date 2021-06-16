using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Vasmegye
{
    class Program
    {
        static void Main(string[] args)
        {
            //2., 4. feladat
            Console.WriteLine($"2. feladat: Adatok beolvasása, tárolása");
            List<SzemélyiSzám> számok = new List<SzemélyiSzám>();
            Console.WriteLine("4. feladat: ");
            foreach (string sor in File.ReadAllLines("vas.txt"))
            {
                try
                {
                    számok.Add(new SzemélyiSzám(sor));
                }
                catch (Exception e)
                {
                    Console.WriteLine("\t" + e.Message);
                }
            }

            //5. feladat
            Console.WriteLine("5. feladat: Vas megyében a vizsgált évek alatt {0} csecsemő született.", számok.Count);

            //6.
            Console.WriteLine($"6. feladat: Fiúk száma: {számok.Where(x => x.Nem == 'f').Count()}");

            //7. feladat
            int minYear = számok.Min(x => x.SzületésiDátum.Year);
            int maxYear = számok.Max(x => x.SzületésiDátum.Year);
            Console.WriteLine("7. feladat: Vizsgált időszak: {0} - {1}", minYear, maxYear);

            //8. feladat
            var s = számok.Where(x => DateTime.IsLeapYear(x.SzületésiDátum.Year)).Where(x => x.SzületésiDátum == new DateTime(x.SzületésiDátum.Year, 2, 24));
            Console.WriteLine(
                $"8. feladat: Szökőnapon " +
                $"{(s.Count() > 0 ? "" : " nem")}" +
                $"született baba!");

            //9. feladat
            Console.WriteLine("9. feladat: Statisztika (Linq)");
            számok
                .GroupBy(g => g.SzületésiDátum.Year)
                .ToList()
                .ForEach(x => Console.WriteLine($"\t{x.Key} - {x.Count()} fő"));

            //9. feladat / B
            Console.WriteLine("9. feladat: Statisztika (Dictionary)");
            Dictionary<int, int> Stat = new Dictionary<int, int>();
            foreach (var item in számok)
            {
                if (!Stat.ContainsKey(item.SzületésiDátum.Year))
                    Stat.Add(item.SzületésiDátum.Year, 1);
                else
                    Stat[item.SzületésiDátum.Year]++;
            }

            foreach (var item in Stat)
            {
                Console.WriteLine("\t{0} - {1} fő", item.Key, item.Value);
            }
        }
    }
}
