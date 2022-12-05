using System;
using MySql.Data.MySqlClient;
using System.Data;




public class YHDISTA
{
    class YHDISTA
    {
        private MySqlConnection yhteys = new MySqlConnection("datasource = localhost; port = 3306;username = root;password = ; database = piskelija");
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

            // Luodaan funktio yhteyden sulkemista varten
            public void suljeYhteys()
            {
                if (yhteys.State == ConnectionState.Open)
                {
                    yhteys.Close();
                }
            }
        }
    }             
}


