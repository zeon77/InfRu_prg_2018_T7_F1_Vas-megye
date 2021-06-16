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
            //2. feladat
            List<SzemélyiSzám> számok = new List<SzemélyiSzám>();
            foreach (string sor in File.ReadAllLines(@"vas.txt"))
            {
                    számok.Add(new SzemélyiSzám(sor));
            }

        }
    }
}
