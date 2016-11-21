using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Aplikacja
    {
        private string a;

        public void WczytajKlawisz()
        {
            a = Convert.ToString(Console.ReadLine());
        }
        public void WykonajDzialanie()
        {
            Console.WriteLine("Dzien dobry");
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("Z - Zakup biletu");
            Console.WriteLine("S - Sprawdzenie biletu");
            Console.WriteLine("X - Powrot do menu");
            WczytajKlawisz();
            if (a == "z" || a =="Z")
            {
                Console.WriteLine("Okresl rodzaj biletu:");
                Console.WriteLine("A - autobusowe");
                Console.WriteLine("K - kolejowe");

                WczytajKlawisz();

                BiletA biletA = new BiletA();
                BiletK biletK = new BiletK();

                if (a == "a" || a=="A")
                {
                    Console.WriteLine("Wybierz rodzaj biletu:\nN-normalny\nU-ulgowy");
                    WczytajKlawisz();
                    if (a == Convert.ToString(RodzajBiletu.N))
                    {
                        biletA.ObliczCene(RodzajBiletu.N);
                    }
                    else if (a== Convert.ToString(RodzajBiletu.U))
                    {
                        biletA.ObliczCene(RodzajBiletu.U);
                    }

                }
                else if (a == "k" || a =="K")
                {
                    biletK.pobierzTrase();
                    Console.WriteLine("Wybierz rodzaj biletu\nN-normalny\nU-ulgowy");
                    WczytajKlawisz();
                    if (a == Convert.ToString(RodzajBiletu.N))
                    {
                        biletK.ObliczCene(RodzajBiletu.N);
                    }
                    else if (a == Convert.ToString(RodzajBiletu.U))
                    {
                        biletK.ObliczCene(RodzajBiletu.U);
                    }
                }
            }
            else if (a == "s" || a =="S")
            {
                Console.WriteLine("One day...");
            }
        }
    }
}
