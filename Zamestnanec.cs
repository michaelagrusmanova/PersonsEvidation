using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolekceAListBoxy
{
    public class Zamestnanec:Osoba
    {
        int _Plat { get; set; }

        public Zamestnanec(string jmeno, string pohlavi, int plat) : base (jmeno, pohlavi)
        {
            this._Plat = plat;
        }

        public override string ToString()
        {
            return ("Jméno: " + _Jmeno + ", pohlaví: " + _Pohlavi + ", plat: " + _Plat);
        }
    }
}
