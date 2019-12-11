using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA191211
{
    struct Diak
    {
        public string Nev;
        public int matekJegye;
        public int magyarJegy;
        public int angolJegy;
        public bool fiu;
    }

    class Program
    {
        static Diak[] diakok;
        static void Main()
        {
            Naplo();
            Console.ReadKey();
        }

        static void ErtekVsRef()
        {
            //ÉRTÉK
            int x = 10;
            int y = x;
            y = y + 10;

            Console.Write("x = ");
            Console.WriteLine(x);
            Console.Write("y = ");
            Console.WriteLine(y);


            //REFERENCIA
            int[] t = new int[2];
            t[0] = 10;
            int[] v = t;
            v[0] = v[0] + 10;

            Console.Write("t[0] = ");
            Console.WriteLine(t[0]);
            Console.Write("v[0] = ");
            Console.WriteLine(v[0]);

        }
        static void Strukturak()
        {
            var d = new Diak()
            {
                Nev = "Kovács Béla",
                matekJegye = 3,
                magyarJegy = 5,
                angolJegy = 4,
                fiu = true,
            };

            var e = new Diak()
            {
                Nev = "Szűcs Gizikeee",
                matekJegye = 1,
                magyarJegy = 2,
                angolJegy = 4,
                fiu = false,
            };

            /*
            var x1 = 10; //<- int
            var x2 = 10.0; //<- double
            var x3 = 10F; //<- float
            var x4 = "10"; //<- string
            var x5 = '1'; //<- char
            */

            Console.WriteLine($"A diák neve: {d.Nev}");
            Console.WriteLine($"Tanulményi átlaga: {(d.matekJegye + d.magyarJegy + d.angolJegy) / 3f}");
            Console.Write($"{d.Nev} egy ");
            if (d.fiu) Console.WriteLine("fiú");
            else Console.WriteLine("lány");
            Console.WriteLine("------------");
            Console.WriteLine($"A diák neve: {e.Nev}");
            Console.WriteLine($"Tanulményi átlaga: {(e.matekJegye + e.magyarJegy + d.angolJegy) / 3f}");
            Console.Write($"{e.Nev} egy ");
            if (e.fiu) Console.WriteLine("fiú");
            else Console.WriteLine("lány");
        }
        static void Naplo()
        {
            //bekérjük, hogy hány fős az osztály!
            //létrehozunk egy ekkora Diak tömböt
            //képernyőről bekérjük mindenkinek az adatait
            //elkészítjük a statisztikát
                //tantárgyi átlagok
                //osztályátlag
                //hány ember áll bukásra
                //melyik a legnehezebb tantárgy

            Adatbevitel();

            float magyAt = TantargyiAtlag("magyar");
            Console.WriteLine($"Magyar átlag: {magyAt}");
            float matAt = TantargyiAtlag("matek");
            Console.WriteLine($"Matek átlag: {matAt}");
            float angAt = TantargyiAtlag("angol");
            Console.WriteLine($"Angol átlag: {angAt}");
            Osztalyatlag();
            Bukasok();
            string legnehezebb = LegnehezebbTantargy(new float[] { magyAt, matAt, angAt });
            Console.WriteLine($"Legproblémásabb tantárgy: {legnehezebb}");
        }

        static private string LegnehezebbTantargy(float[] atlagok)
        {
            //magy - mat - ang

            int mini = 0;
            for (int i = 1; i < atlagok.Length; i++)
            {
                if(atlagok[mini] > atlagok[i])
                {
                    mini = i;
                }
            }

            if (mini == 0) return "magyar";
            if (mini == 1) return "matek";
            if (mini == 2) return "angol";

            return "valami hiba történt";
        }

        static private void Bukasok()
        {
            int dbBukas = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                if (diakok[i].matekJegye == 1) dbBukas++;
                if (diakok[i].magyarJegy == 1) dbBukas++;
                if (diakok[i].angolJegy == 1) dbBukas++;
            }

            Console.WriteLine($"Bukások száma összesen: {dbBukas}");
        }

        static private void Osztalyatlag()
        {
            int sum = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                sum += diakok[i].magyarJegy + diakok[i].matekJegye + diakok[i].angolJegy;
            }

            Console.WriteLine($"Osztályátlag: {sum / (float)(diakok.Length * 3)}");
        }

        static private float TantargyiAtlag(string tantargy)
        {
            int sum = 0;

            for (int i = 0; i < diakok.Length; i++)
            {
                if (tantargy == "magyar") sum += diakok[i].magyarJegy;
                if (tantargy == "matek") sum += diakok[i].matekJegye;
                if (tantargy == "angol") sum += diakok[i].angolJegy;
            }

            return sum / (float)diakok.Length;
        }

        static private void Adatbevitel()
        {
            Console.Write("Hány fős az osztály?: ");
            int osztalyletszam = int.Parse(Console.ReadLine());

            diakok = new Diak[osztalyletszam];

            for (int i = 0; i < diakok.Length; i++)
            {
                diakok[i] = new Diak();
                //----------
                Console.Write($"{i + 1}. diák neve: ");
                diakok[i].Nev = Console.ReadLine();

                Console.Write($"{diakok[i].Nev} milyen nemű? ");
                string valasz = Console.ReadLine();
                if (valasz == "fiu") diakok[i].fiu = true; 
                else diakok[i].fiu = false;

                Console.Write($"{diakok[i].Nev} matek jegye: ");
                diakok[i].matekJegye = int.Parse(Console.ReadLine());

                Console.Write($"{diakok[i].Nev} magyar jegye: ");
                diakok[i].magyarJegy = int.Parse(Console.ReadLine());

                Console.Write($"{diakok[i].Nev} angol jegye: ");
                diakok[i].angolJegy = int.Parse(Console.ReadLine());

                Console.WriteLine("---------------------");
            }

            Console.WriteLine("ADATBEKÉRÉS BEFEJEZŐDÖTT!");
        }
    }
}
