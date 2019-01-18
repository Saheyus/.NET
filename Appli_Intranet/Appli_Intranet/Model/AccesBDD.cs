using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appli_Intranet.Model
{
    class AccesBDD
    {

        private string commandeSQL;
        public string CommandeSQL { get => commandeSQL; set => commandeSQL = value; }

        public void UseBDD()
        {

            try
            {
                Console.WriteLine("A quelle BDD voulez-vous vous connecter ?");
                string nomBDD = Console.ReadLine();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=localhost; Initial Catalog=" + nomBDD +"; Integrated Security=SSPI";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = @"USE " + nomBDD + ";" ;
                

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Drop()
        {

            try
            {
                Console.WriteLine("Que voulez-vous supprimer ? (table, ...)");
                string quoiDrop = Console.ReadLine();
                Console.WriteLine("Quel est le nom de ce que vous voulez supprimer ?");
                string nomQuoiDrop = Console.ReadLine();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=localhost; Initial Catalog=Test; Integrated Security=SSPI";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = string.Format(@"DROP {0} {1};", quoiDrop.ToUpper(), nomQuoiDrop);

                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Select()
        {
            //CONSULTER CLIENTS OU VOYAGES

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=localhost; Initial Catalog=Test; Integrated Security=SSPI";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"USE BoVoyage_VA";
                cmd.CommandText = @" SELECT * FROM Destinations;";

                SqlDataReader reader;

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                        reader["ID_Destination"].ToString() +
                        "; " + reader["Continent"].ToString() +
                        "; " + reader["Pays"].ToString() +
                        "; " + reader["Region"].ToString() +
                        "; " + reader["DescriptionVoyage"].ToString()
                        );
                }

            
                
                reader.Close();

                con.Close();

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreateTable()
        {

            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=localhost; Initial Catalog=Test; Integrated Security=SSPI";
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                cmd.CommandText = @"USE Test";
                cmd.CommandText += @" CREATE TABLE Destinations2(ID_Destination2 INT IDENTITY, Continent NVARCHAR(20) NOT NULL, Pays NVARCHAR(32) NOT NULL, Region NVARCHAR(20), DescriptionVoyage NVARCHAR(500), PRIMARY KEY(ID_Destination2))";
                cmd.CommandText += @" INSERT INTO Destinations2 (Continent, Pays, Region, DescriptionVoyage) VALUES ('Europe', 'France', 'Ile de France', 'Voyage au coeur de la culture française.');";

                cmd.CommandText += " SELECT * FROM Destinations2;";

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public void Update()
        {
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=localhost; Initial Catalog=Test; Integrated Security=SSPI";
                con.Open();

                Console.WriteLine("Quelle table voulez-vous modifier ?");
                string table = Console.ReadLine().Trim();
                Console.WriteLine("Quel champ voulez-vous modifier ?");
                string champ = Console.ReadLine().Trim();
                Console.WriteLine("A quelle ligne?");
                string val = Console.ReadLine().Trim();
                Console.WriteLine("A quelle valeur?");
                string index = Console.ReadLine().Trim();
                Console.WriteLine("Quelle valeur voulez-vous mettre ?");
                string var1 = Console.ReadLine().Trim();

                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"USE Test";
                cmd.CommandText += string.Format(@" UPDATE {0} SET {1} = {2} WHERE {3} = {4};", table, champ, var1, val, index);
                
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /*
        public void AccesBDD()
        {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();

        }


        //private string 


        public void Lecture()
        {

            
            try
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = Localhost; Initial Catalog = Northwind; Integrated Security = SSPI";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "select ContactName,CompanyName from dbo.Customers where city='London';";

                Console.WriteLine("\r\n\tIndiquez votre commande SQL :\r\n");
                CommandeSQL = Console.ReadLine();
                Console.WriteLine("");

                cmd.CommandText = CommandeSQL;

                SqlDataReader reader;

                con.Open();
                reader = cmd.ExecuteReader();

                Console.WriteLine("Quels champs voulez-vous rechercher ? (separer par point virgule)");
                string test = Console.ReadLine();

                List<string> champs = test.Trim().Split(';').ToList();
                foreach (string line in champs)
                {
                    while (reader.Read())
                    {
                        if (champs.IndexOf(line)==0)
                        {
                            Console.WriteLine("\t" + reader[line].ToString());
                        }
                        else
                        {
                            Console.WriteLine("\t" + reader[',' + line].ToString());
                        }
                    }
                    
                }
                

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void Connexion()
        {
            try
            {
                
                con.ConnectionString = @"Data Source = Localhost; Initial Catalog = Northwind; Integrated Security = SSPI";

                
                cmd.Connection = con;
                //cmd.CommandText = "select ContactName,CompanyName from dbo.Customers where city='London';";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Commande()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source = Localhost; Initial Catalog = Northwind; Integrated Security = SSPI";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                //cmd.CommandText = "select ContactName,CompanyName from dbo.Customers where city='London';";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void Execution()
        {
            reader = cmd.ExecuteReader();
        }


        public void Deconnexion()
        {
            try
            {

                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    */
    }
}

