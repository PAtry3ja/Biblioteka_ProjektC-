# Biblioteka_ProjektC
--------
W pierwszej części znajduje sie dokumentcja i opis kod projektu "Biblioteka_projekt_2.0"
W drugiej połowie znajduje sie opis interfejsu graficznego "Biblioteka_Gui_2.0"
-------

"Biblioteka_projekt_2.0"
----Klasa Osoba----
abstrakcyjna klasa na której podstawie tworzony jest Autor i Użytkownik 

-Właściwosci:

 public string Imie -- sprawdza czy imie zaczyna sie z duzej litery
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
 public string Nazwisko -- sprawdza czy nazwsiko zaczyna sie z duzej litery
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

Konstruktory:
*static Osoba()*: statyczny, ustawia id na 0
*public Osoba()*: domyślny, zwieksza id o 1
*public Osoba(string imie, string nazwisko)* : this():parametryczny ustawia imie i nazwisko
--

Metody:
public override string ToString()
{
    return $"{Imie} {Nazwisko}";
}

----Klasa Autor----
Klasa dziedzicząca po klasie Osoba. Zawiera interface IEquatable.

-Konstruktory:
*public Autor(): base()*: domyslny, dziedziczy po bazie
*public Autor(string imie, string nazwisko): base(imie, nazwisko)* : parametryczny, przyjmuje 
imie i nazwisko i dziedziczy je po bazie

-Metody:

public bool Equals(Autor other)*impementacja interface'u IEquatable
{
    return this.Nazwisko == other.Nazwisko;
}



----Klasa Użytownik----
Klasa dziedzicząca po osoba, korzysta z interface'u IComparable.

-Wlaściwości:
 public string Pesel -- sprawdza czy pesel ma 11 znaków
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
 public string NumerTelefonu -- sprawdza czy telefon ma 9 zmnaków
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
 public List<Ksiazka> WypozyczoneKsiazki { get; set; } -- ustawia Liste


-Konstruktory:
*public Uzytkownik(): base()* :Ustawia wypozyczoneKsiazki na nowa liste
*public Uzytkownik(string imie, string nazwisko, string pesel, string numerTelefonu): base(imie, nazwisko)* :ustawia
pesel ,numer telefonu, i liste wypozyczone ksiazki oraz dziedziczy imie i nazwiko po Osobie.


-Metody:
 public int CompareTo(Uzytkownik other) : metoda korzytająca z interface'u. Porównuje imie i nazwisko uzytkownika.



----Klasa Książka----
Klasa służąca do tworzenia Książek. Implementuje IEquatable oraz ICloneable

-Dodatkowe implementacje:
public enum EnumWydawnictwo { Literackie, PWN, Znak, Czarne, Agora } -- enum lista wydawnictw
public enum EnumKategoria { naukowa, biografia, biznes, romans, poradnik, kulinaria, historia, sport, kryminał, fantastyka } - enum lista Kategorii


-Właściwości: 
W tej klasie wszytskie właściwości przyjmuja i ustawiają podane dane.
 
 public static int Id { get; set; }
 public Autor AutorKsiazki { get; set; }
 public string Tytul { get => tytul; init => tytul = value; }
 internal EnumWydawnictwo Wydawnictwo { get => wydawnictwo; set => wydawnictwo = value; }
 internal HashSet<EnumKategoria> Kategorie { get => kategorie; }
 public bool Dostepnosc { get => dostepnosc; set => dostepnosc = value; }
 public string NumerKsiazki { get => numerKsiazki; set => numerKsiazki = value; }

--

-Konstruktory:

 *static Ksiazka()*: statyczny, ustawia id na 0;
 *public Ksiazka()*: domyślny, zwieksza id o 1, ustawia Dostepność na true, Kategorie na nowy Hashset, Wydawniscotow na nowy EnumWydawnictwo
 *public Ksiazka(string tytul, Autor autor, EnumWydawnictwo wydawnictwo): this()* : dziedziczy po konstruktorze domyślnym, ustawia tytul, autora, wydawnistwo na podane wartości. NumerKsązki ustawia na string o dlugosci 4 symboli korzystajacy z id.

-Metody:
 *public void DodajKategorie(EnumKategoria kategoria)* : dodaje kategorie do listy kategorie

public bool EqualsNumer(Ksiazka other) |
public bool EqualsAutor(Ksiazka other) |implementuja interface IEquatable i porównuja Numera i Autora
public bool Equals(Ksiazka other)      |
*public object Clone()*: tworzy klona
 
--


----Klasa Biblioteka----
Klasa w której znajduja sie wszytskie metody wykorzystywane w GUI.

