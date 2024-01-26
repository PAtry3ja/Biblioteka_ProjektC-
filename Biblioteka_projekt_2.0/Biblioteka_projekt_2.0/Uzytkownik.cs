using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteka_projekt_2._0
{
    public interface IComparable<Uzytkownik>
    {
        int CompareTo(Uzytkownik other);
    }
    public class Uzytkownik : Osoba, IComparable<Uzytkownik>
    {
        string pesel;
        string numerTelefonu;
        List<Ksiazka> wypozyczoneKsiazki;

        #region właściwości 
        public string Pesel
        {
            get => pesel;
            init
            {
                if (Regex.IsMatch(value, @"^\d{11}$"))
                {
                    pesel = value;
                }
                else { throw new NiepoprawneDaneOsoboweException("Pesel musi składać się z jedenastu cyfr."); }
            }
        }
        public string NumerTelefonu
        {
            get => numerTelefonu;
            set
            {
                if (Regex.IsMatch(value, @"^\d{9}$"))
                {
                    numerTelefonu = value;
                }
                else { throw new NiepoprawneDaneOsoboweException("Numer telefonu musi składać się z dziewięciu cyfr."); }
            }
        }
        public List<Ksiazka> WypozyczoneKsiazki { get; set; }

        #endregion

        #region konstruktory 
        public Uzytkownik()
           : base()
        {
            WypozyczoneKsiazki = new List<Ksiazka>();
        }

        public Uzytkownik(string imie, string nazwisko, string pesel, string numerTelefonu)
            : base(imie, nazwisko)
        {
            Pesel = pesel;
            NumerTelefonu = numerTelefonu;
            WypozyczoneKsiazki = new List<Ksiazka>();
        }
        #endregion

        #region metody

        
        public int CompareTo(Uzytkownik other)
        {
            // Porównanie użytkowników na podstawie ich imion i nazwisk
            int result = string.Compare(this.Imie, other.Imie, StringComparison.Ordinal);

            if (result == 0)
            {
                // Jeśli imiona są takie same, porównujemy nazwiska
                result = string.Compare(this.Nazwisko, other.Nazwisko, StringComparison.Ordinal);
            }

            return result;
        }


        public override string ToString()
        {

            return $"{base.ToString()}, tel.:{NumerTelefonu} [PESEL: {Pesel}]";
        }
        #endregion


    }
}
