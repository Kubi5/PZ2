using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie1
    {
        public static void rozwiazanie() {
        int rok;
        Console.WriteLine("Wpisz rok: ");

            var val = Console.ReadLine();
            rok = Convert.ToInt32(val);

            if (rok % 4 == 0 && rok % 100 == 0 && rok % 400 == 0 || rok % 4 == 0 && rok % 100 != 0)
            {
                Console.WriteLine("Dany rok JEST przestępny");
                return;
            }
            else
                Console.WriteLine("Dany rok NIE JEST przestępny");
        }

    }
}
