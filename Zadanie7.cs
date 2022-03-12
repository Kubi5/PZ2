using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie7
    {
        public static void rozwiazanie()
        {
            ArrayList students = new ArrayList();
            Console.WriteLine("Podaj liczbę studentów: ");
            int liczbastudentow = Convert.ToInt32(Console.ReadLine());
            String kierunek = null;
            int rok = 0;
            int ileegz = 0;
            Dictionary<String, int> wynikegz;

            for (int i = 0; i < liczbastudentow; i++)
            {
                wynikegz = new Dictionary<String, int>();
                Console.WriteLine("Podaj kierunek studenta" + " " + (i + 1) + ": ");
                kierunek = Console.ReadLine();

                Console.WriteLine("Podaj rok studenta" + " " + (i + 1) + ": ");
                rok = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Podaj ile egz mial student" + " " + (i + 1) + ": ");
                ileegz = Convert.ToInt32(Console.ReadLine());

                for (int j = 0; j < ileegz; j++)
                {
                    Console.WriteLine("Podaj przedmiot na egz studenta" + " " + (i + 1) + ": ");
                    String przedmiot = Console.ReadLine();

                    Console.WriteLine("Podaj wynik (%) z egz studenta" + " " + (i + 1) + ": ");
                    int wynik = Convert.ToInt32(Console.ReadLine());
                    wynikegz.Add(przedmiot, wynik);
                }
                Student student = new Student(kierunek, rok, wynikegz);
                students
                    .Add(student);
            }

            int k = 1;
            foreach (Student student in students)
            {
                Console.WriteLine();
                Console.WriteLine("Student " + k);
                student.pokazStudenta();
                k++;
            }

        }

        class Student
        {
            String nazwakierunku;
            int rokstudiow;
            Dictionary<String, int> wynikegz = new Dictionary<String, int>();

            public Student(String nazwakierunku, int rokstudiow, Dictionary<String, int> wynikegz)
            {
                this.nazwakierunku = nazwakierunku;
                this.rokstudiow = rokstudiow;
                this.wynikegz = wynikegz;
            }
            public void pokazStudenta()
            {
                Console.WriteLine("Kierunek: " + this.nazwakierunku);
                Console.WriteLine("Rok studiów: " + this.rokstudiow);
                foreach(var value in wynikegz)
                {
                 Console.WriteLine("Przedmiot: {0} Wynik: {1}%", value.Key, value.Value);
                }
            }
        }
    }
}
