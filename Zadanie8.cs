using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Zadanie8
    {
        public static void rozwiazanie()
        {
            Kontrakt kontrakt = new Kontrakt();
            Pracownik Fifi = new Pracownik("Filip", "Kubiś", kontrakt);

            Console.WriteLine(Fifi.toString());

            Kontrakt kontrakt2 = new Kontrakt("etat", 20);
            Fifi.zmienKontrakt(kontrakt2);

            Console.WriteLine(Fifi.toString());


        }
    }

    class Kontrakt
    {
        const int stawkaNaEtacie = 5000;
        const int stawkaNaStazu = 1000;

        public String nazwaKontraktu;
        public int iloscNadgodzin = 0;

        public Kontrakt(String nazwaKontraktu = "staż", int iloscNadgodzin = 0)
        {
            this.nazwaKontraktu = nazwaKontraktu;
            this.iloscNadgodzin = iloscNadgodzin;
        }

        public float Pensja()
        {

            if(this.nazwaKontraktu == "staż")
            {
                return stawkaNaStazu;
            }
            if(this.nazwaKontraktu == "etat")
            {
                return stawkaNaEtacie + iloscNadgodzin * (stawkaNaEtacie / 60);
            }

            return 0;
        }
    }

    class Pracownik
    {
        String imie;
        String nazwisko;
        Kontrakt kontrakt;

        public Pracownik(String imie, String nazwisko,Kontrakt kontrakt)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;   
            this.kontrakt = kontrakt;
            this.kontrakt.nazwaKontraktu = "staż";
        }

        public void zmienKontrakt(Kontrakt kontrakt)
        {
            this.kontrakt = kontrakt;
        }

        public float Pensja()
        {
            return this.kontrakt.Pensja();
        }

        public String toString()
        {
            return this.imie + " " + this.nazwisko + " " + this.Pensja().ToString(); 
        }
    }
}
