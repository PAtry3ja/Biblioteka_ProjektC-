using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka_projekt_2._0
{
    internal class iotekViewModel
    {
        public class WypozyczWindowViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Ksiazka> _pobierzDostepne;
            private string _wybranaKsiazkaId;

            public ObservableCollection<Ksiazka> PobierzDostepne
            {
                get { return _pobierzDostepne; }
                set
                {
                    _pobierzDostepne = value;
                    OnPropertyChanged(nameof(PobierzDostepne));
                }
            }

            public string WybranaKsiazkaId
            {
                get { return _wybranaKsiazkaId; }
                set
                {
                    _wybranaKsiazkaId = value;
                    OnPropertyChanged(nameof(WybranaKsiazkaId));
                }
            }

            public WypozyczWindowViewModel(ObservableCollection<Ksiazka> dostepneKsiazki)
            {
                PobierzDostepne = dostepneKsiazki;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        }
    }
}
