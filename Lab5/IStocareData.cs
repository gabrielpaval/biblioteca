using LibrarieModele;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IStocareData
    {
        void AddCarte(Carte s);
        Carte[] GetCarti(out int nrCarti);
        void UpdateCarte(Carte[] carti, int nrCarti);
    }
}
