using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect
{
    class Persoana
    {
        private string nume;
        private string prenume;
        private int varsta;
        private int NrCartiImprumutate;
        private string NrTelefon;
        private string AdresaMail;
        const int NrMaxCarti = 5;

        //Proprietati auto-implemented 
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public int nrCartiImprumutate { get; set; }
        public string nrTelefon { get; set; }
        public string adresaMail { get; set; }
        public string NumeComplet { get { return nume + " " + prenume; } }


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

        public Persoana(string sirr)
        {
            string[] buff = sirr.Split(',');
            nume = buff[0];
            prenume = buff[1];
            varsta = Convert.ToInt32(buff[2]);
            NrCartiImprumutate = Convert.ToInt32(buff[3]);
            NrTelefon = buff[4];
            AdresaMail = buff[5];
        }

        public string compara(Persoana p2)
        {
            if (this.NrCartiImprumutate > p2.NrCartiImprumutate)
                return string.Format("{0} a imprumutat mai multe carti decat: {1}", this.NumeComplet, p2.NumeComplet);
            else
                if (this.NrCartiImprumutate == p2.NrCartiImprumutate)
                return string.Format("{0} a imprumutat la fel de multe carti ca si: {1}", this.NumeComplet, p2.NumeComplet);
            else
                return string.Format("{0} a imprumutat mai putine carti decat: {1}", this.NumeComplet, p2.NumeComplet);
        }
       
        //Afisare info
        public string InfoPersoana()
        {
            return string.Format("{0} {1} are varsta {2} de ani, numarul de telefon {3}, adresa de mail {4} si a imprumutat {5} carti", nume, prenume, varsta, NrTelefon, AdresaMail, NrCartiImprumutate);
        }

    }
}
