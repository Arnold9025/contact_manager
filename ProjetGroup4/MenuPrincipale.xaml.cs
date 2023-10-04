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
using System.Windows.Shapes;
using Model;
using BLL;
using System.Data;

namespace ProjetGroup4 {
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MenuPrincipale : Window {
        User currentUser;

        public MenuPrincipale(User cu) {
            InitializeComponent();
            this.currentUser = cu;
            this.txtUserWelcome.Content = "Welcome " + this.currentUser.Nom;
            this.date.Content = "Date: " + DateTime.Now.ToString("ddd, dd MMM yyy");
            this.DG1.ItemsSource = ProgramBLL.LireEtAfficherTousLesContactSpecific(this.currentUser.ID);
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
        private void Btn_ExitAct(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private void Btn_MinAct(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Window form = new Images.AddForm(this.currentUser);
            form.Visibility = Visibility.Visible;
        }
    

        private void searchKeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                this.DG1.ItemsSource = ProgramBLL.LireResultatRecherche(this.txtSearch.Text, currentUser.ID);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            this.DG1.ItemsSource = ProgramBLL.AfficherTrie("Family", currentUser.ID);
          }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            this.DG1.ItemsSource = ProgramBLL.AfficherTrie("Friend", currentUser.ID);
        }
      
        private void EditEvent(object sender, RoutedEventArgs e) {
            Contact cToEdit = (Contact)((Button)e.Source).DataContext;
            Window ed = new EditForm(cToEdit,this.currentUser);
            ed.Visibility = Visibility.Visible;
            //MessageBox.Show($"{cToEdit.nom}");
        }
        private void RemoveEvent(object sender, RoutedEventArgs e) {
            Contact cToRemove = (Contact)((Button)e.Source).DataContext;
            Window ed = new RemoveForm(cToRemove);
            ed.Visibility = Visibility.Visible;
            //MessageBox.Show($"{cToEdit.nom}");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {
            this.DG1.ItemsSource = ProgramBLL.AfficherTrie("Business", currentUser.ID);

        }

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            this.DG1.ItemsSource = ProgramBLL.LireEtAfficherTousLesContactSpecific(this.currentUser.ID);

        }
    }
}
