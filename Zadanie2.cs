using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie2
    {
        public static void rozwiazanie()
        {
            int value = 0;
            Console.WriteLine("Wpisz liczbe");
            String number = Console.ReadLine();
           
            char []tablicaliczb = number.ToCharArray();

            foreach(char c in tablicaliczb)
            {
                value += Convert.ToInt32(c);
            }

            Console.WriteLine("Suma cyfr w tej liczbie wynosi: " + value);
        }
    }
}
