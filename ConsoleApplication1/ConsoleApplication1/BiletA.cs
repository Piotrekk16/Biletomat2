using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BiletA : Bilet
    {
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (rodzaj == RodzajBiletu.N)
                Console.WriteLine("Cena biletu normalnego na autobus: 2,90zl");
            else
                Console.WriteLine("Cena biletu ulgowego na autobus: 1,45zl");
            Console.ReadKey();
        }
    }
}
