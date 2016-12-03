using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//dyrektywa do obsługi plików

namespace ConsoleApplication1
{
    class BiletA : Bilet
    {
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (rodzaj == RodzajBiletu.N)
            {
                Console.WriteLine("Cena biletu normalnego na autobus: 2,90 zl");
                base.cena = 2.90;//warto jakoś ustawić cenę
            }
            else
            {
                Console.WriteLine("Cena biletu ulgowego na autobus: 1,45 zl");
                base.cena = 1.45;// tu jw
            }
            //Console.ReadKey(); - po co to tu?
        }

        public BiletA() { }

        
        public override void Drukuj()
        {
            Directory.CreateDirectory("Autobus");

            int licznikA = 0;
            string nazwaA = @"Autobus\A" + licznikA + ".txt";
            while (File.Exists(nazwaA))
            {
                licznikA++;
                nazwaA = @"Autobus\A" + licznikA + ".txt";
            }

            using (StreamWriter sw = new StreamWriter(nazwaA))
            {
                string data = System.DateTime.Now.Day.ToString().PadLeft(2, '0') + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Year.ToString().PadLeft(4, '0') + System.DateTime.Now.Hour.ToString().PadLeft(2, '0') + System.DateTime.Now.Minute.ToString().PadLeft(2, '0') + System.DateTime.Now.Second.ToString().PadLeft(2, '0');
                sw.WriteLine(data);
            }


        }
    }
}
