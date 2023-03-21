using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bloodpressure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Adja meg a nevét:");
            string nev = Console.ReadLine();
            Console.WriteLine("Adja meg a mai dátumot:");
            string datum = Console.ReadLine();
            Console.WriteLine("Adja meg a napszakot:");
            string napszak = Console.ReadLine();
            Console.WriteLine("Adja meg a szisztolést:");
            int szisztoles = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg a diasztolést:");
            int diasztoles = int.Parse(Console.ReadLine());
            Console.WriteLine("Adja meg a pulzusszámot:");
            int pulzusszam = int.Parse(Console.ReadLine());

            //listák létrehozása
            List<string> datumok = new List<string>();
            List<int> szisztolesek = new List<int>();
            List<int> diasztolesek = new List<int>();
            List<int> pulzusszamok = new List<int>();
            List<string> napszakok = new List<string>();
            
            if (!File.Exists(nev + ".txt")) //ha nem létezik a fájl
            {
                StreamWriter fajl = new StreamWriter(nev+".txt");
                fajl.WriteLine("Név: {0}",nev);
                fajl.WriteLine("Dátum  \t    Szisztolés\t  Diasztolés\tPulzusszám\tNapszak");
                fajl.WriteLine("{0}\t      {1}\t           {2}\t          {3}\t{4}", datum, szisztoles, diasztoles, pulzusszam, napszak);
                fajl.WriteLine();
                //átlagok megadása
                int atlag1 = szisztoles;
                int atlag2 = diasztoles;
                int atlag3 = pulzusszam;
                //kiírása
                fajl.WriteLine("Átlag vérnyomás:  {0}\t\t     {1}\t\t    {2}", atlag1, atlag2, atlag3);
                //típus eldöntése
                string tipus = "";
                if (90 <= atlag1 && atlag1 <= 119 && 60 <= atlag2 && atlag2 <= 79)
                {
                    tipus = "Normál";
                }
                else if (120 <= atlag1 && atlag1 <= 139 && 80 <= atlag2 && atlag2 <= 89)
                {
                    tipus = "Prehipertónia";
                }
                else if (140 <= atlag1 && atlag1 <= 159 && 90 <= atlag2 && atlag2 <= 99)
                {
                    tipus = "I. fokozatú hipertónia";
                }
                else if (atlag1 >= 160 && atlag2 >= 100)
                {
                    tipus = "II. fokozatú hipertónia";
                }
                else if (atlag1 >= 140 && atlag2 < 90)
                {
                    tipus = "Izolált szisztolés hipertónia";
                }
                else
                {
                    tipus = "semmilyen";
                }

                fajl.WriteLine("Az ön vérnyomása: {0} típusú", tipus);
                fajl.Close();
            }
            else //ha létezik a fájl
            {
                string[] sorok = File.ReadAllLines(nev + ".txt"); //beolvassuk az előző fájlt
                StreamWriter fajl = new StreamWriter(nev + ".txt"); //megnyitjuk a fájlt emiatt kitöröljük a tartalmát

                //fájl sorainak elsplitelése
                for (int i = 2; i < sorok.Length - 3; i++)
                {
                    datumok.Add(sorok[i].Split('\t')[0]);

                    for (int x = 1; x <= 3; x++)
                    {
                        string ideiglenes = sorok[i].Split('\t')[x];
                        //fölösleges space-ek kitörlése
                        for (int f = ideiglenes.Length - 1; f > 0; f--)
                        {
                            if (ideiglenes[i] == ' ')
                            {
                                ideiglenes.Remove(f, 1);
                            }
                        }
                        if (x == 1)
                        {
                            szisztolesek.Add(int.Parse(ideiglenes));
                        }
                        else if(x == 2)
                        {
                            diasztolesek.Add(int.Parse(ideiglenes));
                        }
                        else if(x == 3)
                        {
                            pulzusszamok.Add(int.Parse(ideiglenes));
                        }
                    }
                    napszakok.Add(sorok[i].Split('\t')[4]);
                }

                //új adatok hozzáadása a listához
                datumok.Add(datum);
                szisztolesek.Add(szisztoles);
                diasztolesek.Add(diasztoles);
                pulzusszamok.Add(pulzusszam);
                napszakok.Add(napszak);

                //átlagok kiszámítása
                int atlag1 = 0;
                int atlag2 = 0;
                int atlag3 = 0;
                for (int i = 0; i < szisztolesek.Count; i++)
                {
                    atlag1 += szisztolesek[i];
                }
                for (int i = 0; i < diasztolesek.Count; i++)
                {
                    atlag2 += diasztolesek[i];
                }
                for (int i = 0; i < pulzusszamok.Count; i++)
                {
                    atlag3 += pulzusszamok[i];
                }

                atlag1 = atlag1 / szisztolesek.Count;
                atlag2 = atlag2 / diasztolesek.Count;
                atlag3 = atlag3 / pulzusszamok.Count;

                //típus eldöntése
                string tipus = "";
                if (90 <= atlag1 && atlag1 <= 119 && 60 <= atlag2 && atlag2 <= 79)
                {
                    tipus = "Normál";
                }
                else if (120 <= atlag1 && atlag1 <= 139 && 80 <= atlag2 && atlag2 <= 89)
                {
                    tipus = "Prehipertónia";
                }
                else if (140 <= atlag1 && atlag1 <= 159 && 90 <= atlag2 && atlag2 <= 99)
                {
                    tipus = "I. fokozatú hipertónia";
                }
                else if (atlag1 >= 160 && atlag2 >= 100)
                {
                    tipus = "II. fokozatú hipertónia";
                }
                else if (atlag1 >= 140 && atlag2 < 90)
                {
                    tipus = "Izolált szisztolés hipertónia";
                }
                else
                {
                    tipus = "semmilyen";
                }


                //új fájlba írás

                fajl.WriteLine("Név: {0}", nev);
                fajl.WriteLine("Dátum  \t    Szisztolés\t  Diasztolés\tPulzusszám\tNapszak");

                //adatok beírása soronként
                for (int i = 0; i < datumok.Count; i++)
                {
                    fajl.WriteLine("{0}\t      {1}\t           {2}\t          {3}\t{4}", datumok[i], szisztolesek[i], diasztolesek[i], pulzusszamok[i], napszakok[i]);
                }
                fajl.WriteLine();
                fajl.WriteLine("Átlag vérnyomás:  {0}\t\t     {1}\t\t    {2}", atlag1, atlag2, atlag3);
                fajl.WriteLine("Az ön vérnyomása: {0} típusú", tipus);
                fajl.Close();
            }
            Console.WriteLine("Nyomjon meg egy gombot a kilépéshez!");
            Console.ReadKey();
        }
    }
}
