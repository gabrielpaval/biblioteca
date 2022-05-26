using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect
{
    class Persoana
    {
        string nume;
        string prenume;
        int varsta;
        int NrCartiImprumutate;
        string NrTelefon;
        string AdresaMail;
        //Constructor fara parametrii
        public Persoana()
        {
            nume = string.Empty;
            prenume = string.Empty;
            varsta = 0;
            NrCartiImprumutate = 0;
            NrTelefon = string.Empty;
            AdresaMail = string.Empty;
        }
        //Constructor cu parametrii
        public Persoana(string _nume, string _prenume, int _varsta, int _NrCartiImprumutate, string _NrTelefon, string _AdresaMail)
        {
            nume= _nume;
            prenume = _prenume;
            varsta = _varsta;
            NrCartiImprumutate = _NrCartiImprumutate;
            NrTelefon = _NrTelefon;
            AdresaMail = _AdresaMail;
        }
        //Afisare info
        public string InfoPersoana()
        {
            return string.Format("{0} {1} are varsta {2} de ani, numarul de telefon {3}, adresa de mail {4} si a imprumutat {5} carti", nume, prenume, varsta, NrTelefon, AdresaMail, NrCartiImprumutate);
        }

    }
}
