using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{

    class PESELComparator : Comparer<CzłonekZespołu>
    {
        public override int Compare(CzłonekZespołu x, CzłonekZespołu y)
        {
            return x.PESEL1.CompareTo(y.PESEL1);
        }
    }
    [Serializable]

    public class CzłonekZespołu:Osoba,IComparable<CzłonekZespołu>
    {
        DateTime dataZapisu;
        string funkcja;

        public DateTime DataZapisu { get => dataZapisu; set => dataZapisu = value; }
        [XmlElement("FukcjaWZepsole")]
        public string Funkcja { get => funkcja; set => funkcja = value; }

        public CzłonekZespołu()
        { }

        public CzłonekZespołu(string imię, string nazwisko, DateTime dataZapisu, string funkcja):base(imię,nazwisko)
        {
            this.dataZapisu = dataZapisu;
            this.funkcja = funkcja;
        }

        public CzłonekZespołu(string imię, string nazwisko, string dataUrodzenia, string pESEL, Płcie pleć, DateTime dataZapisu, string funkcja) : base(imię,nazwisko,dataUrodzenia,pESEL,pleć)
        {
            this.dataZapisu = dataZapisu;
            this.Funkcja = funkcja;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return base.ToString()+" "+funkcja;
        }

        public int CompareTo(CzłonekZespołu other)
        {
            if (this.Nazwisko != other.Nazwisko) 
                return this.Nazwisko.CompareTo(other.Nazwisko);
            else
                return this.Imię.CompareTo(other.Imię);
        }
    }
}
