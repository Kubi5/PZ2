using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie4
    {
        public static void rozwiazanie()
        {
            int sumawagi = 0;
            int result = -1023;
            Console.WriteLine("Wpisz ile liczb wpiszesz: ");
            var value = Console.ReadLine();
            int n = Convert.ToInt32(value);
            int[] tab = new int[n];

            Console.WriteLine("Wpisuj liczby oddzielone spacją: ");
            var line = Console.ReadLine();
            string[] tokens = line.Split(' ');
            int[] numbers = Array.ConvertAll(tokens, s => int.Parse(s));

            for (int i = 0; i < numbers.Length; i++)
            {
                int val = numbers[i];
                int j = i+1;
                if(j == numbers.Length)
                {
                    break;
                }
                int liczba = 0;
                while (val > numbers[j])
                {
                    liczba = numbers[j];
                    j++;
                    if(j == numbers.Length)
                    {
                        break;
                    }
                }
                sumawagi = val - liczba;
                if (sumawagi > result) {
                result = sumawagi;
                }
            }
            
            Console.WriteLine(result);
        }
    }
}
