using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class ProgramBLL
    {

        public static bool ComparerMail(string mail, string pass,ref User curentUser)
        {
            bool retour = false;
            List<User> l = Connexion.LireUtilisateur();
            for (int i = 0; i < l.Count; i++)
            {
                if (mail == l[i].Couriel && pass == l[i].pass)
                {
                    retour = true;
                    curentUser = l[i];
                }
            }
            return retour;
        }
        public static void LireEtAfficherTousLesContact()
        {
            List<Contact> l = Connexion.LireContact();
            foreach (Contact item in l)
            {
                Console.WriteLine(item);
            }
        }

        public static void LireEtAfficherTousLesUtilisateurs()
        {
            List<User> l = Connexion.LireUtilisateur();
            foreach (User item in l)
            {
                Console.WriteLine(item);
            }
        }

        public static List<Contact> LireEtAfficherTousLesContactSpecific(int idUtilisateur)
        {
            List<Contact> l = Connexion.LireContactSpecific(idUtilisateur);

            return l;
        }

        public static List<Contact> LireResultatRecherche(string recherche, int id) {
            List<Contact> l = Connexion.LireRecherche(recherche, id);
            return l;
        }
        public static List<Contact> AfficherTrie(string relationShip, int id) {
            List<Contact> l = Connexion.Trier(relationShip, id);
            return l;
        }
        public static void AjoutDeLigne(int nbLigne)
        {
            Console.WriteLine("\n");
            for (int i = 0; i < nbLigne; i++)
            {
                Console.WriteLine("------------------------------------------------------------------");
            }
            Console.WriteLine("\n");
        }
        public static string AddContact(Contact c) {
            string retour = " ";
                long id = Connexion.AjouterContact(c);
                retour = $"Vous avez ajouté un contact";
          
            return retour;
        }
        public static string Registrer(User u) {
            string retour = " ";
            long id = Connexion.SignUp(u);
            retour = $"Vous avez ajouté un contact";

            return retour;
        }
        public static string ModifierContact(Contact c1, Contact c2) {
            string retour = " ";
            long id = Connexion.EditContact(c1,c2);
            retour = $"Vous avez modifie un contact";

            return retour;
        }
        public static string SupprimerContact(Contact c1) {
            string retour = " ";
            long id = Connexion.DeleteContact(c1);
            retour = $"Vous avez supprimer un contact";

            return retour;
        }
        static void Main(string[] args)
        {
          /*  //THIS WORKS....
            ProgramBLL.LireEtAfficherTousLesUtilisateurs();
            Console.ReadLine();
            AjoutDeLigne(2);
            ProgramBLL.LireEtAfficherTousLesContact();
            AjoutDeLigne(3);
            Console.WriteLine("Anto:::");
            ProgramBLL.LireEtAfficherTousLesContactSpecific(1);
            AjoutDeLigne(1);
            Console.WriteLine("ARNOLD:::");
            ProgramBLL.LireEtAfficherTousLesContactSpecific(2);
       */
            Console.ReadLine();
        }
    }
}
