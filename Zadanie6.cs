using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie6
    {
        public static void rozwiazanie()
        {
            Console.WriteLine("Podaj dowolny tekst: ");
            String text = Console.ReadLine();
            Console.WriteLine("Podaj fragment tekstu który chcesz zamienić: ");
            String outtext = Console.ReadLine();
            Console.WriteLine("Podaj tekst który chcesz wstawić: ");
            String intext = Console.ReadLine();
            text = text.Replace(outtext, intext);
            Console.WriteLine(text);
        }
    }
}
