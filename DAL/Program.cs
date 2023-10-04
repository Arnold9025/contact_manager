using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Model;


namespace DAL {

    public class Connexion {
        const string connectionString = @"Data Source=751FJW2\SQLEXPRESS;" +
                    "Initial Catalog=TP_Groupe4;" +
                    "Integrated Security=True;" +
                    "Connect Timeout=5";

        public static void Using() {
            using (SqlConnection connection = new SqlConnection(Connexion.connectionString)) {
                connection.Open();
            }
        }
        public static List<User> LireUtilisateur() {
            List<User> liste = new List<User>();


            using (SqlConnection conn = new SqlConnection(Connexion.connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Utilisateur";

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) {
                    User us = new User();
                    us.ID = (Int32)reader["ID"];
                    us.Username = (string)reader["Username"];
                    us.Nom = (string)reader["Nom"];
                    us.Couriel = (string)reader["Couriel"];
                    us.Telephone = (string)reader["Telephone"];
                    us.pass = (string)reader["MotDePasse"];
                    liste.Add(us);
                }
            }

            return liste;
        }

        public static List<Contact> LireContact() {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(Connexion.connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Contact";
                var converter = new BrushConverter();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) {
                    Contact Co = new Contact();

                    Co.nom = (string)reader["Nom"];
                    Co.First = Co.nom.Substring(0, 1);
                    Co.couriel = (string)reader["Couriel"];
                    Co.telephone = (string)reader["Telephone"];
                    Co.dateFete = reader["DateFete"] == DBNull.Value ? null : (DateTime?)reader["DateFete"];
                    Co.relationShip = (string)reader["RelationShip"];
                    liste.Add(Co);
                }
            }

            return liste;
        }

        public static List<Contact> LireContactSpecific(int idUtilisateur) {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(Connexion.connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Nom AS 'Nom Complet',Couriel AS 'Courriel',Telephone AS 'Numero Telephone',DateFete AS 'Date de Naissance', RelationShip AS 'RelationShip' FROM Contact WHERE UtilisateurID =" + idUtilisateur;

                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) {
                    Contact Co = new Contact();

                    Co.nom = (string)reader["Nom Complet"];
                    Co.First = Co.nom.Substring(0, 1);
                    Co.couriel = (string)reader["Courriel"];
                    Co.telephone = (string)reader["Numero Telephone"];
                    Co.dateFete = reader["Date de Naissance"] == DBNull.Value ? null : (DateTime?)reader["Date de Naissance"];
                    Co.relationShip = (string)reader["RelationShip"];
                    liste.Add(Co);
                }
            }

