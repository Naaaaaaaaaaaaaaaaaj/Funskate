using System;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace FunskateLoginTest
{
    public partial class index : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string u_pass;
        private string u_email;
        private string u_cpr;
        private string u_name;
        private string u_løbernummer;
        private string u_klub;
        private string u_klubmærke;
        private string u_fødselsdato;
        private string u_elementrække;
        private string u_freerække;
        private string u_konkurrence;
        private string u_udvalget;
        private string u_list;
        private string u_sletning;
        protected void Page_Load(object sender, EventArgs e)
        {
            server = "mysql2.dandomain.dk";
            database = "danskate_biz_db";
            uid = "danskate";
            password = "T47-mpCc";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        protected void loginknap_Click(object sender, EventArgs e)
        {
            if (usercheck(CPR.Text, "Admin"))
            {
                if (u_pass == pPassword.Text)
                {
                    //Admin logget ind
                    test.Text = "Admin logget ind";
                }
                else
                {
                    //Cpr rigtigt, adgangskode forkert
                    test.Text = "Forkert login";
                }
            }
            else if (usercheck(CPR.Text, "Ansvarlig"))
            {
                if (u_pass == pPassword.Text)
                {
                    //Ansvarlig logget ind
                    test.Text = "Ansvarlig logget ind";
                }
                else
                {
                    //Cpr rigtigt, adgangskode forkert
                    test.Text = "Forkert login";
                }
            }
            else
            {
                test.Text = "Forkert login";
            }
            test2.Text = u_list;
        }
        //Check om brugeren eksistere, derefter hent info om CPR nummeret valgt.
        //Returner TRUE hvis det findes (samt hent info om det)
        //Returner FALSE hvis det ikke findes.
        private bool usercheck(string cpr, string table)
        {
            try
            {
                string query = "SELECT * FROM " + table;
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in temporary variables
                while (dataReader.Read())
                {
                    if (dataReader["CPR-nummer"].ToString() == cpr)
                    {
                        try
                        {
                            //Fjern alt eksisterene data, så vi ikke får mikset data ind i hinaden
                            //hvis et cpr nummer ikke har alt data, og vi har hentet fra et andet
                            u_list = "";
                            u_cpr = "";
                            u_email = "";
                            u_pass = "";
                            u_name = "";
                            u_løbernummer = "";
                            u_klub = "";
                            u_klubmærke = "";
                            u_fødselsdato = "";
                            u_elementrække = "";
                            u_freerække = "";
                            u_konkurrence = "";
                            u_udvalget = "";
                            try
                            {
                                u_cpr = dataReader["CPR-nummer"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_pass = dataReader["Password"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_email = dataReader["Email"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_name = dataReader["Fornavn"].ToString() + " " + dataReader["Efternavn"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_løbernummer = dataReader["Løbernummer"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_klub = dataReader["Klub"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_klubmærke = dataReader["Klubmærke"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_fødselsdato = dataReader["Fødselsdato"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_elementrække = dataReader["Elementrække"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_freerække = dataReader["Freerække"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_konkurrence = dataReader["konkurrence"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_udvalget = dataReader["Udvalget"].ToString();
                            }
                            catch { }
                            try
                            {
                                u_sletning = dataReader["sletning"].ToString();
                            }
                            catch { }
                            //Fyld alt det info vi kunne fange ind i en liste
                            //Dette er mest så vi kan teste hvor meget info vi fik
                            u_list = "CPR: " + u_cpr + " - Password:" + u_pass + 
                                " - Email: "+ u_email + " - Navn:" + 
                                u_name + " - Løbernummer:" +
                                u_løbernummer + " - Klub:" +
                                u_klub + " - Klubmærke:" + u_klubmærke +
                                " - Fødselsdato:" + u_fødselsdato + " - Elementrække:" +
                                u_elementrække + " - Freerække:" + u_freerække + " - Konkurrence:" +
                                u_konkurrence + " - Udvalget:"+u_udvalget+
                                " - Sletning: "+u_sletning;
                            return true;
                        }
                        catch
                        { }
                    }
                }
                CloseConnection();
                return false;
            }
            catch
            { }
            return false;
        }
        //Open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password.");
                        break;
                }
                return false;
            }
        }
        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}