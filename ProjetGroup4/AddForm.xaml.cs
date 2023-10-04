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
using Model;
using ProjetGroup4;

namespace ProjetGroup4.Images {
    /// <summary>
    /// Interaction logic for AddForm.xaml
    /// </summary>
    public partial class AddForm : Window {
        User currentUser;
        public AddForm(User u) {
            InitializeComponent();
            DataContext = new ComboboxViewModel();
            this.currentUser = u;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string message = BLL.ProgramBLL.AddContact(new Model.Contact(this.currentUser.ID, this.txt_Nom.Text, this.txt_adr.Text, this.txt_tel.Text, this.DateF.SelectedDate, this.txt_rel.Text));
            this.Close();
            MessageBox.Show(message);
        }
        private void TypeNumericValidation(object sender, TextCompositionEventArgs e) {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}























