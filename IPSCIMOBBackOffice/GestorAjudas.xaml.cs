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
    /// Interaction logic for GestorAjudas.xaml
    /// </summary>
    public partial class GestorAjudas : Window
    {
        ObservableCollection<Ajuda> ajudas = new ObservableCollection<Ajuda>();

        public GestorAjudas()
        {
            InitializeComponent();
            ajudas = App.IPSCIMOBDB.GetAjuda();

            listBoxAjudas.ItemsSource = ajudas;

            listBoxAjudas.DisplayMemberPath = "Nome";

            listBoxAjudas.SelectedItem = listBoxAjudas.Items[0];
            listBoxAjudas.IsSynchronizedWithCurrentItem = true;

            DataGridAjudas.ItemsSource = ajudas;
        }


        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxAjudas.SelectedItem == null)
                return;

            Ajuda ajudaAtual = (Ajuda)listBoxAjudas.SelectedItem as Ajuda;

            if (ajudaAtual == null)
                return;

            EditAjuda eS = new EditAjuda(ajudaAtual);
            eS.Title = "Editar Ajudas";
            if (eS.ShowDialog() == true)
            {
                App.IPSCIMOBDB.ActualizarAjuda(eS.Ajuda);
            }
        }

       

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxAjudas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Ajuda ajudaAtual = listBoxAjudas.SelectedItem as Ajuda;
            if (ajudaAtual == null)
                return;
        }
    }
}