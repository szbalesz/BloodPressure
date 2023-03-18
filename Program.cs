using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloodpressure
{
    class Program
    {
        static void Main(string[] args)
        {
            int szAtlag = 0;
            int dAtlag = 0;
            int pAtlag = 0;

            Console.WriteLine("Vezetéknév");
            string vezNev = Console.ReadLine();
            Console.WriteLine("Keresztnév");
            string kerNev = Console.ReadLine();
            Console.WriteLine("Dátum");
            string datum = Console.ReadLine();
            Console.WriteLine("Napszak");
            string napszak = Console.ReadLine();
            Console.WriteLine("Szisztolés");
            int szisztoles = int.Parse(Console.ReadLine());
            Console.WriteLine("Diasztolés");
            int diasztoles = int.Parse(Console.ReadLine());
            Console.WriteLine("Pulzusszám");
            int pulzusszam = int.Parse(Console.ReadLine());

            for (int i = 0; i < szisztolestomb.Length; i++)
            {
                szAtlag += szisztolestomb[i];                
            }
            for (int i = 0; i < diasztolestomb.Length; i++)
            {
                dAtlag += diasztolestomb[i];
            }
            for (int i = 0; i < pulzustomb.Length; i++)
            {
                pAtlag += pulzustomb[i];
            }
            Console.WriteLine(szAtlag/szisztolestomb.Length);
            Console.WriteLine(dAtlag / diasztolestomb.Length);
            Console.WriteLine(pAtlag / pulzustomb.Length);

            if (90 <= szAtlag && szAtlag <= 119 && 60 <= dAtlag && dAtlag <= 79)
            {
                Console.WriteLine("Normál");
            }
            if (120 <= szAtlag && szAtlag <= 139 && 80 <= dAtlag && dAtlag <= 89)
            {
                Console.WriteLine("Prehipertónia");
            }
            if (140 <= szAtlag && szAtlag <= 159 && 90 <= dAtlag && dAtlag <= 99)
            {
                Console.WriteLine("I. fokozatú hipertónia");
            }
            if (szAtlag >= 160 && dAtlag >= 100)
            {
                Console.WriteLine("II. fokozatú hipertónia");
            }
            if (szAtlag <= 140 && dAtlag < 90)
            {
                Console.WriteLine("Izolált szisztolés hipertónia");
            }

            Console.ReadKey();
        }
    }
}