-Własciwości:
public List<Uzytkownik> Uzytkownicy { get => uzytkownicy; set => uzytkownicy = value; } -- przyjmuje i ustawia liste

-Konstruktory:
 *public Biblioteka(string nazwa)* : przyjmuje i ustawia nazwe biblioteki. Dodatkowo usyawia listy asortyment i uzytkownicy na nowe puste listy


-Metody:

Dla Ksiązki:
*public void DodajKsiazke(Ksiazka ksiazka)* : Dodaje utworzona kasiązke do listy ksiażek
*public List<Ksiazka> WyswietlKsiazki()* : Wyswietla liste ksiażek
*public List<Ksiazka> PobierzDostepne()* : Pobiera dostepkne ksiązki  zwraca je jako liste
*public List<Ksiazka> PobierzPoTytule(string tytul)* : Pobiera książki o danym tytule i zwraca je jako liste
*public List<Ksiazka> PobierzPoAutorze(Autor n)* : Pobiera ksiazki po danym autorze i zwraca je jako liste.
*public Ksiazka ZnajdzKsiazkePoId(string id)* : Szuka ksiązki o danym Id i zwraca ją.

Dla uzytkowników:
*public void DodajUzytkownikaDoSystemu(Uzytkownik uzytkownik)*: dodaje utowrzonych uzytkownikow do listy uzytkoniwkow.
*public List<Uzytkownik> SortujUzytnowkiów()* : Zwraca posortowana liste uzytkonwikow
*public void UsunUzytkownika(string pesel)* : Usuwa uzytkownika z listy
*public Uzytkownik SzukajPesel(string pesel)* : Wyszukije uzytkoników po podanym peselu.
*public List<Ksiazka> WyświetlWypozyczoneKsiazki(Uzytkownik uzytkownik)* : Wyświetla wypozyczone kasiązki uzytkownika.

Wspolne:
*public string Wypozyczenie(Ksiazka ksiazka, string pesel)* : dodaje kasiązki do listy wypozyczoneKsiazki po numerze pesel
*public string Zwrot(Ksiazka ksiazka, string pesel)* : zwaraca ksiazke z listy po peselu

--

Dodatkowe metody:
 public void ZapiszDoPlikuXml(string nazwaPliku) : zapsuje do formatu XML
 public void OdczytajZPlikuXml(string nazwaPliku) : odczutuje plik XML

--



"Biblioteka_Gui_2.0"

----MainWindow----
Startowe okno aplikacji

-Konstruktory: 
*public MainWindow()* :  zczytuje plik XML oraz inicjalizuje biblioteke i przyciski

-Zdarzenia:
*private void Dodaj()* : dodaje wszyskie potrzebne obiekty, czyli ksiazki, autorów i uzytkowników.
*private void BtnZwroc_Click(object sender, RoutedEventArgs e)* : podpina okno ZwrocWindow do guzika Zwroc
*private void BtnWypozycz_Click(object sender, RoutedEventArgs e)*: podpina okno WypozyczWindow do guzika Wypozycz
*private void BtnSzukajKsiazki_Click(object sender, RoutedEventArgs e)* : podpina okno SzukajKsiazkiWindow do guzika Szukaj
*private void BtnUsunUzytkownika_Click(object sender, RoutedEventArgs e)* : podpina okno UsunUzytkownikaWindow do guzika Usun
*private void BtnSzukajUzytkownicy_Click(object sender, RoutedEventArgs e)*: podpina okno SzukajUzytkownikaWindow do guzika Szukaj
*private void BtnDodajUzytkownika_Click(object sender, RoutedEventArgs e)* : podpin aokno DodajUzytkownikaWindow do guzika Dodaj


----DodajUzytkownikaWindow----

-Konstruktor :
* public DodajUzytkownikaWindow(Biblioteka biblioteka)* : przypisuje do zmiennej biblioteka biblioteke z MainWindow. Inicjalizuje przycisk ZatwierdzDodanie.

