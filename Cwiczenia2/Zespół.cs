using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    /// <summary>
    /// Klasa Zespół opisuje zespół projektowy.
    /// </summary>
    [Serializable]
    [XmlRoot("ZespółProjektowy")]
    public class Zespół : ICloneable,IZapisywalna
    {
        [Key]
        public int zespolId { get; set; }
        string nazwa;
        KierownikZespołu kierownik;
        private List<CzłonekZespołu> członkowie;
        int liczbaCzłonków;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public virtual KierownikZespołu Kierownik { get => kierownik; set => kierownik = value; }
        public int LiczbaCzłonków { get => liczbaCzłonków; set => liczbaCzłonków = value; }
        public virtual List<CzłonekZespołu> Członkowie { get => członkowie; set => członkowie = value; }

        public Zespół()
        {
            nazwa = "";
            kierownik = null;
            Członkowie = new List<CzłonekZespołu>();
        }

        public Zespół(string nazwa, KierownikZespołu kierownik):this()
        {
            this.nazwa = nazwa;
            this.kierownik = kierownik;
        }
        /// <summary>
        /// Dodaje członka do zespołu.
        /// </summary>
        /// <param name="członek">
        /// obiekt CzłonekZespołu
        /// </param>
        public void DodajCzłonka(CzłonekZespołu członek)
        {
            this.Członkowie.Add(członek);
            liczbaCzłonków++;
        }

        public void UsunCzlonka(CzłonekZespołu członek)
        {
            Członkowie.Remove(członek);
        }

        public List<CzłonekZespołu> WyszukajCzłonków(string funkcja)
        {
            //List<CzłonekZespołu> wynik = new List<CzłonekZespołu>();
            //foreach (CzłonekZespołu członekZespołu in członkowie)
            //    if (członekZespołu.Funkcja == funkcja)
            //        wynik.Add(członekZespołu);
            //return wynik;
            return Członkowie.FindAll(c => c.Funkcja.ToLower() == funkcja.ToLower());
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("nazwa: " + nazwa +"\n");
            stringBuilder.AppendLine("kierownik: " + kierownik);
            foreach (CzłonekZespołu członek in Członkowie)
                stringBuilder.AppendLine(członek.ToString());
            return stringBuilder.ToString();
        }

        public object Clone()
        {
            Zespół klon = this.MemberwiseClone() as Zespół;
            klon.Kierownik = this.Kierownik.Clone() as KierownikZespołu;
            klon.Członkowie = new List<CzłonekZespołu>();
            foreach (CzłonekZespołu czlonek in Członkowie)
                klon.Członkowie.Add(czlonek.Clone() as CzłonekZespołu);
            return klon;
        }

        public void Sortuj()
        {
            Członkowie.Sort();
        }

        public void SortujPoPESEL()
        {
            Członkowie.Sort(new PESELComparator());
        }

        public bool JestCzlonkiem(CzłonekZespołu inny)
        {
            //foreach (CzłonekZespołu czlonek in członkowie)
            //    if (czlonek.Equals(inny))
            //        return true;
            //return false;

            return Członkowie.Exists(x => x.Equals(inny));
;        }

        public void ZapiszBin(string nazwa)
        {
            //BinaryFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(nazwa, FileMode.Create);
            //formatter.Serialize(stream, this);
            //stream.Close();

            using (Stream stream = new FileStream(nazwa, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }
        }

        public object OdczytajBin(string nazwa)
        {
            object wynik = null;
            using (Stream stream = new FileStream(nazwa, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                wynik = formatter.Deserialize(stream);
            }
            return wynik;
        }

        public static void ZapiszXML(string nazwa, Zespół z)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Zespół));
                serializer.Serialize(writer, z);
            }
        }

        public static void ZapiszJSON(string nazwa, Zespół z)
        {
            using (StreamWriter writer = new StreamWriter(nazwa))
            {
                string wynik = JsonSerializer.Serialize(z);
                writer.Write(wynik);
            }
        }

        public static Zespół OdczytajXML(string nazwa)
        {
            using (StreamReader reader = new StreamReader(nazwa))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Zespół));
                return serializer.Deserialize(reader) as Zespół;
            }
        }

        public void ZapiszDoBazy()
        {
            using (var db = new MyContext())
            {
                db.zespolBaza.Add(this);
                db.SaveChanges();
            }
        }

        public static Zespół OdczytajZBazy()
        {
            Zespół z = null;
            using (var db = new MyContext())
            {
                z = db.zespolBaza.Include(z => z.Kierownik).Include(z => z.Członkowie).FirstOrDefault();
            }
            return z;
        }

        public static void WypiszZespol()
        {
            using (var db = new MyContext())
            {
                List<Zespół> query = db.zespolBaza.Include(z => z.Kierownik).Include(z=>z.Członkowie).ToList<Zespół>();

                foreach (Zespół item in query)
                {
                    Console.WriteLine(item);
                }
            }
        }


    }
}
