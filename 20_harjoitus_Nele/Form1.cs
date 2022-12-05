using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace _20_harjoitus_Nele
{
    public partial class Form1 : Form
    {
        class YHDISTA
        {
        private MySqlConnection yhteys = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=piskelija");//localhost/phpmyadmin/index.php?route=/database/structure&db=piskelija
        //lUODAAN FUNKTIO YHTEYTTÄ VARTEN
        public MySqlConnection otaYhteys()
        {
            return yhteys;
        }
            //Luodaan funktio yhteyden avaamista varten - HUOM! System.Data -kirjasto
            public void avaaYhteys()
            {
                if (yhteys.State == ConnectionState.Closed)
                {
                    yhteys.Open();
                }
            }
            // Luodaan funktio yhteyden sulkemista varten
            public void suljeYhteys()
            {
                if (yhteys.State == ConnectionState.Open)
                {
                    yhteys.Close();
                }
            }
        }
        
        OPISKELIJA piskelija = new OPISKELIJA();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TietotauluDG.DataSource = piskelija.haePiskelija();
        }
        private void TyhjennaBT_Click(object sender, EventArgs e)
        {
            IdTB.Text = "";
            EnimiTB.Text = "";
            SnimiTB.Text = "";
            PuhTB.Text = "";
            ONroTB.Text = "";
        }

        private void TallennaBT_Click(object sender, EventArgs e)
        {
            String enimi = EnimiTB.Text;
            String snimi = SnimiTB.Text;
            String puh = PuhTB.Text;
            String email = EmailTB.Text;
            int oNro = Int32.Parse(ONroTB.Text);

            if (enimi.Trim().Equals("") || snimi.Trim().Equals("") || puh.Trim().Equals("") || email.Trim().Equals("") || oNro.Equals(""))
            {
                MessageBox.Show("VIRHE - Vaaditut kentät - Etu- ja sukunimi, Puhelin, Sähköposti ja Opiskelijanumero", "Tyhjä kenttä", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean lisaaAsiakas = piskelija.lisaaPiskelija(enimi, snimi, puh, email, oNro);
                if (lisaaAsiakas)
                {
                    MessageBox.Show("Uusi opiskelijaa lisätty onnistuneesti", "Opiskelijan lisäys", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Uutta opiskelijaa ei pystytty lisäämään", "Opiskelijan lisäys", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TietotauluDG.DataSource = piskelija.haePiskelijat();
        }

        private void PaivitaBT_Click(object sender, EventArgs e)
        {
            String enimi = EnimiTB.Text;
            String snimi = SnimiTB.Text;
            String puh = PuhTB.Text;
            String email = EmailTB.Text;
            int oNro = Int32.Parse(ONroTB.Text);
            int oid = Int32.Parse(IdTB.Text);

            if (oid.Equals("") || enimi.Trim().Equals("") || snimi.Trim().Equals("") || puh.Trim().Equals("") || email.Trim().Equals("") || oNro.Equals(""))
            {
                MessageBox.Show("VIRHE - Vaaditut kentät - OID, Etu- ja sukunimi, Puhelin, Sähköposti ja Opiskelijanumero", "Tyhjä kenttä", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean muokkaaPiskelija = piskelija.muokkaaPiskelijaa(oid, enimi, snimi, puh, email, oNro);
                if (muokkaaPiskelija)
                {
                    MessageBox.Show("Opiskelija muokattu onnistuneesti", "Opiskelijan muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Opiskelijaa ei pystytty muokkaamaan", "Opiskelijan muokkaus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            TietotauluDG.DataSource = piskelija.haePiskelijat();

        }

        private void TietotauluDG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }  

    
}