            return liste;
        }
        public static List<Contact> LireRecherche(string recherche, int id) {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(Connexion.connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Nom AS 'Nom Complet',Couriel AS 'Courriel',Telephone AS 'Numero Telephone',DateFete AS 'Date de Naissance', RelationShip AS 'RelationShip' FROM Contact WHERE Nom LIKE '%"+ recherche+ "%' AND UtilisateurID =" + id;
                //cmd.Parameters.AddWithValue("@recherche", recherche);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) {
                    Contact Co = new Contact();

                    Co.nom = (string)reader["Nom Complet"];
                    Co.First = Co.nom.Substring(0, 1);
                    Co.couriel = (string)reader["Courriel"];
                    Co.telephone = (string)reader["Numero Telephone"];
                    Co.dateFete = reader["Date de Naissance"] == DBNull.Value ? null : (DateTime?)reader["Date de Naissance"];
                    Co.relationShip = (string)reader["RelationShip"];
                    liste.Add(Co);
                }
            }

            return liste;
        }

        public static List<Contact> Trier(string relationship, int id) {
            List<Contact> liste = new List<Contact>();

            using (SqlConnection conn = new SqlConnection(Connexion.connectionString)) {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Nom AS 'Nom Complet',Couriel AS 'Courriel',Telephone AS 'Numero Telephone',DateFete AS 'Date de Naissance', RelationShip AS 'RelationShip' FROM Contact WHERE RelationShip LIKE '%" + relationship + "%' AND UtilisateurID = " + id;
                //cmd.Parameters.AddWithValue("@recherche", recherche);
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read()) {
                    Contact Co = new Contact();

                    Co.nom = (string)reader["Nom Complet"];
                    Co.First = Co.nom.Substring(0, 1);
                    Co.couriel = (string)reader["Courriel"];
                    Co.telephone = (string)reader["Numero Telephone"];
                    Co.dateFete = reader["Date de Naissance"] == DBNull.Value ? null : (DateTime?)reader["Date de Naissance"];
                    Co.relationShip = (string)reader["RelationShip"];
                    liste.Add(Co);
                }
            }

            return liste;
        }
        public static long AjouterContact(Contact c) {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                //"SELECT * FROM publishers WHERE pub_id = @login";
                //cmd.Parameters.AddWithValue("@login", login);
                cmd.CommandText = "INSERT INTO Contact(UtilisateurID, Nom, Couriel, Telephone, DateFete, RelationShip) VALUES(@ID, @nom, @Couriel, @Telephone, @DateFete, @RelationShip)";

                cmd.Parameters.AddWithValue("@ID", c.contactOwnerID);
                cmd.Parameters.AddWithValue("@nom", c.nom);
                cmd.Parameters.AddWithValue("@Couriel", c.couriel);
                cmd.Parameters.AddWithValue("@Telephone", c.telephone);
                if (c.dateFete == null) {
                    cmd.Parameters.AddWithValue("@dateFete", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@dateFete", (DateTime)c.dateFete);

                }
            
            cmd.Parameters.AddWithValue("@RelationShip", c.relationShip);

            cmd.ExecuteNonQuery();
        }
            return id;
        }
        public static long SignUp(User u) {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
             
      //                ,[Nom]
      //,[Username]
      //,[MotdePasse]
      //,[Couriel]
      //,[Telephone]
      //  FROM[TP_GROUPE4].[dbo].[Utilisateur]
        cmd.CommandText = "INSERT INTO Utilisateur(Nom, Username, MotdePasse, Couriel, Telephone) VALUES(@nom, @username, @MotdePasse, @Couriel, @Telephone)";

                cmd.Parameters.AddWithValue("@nom", u.Nom);
                cmd.Parameters.AddWithValue("@username", u.Username);
                cmd.Parameters.AddWithValue("@MotdePasse", u.pass);
                cmd.Parameters.AddWithValue("@Couriel", u.Couriel);
                cmd.Parameters.AddWithValue("@Telephone", u.Telephone);
                
                cmd.ExecuteNonQuery();
            }
            return id;
        }

        public static long EditContact(Contact c1, Contact c2) {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                //"SELECT * FROM publishers WHERE pub_id = @login";
                //cmd.Parameters.AddWithValue("@login", login);
                cmd.CommandText = " UPDATE Contact SET Nom = @nom, Couriel = @Couriel, Telephone = @Telephone, DateFete = @dateFete, RelationShip = @RelationShip WHERE Nom = @nom1 AND Couriel = @Couriel1";

                cmd.Parameters.AddWithValue("@ID", c2.contactOwnerID);
                cmd.Parameters.AddWithValue("@nom", c2.nom);
                cmd.Parameters.AddWithValue("@Couriel", c2.couriel);
                cmd.Parameters.AddWithValue("@nom1", c1.nom);
                cmd.Parameters.AddWithValue("@Couriel1", c1.couriel);
                cmd.Parameters.AddWithValue("@Telephone", c2.telephone);
                if (c2.dateFete == null) {
                    cmd.Parameters.AddWithValue("@dateFete", DBNull.Value);
                }
                else {
                    cmd.Parameters.AddWithValue("@dateFete", (DateTime)c2.dateFete);

                }

                cmd.Parameters.AddWithValue("@RelationShip", c2.relationShip);

                cmd.ExecuteNonQuery();
            }
            return id;
        }
        public static long DeleteContact(Contact c1) {
            long id = 0;
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                //"SELECT * FROM publishers WHERE pub_id = @login";
                //cmd.Parameters.AddWithValue("@login", login);
                cmd.CommandText = " DELETE FROM Contact  WHERE Nom = @nom1 AND Couriel = @Couriel1";


                cmd.Parameters.AddWithValue("@nom1", c1.nom);
                cmd.Parameters.AddWithValue("@Couriel1", c1.couriel);
                cmd.ExecuteNonQuery();
            }
            return id;
        }
    }
}


    
