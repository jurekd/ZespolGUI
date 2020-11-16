using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    class Program
    {
        static void Main()
        {
            //Osoba osoba1 = new Osoba("Jurek","Duda");
            CzłonekZespołu c1 = new CzłonekZespołu("Jan", "Nowak", "1980-01-01", "12345678971", Płcie.M,DateTime.Today,"programista");
            KierownikZespołu k = new KierownikZespołu("Adam", "Kierownik", "1980-01-01", "12345678971", Płcie.M, 20);
            Zespół z = new Zespół("zespół", k);
            z.DodajCzłonka(c1);
            z.DodajCzłonka(new CzłonekZespołu("Jan", "But", "1992-05-16", "92051613915", Płcie.M, new DateTime(2019, 6, 1), "programista"));
            z.DodajCzłonka(new CzłonekZespołu("Andrzej", "But", "1992-05-16", "92051613911", Płcie.M, new DateTime(2019, 6, 1), "programista"));

            #region demo
            //Console.WriteLine("Wyszukaj programistów");
            //List<CzłonekZespołu> programiści = z.WyszukajCzłonków("programista");
            //foreach (CzłonekZespołu programista in programiści)
            //    Console.WriteLine(programista);

            //KierownikZespołu k2 = k.Clone() as KierownikZespołu;
            //KierownikZespołu k2 = k.Clone() as KierownikZespołu;
            //k2.Imię = "Jurek";
            //Console.WriteLine(k);
            //Console.WriteLine(k2);

            //Zespół z2 = z.Clone() as Zespół;
            //z2.Kierownik.Imię = "Jurek";

            //Console.WriteLine(z);
            //Console.WriteLine(z2);


            //Console.WriteLine(z);
            //z.Sortuj();
            //Console.WriteLine(z);
            //z.SortujPoPESEL();
            //CzłonekZespołu cn = new CzłonekZespołu("Adam", "Rys", "1980-01-01", "12345678970", Osoba.Płcie.M, DateTime.Today, "programista");

            //Console.WriteLine(z.JestCzlonkiem(cn));

            //Console.WriteLine(z);
            #endregion
            Console.WriteLine(z);
            //z.ZapiszBin("zespol.bin");
            //Zespół z2 = z.OdczytajBin("zespol.bin") as Zespół;
            //Console.WriteLine(z2);
            Zespół.ZapiszXML("zespol.xml",z);
            //// Console.ReadLine();
            Zespół z2 = Zespół.OdczytajXML("zespol.xml");
            //Zespół.ZapiszJSON("zespol.json", z);
            Console.WriteLine("Odczytane z XML");
            Console.WriteLine(z2);
            //Console.ReadLine();

            //z2.ZapiszDoBazy();

            Zespół z3 = Zespół.OdczytajZBazy();
            Console.WriteLine("Odczytane z bazy");
            Console.WriteLine(z3);
            //Zespół.WypiszZespol();
        }
    }
}
