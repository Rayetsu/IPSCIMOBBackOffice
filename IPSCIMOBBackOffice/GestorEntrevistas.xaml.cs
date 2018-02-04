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
    /// Interaction logic for GestorEntrevistas.xaml
    /// </summary>
    public partial class GestorEntrevistas : Window
    {
        ObservableCollection<Entrevista> entrevistas = new ObservableCollection<Entrevista>();

        public GestorEntrevistas()
        {
            InitializeComponent();
            entrevistas = App.IPSCIMOBDB.GetEntrevistas();

            listBoxEntrevista.ItemsSource = entrevistas;

            listBoxEntrevista.DisplayMemberPath = "NumeroAluno";

            listBoxEntrevista.SelectedItem = listBoxEntrevista.Items[0];
            listBoxEntrevista.IsSynchronizedWithCurrentItem = true;

            DataGridEntrevista.ItemsSource = entrevistas;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditEntrevista aS = new EditEntrevista();
            if (aS.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirEntrevista(aS.Entrevista);

                if (id > 0)
                {
                    aS.Entrevista.EntrevistaId = id;
                    aS.Entrevista.EntrevistaAtual = false;
                    
                    entrevistas.Add(aS.Entrevista);
                }
                listBoxEntrevista.Items.MoveCurrentToLast();
            }
            
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxEntrevista.SelectedItem == null)
                return;

            Entrevista entrevistaAtual = (Entrevista)listBoxEntrevista.SelectedItem as Entrevista;

            if (entrevistaAtual == null)
                return;

            EditEntrevista eS = new EditEntrevista(entrevistaAtual)
            {
                Title = "Editar Entrevista"
            };
            if (eS.ShowDialog() == true)
            {



                App.IPSCIMOBDB.ActualizarEntrevista(eS.Entrevista);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxEntrevista.SelectedItem == null)
                return;

            Entrevista entrevistaAtual = (Entrevista)listBoxEntrevista.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverEntrevista(entrevistaAtual.EntrevistaId);
                entrevistas.Remove(entrevistaAtual);

                listBoxEntrevista.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Entrevista infoAtual = listBoxEntrevista.SelectedItem as Entrevista;
            if (infoAtual == null)
                return;
        }
    }
}