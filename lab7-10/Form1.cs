using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using NivelAccesDate;

namespace proiectForm2
{
    public partial class Form1 : Form
    {
        IStocareData adminCarti;
        public List<string> specificatiiSelectate = new List<string>();
        public Form1()
        {
            InitializeComponent();
            adminCarti = StocareFactory.GetAdministratorStocare();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            ResetCuloareEtichete();
            CodEroare codValidare = Validare(txtNume.Text, txtAutor.Text, txtEditura.Text, txtNrExemplare.Text,cmbAnAparitie.Text);
            int specificatii = validareSpecificatii();
            if (codValidare != CodEroare.CORECT )
            {
                MarcheazaControaleCuDateIncorecte(codValidare);
            }
            else
            {
                Carte c = new Carte(txtNume.Text, txtAutor.Text, txtEditura.Text);
                c.AnAparitie = Int32.Parse(cmbAnAparitie.Text);
                c.GenCarte = GetGenCarteSelectat();
                c.NrExemplare = Convert.ToInt32(txtNrExemplare.Text);
                c.Specificatii = (SPECIFICATII)specificatii;
                //c.Specificatii= new List<string>();
                //c.Specificatii.AddRange(specificatiiSelectate);
                c.Disponibil = c.disponibilitate();
                c.DataActualizare = DateTime.Now;
                adminCarti.AddCarte(c);
                MessageBox.Show("Cartea a fost adaugata", "Adaugare carte");

                //resetarea controalelor pentru a introduce datele unui student nou
                ResetareControale();
            }
        }


        public void btnAfisare_Click(object sender, EventArgs e)
        {

            List<Carte> carti = adminCarti.GetCarti();

            AdaugaCartiInControlListbox(carti);
        }

        public void AdaugaCartiInControlListbox(List<Carte> carti)
        {
            lstAfisare.Items.Clear();

            //var antetTabel = String.Format("{0,-5}{1,-10}{2,0}{3,15}{4,15}{5,15}{6,15}{7,15}\n", "Id", "Nume", "Autor", "Editura", "An aparitie", "Nr exemplare", "Gen", "Specificatii");
            //lstAfisare.Items.Add(antetTabel);

            foreach (Carte c in carti)
            {
                const string Format = "{0,-5}{1,-10}{2,0}{3,15}{4,15}{5,15}{6,20}{7,30}\n";
                var linieTabel = string.Format(Format, c.IDcarte, c.Nume, c.Autor, c.Editura, c.AnAparitie.ToString(), c.NrExemplare.ToString(), c.GenCarte.ToString(), c.Specificatii);
                lstAfisare.Items.Add(linieTabel);
            }


            ////personalizare sursa de date
            ////var antetTabel = String.Format("{0,-5}{1,-35}{2,20}{3,10}\n", "Id", "Nume Prenume", "ProgramStudiu", "Medie");
            ////lstAfisare.Items.Add(antetTabel);

            //foreach (Carte c in carti)
            //{
            //    //pentru a adauga un obiect de tip Student in colectia de Items a unui control de tip ListBox, 
            //    // clasa Student trebuie sa implementeze metoda ToString() specificand cuvantul cheie 'override' in definitie
            //    //pentru a arata ca metoda ToString a clasei de baza (Object) este suprascrisa
            //    lstAfisare.Items.Add(c);


            //    //personalizare sursa de date
            //    //var linieTabel = String.Format("{0,-5}{1,-35}{2,20}{3,10}\n", s.IdStudent, s.NumeComplet, s.ProgramSTD.ToString(), s.Media.ToString());
            //    //lstAfisare.Items.Add(linieTabel);
            //}
        }


        private void AdaugaCartiInControlDataGridView(List<Carte> carti)
        {
            //reset continut control DataGridView
            dataGridCarti.DataSource = null;

            //!!!! Controlul de tip DataGridView are ca sursa de date lista de obiecte de tip Student !!!
            //dataGridStudenti.DataSource = studenti;

            //personalizare sursa de date
            dataGridCarti.DataSource = carti.Select(c => new { c.IDcarte, c.Nume, c.Autor, c.Editura, c.GenCarte, Specificatii = string.Join(",", c.Specificatii), c.AnAparitie, c.NrExemplare, c.DataActualizare }).ToList();
        }


