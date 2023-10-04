using Model;
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

namespace ProjetGroup4 {
    /// <summary>
    /// Interaction logic for RemoveForm.xaml
    /// </summary>
    public partial class RemoveForm : Window {
        Contact ContASup;
        public RemoveForm(Contact c) {
            InitializeComponent();
            this.ContASup = c;
            this.confirmDelete.Text = this.ContASup.nom;

        }

        private void Yes_Click(object sender, RoutedEventArgs e) {
            string message = BLL.ProgramBLL.SupprimerContact(ContASup);
            this.Close();
            
        }
    }
}
