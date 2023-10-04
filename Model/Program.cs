using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Model {


    public class User {
        public int ID { get; set; }
        public string Nom { get; set; }
        public string Username { get; set; }
        public string Couriel { get; set; }
        public string Telephone { get; set; }
        public string pass { get; set; }
        public User() { }
        public User(string Nom, string Username, string couriel, string telephone, string pass) {
            this.Nom = Nom;
            this.Username = Username;
            this.Couriel = couriel;
            this.Telephone = telephone;
            this.pass = pass;
        }
        public override string ToString() {
            return $"{this.ID} - {this.Nom} - {this.Couriel} - {this.Telephone} - {this.pass}";
        }
    }
    public class Contact {
        public int contactOwnerID { get; set; }
        public string First { get; set; }
        public string nom { get; set; }
        public string couriel { get; set; }
        public string telephone { get; set; }
        public DateTime? dateFete { get; set; }
        public string relationShip { get; set; }

        public Contact() { }
        public Contact(int IDOwner, string nom, string couriel, string telephone, DateTime? dateFete, string relationShip) {
            this.contactOwnerID = IDOwner;
            this.nom = nom;
            this.First = this.nom.Substring(0, 1);
            this.couriel = couriel;
            this.telephone = telephone;
            this.dateFete = dateFete;
            this.relationShip = relationShip;
        }
        public override string ToString() {
            return $"{this.First} - {this.nom} - {this.couriel} - {this.telephone} - {this.dateFete}";
        }
    }
}