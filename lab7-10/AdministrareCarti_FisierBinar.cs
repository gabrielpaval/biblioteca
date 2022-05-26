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

        public List <Carte> GetCarti()
        {
            throw new Exception("Optiunea GetCarti nu este implementata");
        }

        public Carte GetCarte(string nume, string autor)
        {
            throw new Exception("Optiunea GetCarte nu este implementata");
        }

        public void UpdateCarte(Carte carte,int index)
        {
            throw new NotImplementedException();
        }
        public Carte GetCarteID(int id)
        {
            throw new Exception("Optiunea GetCarteId nu este implementata");
        }
        public List<Carte> GetCartiDisponibile()
        {
            List<Carte> carti = GetCarti();
            List<Carte> disponibile = new List<Carte>();
            foreach (Carte c in carti)
            {
                if (c.disponibilitate() == true)
                    disponibile.Add(c);
            }
            return disponibile;
        }
    }
}
