using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
        //ObservableCollection<Sugestao> sugestoes = new ObservableCollection<Sugestao>();
        private IPSCIMOBDBContext _db = new IPSCIMOBDBContext();

        public GestorSugestoes()
        {
            InitializeComponent();
            //sugestoes = App.IPSCIMOBDB.GetSugestoes();
            if (!_db.Sugestoes.Any())
            {
                _db.Sugestoes.Add(new Sugestao("Auto Europa", "AUTOE"));
                _db.Sugestoes.Add(new Sugestao("Hidro Sado", "HIDROSA"));
                
                _db.SaveChanges();
            }
            //listBoxSugestoes.ItemsSource = sugestoes;

            //listBoxSugestoes.DisplayMemberPath = "EmailUtilizador";
            ////listBoxAvioes.DisplayMemberPath = "Preco";

            //listBoxSugestoes.SelectedItem = listBoxSugestoes.Items[0];
            //listBoxSugestoes.IsSynchronizedWithCurrentItem = true;

            //DataGridSugestoes.ItemsSource = sugestoes;

            //if (!_db.Sugestoes.Any())
            //{

            //}
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            EditSugestao eS = new EditSugestao(_db.Sugestoes) { Title = "Nova Sugestão" };

            if (eS.ShowDialog() == true)
            {
                _db.Sugestoes.Add(eS.Sugestao);
                _db.SaveChanges();
                listBoxSugestoes.Items.MoveCurrentToLast();
                //EditSugestao aS = new EditSugestao();
                //if (aS.ShowDialog() == true)
                //{
                //    int id = App.IPSCIMOBDB.InserirSugestao(aS.Sugestao);

                //    if (id > 0)
                //    {
                //        aS.Sugestao.SugestaoID = id;
                //        sugestoes.Add(aS.Sugestao);
                //    }
                //    listBoxSugestoes.Items.MoveCurrentToLast();
                //}

            }
        }

        private void Edit_OnClick(object sender, RoutedEventArgs e)
        {
            if (listBoxSugestoes.SelectedItem == null)
                return;

           

            Sugestao sugestao = listBoxSugestoes.SelectedItem as Sugestao;
            EditSugestao dlg = new EditSugestao(_db.Sugestoes, sugestao) { Title = "Editar Sugestao" };
            
            if (dlg.ShowDialog() == true /*&& dlg.Sugestao != sugestao*/)
            {
                //sugestao.Nome = dlg.Empresa.Nome;
                //empresa.Sigla = dlg.Empresa.Sigla;
                //empresa.Quantidade = dlg.Empresa.Quantidade;

                _db.Entry(sugestao).State = EntityState.Modified;
                _db.SaveChanges();

            }
            //if (listBoxSugestoes.SelectedItem == null)
            //    return;

            //Sugestao sugestaoAtual = (Sugestao)listBoxSugestoes.SelectedItem as Sugestao;

            //if (sugestaoAtual == null)
            //    return;

            //EditSugestao eS = new EditSugestao(sugestaoAtual);
            //eS.Title = "Editar Sugestões";
            //if (eS.ShowDialog() == true)
            //{                 
            //    App.IPSCIMOBDB.ActualizarSugestao(eS.Sugestao);
            //}
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {

            if (listBoxSugestoes.SelectedItem == null)
                return;

            Sugestao sugestao = listBoxSugestoes.SelectedItem as Sugestao;

            if (MessageBox.Show("Deseseja mesmo apagar o empresa (Y/N)?", "Apagar Empresa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _db.Sugestoes.Remove(sugestao);
                _db.SaveChanges();

                listBoxSugestoes.Items.MoveCurrentToFirst();

               
            }
            //if (listBoxSugestoes.SelectedItem == null)
            //    return;

            //Sugestao sugestaoAtual = (Sugestao)listBoxSugestoes.SelectedItem;

            //if (MessageBox.Show("Deseseja mesmo apagar este registo (Y/N)?", "Apagar registo?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            //{
            //    App.IPSCIMOBDB.RemoverSugestao(sugestaoAtual.SugestaoID);
            //    sugestoes.Remove(sugestaoAtual);

            //    listBoxSugestoes.Items.MoveCurrentToFirst();
            //}
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ListBoxSugestoes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ApplicationUser userAtual = listBoxSugestoes.SelectedItem as ApplicationUser;
            //if (userAtual == null)
            //    return;

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _db.Sugestoes.Load();
            listBoxSugestoes.ItemsSource = _db.Sugestoes.Local;
            listBoxSugestoes.SelectedValuePath = "SugestaoID";
            listBoxSugestoes.DisplayMemberPath = "EmailUtilizador";
            listBoxSugestoes.SelectedIndex = 0;
            listBoxSugestoes.IsSynchronizedWithCurrentItem = true;
            DataGridSugestoes.ItemsSource = _db.Sugestoes.Local;

        }


    }
}