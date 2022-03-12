using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie3
    {
        public static void rozwiazanie()
        {
            Console.WriteLine("Wpisz ile liczb wpiszesz: ");
            var value = Console.ReadLine();
            int n = Convert.ToInt32(value);
            int[] tab = new int[n];

            Console.WriteLine("Wpisuj liczby oddzielone spacją: ");
            var line = Console.ReadLine();
            string[] tokens = line.Split(' ');

            for (int i = 0; i < n; i++)
            {
                tab[i] = Convert.ToInt32(tokens[i]);

                if(Convert.ToInt32(tokens[i]) > n) { Console.WriteLine("NIE"); return; }
            }

            Array.Sort(tab);

            for(int i=1; i<=tab.Length; i++)
            {
                if(i != tab[i-1])
                {
                    Console.WriteLine("NIE");
                    return;
                }
            }

            Console.WriteLine("TAK");

            Console.ReadKey();
        }
    }
}
