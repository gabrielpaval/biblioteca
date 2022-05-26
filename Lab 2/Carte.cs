using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect
{
    class Carte
    {
        private
        string nume;
        string autor;
        string editura;
        int AnAparitie;
        int NrExemplare;
        static int ID;
        //Constructor fara parametrii
        public Carte()
        {
            nume = string.Empty;
            autor = string.Empty;
            editura= string.Empty;
            AnAparitie = 0;
            NrExemplare = 0;
            ID=ID+1;
        }
        //Constructor cu parametrii
        public Carte(string _nume,string _autor, string _editura, int _AnAparitie, int _NrExemplare)
        {
            nume = _nume;
            autor = _autor;
            editura = _editura;
            AnAparitie = _AnAparitie;
            NrExemplare = _NrExemplare;
            ID = ID + 1;
        }
        public string Info()
        {
            return string.Format("Cartea cu numele {0}, scrisa de {1}, publicata la editura {2}, a aparut in anul {3} si o avem disponibila in {4} exemplare ( are ID-ul : {5}).", nume, autor, editura, AnAparitie, NrExemplare,ID);
        }
    }
}