        private void btnCauta_Click(object sender, EventArgs e)
        {
            List<Carte> carti = adminCarti.GetCarti();
            bool ok = false;
            lstAfisare.Items.Clear();
            foreach (Carte c in carti)
            {
                if (c.Nume == txtNume.Text && c.Autor == txtAutor.Text)
                {
                    lstAfisare.Items.Add(c.ConversieLaSir_PentruFisier());
                    ok = true;
                }
            }
            if (ok == true)
                lblCauta.Text = "Cartea dorita a fost gasita";
            else
                lblCauta.Text = "Ne pare rau. Nu am gasit cartea dorita.";


        }
        private GENCARTE GetGenCarteSelectat()
        {
            if (rdbCopii.Checked)
                return GENCARTE.Copii;
            if (rdbSpecialitate.Checked)
                return GENCARTE.Specialitate;
            if (rdbFictiune.Checked)
                return GENCARTE.Fictiune;
            if (rdbBiografii.Checked)
                return GENCARTE.Biografii;
            return GENCARTE.GenCarteInexistent;
        }

        private int validareSpecificatii()
        {
            int rezultat = 0;
            if (ckbColorat.Checked == true)
                rezultat += 1;
            if (ckbCopertiCartonate.Checked == true)
                rezultat += 2;
            if (ckbCopertiNormale.Checked == true)
                rezultat += 4;
            return rezultat;
        }
        private void btnModifica_Click(object sender, EventArgs e)
        {
            int index = lstAfisare.SelectedIndex + 1;
            Carte c = adminCarti.GetCarteID(index);
            if (c is null)
            {
                MessageBox.Show("Nu ati selectat nicio carte", "Modifica");
            }
            c.DataActualizare = DateTime.Now;
            FormModificare f = new FormModificare();
            f.m_carte = c;
            f.frmPrincipala = this;
            f.Show();
        }

        private void btnNrTotal_Click(object sender, EventArgs e)
        {
            List<Carte> carti = adminCarti.GetCarti();
            int numarexemplare = 0;
            foreach (Carte c in carti)
            {
                numarexemplare += c.NrExemplare;
            }
            MessageBox.Show("Numarul total de carti din biblioteca: " + Convert.ToString(numarexemplare), "Biblioteca total");
        }

        private void CodEroareCarte(int opt)
        {
            switch (opt)
            {
                case 1:
                    lblNume.ForeColor = Color.Red;
                    break;
                case 2:
                    lblAutor.ForeColor = Color.Red;
                    break;
                case 3:
                    lblEditura.ForeColor = Color.Red;
                    break;
                case 4:
                    lblGenCarte.ForeColor = Color.Red;
                    break;
                case 5:
                    lblNrExemplare.ForeColor = Color.Red;
                    break;
            }
        }

        private CodEroare Validare(string nume, string autor, string editura, string nrexemplare, string anaparitie)
        {
            CodEroare rezultatValidare = CodEroare.CORECT;
            if (nume == string.Empty)
            {
                rezultatValidare |= CodEroare.NUME_INCORECT;
            }
            if (autor == string.Empty)
            {
                rezultatValidare |= CodEroare.AUTOR_INCORECT;
            }
            if (editura == string.Empty)
            {
                rezultatValidare |= CodEroare.EDITURA_INCORECTA;
            }
            if (nrexemplare == string.Empty)
            {
                rezultatValidare |= CodEroare.NREXEMPLARE_INCORECTE;
            }
            // verificare ca este cel putin un program studiu selectat
            int genCarteSelectat = 0;
            foreach (var control in gpbGenCarte.Controls)
            {
                RadioButton rdb = null;
                try
                {
                    rdb = (RadioButton)control;
                }
                catch { }

                if (rdb != null && rdb.Checked == true)
                    genCarteSelectat = 1;
            }
            if (genCarteSelectat == 0)
                rezultatValidare |= CodEroare.NO_GEN_CARTE;
            if( anaparitie ==string.Empty)
            {
                rezultatValidare |= CodEroare.AN_APARITIE;
            }
            if( validareSpecificatii() == 0)
            {
                rezultatValidare |= CodEroare.SPECIFICATII;
            }
            return rezultatValidare;
        }

