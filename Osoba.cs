using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace KolekceAListBoxy
{
    public class Osoba : IComparable
    {
        public string _Jmeno { get; set; }
        public string _Pohlavi { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Osoba otherOsoba = obj as Osoba;
            if (otherOsoba != null)
                return this._Jmeno.CompareTo(otherOsoba._Jmeno);
            else
                throw new ArgumentException("Objekt nemá jméno.");
        }
        public Osoba(string jmeno, string pohlavi)
        {
            this._Jmeno = jmeno;
            this._Pohlavi = pohlavi;
        }

        public Osoba()
        {

        }

       public override string ToString()
        {
            return ("Jméno: " + _Jmeno + ", pohlaví: " + _Pohlavi);
        }
    }
}
