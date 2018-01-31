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
    /// Interaction logic for GestorSugestoes.xaml
    /// </summary>
    public partial class GestorSugestoes : Window
    {
        ObservableCollection<Sugestao> sugestoes = new ObservableCollection<Sugestao>();

        public GestorSugestoes()
        {
            InitializeComponent();
            sugestoes = App.IPSCIMOBDB.GetSugestoes();

            listBoxSugestoes.ItemsSource = sugestoes;

            listBoxSugestoes.DisplayMemberPath = "EmailUtilizador";
            //listBoxAvioes.DisplayMemberPath = "Preco";

            listBoxSugestoes.SelectedItem = listBoxSugestoes.Items[0];
            listBoxSugestoes.IsSynchronizedWithCurrentItem = true;

            DataGridSugestoes.ItemsSource = sugestoes;
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditSugestao aS = new EditSugestao();
            if (aS.ShowDialog() == true)
            {
                int id = App.IPSCIMOBDB.InserirSugestao(aS.Sugestao);

                if (id > 0)
                {
                    aS.Sugestao.SugestaoID = id;
                    sugestoes.Add(aS.Sugestao);
                }
                listBoxSugestoes.Items.MoveCurrentToLast();
            }
            //aA.ShowDialog();
            //aviaoAtual = aA.Aviao;
            //avioes.Add(aviaoAtual);
            //listBoxAvioes.Items.Add(aviaoAtual);
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxSugestoes.SelectedItem == null)
                return;

            Sugestao sugestaoAtual = (Sugestao)listBoxSugestoes.SelectedItem as Sugestao;

            if (sugestaoAtual == null)
                return;

            EditSugestao eS = new EditSugestao(sugestaoAtual);
            eS.Title = "Editar Sugestões";
            if (eS.ShowDialog() == true)
            {

                //sugestaoAtual.EmailUtilizador = eS.Sugestao.EmailUtilizador;
                //sugestaoAtual.TextoSugestao = eS.Sugestao.TextoSugestao;
                

                App.IPSCIMOBDB.ActualizarSugestao(eS.Sugestao);
            }
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxSugestoes.SelectedItem == null)
                return;

            Sugestao sugestaoAtual = (Sugestao)listBoxSugestoes.SelectedItem;

            if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.IPSCIMOBDB.RemoverSugestao(sugestaoAtual.SugestaoID);
                sugestoes.Remove(sugestaoAtual);

                listBoxSugestoes.Items.MoveCurrentToFirst();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxSugestoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sugestao sugestaoAtual = listBoxSugestoes.SelectedItem as Sugestao;
            if (sugestaoAtual == null)
                return;
        }
    }
}