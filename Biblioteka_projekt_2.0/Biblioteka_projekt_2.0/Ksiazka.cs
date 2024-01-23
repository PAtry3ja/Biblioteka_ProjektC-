using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka_projekt_2._0
{
    public class WrongAuthorException : Exception
    {
        public WrongAuthorException(string message) : base(message) { }
    }


    public enum EnumWydawnictwo { Literackie, PWN, Znak, Czarne, Agora }
    public enum EnumKategoria { naukowa, biografia, biznes, romans, poradnik, kulinaria, historia, sport, kryminał, fantastyka }
    public interface IEquatable<T>
    {
        bool Equals(T other);
    }
    [Serializable]
    public class Ksiazka : IEquatable<Ksiazka>, ICloneable<Ksiazka>
    {

        string tytul;
        Autor autorKsiazki;
        static int id;
        EnumWydawnictwo wydawnictwo;
        HashSet<EnumKategoria> kategorie; //używam HashSet, bo gwarantuje niepowtarzalność elementów
        bool dostepnosc;
        string numerKsiazki;


        #region właściwości 

        public static int Id { get; set; }
        public Autor AutorKsiazki { get; set; }
        public string Tytul { get => tytul; init => tytul = value; }
        internal EnumWydawnictwo Wydawnictwo { get => wydawnictwo; set => wydawnictwo = value; }
        internal HashSet<EnumKategoria> Kategorie { get => kategorie; }
        public bool Dostepnosc { get => dostepnosc; set => dostepnosc = value; }
        public string NumerKsiazki { get => numerKsiazki; set => numerKsiazki = value; }

        #endregion

        #region konstruktory

        static Ksiazka()
        {
            id = 0;
        }
        public Ksiazka()
        {
            id++;
            Wydawnictwo = new EnumWydawnictwo();
            kategorie = new HashSet<EnumKategoria>();
            Dostepnosc = true;

        }
        public Ksiazka(string tytul, Autor autor, EnumWydawnictwo wydawnictwo)
            : this()
        {
            Tytul = tytul;
            AutorKsiazki = autor;
            Wydawnictwo = wydawnictwo;
            NumerKsiazki = $"{id:D4}";
        }

        #endregion 

        #region metody

        public void DodajKategorie(EnumKategoria kategoria)
        {
            Kategorie.Add(kategoria);
        }


        public bool EqualsNumer(Ksiazka other)
        {
            return this.NumerKsiazki == other.NumerKsiazki;
        }
        public bool EqualsAutor(Ksiazka other)
        {
            return this.autorKsiazki == other.autorKsiazki;
        }
        public bool Equals(Ksiazka other)
        {
            throw new NotImplementedException();
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            string gatunki = string.Join(", ", Kategorie);

            return $"{numerKsiazki}: \"{Tytul}\" {AutorKsiazki} [{gatunki}]- Wydawnictwo {Wydawnictwo}  ";
        }


        #endregion
    }
}
