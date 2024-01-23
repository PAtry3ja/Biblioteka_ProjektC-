using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteka_projekt_2._0
{
    public class Biblioteka
    {
        string nazwa;
        List<Ksiazka> asortyment;
        List<Uzytkownik> uzytkownicy;



        #region właściwości 
        public List<Uzytkownik> Uzytkownicy { get => uzytkownicy; set => uzytkownicy = value; }
        #endregion

        #region konstruktory 
        public Biblioteka(string nazwa)
        {
            this.nazwa = nazwa;
            this.asortyment = new List<Ksiazka>();
            this.Uzytkownicy = new List<Uzytkownik>();
        }
        #endregion

        #region metody
        public void DodajKsiazke(Ksiazka ksiazka)
        {
            asortyment.Add(ksiazka);
        }

        public List<Ksiazka> WyswietlKsiazki()
        {
            return asortyment;
        }
        public void DodajUzytkownikaDoSystemu(Uzytkownik uzytkownik)
        {
            Uzytkownicy.Add(uzytkownik);
        }
        public string Wypozyczenie(Ksiazka ksiazka, string pesel)
        {
            Uzytkownik uzytkownik = Uzytkownicy.FirstOrDefault(u => u.Pesel == pesel);

            if (uzytkownik != null && asortyment.Contains(ksiazka))
            {
                if (uzytkownik.WypozyczoneKsiazki.Count() < 5 && ksiazka.Dostepnosc == true)
                {
                    uzytkownik.WypozyczoneKsiazki.Add(ksiazka);
                    ksiazka.Dostepnosc = false;
                    return $"Książka '{ksiazka.Tytul}' została wypożyczona przez {uzytkownik.Imie} {uzytkownik.Nazwisko}.";
                }
                else if (uzytkownik.WypozyczoneKsiazki.Count() < 5 && ksiazka.Dostepnosc != true)
                {
                    return "Książka nie jest dostępna do wypożyczenia.";
                }
                else if (uzytkownik.WypozyczoneKsiazki.Count() >= 5 && ksiazka.Dostepnosc == true)
                {
                    return "Nie można mieć wypożyczonych więcej niż 5 książek.";
                }
            }
            else
            {
                return "Użytkownik bądź książka nie są zarejestrowane w systemie.";
            }
            return "nieznany bład";
        }

        public string Zwrot(Ksiazka ksiazka, string pesel)
        {
            Uzytkownik uzytkownik = Uzytkownicy.FirstOrDefault(u => u.Pesel == pesel);

            if (uzytkownik != null && uzytkownik.WypozyczoneKsiazki.Contains(ksiazka))
            {
                uzytkownik.WypozyczoneKsiazki.Remove(ksiazka);
                ksiazka.Dostepnosc = true;

                return $"Książka '{ksiazka.Tytul}' została zwrócona przez {uzytkownik.Imie} {uzytkownik.Nazwisko}.";
            }
            else
            {
                return "Podany użytkownik bądź książka nie są zarejestrowane w systemie lub książka nie jest wypożyczona przez tego użytkownika.";
            }
        }

        public List<Ksiazka> PobierzDostepne()
        {
            return asortyment.Where(k => k.Dostepnosc).ToList();
        }

        public List<Ksiazka> PobierzPoTytule(string tytul)
        {
            return asortyment.Where(k => k.Tytul == tytul).ToList();
        }

        public List<Ksiazka> PobierzPoAutorze(Autor n)
        {
            return asortyment.Where(ksiazka => ksiazka.AutorKsiazki.Equals(n)).ToList();
        }

        public Ksiazka ZnajdzKsiazkePoId(string id)
        {
            return asortyment.FirstOrDefault(ksiazka => ksiazka.NumerKsiazki == id);
        }

        public List<Uzytkownik> SortujUzytnowkiów()
        {
            Uzytkownicy.Sort((u1, u2) => string.Compare(u1.Imie, u2.Imie));
            return Uzytkownicy;
        }

        public void UsunUzytkownika(string pesel)
        {
            if (pesel.Length != 11)
            {
                throw new Exception("Niepoprawny pesel.");
            }
            Uzytkownicy.RemoveAll(uz => uz.Pesel == pesel);
        }
        public Uzytkownik SzukajPesel(string pesel)
        {
            return uzytkownicy.FirstOrDefault(p => p.Pesel == pesel);
        }
        public List<Uzytkownik> WyswietlUzytkownikow()
        {
            return uzytkownicy;
        }
        public List<Ksiazka> WyświetlWypozyczoneKsiazki(Uzytkownik uzytkownik)
        {
            if (uzytkownik != null && uzytkownik.WypozyczoneKsiazki.Any())
            {
                Console.WriteLine($"Lista wypożyczonych książek przez użytkownika {uzytkownik.Imie} {uzytkownik.Nazwisko}:");
                foreach (var ksiazka in uzytkownik.WypozyczoneKsiazki)
                {
                    Console.WriteLine(ksiazka.ToString());
                }
                return uzytkownik.WypozyczoneKsiazki.ToList();
            }
            else
            {
                Console.WriteLine("Użytkownik nie ma żadnych wypożyczonych książek.");
                return new List<Ksiazka>();
            }
        }
        public override string ToString()
        {
            string ksiazkiInfo = string.Join("\n", asortyment.Select(k => k.ToString()));
            return $"Asortyment biblioteki {nazwa}:\n{ksiazkiInfo}";
        }
        #endregion
        public void ZapiszDoPlikuXml(string nazwaPliku)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Ksiazka>));

                using (TextWriter writer = new StreamWriter(nazwaPliku))
                {
                    serializer.Serialize(writer, asortyment);
                }

                Console.WriteLine("Zapisano dane do pliku XML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas zapisu do pliku XML: {ex.Message}");
            }
        }

        public void OdczytajZPlikuXml(string nazwaPliku)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Ksiazka>));

                using (TextReader reader = new StreamReader(nazwaPliku))
                {
                    asortyment = (List<Ksiazka>)serializer.Deserialize(reader);
                }

                Console.WriteLine("Odczytano dane z pliku XML.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd podczas odczytu z pliku XML: {ex.Message}");
            }
        }
    }
}
