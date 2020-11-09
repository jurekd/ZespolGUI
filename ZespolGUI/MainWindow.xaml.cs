using System.Collections.ObjectModel;
using System.Windows;
using Projekt;


namespace ZespolGUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zespół zespol = new Zespół();
        ObservableCollection<CzłonekZespołu> lista;
        public MainWindow()
        {
            InitializeComponent();

            zespol = Zespół.OdczytajXML("zespol.XML") as Zespół;
            if (zespol != null)
            {
                lista = new ObservableCollection<CzłonekZespołu>(zespol.Członkowie);
                lbCzlonkowie.ItemsSource = lista;
                tbNazwa.Text = zespol.Nazwa;
                tbKierownik.Text = zespol.Kierownik.ToString();
            }
        }

        private void btZmien_Click(object sender, RoutedEventArgs e)
        {
            OsobaWindow osoba = new OsobaWindow(zespol.Kierownik);
            osoba.ShowDialog();
            if(osoba.DialogResult==true)
            {
                tbKierownik.Text = zespol.Kierownik.ToString();
            }

        }

        private void btDodaj_Click(object sender, RoutedEventArgs e)
        {
            CzłonekZespołu cz = new CzłonekZespołu();
            OsobaWindow okno = new OsobaWindow(cz);
            okno.ShowDialog();
            zespol.DodajCzłonka(cz); //dodajemy członka
            lista.Add(cz);
        }

        private void btUsun_Click(object sender, RoutedEventArgs e)
        {
            int zaznaczony = lbCzlonkowie.SelectedIndex;
            if (zaznaczony >= 0)
            {
                lista.RemoveAt(zaznaczony);
                zespol.Członkowie.RemoveAt(zaznaczony);
            }
        }

        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                zespol.Nazwa = tbNazwa.Text;
                Zespół.ZapiszXML(filename,zespol);
            }
        }
    }
}
