using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Carte
    {
        private const string SEPARATOR_AFISARE = " ";
        private const char SEPARATOR_PRINCIPAL_FISIER = ',';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        public string Nume { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public int AnAparitie { get; set; }
        public GENCARTE GenCarte;
        public int NrExemplare { get; set; }
        public int IDcarte { get; set; }
        public static int ID;

        public DateTime DataActualizare { get; set; }

        public bool Disponibil;
       // public List<string> Specificatii { get; set; }
        public SPECIFICATII Specificatii;
        //Constructor fara parametrii
        public Carte()
        {
            Nume = string.Empty;
            Autor = string.Empty;
            Editura = string.Empty;
            GenCarte = GENCARTE.Copii;
            AnAparitie = 0;
            NrExemplare = 0;

            IDcarte = ID;
            ID = ID + 1;
            DataActualizare = DateTime.Now;
        }

        public bool disponibilitate()
        {
            if (NrExemplare == 0)
                Disponibil = false;
            else
               Disponibil = true;
            return Disponibil;
        }

        //public string SpecificatiiAsString
        //{
        //    get
        //    {
        //        string sinPlus = string.Empty;

        //        foreach (string opt in Specificatii)
        //        {
        //            if (sinPlus != string.Empty)
        //            {
        //                sinPlus += SEPARATOR_SECUNDAR_FISIER;
        //            }
        //            sinPlus += opt;
        //        }

        //        return sinPlus;
        //    }
        //}



        //Constructor cu 3 parametrii
        public Carte(string _nume, string _autor, string _editura)
        {
            Nume = _nume;
            Autor = _autor;
            Editura = _editura;
            DataActualizare = DateTime.Now;
        }
        //Constructor cu parametrii 2
        public Carte(string _nume, string _autor, string _editura, int _AnAparitie, int _NrExemplare, int n,int specificatii)
        {
            Nume = _nume;
            Autor = _autor;
            Editura = _editura;
            AnAparitie = _AnAparitie;
            NrExemplare = _NrExemplare;
            IDcarte = ID;
            ID = ID + 1;
            GenCarte = (GENCARTE)(n);
            Specificatii = (SPECIFICATII)specificatii;
            DataActualizare = DateTime.Now;
        }
        //Constructor care primeste un sir
        //public Carte(string sirr)
        //{
        //    string[] buff = sirr.Split(',');
        //    Nume = buff[0];
        //    Autor = buff[1];
        //    Editura = buff[2];
        //    AnAparitie = Convert.ToInt32(buff[3]);
        //    NrExemplare = Convert.ToInt32(buff[4]);
        //    IDcarte = Convert.ToInt32(buff[5]);
        //}

        public string ComparaCarte(Carte c2)
        {
            if (this.NrExemplare > c2.NrExemplare)
                return string.Format("Cartea cu numele {0} si ID-ul {1} este in mai multe exemplare ({2})", this.Nume, this.IDcarte, this.NrExemplare);
            else
            {
                if (this.NrExemplare == c2.NrExemplare)
                { return string.Format("Cele 2 carti sunt in acelasi numar de exemplare ({0})", this.NrExemplare); }
                else
                { return string.Format("Cartea cu numele {0} si ID-ul {1} este in mai multe exemplare ({2})", c2.Nume, c2.IDcarte, c2.NrExemplare); }
            }
        }

        public bool CautareGenCarte(int opt)
        {
            if (this.GenCarte == (GENCARTE)opt)
            {
                return true;
            }
            else
                return false;
        }

        public bool CautareNume(string _nume)
        {
            if (this.Nume == _nume)
                return true;
            return false;
        }

        public Carte(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ToString()
            IDcarte = Convert.ToInt32(dateFisier[(int)CampuriCarte.ID]);
            Nume = dateFisier[(int)CampuriCarte.NUME];
            Autor = dateFisier[(int)CampuriCarte.AUTOR];
            Editura = dateFisier[(int)CampuriCarte.EDITURA];
            AnAparitie = Int32.Parse(dateFisier[(int)CampuriCarte.ANAPARITIE]);
            NrExemplare = Int32.Parse(dateFisier[(int)CampuriCarte.NREXEMPLARE]);
            GenCarte = (GENCARTE)Convert.ToInt32(dateFisier[(int)CampuriCarte.GEN]);
            Specificatii = (SPECIFICATII)Convert.ToInt32(dateFisier[(int) CampuriCarte.SPECIFICATII  ]);
           
        }


        public string Info()
        {
            return string.Format("{0} {1} {2} {3} {4} exemplare ( are ID-ul : {5}).", Nume, Autor, Editura, AnAparitie, NrExemplare, IDcarte);
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}", ',',IDcarte, Nume, Autor, Editura, AnAparitie, NrExemplare,Convert.ToInt32( GenCarte), Convert.ToInt32(Specificatii), DataActualizare);
        }
    }
}
