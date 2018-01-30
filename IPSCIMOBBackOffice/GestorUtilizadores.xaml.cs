using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace IPSCIMOBBackOffice
{
    /// <summary>
    /// Lógica interna para GestorUtilizadores.xaml
    /// </summary>
    public partial class GestorUtilizadores : Window
    {
        ObservableCollection<ApplicationUser> users = new ObservableCollection<ApplicationUser>();

        public GestorUtilizadores()
        {
            InitializeComponent();
            users = App.IPSCIMOBDB.GetUsers();

            listBoxUtilizadores.ItemsSource = users;

            listBoxUtilizadores.DisplayMemberPath = "NumeroInterno";
            //listBoxAvioes.DisplayMemberPath = "Preco";

            listBoxUtilizadores.SelectedItem = listBoxUtilizadores.Items[0];
            listBoxUtilizadores.IsSynchronizedWithCurrentItem = true;

            DataGridUtilizadores.ItemsSource = users;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxUtilizadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationUser userAtual = listBoxUtilizadores.SelectedItem as ApplicationUser;
            if (userAtual == null)
                return;
        }
    }
}
