using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka_projekt_2._0
{
    public class Autor : Osoba, IEquatable<Autor>
    {
        public Autor()
            : base() { }


        public Autor(string imie, string nazwisko)
            : base(imie, nazwisko) { }

        public bool Equals(Autor other)
        {
            return this.Nazwisko == other.Nazwisko;
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
