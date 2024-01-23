namespace Biblioteka_projekt_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Autor AnnaPrzykladowa = new Autor("Anna", "Przykładowa");
            Ksiazka ksiazka1 = new Ksiazka("Tytuł1", AnnaPrzykladowa, EnumWydawnictwo.Znak);

            ksiazka1.DodajKategorie(EnumKategoria.romans);
            ksiazka1.DodajKategorie(EnumKategoria.fantastyka);

            Console.WriteLine(ksiazka1);


            Biblioteka biblioteka = new Biblioteka("Moja Biblioteka");
            Autor BogusPrzykładowy = new Autor("Bogus", "Przykładowy");
            Ksiazka ksiazka2 = new Ksiazka("Tytuł2", BogusPrzykładowy, EnumWydawnictwo.Literackie);
            Ksiazka ksiazka3 = new Ksiazka("Tytuł3", BogusPrzykładowy, EnumWydawnictwo.Znak);

            ksiazka2.DodajKategorie(EnumKategoria.poradnik);
            Console.WriteLine(ksiazka2);
            ksiazka3.DodajKategorie(EnumKategoria.kulinaria);

            Console.WriteLine(ksiazka3);
            Uzytkownik uzytkownicy = new Uzytkownik();
            Uzytkownik uzytkownik1 = new Uzytkownik("Maciek", "Trzeci", "11111111111", "000000000");
            Uzytkownik uzytkownik2 = new Uzytkownik("Anna", "Druga", "22222222222", "111111111");
            biblioteka.DodajUzytkownikaDoSystemu(uzytkownik1);

            biblioteka.DodajKsiazke(ksiazka1);
            biblioteka.DodajKsiazke(ksiazka2);
            biblioteka.DodajKsiazke(ksiazka3);

            Console.WriteLine(biblioteka);
            Console.WriteLine("Szukanie ksiazek: ");
            Console.WriteLine(biblioteka.ZnajdzKsiazkePoId("0002")); //działa

            Console.WriteLine("Szukanie po autorze:");
            biblioteka.PobierzPoAutorze(BogusPrzykładowy);

            Console.WriteLine("Szukanie po tytule: ");
            biblioteka.PobierzPoTytule("Tytuł2"); 

            biblioteka.PobierzDostepne();

           // biblioteka.Wypozyczenie(ksiazka2, uzytkownik1); //działa            
            //uzytkownik1.WyświetlWypozyczoneKsiazki(); //działa

            biblioteka.PobierzDostepne();

            //biblioteka.Zwrot(ksiazka2, uzytkownik1);

            biblioteka.PobierzDostepne();


            biblioteka.ZapiszDoPlikuXml("biblioteka.xml");

            /*
             #region właściwości 
        #endregion

        #region konstruktory 
        #endregion

        #region metody
        #endregion
            
             */

        }
    }
}
