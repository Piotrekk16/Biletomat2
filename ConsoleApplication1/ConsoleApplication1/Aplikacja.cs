using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//do systemu plików

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
            
            Console.WriteLine("Co chcesz zrobic?");
            Console.WriteLine("Z - Zakup biletu");
            Console.WriteLine("S - Sprawdzenie biletu");
            Console.WriteLine("X - Koniec"); //by zachować jako tako sens aplikacji warto tu dodac koniec
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
                    biletA.Drukuj();
                }
                else if (a == "k" || a =="K")
                {
                    biletK.PobierzTrase();
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
                    biletK.Drukuj();
                }
                else
                {
                    Console.WriteLine("błędny klawisz");
                }
            }
            else if (a == "s" || a =="S")
            {
                SprawdzBilet();
            }
            else if (a == "x" || a == "X")
            {
                Console.WriteLine("Koniec");
            }
            else
            {
                Console.WriteLine("błędny klawisz");
            }
        }

        private void SprawdzBilet()
        {
            Console.WriteLine("Podaj numer biletu");
            string nrBiletu = Console.ReadLine();
            string kod = nrBiletu.Substring(0, 1);
            string nazwaPliku="";
            if (kod == "A")
            {
                nazwaPliku = @"Autobus\" + nrBiletu + ".txt";
            }
            else if (kod == "K")
            {
                nazwaPliku = @"Kolej\" + nrBiletu + ".txt";
            }
            string kodBiletu = File.ReadAllText(nazwaPliku);
            Console.WriteLine("Kod biletu: {0}", kodBiletu);
            int dzien = Convert.ToInt32(kodBiletu.Substring(0, 2));
            int miesiac = Convert.ToInt32(kodBiletu.Substring(2, 2));
            int rok = Convert.ToInt32(kodBiletu.Substring(4, 4));
            int godzina = Convert.ToInt32(kodBiletu.Substring(8, 2));
            int minuty = Convert.ToInt32(kodBiletu.Substring(10, 2));
            int sekundy = Convert.ToInt32(kodBiletu.Substring(12, 2));
            
            DateTime zakup = new DateTime(rok, miesiac, dzien, godzina, minuty, sekundy);

            if (kod == "A")
            {
                if (DateTime.Now.Subtract(zakup).TotalMinutes <= 30)
                {
                    Console.WriteLine("Bilet ważny");
                }
                else
                {
                    Console.WriteLine("Bilet nieważny");
                }
            }
            else if (kod == "K")
            {
                double dlTrasy = Convert.ToDouble(kodBiletu.Substring(14, 3));
                if (dlTrasy <=100)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 3)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
                else if (dlTrasy >100 && dlTrasy <=200)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 12)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
                else if (dlTrasy>100)
                {
                    if (DateTime.Now.Subtract(zakup).TotalHours <= 24)
                    {
                        Console.WriteLine("Bilet ważny");
                    }
                    else
                    {
                        Console.WriteLine("Bilet nieważny");
                    }
                }
            }
            
        
        }
    }
}
