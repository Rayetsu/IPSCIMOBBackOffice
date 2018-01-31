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

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxUtilizadores.SelectedItem == null)
                return;

            ApplicationUser userAtual = (ApplicationUser)listBoxUtilizadores.SelectedItem as ApplicationUser;

            if (userAtual == null)
                return;

            EditUtilizador eS = new EditUtilizador(userAtual)
            {
                Title = "Editar Utilizador"
            };
            if (eS.ShowDialog() == true)
            {


                App.IPSCIMOBDB.ActualizarUtilizador(eS.Utilizador);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxUtilizadores.SelectedItem == null)
                return;

            ApplicationUser userAtual = (ApplicationUser)listBoxUtilizadores.SelectedItem as ApplicationUser;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverUtilizador(userAtual.NumeroInterno);
                users.Remove(userAtual);

                listBoxUtilizadores.Items.MoveCurrentToFirst();
            }
        }

        private void ListBoxUtilizadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplicationUser userAtual = listBoxUtilizadores.SelectedItem as ApplicationUser;
            if (userAtual == null)
                return;
        }
    }
}
