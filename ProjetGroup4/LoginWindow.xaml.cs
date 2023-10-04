using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using Model;
using ProjetGroup4;
namespace View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
            this.Top = 70;
            this.Left = 500;
        }

        private void Btn_login(object sender, RoutedEventArgs e) {
            User cu = null;
            bool v = ProgramBLL.ComparerMail(txt_User.Text, txt_Pass.Text, ref cu);
            //v = true;   //  A ENLEVER!
            if (v == true) {
                Window acceuil = new MenuPrincipale(cu);
                acceuil.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }
        private void Btn_SignUp(object sender, RoutedEventArgs e) {
            Window signup = new SignUpForm();
            signup.Visibility = Visibility.Visible;
            this.Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e) {
        }
        private void Btn_ExitAct(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        public static string EnvoyerEmail(String email) {

            return email;
        }
    }
}
