using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//dyrektywa do obsługi systemu plików

namespace ConsoleApplication1
{
    class BiletK : Bilet
    {
        private double dlugoscTrasy; //hermetyzacja

        
        public override void ObliczCene(RodzajBiletu rodzaj)
        {
            if (dlugoscTrasy <= 100)
                base.cena = dlugoscTrasy * 1.04;//dobra praktyka
            else
                base.cena = dlugoscTrasy * 0.73;//dobra praktyka

            if (rodzaj == RodzajBiletu.N)
            {
                Console.WriteLine("Cena biletu kolejowego na odcinku {0}-km wynosi: {1} zl", dlugoscTrasy, cena);
                base.cena = Math.Round(cena, 2); //warto dopisac parametr
            }
            else
            {
                Console.WriteLine("Cena biletu kolejowego na odcinku {0}-km wynosi: {1} zl", dlugoscTrasy, cena / 2);
                base.cena = Math.Round(cena / 2, 2);
            }
            
        }
        public void PobierzTrase() //nazwy metod od dużej litery
        {
            Console.WriteLine("Podaj dlugosc trasy:");
            this.dlugoscTrasy = Convert.ToDouble(Console.ReadLine());
        }

        public BiletK(double odleglosc)
        {
            this.dlugoscTrasy = odleglosc;
        }

        public BiletK() { }

        public override void Drukuj()
        {
            Directory.CreateDirectory("Kolej");

            int licznikk = 0;
            string nazwaK = @"Kolej\K" + licznikk + ".txt";
            while (File.Exists(nazwaK))
            {
                licznikk++;
                nazwaK = @"Kolej\K" + licznikk + ".txt";
            }

            using (StreamWriter sw = new StreamWriter(nazwaK))
            {
                string data = System.DateTime.Now.Day.ToString().PadLeft(2, '0') + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + System.DateTime.Now.Year.ToString().PadLeft(4, '0') + System.DateTime.Now.Hour.ToString().PadLeft(2, '0') + System.DateTime.Now.Minute.ToString().PadLeft(2, '0') + System.DateTime.Now.Second.ToString().PadLeft(2, '0') + dlugoscTrasy.ToString().PadLeft(3, '0'); //uzupełniam kod biletu o dlugosc trasy
                sw.WriteLine(data);
            }
        }
    }
}
