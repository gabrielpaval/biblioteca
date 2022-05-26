using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCarte(Carte s);
        List <Carte> GetCarti();
        void UpdateCarte(Carte carte,int index);
        Carte GetCarte(string nume, string autor);
        Carte GetCarteID(int id);
        List<Carte> GetCartiDisponibile();
    }
}
