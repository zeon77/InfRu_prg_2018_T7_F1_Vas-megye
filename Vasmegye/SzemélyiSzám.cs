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
        public DateTime SzületésiDátum { get; private set; }
        public char Nem { get; private set; }
        public int Sorszám { get; private set; }

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

            return Sum % sz.Length == int.Parse(sz[sz.Length - 1].ToString());
        }

        //Constructor
        public SzemélyiSzám(string sz)
        {
            //4.
            if (!CdvEll(sz))
                throw new Exception($"Hibás a {sz} személyi azonosító!");
            else
                Azonosító = sz;

            string[] db = sz.Split('-');
            int _M = int.Parse(db[0]);
            int _ÉÉÉÉ;
            if (_M <= 2)
                _ÉÉÉÉ = int.Parse(db[1].Substring(0, 2)) + 1900;
            else
                _ÉÉÉÉ = int.Parse(db[1].Substring(0, 2)) + 2000;
            
            int _HH = int.Parse(db[1].Substring(2, 2));
            int _NN = int.Parse(db[1].Substring(4, 2));
            SzületésiDátum = new DateTime(_ÉÉÉÉ, _HH, _NN);
            
            if (_M % 2 == 1)
                Nem = 'f';
            else
                Nem = 'n';
            
            Sorszám = int.Parse(db[2].Substring(0, 3));
        }
    }
}
