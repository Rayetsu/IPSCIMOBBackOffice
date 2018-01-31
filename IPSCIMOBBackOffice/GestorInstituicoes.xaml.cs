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
    /// Interaction logic for GestorInstituicoes.xaml
    /// </summary>
    public partial class GestorInstituicoes : Window
    {
        ObservableCollection<InstituicaoParceira> instituicoes = new ObservableCollection<InstituicaoParceira>();

        public GestorInstituicoes()
        {
            InitializeComponent();
            instituicoes = App.IPSCIMOBDB.GetInstituicoes();

            listBoxInstituicoes.ItemsSource = instituicoes;

            listBoxInstituicoes.DisplayMemberPath = "Nome";
            //listBoxAvioes.DisplayMemberPath = "Preco";

            listBoxInstituicoes.SelectedItem = listBoxInstituicoes.Items[0];
            listBoxInstituicoes.IsSynchronizedWithCurrentItem = true;

            DataGridInstituicoes.ItemsSource = instituicoes;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditInstituicao aS = new EditInstituicao();
            if (aS.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirInstituicao(aS.Instituicao);

                if (id > 0)
                {
                    aS.Instituicao.InstituicaoParceiraID = id;
                    instituicoes.Add(aS.Instituicao);
                }
                listBoxInstituicoes.Items.MoveCurrentToLast();
            }
           
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxInstituicoes.SelectedItem == null)
                return;

            InstituicaoParceira instituicaoAtual = (InstituicaoParceira)listBoxInstituicoes.SelectedItem as InstituicaoParceira;

            if (instituicaoAtual == null)
                return;

            EditInstituicao eS = new EditInstituicao(instituicaoAtual);
            eS.Title = "Editar Instituição";
            if (eS.ShowDialog() == true)
            {
            
                App.IPSCIMOBDB.ActualizarInstituicao(eS.Instituicao);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxInstituicoes.SelectedItem == null)
                return;

            InstituicaoParceira instituicaoAtual = (InstituicaoParceira)listBoxInstituicoes.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverInstituicao(instituicaoAtual.InstituicaoParceiraID);
                instituicoes.Remove(instituicaoAtual);

                listBoxInstituicoes.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxInstituicoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InstituicaoParceira instituicaoAtual = listBoxInstituicoes.SelectedItem as InstituicaoParceira;
            if (instituicaoAtual == null)
                return;
        }
    }
}