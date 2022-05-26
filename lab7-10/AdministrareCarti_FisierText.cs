using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModele;

namespace NivelAccesDate
{
    public class AdministrareCarti_FisierText : IStocareData
    {
        private const int PAS_ALOCARE = 10;
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();

            //liniile de mai sus pot fi inlocuite cu linia de cod urmatoare deoarece
            //instructiunea 'using' va apela sFisierText.Close();
            //using (Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }
        /*public void AddCarte(Carte s)
        {
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversieLaSir_PentruFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }
        */
        /*
        public Carte[] GetCarti(out int nrCarti)
        {
            Carte[] carti = new Carte[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrCarti = 0;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        carti[nrCarti++] = new Carte(line);
                        if (nrCarti == PAS_ALOCARE)
                        {
                            Array.Resize(ref carti, nrCarti + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return carti;
        }*/

        public List <Carte> GetCarti()
        {
            List <Carte> carti = new List <Carte> () ;

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Carte c = new Carte(line);
                        carti.Add(c);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return carti;
        }

        public Carte GetCarte(string nume, string autor)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Carte carte = new Carte(line);
                        if (carte.Nume.Equals(nume) && carte.Autor.Equals(autor))
                            return carte;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }


        public Carte GetCarteID(int id)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Carte pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Carte carte = new Carte(line);
                        if (carte.IDcarte== id)
                            return carte;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }



        /*
        public void UpdateCarte(Carte[] carti, int nrCarti)
        {
            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier))
                {
                    for (int i = 0; i < nrCarti; i++)
                    {
                        swFisierText.WriteLine(carti[i].ConversieLaSir_PentruFisier());
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }*/

        public void UpdateCarte(Carte CarteActualizat,int index)
        {
            List <Carte> carti = GetCarti();
            bool actualizareCuSucces = false;

            try
            {
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier))
                {
                    foreach (Carte car in carti)
                    {
                        if (car.IDcarte == index)
                          swFisierText.WriteLine(CarteActualizat.ConversieLaSir_PentruFisier());
                       
                        else
                           swFisierText.WriteLine(car.ConversieLaSir_PentruFisier());
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        private int GetId()
        {
            int IdCarte = 1;
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Carte c = new Carte(line);
                        IdCarte = c.IDcarte + 1;
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return IdCarte;
        }

        public void AddCarte(Carte c)
        {
            c.IDcarte = GetId();
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(c.ConversieLaSir_PentruFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public List<Carte> GetCartiDisponibile()
        {
            List<Carte> carti = GetCarti();
            List<Carte> disponibile = new List<Carte>();
            foreach ( Carte c in carti)
            {
                if (c.disponibilitate() == true)
                    disponibile.Add(c);
            }
            return disponibile;
        }
    }

}

