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
    /// Interaction logic for GestorCandidaturas.xaml
    /// </summary>
    public partial class GestorCandidaturas : Window
    {
        ObservableCollection<Candidatura> candidaturas = new ObservableCollection<Candidatura>();

        public GestorCandidaturas()
        {
            InitializeComponent();
            candidaturas = App.IPSCIMOBDB.GetCandidatura();

            listBoxCandidatura.ItemsSource = candidaturas;

            listBoxCandidatura.DisplayMemberPath = "NumeroInterno";

            listBoxCandidatura.SelectedItem = listBoxCandidatura.Items[0];
            listBoxCandidatura.IsSynchronizedWithCurrentItem = true;

            DataGridCandidatura.ItemsSource = candidaturas;
        }

        

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxCandidatura.SelectedItem == null)
                return;

            Candidatura candidaturaAtual = (Candidatura)listBoxCandidatura.SelectedItem as Candidatura;

            if (candidaturaAtual == null)
                return;

            EditCandidatura eS = new EditCandidatura(candidaturaAtual)
            {
                Title = "Editar Candidatura"
            };
            if (eS.ShowDialog() == true)
            {



                App.IPSCIMOBDB.ActualizarCandidatura(eS.Candidatura);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxCandidatura.SelectedItem == null)
                return;

            Candidatura candidaturaAtual = (Candidatura)listBoxCandidatura.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverCandidatura(candidaturaAtual.CandidaturaID);
                candidaturas.Remove(candidaturaAtual);

                listBoxCandidatura.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Candidatura infoAtual = listBoxCandidatura.SelectedItem as Candidatura;
            if (infoAtual == null)
                return;
        }
    }
}