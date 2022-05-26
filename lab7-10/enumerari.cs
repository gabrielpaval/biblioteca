using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectForm2
{

    [Flags]
    public enum CodEroare
    {
        CORECT = 0,
        NUME_INCORECT = 1,
        AUTOR_INCORECT = 2,
        EDITURA_INCORECTA = 4,
        NREXEMPLARE_INCORECTE = 8,
        NO_GEN_CARTE = 16,
        SPECIFICATII = 32,
        AN_APARITIE = 64
    }
}

