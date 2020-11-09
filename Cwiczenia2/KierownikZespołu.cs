using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    [Serializable]
    public class KierownikZespołu : Osoba, ICloneable
    {
        int doswiadczenie;
        //public int[] tab = { 1, 2, 3 };

        public KierownikZespołu() { }

        public KierownikZespołu(string imię, string nazwisko, int doswiadczenie) : base(imię,nazwisko)
        {
            this.Doswiadczenie = doswiadczenie;
        }

        public KierownikZespołu(string imię, string nazwisko, string dataUrodzenia, string pESEL, Płcie pleć, int doswiadczenie) : base(imię, nazwisko, dataUrodzenia, pESEL, pleć)
        {
            this.Doswiadczenie = doswiadczenie;
        }

        public int Doswiadczenie { get => doswiadczenie; set => doswiadczenie = value; }

        public object Clone()
        {
            //KierownikZespołu klon = new KierownikZespołu(this.Imię, this.Nazwisko, this.DataUrodzenia.ToString(),
            //    this.PESEL1, this.Pleć, this.doswiadczenie);
            //KierownikZespołu klon = new KierownikZespołu();
            //klon.Imię = this.Imię;
            //klon.tab = this.tab;


            KierownikZespołu klon = this.MemberwiseClone() as KierownikZespołu;
            return klon;
        }

        public override string ToString()
        {
            return base.ToString() + " doświadczenie: " + Doswiadczenie;
        }
    }
}
