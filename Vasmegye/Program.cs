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

        }
    }
}
