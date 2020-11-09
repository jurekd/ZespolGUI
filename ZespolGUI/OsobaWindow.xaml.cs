using System;
using System.Globalization;
using System.Windows;
using Projekt;

namespace ZespolGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OsobaWindow.xaml
    /// </summary>
    public partial class OsobaWindow : Window
    {
        Osoba _osoba;
        public OsobaWindow()
        {
            InitializeComponent();
        }
        public OsobaWindow(Osoba osoba) : this()
        {
            _osoba = osoba;
            if (_osoba is KierownikZespołu || _osoba is CzłonekZespołu)
            {
                tbPESEL.Text = osoba.PESEL1;
                tbImie.Text = osoba.Imię;
                tbNazwisko.Text = osoba.Nazwisko;
                dpDataUrodz.Text = osoba.DataUrodzenia.ToString();
                cbPlec.Text = (osoba.Pleć == Płcie.K) ? "kobieta" : "mężczyzna";
            }
        }

        private void btAnuluj_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btZatwiedz_Click(object sender, RoutedEventArgs e)
        {
            if (tbPESEL.Text != "" && tbImie.Text != "" && tbNazwisko.Text != "")
            {
                _osoba.PESEL1 = tbPESEL.Text;
                _osoba.Imię = tbImie.Text;
                _osoba.Nazwisko = tbNazwisko.Text;
                //string[] fdate = { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" };
                //DateTime.TryParseExact(tbDataUrodz.Text, fdate, null, DateTimeStyles.None, out DateTime
                //date);
                if (dpDataUrodz.SelectedDate != null)
                    _osoba.DataUrodzenia = (DateTime)dpDataUrodz.SelectedDate;
                else
                { 
                    MessageBox.Show("Wpisz prawidłową datę");
                    return;
                }
                _osoba.Pleć = (cbPlec.Text == "kobieta") ? Płcie.K : Płcie.M;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
