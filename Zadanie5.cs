using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie5
    {
        public static void rozwiazanie()
        {
            
            String tab = Console.ReadLine().ToLower();
            tab = tab.Replace(" ", string.Empty);
            char[] text = tab.ToCharArray();
            int[] howmany = new int[25];
            for(int i = 0; i < text.Length; i++)
            {
                howmany[(int)text[i] - Convert.ToInt32('a')]++;  //97
            }

            for(int i = 0; i < howmany.Length; i++)
            {
                if (howmany[i] != 0)
                {
                    Console.WriteLine(((char)(i + Convert.ToInt32('a')) + ": " + howmany[i]));
                }
            }
            
           
        }
    }
}
