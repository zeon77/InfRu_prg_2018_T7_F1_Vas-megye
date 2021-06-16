using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vasmegye
{
    class SzemélyiSzám
    {
        //Properties
        public string Azonosító { get; private set; }

        //Methods
        //3.
        public bool CdvEll(string sz)
        {
            sz = sz.Replace("-", "");
            int Sum = 0;

            for (int i = 0; i < sz.Length - 1; i++)
            {
                Sum += int.Parse(sz[i].ToString()) * (sz.Length - 1 - i);
            }

            if (Sum % sz.Length == int.Parse(sz[sz.Length - 1].ToString()))
                return true;

            return false;
        }

        //Constructor
        public SzemélyiSzám(string sz)
        {
            //4.
            if (!CdvEll(sz))
                throw new Exception($"Hibás a {sz} személyi azonosító!");
            else
                Azonosító = sz;
        }
    }
}
