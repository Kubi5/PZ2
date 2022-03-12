using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie9
    {
        public static void rozwiazanie()
        {
            double iloscWypitejWody = 0;
            int iloscZjedzonegoJedzenia = 0;

            Farma farma1 = new Farma(10, 5, 6);

            Krowa[] krowy = new Krowa[farma1.iloscKrow];
            Kotek[] koty = new Kotek[farma1.iloscKotow];
            Owca[] owce = new Owca[farma1.iloscOwiec];

            for(int i = 0; i < farma1.iloscKrow; i++)
            {
                Random wagaKrowy = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                Thread.Sleep(20);
                Krowa krowa = new Krowa(wagaKrowy.Next(400,600));
                
                Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                int value = rand.Next(2);
                if(value == 0)
                {
                    
                    krowa.PijWodę();
                    iloscWypitejWody += 3;
                }
                else
                {
                    krowa.JemSiano();
                    iloscZjedzonegoJedzenia += 80;
                }
                krowy[i] = krowa;
            }

            for (int i = 0; i < farma1.iloscKotow; i++)
            {
                Random wagaKota = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                Thread.Sleep(20);
                Kotek kotek = new Kotek(wagaKota.Next(7, 12));

                Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                int value = rand.Next(2);
                if (value == 0)
                {
                    kotek.PijWodę();
                    iloscWypitejWody += 0.5;
                }
                else
                {
                    int WagaKotaPrzedJedzeniem = kotek.SprawdzWage();
                    kotek.JemWszystkoOproczSiana();
                    int WagaKotaPoJedzeniu = kotek.SprawdzWage();
                    iloscZjedzonegoJedzenia += WagaKotaPoJedzeniu - WagaKotaPrzedJedzeniem;
                }
                koty[i] = kotek;
            }

            for (int i = 0; i < farma1.iloscOwiec; i++)
            {
                Random wagaOwcy = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                Thread.Sleep(20);
                Owca owca = new Owca(wagaOwcy.Next(60, 120));

                Random rand = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
                int value = rand.Next(2);
                if (value == 0)
                {
                    owca.PijWodę();
                    iloscWypitejWody += 2;
                }
                else
                {
                    owca.JemSiano();
                    iloscZjedzonegoJedzenia += 40;
                }
                owce[i] = owca;
            }


            int minimalnaWaga = 100000;
            String zwierzeMinimalnejWagi = "";

            for(int i = 0; i < farma1.iloscKrow; i++)
            {
                if(krowy[i].SprawdzWage() < minimalnaWaga)
                {
                    minimalnaWaga = krowy[i].SprawdzWage();
                    zwierzeMinimalnejWagi = "Krowa" + " " + (i + 1);
                }
            }
            for (int i = 0; i < farma1.iloscOwiec; i++)
            {
                if (owce[i].SprawdzWage() < minimalnaWaga)
                {
                    minimalnaWaga = owce[i].SprawdzWage();
                    zwierzeMinimalnejWagi = "Owca" + " " + (i + 1);
                }
            }
            for (int i = 0; i < farma1.iloscKotow; i++)
            {
                if (koty[i].SprawdzWage() < minimalnaWaga)
                {
                    minimalnaWaga = koty[i].SprawdzWage();
                    zwierzeMinimalnejWagi = "Kot" + " " + (i + 1);
                }
            }

            Console.WriteLine("Ilość wypitej wody przez zwierzęta: " + iloscWypitejWody + " l");
            Console.WriteLine("Ilość zjedzonej karmy: " + iloscZjedzonegoJedzenia + " jednostek");
            Console.WriteLine("Najlżejsze zwierze to : " + zwierzeMinimalnejWagi + ", waży " + minimalnaWaga + " kg");
            Console.WriteLine("=================================");  
            for(int i = 0; i < farma1.iloscKotow; i++)
            {
                Console.WriteLine("Kot " + (i + 1) + " waży: " + koty[i].SprawdzWage() + " kg");
            }
            for (int i = 0; i < farma1.iloscKrow; i++)
            {
                Console.WriteLine("Krowa " + (i + 1) + " waży: " + krowy[i].SprawdzWage() + " kg");
            }
            for (int i = 0; i < farma1.iloscOwiec; i++)
            {
                Console.WriteLine("Owca " + (i + 1) + " waży: " + owce[i].SprawdzWage() + " kg");
            }
            Console.WriteLine("=================================");

        }

        class Ssak
        {
            public int waga;

            public Ssak(int waga)
            {
                this.waga = waga;
            }

            public int SprawdzWage() { return this.waga; }


        }

        class Krowa : Ssak
        {
            int wypitaWoda = 0;
            int zjedzoneSiano = 0;
            public Krowa(int waga) : base(waga)
            {
            }

            public void PijWodę()
            {
                wypitaWoda += 3;
                this.waga += 3;
            }

            public void JemSiano()
            {
                zjedzoneSiano += 80;
                this.waga += 80 / 20;
            }
        }

        class Owca : Ssak
        {
            int wypitaWoda = 0;
            int zjedzoneSiano = 0;
            public Owca(int waga) : base(waga)
            {
            }

            public void PijWodę()
            {
                wypitaWoda += 2;
                this.waga += 3;
            }

            public void JemSiano()
            {
                zjedzoneSiano += 40;
                this.waga += zjedzoneSiano / 20;
            }
        }

        class Kotek : Ssak
        {
            int wypitaWoda = 0;
            int zjedzoneWszystkoOproczSiana = 0;
            public Kotek(int waga) : base(waga)
            {
            }

            public void PijWodę()
            {
                wypitaWoda += 2;
                this.waga += 2;
            }

            public void JemWszystkoOproczSiana()
            {
                Random random = new Random();
                int jedzenie = random.Next(1, 5);
                zjedzoneWszystkoOproczSiana += jedzenie;
                this.waga += jedzenie;
            }
        }

        class Farma
        {
            Ssak[] tab;
            public int iloscKrow;
            public int iloscKotow;
            public int iloscOwiec;

            public Farma(int iloscKrow, int iloscKotow,int iloscOwiec)
            {
                this.iloscKrow = iloscKrow;
                this.iloscKotow = iloscKotow;
                this.iloscOwiec = iloscOwiec;
            }
        }
    }
}
