using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Projekt
{
    public enum Płcie {
        [XmlEnum(Name = "kobieta")]
        K,
        [XmlEnum(Name = "Mężczyzna")]
        M };
    [Serializable]
    public abstract class Osoba : IEquatable<Osoba>
    {
        string imię;
        private string nazwisko;
        private DateTime dataUrodzenia;
        private string PESEL;
        private Płcie pleć;

        /// <summary>
        /// Właściwosć umożliwia dostęp do pola imię
        /// </summary>
        public string Imię
        {
            get { return imię; }
            set { imię = value; }
        }

        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }
        [XmlAttribute("PESEL")]
        public string PESEL1
        {
            get => PESEL;
            set
            {
                Regex wzorzec = new Regex("^\\d{11}$");
                if (wzorzec.IsMatch(value))
                    PESEL = value;
            }
        }
        public Płcie Pleć { get => pleć; set => pleć = value; }

        protected Osoba()
        {
        }

        public Osoba(string imię, string nazwisko)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
        }

        public Osoba(string imię, string nazwisko, string dataUrodzenia, string pESEL, Płcie pleć) : this(imię, nazwisko)
        {
            DateTime.TryParse(dataUrodzenia, out this.dataUrodzenia);
            this.PESEL1 = pESEL;
            this.pleć = pleć;
        }

        public int Wiek()
        {
            return DateTime.Today.Year - dataUrodzenia.Year;
        }

        public override string ToString()
        {
            return this.imię + " " + this.nazwisko + " " + this.PESEL + " lat: " + this.Wiek();
        }

        public bool Equals(Osoba other)
        {
            return this.PESEL == other.PESEL;
        }
    }

}