-Zdarzenie:
 private void BtnZatwierdzDodanie_Click(object sender, RoutedEventArgs e)
 {
     string imie = txtImie.Text;
     string nazwisko = txtNazwisko.Text;
     string pesel = txtPesel.Text;
     string numerTelefonu = txtNrTelefonu.Text;

     if (biblioteka.Uzytkownicy.Any(u => u.Pesel.CompareTo(pesel) == 0))
     {
         MessageBox.Show("Użytkownik o podanym PESEL już istnieje.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
         return;
     }

     try
     {
         Uzytkownik nowyUzytkownik = new Uzytkownik(imie, nazwisko, pesel, numerTelefonu);

         biblioteka.DodajUzytkownikaDoSystemu(nowyUzytkownik);

         this.Close();
     }
     catch (NiepoprawneDaneOsoboweException ex)
     {
         MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
     }
 }

Inicjalizuje dodawanie uzytkownika. Sprawdza czy dany uzytkoniwnik juz istnieje po numerze pesel. Jezeli nie istnieje dodaje uzytkownika. Implementuje wyjątek o wprowadzeniu złych danych osobowych.


----SzukajUzytownikaWindow----

-Konstruktor:
 *public SzukajUzytkownikWindow(Biblioteka biblioteka, List<Uzytkownik> uzytkownicyList)* : inicjalizuje biblioteke z MainWindow oraz przyciski PokazWszytskich, WyszukajWypozyczone, SzukajPesel

-Zdarzenia:
*private void BtnPokazWszystkich_Click(object sender, RoutedEventArgs e)* : pokazuje liste wszytskich uzytkowników
* private void BtnWyszukajWypozyczone_Click(object sender, RoutedEventArgs e)*: Szuka czy uzytkonwnik o danym peselu ma jakies wypozyczone ksiazki, jesli tak to wyswietla je, jesli nie wysyła stosowny komunikat
*private void BtnSzukajPesel_Click(object sender, RoutedEventArgs e)*:Szuka uzytkownika o podanym peselu, wyswietla stosowny komunikat


----UsunUzytkownikaWindow----
-Konstruktor:
* public UsunUzytkownikaWindow(Biblioteka biblioteka)* :Inicjalizuje biblioteke z MainWindow oraz przycisk Usun.

-Zdarzenie: 

private void BtnUsun_Click(object sender, RoutedEventArgs e)
{
   
    string PeselDoUsuniecia = txtPesel.Text;
    try
    {
        biblioteka.UsunUzytkownika(PeselDoUsuniecia);
        this.Close();
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
Szuka uzytkownika po danym peselu i jesli taki uzytownik istnieje, usuwa go z listy.


----SzukajKsiazkaWindow----
-Konstruktor:
* public SzukajKsiazkaWindow(Biblioteka biblioteka, List<Ksiazka> dostepneKsiazki)* : Inicjalizuje biblioteke z MainWindow oraz przyciski PokazDostepne, SzukajPoTytule, SzukajPoID.

-Zdarzenia:
*private void BtnPokazDostepne_Click(object sender, RoutedEventArgs e)* : Wyswietla dostepne ksiazki, korzytsa z wcześniej napisanych metod
*private void BtnSzukajPoTytule_Click(object sender, RoutedEventArgs e)* : wyswietla ksiazki o danym tytule, korzytsa z wcześniej napisanych metod
*private void BtnSzukajPoID_Click(object sender, RoutedEventArgs e)* : Wyswietla ksiazki o danym ID, korzytsa z wcześniej napisanych metod

----WypozyczWindow----
-Konstruktor:
*public WypozyczWindow(Biblioteka biblioteka)* :Inicjalizuje biblioteke z MainWindow oraz przycisk Wypozycz.
-Zdarzenie:
*private void BtnWypozycz_Click(object sender, RoutedEventArgs e)
        {

            string idKsiazki = IDksiazki.Text;
            string peselUzytkownika = PodanyPesel.Text;

            Ksiazka ksiazka = biblioteka.ZnajdzKsiazkePoId(idKsiazki);
            string komunikat = biblioteka.Wypozyczenie(ksiazka, peselUzytkownika);

            MessageBox.Show(komunikat, "Wypożyczanie książki", MessageBoxButton.OK, MessageBoxImage.Information);
        }* 
Przypisuje wypozyczoną ksiazke danemu uzytkownikowi, korzysta w tym celu z wcześniej napisanych metod. Wyswietla stosowny komunikat.


----ZwrocWindow----
-Konstruktor:
*public ZwrocWindowxaml(Biblioteka biblioteka)*:nicjalizuje biblioteke z MainWindow oraz przycisk Zwroc.

-Zdarzenie:
*private void BtnZwroc_Click(object sender, RoutedEventArgs e)
{

    string idKsiazkiZ = IDzwrotu.Text;
    string peselUzytkownikaZ = PeselZwrotu.Text;

    Ksiazka ksiazka = biblioteka.ZnajdzKsiazkePoId(idKsiazkiZ);
    string komunikat = biblioteka.Zwrot(ksiazka, peselUzytkownikaZ);

    MessageBox.Show(komunikat, "Zqracanie książki", MessageBoxButton.OK, MessageBoxImage.Information);
}*
Usuwa wybrną książke z listy wypozyczonych książek użytkownika i zwraca sotsowny komunikat. Wykorzystuje napisane wcześniej metoedy._
