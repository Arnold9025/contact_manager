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
using BLL;
using Model;
using View;

namespace ProjetGroup4 {
    /// <summary>
    /// Interaction logic for SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Window {
        public SignUpForm() {
            InitializeComponent();
        }

        private void Btn_SignUp(object sender, RoutedEventArgs e) {
            string message = BLL.ProgramBLL.Registrer(new User(this.txt_Name.Text, this.txt_User.Text, this.txt_mail.Text, this.txt_phone.Text, this.txt_Pass.Text));
            MessageBox.Show(message);
            Window login = new LoginWindow();
            login.Visibility = Visibility.Visible;
            this.Close();

        }
        private void Btn_login(object sender, RoutedEventArgs e) {
         
                Window login = new LoginWindow();
                login.Visibility = Visibility.Visible;
            this.Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
        }
        private void Btn_ExitAct(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private void TypeNumericValidation(object sender, TextCompositionEventArgs e) {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
