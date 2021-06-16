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

        //Constructor
        public SzemélyiSzám(string sor)
        {
            Azonosító = sor;
        }
    }
}
