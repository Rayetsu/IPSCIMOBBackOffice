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
    /// Interaction logic for GestorInformacoes.xaml
    /// </summary>
    public partial class GestorInformacoes : Window
    {
        ObservableCollection<InformacaoGeral> informacoes = new ObservableCollection<InformacaoGeral>();

        public GestorInformacoes()
        {
            InitializeComponent();
            informacoes = App.IPSCIMOBDB.GetInformacoes();

            listBoxInfo.ItemsSource = informacoes;

            listBoxInfo.DisplayMemberPath = "Titulo";   

            listBoxInfo.SelectedItem = listBoxInfo.Items[0];
            listBoxInfo.IsSynchronizedWithCurrentItem = true;

            DataGridInfo.ItemsSource = informacoes;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditInformacoes aS = new EditInformacoes();
            if (aS.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirInformacao(aS.Informacao);

                if (id > 0)
                {
                    aS.Informacao.InformacaoGeralID = id;
                    aS.Informacao.ProgramaAtual = false;
                    informacoes.Add(aS.Informacao);
                }
                listBoxInfo.Items.MoveCurrentToLast();
            }
            //aA.ShowDialog();
            //aviaoAtual = aA.Aviao;
            //avioes.Add(aviaoAtual);
            //listBoxAvioes.Items.Add(aviaoAtual);
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxInfo.SelectedItem == null)
                return;

            InformacaoGeral infoAtual = (InformacaoGeral)listBoxInfo.SelectedItem as InformacaoGeral;

            if (infoAtual == null)
                return;

            EditInformacoes eS = new EditInformacoes(infoAtual)
            {
                Title = "Editar Informação Geral"
            };
            if (eS.ShowDialog() == true)
            {

             

                App.IPSCIMOBDB.ActualizarInformacao(eS.Informacao);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxInfo.SelectedItem == null)
                return;

            InformacaoGeral infoAtual = (InformacaoGeral)listBoxInfo.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverInformacao(infoAtual.InformacaoGeralID);
                informacoes.Remove(infoAtual);

                listBoxInfo.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InformacaoGeral infoAtual = listBoxInfo.SelectedItem as InformacaoGeral;
            if (infoAtual == null)
                return;
        }
    }
}