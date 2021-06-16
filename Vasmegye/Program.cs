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

        }
    }
}
