using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
namespace LibrarieModele
{
    public enum GENCARTE
    {
        GenCarteInexistent = 0,
        Copii = 1,
        Fictiune = 2,
        Biografii = 3,
        Specialitate = 4,
    };

    public enum STATUT
    {
        Elev = 1,
        Student = 2,
        Angajat = 3,
        Pensionar = 4,
    };

    [Flags]
    public enum SPECIFICATII
    {
        ImaginiColorate = 1,
        CopertiCartonate = 2,
        CopertiNormale = 4,
    }

    public enum CampuriCarte
    {
        ID = 0,
        NUME = 1,
        AUTOR = 2,
        EDITURA = 3,
        ANAPARITIE = 4,
        NREXEMPLARE=5,
        GEN = 6,
        SPECIFICATII = 7,
    };







}
