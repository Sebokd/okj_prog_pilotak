using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilotak
{
    class Adat
    {
        public string Név { get; set; }
        public DateTime SzulDatum { get; set; }
        public string Nemzetiseg { get; set; }
        public int Rajtszam { get; set; }

        public Adat(string sor)
        {
            string[] s = sor.Split(';');
            Név = s[0];
            SzulDatum = DateTime.Parse(s[1]);
            Nemzetiseg = s[2];
            if (s[3] == "")
            {
                Rajtszam = 0;
            }
            else
            {
                Rajtszam = int.Parse(s[3]);
            }
            
        }
    }
}