        private void ResetCuloareEtichete()
        {
            lblNume.ForeColor = Color.Black;
            lblAutor.ForeColor = Color.Black;
            lblEditura.ForeColor = Color.Black;
            lblAnAparitie.ForeColor = Color.Black;
            lblGenCarte.ForeColor = Color.Black;
            lblSpecificatii.ForeColor = Color.Black;
            lblNrExemplare.ForeColor = Color.Black;

        }
        private void MarcheazaControaleCuDateIncorecte(CodEroare codValidare)
        {
            if ((codValidare & CodEroare.NUME_INCORECT) == CodEroare.NUME_INCORECT)
            {
                lblNume.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.AUTOR_INCORECT) == CodEroare.AUTOR_INCORECT)
            {
                lblAutor.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.EDITURA_INCORECTA) == CodEroare.EDITURA_INCORECTA)
            {
                lblEditura.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.NO_GEN_CARTE) == CodEroare.NO_GEN_CARTE)
            {
                lblGenCarte.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.NREXEMPLARE_INCORECTE) == CodEroare.NREXEMPLARE_INCORECTE)
            {
                lblNrExemplare.ForeColor = Color.Red;
            }
            if ((codValidare & CodEroare.SPECIFICATII) == CodEroare.SPECIFICATII)
            {
                lblSpecificatii.ForeColor = Color.Red;
            }
            if(( codValidare & CodEroare.AN_APARITIE ) ==CodEroare.AN_APARITIE)
            {
                lblAnAparitie.ForeColor = Color.Red;
            }
        }
        private void ResetareControale()
        {
            txtNume.Text = txtAutor.Text = txtEditura.Text = string.Empty;
            rdbBiografii.Checked = false;
            rdbFictiune.Checked = false;
            rdbSpecialitate.Checked = false;
            rdbCopii.Checked = false;
            ckbColorat.Checked = false;
            ckbCopertiCartonate.Checked = false;
            ckbCopertiNormale.Checked = false;
            specificatiiSelectate.Clear();
            lblDisponibil.Text = string.Empty;
        }

        private void btnDisponibil_Click(object sender, EventArgs e)
        {
            int index = lstAfisare.SelectedIndex + 1;
            Carte c = adminCarti.GetCarteID(index);

            if (c != null)
            {
                c.Disponibil = c.disponibilitate();
                if (c.Disponibil == true)
                    lblDisponibil.Text = "Cartea este disponibila";
                else
                    lblDisponibil.Text = "In acest moment nu este disponibila";

            }
            else
                lblDisponibil.Text = "Verificati daca ati selectat cartea dorita.";


        }

        private void lstAfisare_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstAfisare.SelectedIndex + 1;
            Carte c = adminCarti.GetCarteID(index);
            if (c != null)
            {
                txtNume.Text = c.Nume;
                txtAutor.Text = c.Autor;
                txtEditura.Text = c.Editura;
                txtNrExemplare.Text = Convert.ToString(c.NrExemplare);
                if (c.GenCarte.ToString() == "Copii")
                    rdbCopii.Checked = true;
                if (c.GenCarte.ToString() == "Biografii")
                    rdbBiografii.Checked = true;
                if (c.GenCarte.ToString() == "Fictiune")
                    rdbFictiune.Checked = true;
                if (c.GenCarte.ToString() == "Specialitate")
                    rdbSpecialitate.Checked = true;
                cmbAnAparitie.Text = c.AnAparitie.ToString();

            }
        }


        private void ckbSpecificatii_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; //operator 'as'
            //sau
            //CheckBox checkBoxControl = (CheckBox)sender;  //operator cast

            string SpecificatieSelectata = checkBoxControl.Text;

            //verificare daca checkbox-ul asupra caruia s-a actionat este selectat
            if (checkBoxControl.Checked == true)
                specificatiiSelectate.Add(SpecificatieSelectata);
            else
                specificatiiSelectate.Remove(SpecificatieSelectata);
        }

        private void filtrareCartiDisponibileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Carte> disponibile = adminCarti.GetCartiDisponibile();
            if (disponibile.Count ==0 )
                dataGridCarti.DataSource = disponibile.Select(c => new { c.IDcarte, c.Nume, c.Autor, c.Editura, c.GenCarte, Specificatii = string.Join(",", c.Specificatii), c.AnAparitie, c.NrExemplare, c.DataActualizare }).ToList();
            else
                MessageBox.Show("Momentan nu sunt carti disponibile", "Afisare carti disponibile");
        }

        private void btnLimite_Click(object sender, EventArgs e)
        {
            DateTime data1 = dateTimePicker1.Value;
            DateTime data2 = dateTimePicker2.Value;
            List<Carte> carti = adminCarti.GetCarti();
            List<Carte> cartipotrivite = new List<Carte>();
            foreach ( Carte c in carti)
            {
                if (c.DataActualizare > data1 && c.DataActualizare < data2)
                    cartipotrivite.Add(c);
            }
            List<Carte> exemplu = new List<Carte>();
            if (cartipotrivite != exemplu)
                dataGridCarti.DataSource = cartipotrivite.Select(c => new { c.IDcarte, c.Nume, c.Autor, c.Editura, c.GenCarte, Specificatii = string.Join(",", c.Specificatii), c.AnAparitie, c.NrExemplare, c.DataActualizare }).ToList();
            else
                MessageBox.Show("Nu am gasit carti adaugate sau modificate intre aceste date", "Cautare carti dupa data");
        }
    }
}
