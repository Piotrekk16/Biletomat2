using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BiletK : Bilet
    {
        public double dlugoscTrasy;

        
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (dlugoscTrasy <= 100)
                cena = dlugoscTrasy * 1.04;
            else
                cena = dlugoscTrasy * 0.73;

            if (rodzaj == RodzajBiletu.N)
                Console.WriteLine("Cena biletu kolejowego na odcinku {0}-km wynosi: {1}zl", dlugoscTrasy, cena);
            else
                Console.WriteLine("Cena biletu kolejowego na odcinku {0}-km wynosi: {1}zl", dlugoscTrasy, cena/2);
            Console.ReadKey();
        }
        public void pobierzTrase()
        {
            Console.WriteLine("Podaj dlugosc trasy:");
            this.dlugoscTrasy = Convert.ToDouble(Console.ReadLine());
        }
    }
}
