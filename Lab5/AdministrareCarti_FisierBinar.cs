using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareCarti_FisierBinar : IStocareData
    {
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierBinar(string NumeFisier)
        {
            this.NumeFisier = NumeFisier;

        }

        public void AddCarte(Carte s)
        {
            throw new Exception("Optiunea AddStudent nu este implementata");
        }

        public Carte[] GetCarti(out int nrCarti)
        {
            throw new Exception("Optiunea GetCarti nu este implementata");
        }

        
        public void UpdateCarte(Carte[] carti, int nrCarti)
        {
            throw new NotImplementedException();
        }
    }
}
