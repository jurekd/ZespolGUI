using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    interface IZapisywalna
    {
        void ZapiszBin(string nazwa);
        Object OdczytajBin(string nazwa);
    }
}
