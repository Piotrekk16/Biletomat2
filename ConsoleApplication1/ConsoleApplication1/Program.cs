﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum RodzajBiletu { N, U }
    class Program
    {
        static void Main(string[] args)
        {
            
            Aplikacja app = new Aplikacja();
            app.WykonajDzialanie();
        }
    }
}