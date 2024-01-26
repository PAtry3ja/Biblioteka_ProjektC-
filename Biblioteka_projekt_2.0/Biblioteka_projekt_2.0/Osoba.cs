using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Biblioteka_projekt_2._0
{
  
        public class NiepoprawneDaneOsoboweException : Exception
        {
            public NiepoprawneDaneOsoboweException(string message) : base(message) { }
        }
        [Serializable]
        public abstract class Osoba
        {
            string imie;
            string nazwisko;
            static int id;
            


            #region właściwości 
            public string Imie
            {
                get => imie;
                set
                {
                    if (Regex.IsMatch(value, @"^[A-Z]"))
                    {
                        imie = value;
                    }
                    else { throw new NiepoprawneDaneOsoboweException("Imię musi być zapisane z dużej litery."); }
                }
            }
            public string Nazwisko
            {
                get => nazwisko;
                set
                {
                    if (Regex.IsMatch(value, @"^[A-Z]"))
                    {
                        nazwisko = value;
                    }
                    else { throw new NiepoprawneDaneOsoboweException("Nazwisko musi być zapisane z dużej litery."); }
                }
            }

            #endregion

            #region konstruktory 
            static Osoba()
            {
                id = 0;
            }
            public Osoba()
            {
                id++;
            }
            public Osoba(string imie, string nazwisko)
                : this()
            {
                Imie = imie;
                Nazwisko = nazwisko;

            }

            #endregion

            #region metody
            public override string ToString()
            {
                return $"{Imie} {Nazwisko}";
            }
            #endregion

        }
    

}
