using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilotak
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("pilotak.csv");
            List<Adat> adatok = new List<Adat>();
            foreach (string sor in sorok.Skip(1))
            {
                adatok.Add(new Adat(sor));
            }

            int adatokSzama = adatok.Count();
            Console.WriteLine($"3. feladat: hány adat van? {adatokSzama} db adat van");
                      
            string utolsoPilotaNeve = adatok.Last().Név;
            Console.WriteLine($"4. feladat: az utolsó pilóta neve: {utolsoPilotaNeve}");

            Console.WriteLine($"5.feladat: Határozza meg kik születtek 1901. Január 1 előtt: ");
            for (int i = 0; i < adatokSzama; i++)
            {
                if (adatok[i].SzulDatum.Year < 1901)
                {
                    Console.WriteLine($"\t {adatok[i].Név} ({adatok[i].SzulDatum.Year}. {adatok[i].SzulDatum.Month}. {adatok[i].SzulDatum.Day})");
                }
            }

            int minrajtszam = adatok[0].Rajtszam;
            int mini = 0;
            for (int i = 1; i < adatokSzama; i++)
            {
                if (adatok[i].Rajtszam != 0)
                {
                    if (adatok[i].Rajtszam < minrajtszam)
                    {
                        minrajtszam = adatok[i].Rajtszam;
                        mini = i;
                    }
                }

            }
            Console.WriteLine($"6.feladat: Hat. meg a legkisebb értékő rajtszám pilótájának nemzetiségét!" +
                $"\n\t válasz: {adatok[mini].Nemzetiseg}");

            int rajtsz = 0;
            int ossz = 0;


            Console.WriteLine("7.Feladat:");


            Dictionary<int, int> Dict = new Dictionary<int, int>();
            foreach (Adat adat in adatok)
            {
                if (adat.Rajtszam != 0)
                {
                    int kulcs = adat.Rajtszam;
                    if (Dict.ContainsKey(kulcs))
                    {
                        Dict[kulcs]++;
                    }
                    else
                    {
                        Dict.Add(adat.Rajtszam, 1);
                    } 
                }
            }
            foreach (var item in Dict)
            {
                if (item.Value > 1 )
                {
                    Console.Write($"{item.Key}, ");
                }
            }


            Console.ReadLine();
        }
    }
}
