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
    /// Interaction logic for GestorProgramas.xaml
    /// </summary>
    public partial class GestorProgramas : Window
    {
        ObservableCollection<ProgramaModel> programas = new ObservableCollection<ProgramaModel>();

        public GestorProgramas()
        {
            InitializeComponent();
            programas = App.IPSCIMOBDB.GetProgramas();

            listBoxProgramas.ItemsSource = programas;

            listBoxProgramas.DisplayMemberPath = "Nome";

            listBoxProgramas.SelectedItem = listBoxProgramas.Items[0];
            listBoxProgramas.IsSynchronizedWithCurrentItem = true;

            DataGridProgramas.ItemsSource = programas;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditPrograma aS = new EditPrograma();
            if (aS.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirPrograma(aS.Programa);

                if (id > 0)
                {
                    aS.Programa.ProgramaID = id;
                    aS.Programa.ProgramaAtual = false;

                    programas.Add(aS.Programa);
                }
                listBoxProgramas.Items.MoveCurrentToLast();
            }

        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxProgramas.SelectedItem == null)
                return;

            ProgramaModel programaAtual = (ProgramaModel)listBoxProgramas.SelectedItem as ProgramaModel;

            if (programaAtual == null)
                return;

            EditPrograma eS = new EditPrograma(programaAtual)
            {
                Title = "Editar Programa de Mobilidade"
            };
            if (eS.ShowDialog() == true)
            {



                App.IPSCIMOBDB.ActualizarPrograma(eS.Programa);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxProgramas.SelectedItem == null)
                return;

            ProgramaModel programaAtual = (ProgramaModel)listBoxProgramas.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverPrograma(programaAtual.ProgramaID);
                programas.Remove(programaAtual);

                listBoxProgramas.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgramaModel infoAtual = listBoxProgramas.SelectedItem as ProgramaModel;
            if (infoAtual == null)
                return;
        }
    }
}