using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetGroup4 {
    /// <summary>
    /// Interaction logic for EditForm.xaml
    /// </summary>
    public partial class EditForm : Window {
        Contact ContAMod;
        User currentUser;

        public EditForm(Contact c, User u) {
            InitializeComponent();
            this.currentUser = u;
            this.ContAMod = c;
            this.txt_Nom.Text = this.ContAMod.nom;
            this.txt_adr.Text = this.ContAMod.couriel;
            this.txt_tel.Text = this.ContAMod.telephone;
            DataContext = new ComboboxViewModel();
            this.DateF.SelectedDate = this.ContAMod.dateFete;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string message = BLL.ProgramBLL.ModifierContact(ContAMod, new Model.Contact(this.currentUser.ID, this.txt_Nom.Text, this.txt_adr.Text, this.txt_tel.Text, this.DateF.SelectedDate, this.txt_rel.Text));
            this.Close();
            MessageBox.Show(message);
        }
        private void TypeNumericValidation(object sender, TextCompositionEventArgs e) {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
