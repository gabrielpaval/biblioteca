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
    public partial class FormModificare : Form
    {
        IStocareData adminCarti;
        public Carte m_carte;
        public Form1 frmPrincipala;
        public FormModificare()
        {
            InitializeComponent();
            adminCarti = StocareFactory.GetAdministratorStocare();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            try
            {
                m_carte.Nume = txtNume.Text;
                m_carte.Autor = txtAutor.Text;
                m_carte.Editura = txtEditura.Text;
                m_carte.AnAparitie = Convert.ToInt32(cmbAnAparitie.Text);
                m_carte.Specificatii = (SPECIFICATII)validareSpecificatii();
                m_carte.NrExemplare = Convert.ToInt32(txtNrExemplare.Text);
                m_carte.GenCarte = (GENCARTE)GetGenCarteSelectat();
                adminCarti.UpdateCarte(m_carte, m_carte.IDcarte);
                MessageBox.Show("Cartea a fost modificata cu succes!");
            }
            catch (Exception)
            {
                MessageBox.Show("Cartea nu a putut fi actualizata!");
            }
            finally
            {
                frmPrincipala.btnAfisare_Click(null,null);
                this.Close();
            }   


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

        private void FormModificare_Load(object sender, EventArgs e)
        {
            txtNume.Text = m_carte.Nume;
            txtAutor.Text = m_carte.Autor;
            txtEditura.Text = m_carte.Editura;
            txtNrExemplare.Text = Convert.ToString(m_carte.NrExemplare);
            if (m_carte.GenCarte.ToString() == "Copii")
                rdbCopii.Checked = true;
            if (m_carte.GenCarte.ToString() == "Biografii")
                rdbBiografii.Checked = true;
            if (m_carte.GenCarte.ToString() == "Fictiune")
                rdbFictiune.Checked = true;
            if (m_carte.GenCarte.ToString() == "Specialitate")
                rdbSpecialitate.Checked = true;
            cmbAnAparitie.Text = m_carte.AnAparitie.ToString();
           // foreach (var specificatie in gpbSpecificatii.Controls)
           // {
            //    if (specificatie is CheckBox)
            //    {
              //      var specificatieBox = specificatie as CheckBox;
                    //foreach (String sp in (m_carte.Specificatii)
                     //   if (specificatieBox.Text.Equals(sp))
                    //        specificatieBox.Checked= true;
            //    }
            //}
        }
    }
}
